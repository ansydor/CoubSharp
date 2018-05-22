using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CoubSharp.Receivers
{
    /// <summary>OAuth 2.0 verification code receiver</summary>
    public interface ICodeReceiver
    {
        /// <summary>Gets the redirected URI</summary>
        string RedirectUri { get; }

        /// <summary>Receives the authorization code</summary>
        /// <param name="url">The authorization code request URL</param>
        /// <param name="taskCancellationToken">Cancellation token</param>
        /// <returns>The authorization code response</returns>
        Task<string> ReceiveCodeAsync(string url, CancellationToken taskCancellationToken);
    }


    /// <summary>
    /// OAuth 2.0 verification code receiver that runs a local server on a free port and waits for a call with the 
    /// authorization verification code.
    /// </summary>
    public class LocalhostServerCodeReceiver : ICodeReceiver
    {

        /// <summary>Close HTML tag to return the browser so it will close itself.</summary>
        internal const string ClosePageResponse =
@"<html>
  <head><title>OAuth 2.0 Authentication Token Received</title></head>
  <body>
    Received verification code. You may now close this window.
    <script type='text/javascript'>
      window.setTimeout(function() {
          this.focus();
          window.opener = this;
          window.open('', '_self', ''); 
          window.close(); 
        }, 1000);
    </script>
  </body>
</html>";

        /// <summary>
        /// Create an instance of <see cref="LocalServerCodeReceiver"/>.
        /// </summary>
        public LocalhostServerCodeReceiver(string callbackUrl)
        {
            RedirectUri = callbackUrl;
        }

        /// <inheritdoc />
        public string RedirectUri { get; private set; }

        /// <inheritdoc />
        public async Task<string> ReceiveCodeAsync(string url, CancellationToken taskCancellationToken)
        {
            if (url == null)
                throw new ArgumentException("url", "Url can't be null");

            url = string.Concat(url, "&redirect_uri=", RedirectUri);
            var authorizationUrl = url;

            using (var listener = StartListener())
            {
                bool browserOpenedOk;
                try
                {
                    browserOpenedOk = OpenBrowser(authorizationUrl);
                }
                catch (Exception e)
                {
                    throw new NotSupportedException($"Failed to launch browser with \"{authorizationUrl}\" for authorization. See inner exception for details.", e);
                }
                if (!browserOpenedOk)
                {
                    throw new NotSupportedException($"Failed to launch browser with \"{authorizationUrl}\" for authorization; platform not supported.");
                }

                var response = await GetResponseFromListener(listener, taskCancellationToken).ConfigureAwait(false);
                return response;
            }
        }

        /// <summary>
        /// Start HttpListener to read Coub server response
        /// </summary>
        /// <returns></returns>
        private HttpListener StartListener()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add(RedirectUri);
            listener.Start();
            return listener;
        }

        /// <summary>
        /// Returns code as response from Coub server
        /// </summary>
        /// <param name="listener">Listener to listen redirect url</param>
        /// <param name="cancellationToken">CancellationToken to cancel operation</param>
        /// <returns></returns>
        private async Task<string> GetResponseFromListener(HttpListener listener, CancellationToken cancellationToken)
        {
            HttpListenerContext context;
            // Set up cancellation. HttpListener.GetContextAsync() doesn't accept a cancellation token,
            // the HttpListener needs to be stopped which immediately aborts the GetContextAsync() call.
            using (cancellationToken.Register(listener.Stop))
            {
                // Wait to get the authorization code response.
                try
                {
                    context = await listener.GetContextAsync().ConfigureAwait(false);
                }
                catch (Exception) when (cancellationToken.IsCancellationRequested)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    // Next line will never be reached because cancellation will always have been requested in this catch block.
                    // But it's required to satisfy compiler.
                    throw new InvalidOperationException();
                }
            }
            NameValueCollection coll = context.Request.QueryString;

            //Notify user, that code is received with browser
            var bytes = Encoding.UTF8.GetBytes(ClosePageResponse);
            context.Response.ContentLength64 = bytes.Length;
            context.Response.SendChunked = false;
            context.Response.KeepAlive = false;
            var output = context.Response.OutputStream;
            await output.WriteAsync(bytes, 0, bytes.Length).ConfigureAwait(false);
            await output.FlushAsync().ConfigureAwait(false);
            output.Close();
            context.Response.Close();

            //Return code value from url query
            return coll["code"];
        }

        /// <summary>
        /// Opens browser with url
        /// </summary>
        /// <param name="url">Url to open</param>
        /// <returns>True if opened with success</returns>
        private bool OpenBrowser(string url)
        {
            Process.Start(url);
            return true;
        }

    }
}

