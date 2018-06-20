using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoubSharp;
using CoubSharp.Receivers;
using CoubSharp.Managers;
using CoubSharp.Model;
using CoubSharp.Enums;
using System.Net.Http;
using System.IO;
using CoubSharp.ConsoleSample.Snippets;

namespace CoubSharp.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                #region coub snippets
                // Sample: Get coub by permalink value
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //CoubSnippets snippet = new CoubSnippets();
                //var coub = await snippet.GetCoubAsync(token, "xyz");

                // Sample: Edit coub by permalink value
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //CoubSnippets snippet = new CoubSnippets();
                //var coub = await snippet.EditCoubAsync(token, "xyz", "New Title" ,new string[] { "new", "tags" });

                // Sample: Recoub a coub by id value, looks like a repost, not making a new coub
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //CoubSnippets snippet = new CoubSnippets();
                //var coub = await snippet.MakeRecoubAsync(token, 123456, 12345);
                #endregion

                #region channel snippets
                // Sample: Get channel by permalink
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //ChannelSnippets snippet = new ChannelSnippets();
                //var channel = await snippet.GetChannelAsync(token, "xyzchannel");
                #endregion

                #region timeline
                // Sample: Get a tag timeline
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //TimelineSnippets snippet = new TimelineSnippets();
                //var timeline = await snippet.GetTegTimelineAsync(token, "dance");

                // Sample: Get user's timeline
                //var auth = new AuthorizeSnippets();
                //var token = await auth.AuthorizeAsync();
                //TimelineSnippets snippet = new TimelineSnippets();
                //var timeline = await snippet.GetUserTimelineAsync(token);
                #endregion

            }).Wait();
        }



       



    }
}
