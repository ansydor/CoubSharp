using CoubSharp.Enums;
using CoubSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.ConsoleSample.Snippets
{
    public class CoubSnippets
    {

        public async Task<Coub> GetCoubAsync(string token, string permalink)
        {
            ICoubService coubService = new CoubService(token);
            var coub = await coubService.Coubs.GetCoubAsync(permalink);
            return coub;
        }

        public async Task<Coub> EditCoubAsync(string token, string permalink, string title, string[] tags)
        {
            ICoubService coubService = new CoubService(token);
            var coub = await coubService.Coubs.GetCoubAsync(permalink);
            var coubEdit = await coubService.Coubs.EditCoubAsync(coub.Permalink, new EditCoub() { Title = title, ChannelId = coub.ChannelId, OriginalVisibilityType = OriginalVisibilityType.@public.ToString(), Tags = tags });
            return coubEdit;
        }

        public async Task<Coub> MakeRecoubAsync(string token, int coubId, int channelId)
        {
            ICoubService coubService = new CoubService(token);
            var recoub = await coubService.Recoubs.MakeRecoubAsync(coubId, channelId);
            return recoub;
        }
    }
}
