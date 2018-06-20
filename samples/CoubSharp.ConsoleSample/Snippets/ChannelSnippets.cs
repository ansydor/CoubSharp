using CoubSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.ConsoleSample.Snippets
{
    public class ChannelSnippets
    {
        public async Task<Channel> GetChannelAsync(string token, string channelId)
        {
            ICoubService coubService = new CoubService(token);
            var channel = await coubService.Channels.GetChannelAsync(channelId);
            return channel;
        }
    }
}
