﻿using CoubSharp.Managers;
using CoubSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.ConsoleSample.Snippets
{
    public class TimelineSnippets
    {

        public async Task<Timeline> GetTegTimelineAsync(string token, string tag)
        {
            ICoubService coubService = new CoubService(token);
            var timeline = await coubService.Timelines.GetTagFeedTimelineAsync(tag, 1, 1, TimelineManager.ChannelTimelineOrderBy.LikesCount);
            return timeline;
        }

        public async Task<Timeline> GetUserTimelineAsync(string token)
        {
            ICoubService coubService = new CoubService(token);
            var timeline = await coubService.Timelines.GetUserTimelineAsync(1, 20);
            return timeline;
        }
    }
}
