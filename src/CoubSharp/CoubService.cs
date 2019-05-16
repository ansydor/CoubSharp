using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using CoubSharp.Receivers;
using Newtonsoft.Json;
using CoubSharp.Model;
using CoubSharp.Managers;

namespace CoubSharp
{
    public interface ICoubService
    {
        CoubManager Coubs { get; }
        TimelineManager Timelines { get; }
        ChannelManager Channels { get; }
        RecoubManager Recoubs { get; }
        SearchService GeneralSearch { get; }
    }
    public class CoubService : ICoubService, IDisposable
    {
        /// <summary>
        /// Endpoint url base part
        /// </summary>
        internal const string ApiUrlBase = "http://coub.com/api/v2/";

        public string ApplicationId { get; set; }
        public string ApplicationSecret { get; set; }

        internal string _acceessToken;
        public CoubManager Coubs { get; internal set; }
        public TimelineManager Timelines { get; internal set; }
        public ChannelManager Channels { get; internal set; }

        public RecoubManager Recoubs { get; internal set; }
        public SearchService GeneralSearch { get; internal set; }

        internal HttpClient httpClient;

        /// <summary>
        /// Create an instance of <see cref="CoubService"/> with access token
        /// </summary>
        /// <param name="accessToken">Access Token for <see cref="CoubService"/></param>
        public CoubService(string accessToken)
        {
            _acceessToken = accessToken ?? throw new ArgumentNullException("accessToken", "accessToken can't be null");

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ApiUrlBase);
            Coubs = new CoubManager(accessToken, httpClient);
            Timelines = new TimelineManager(accessToken, httpClient);
            Channels = new ChannelManager(accessToken, httpClient);
            Recoubs = new RecoubManager(accessToken, httpClient);
            GeneralSearch = new SearchService(httpClient);
        }

        /// <summary>
        /// Create an instance of <see cref="CoubService"/>
        /// </summary>
        public CoubService()
        {
        }

        public void Dispose()
        {
            httpClient?.Dispose();
        }
    }
}
