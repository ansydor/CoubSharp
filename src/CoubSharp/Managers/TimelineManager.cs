using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using CoubSharp.Model;
using CoubSharp.Enums;

namespace CoubSharp.Managers
{
    public class TimelineManager
    {
        public static class ChannelTimelineOrderBy
        {
            public const string LikesCount = "likes_count";
            public const string ViewsCount = "views_count";
            public const string NewestPopular = "newest_popular";

        }

        public static class TagFeedTimelineOrderBy
        {
            public const string LikesCount = "likes_count";
            public const string ViewsCount = "views_count";
            public const string NewestPopular = "newest_popular";
            public const string Oldest = "oldest";
        }

        public static class HotSectionTimelineOrderBy
        {
            public const string LikesCount = "likes_count";
            public const string ViewsCount = "views_count";
            public const string NewestPopular = "newest_popular";
            public const string Oldest = "oldest";
        }

        public  string AccessToken { get; set; }
        internal const string TimelineUrlBase = "/api/v2/timeline";

        public TimelineManager(string accessToken)
        {
            AccessToken = accessToken;
        }

        public TimelineManager()
        {
        }

        public async Task<Timeline> GetUserTimelineAsync(int page, int perPage)
        {
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}?access_token={AccessToken}&page={page}&per_page={perPage}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

        public async Task<Timeline> GetChannelTimelineAsync(string channelId, int page, int perPage, string orderBy = null)
        {
            if (string.IsNullOrWhiteSpace(channelId)) throw new ArgumentNullException("channelId", "channelId can't be null or empty");
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var order = orderBy == null ? string.Empty : $"&order_by={orderBy}";
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}/channel/{channelId}?page={page}&per_page={perPage}" + order;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

        public async Task<Timeline> GetTagFeedTimelineAsync(string tagName, int page, int perPage, string orderBy = null)
        {
            if (string.IsNullOrWhiteSpace(tagName)) throw new ArgumentNullException("tagName", "tagName can't be null or empty");
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var order = orderBy == null ? string.Empty : $"&order_by={orderBy}";
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}/tag/{tagName}?page={page}&per_page={perPage}" + order;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

        public async Task<Timeline> GetHotTimelineAsync(int page, int perPage, string orderBy)
        {
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var order = orderBy == null ? string.Empty : $"&order_by={orderBy}";
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}/hot?page={page}&per_page={perPage}" + order;
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

        public async Task<Timeline> GetExploreTimelineAsync(string categoryId, int page, int perPage)
        {
            if (string.IsNullOrWhiteSpace(categoryId)) throw new ArgumentNullException("categoryId", "categoryId can't be null or empty");
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}/explore/{categoryId}?page={page}&per_page={perPage}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

        public async Task<Timeline> GetLikesTimelineAsync(int page, int perPage)
        {
            if (page < 0 || perPage < 0) throw new ArgumentOutOfRangeException("page or perpage", "page and perpage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{TimelineUrlBase}/likes/?page={page}&per_page={perPage}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var timeline = JsonConvert.DeserializeObject<Timeline>(json);
                return timeline;
            }
        }

    }
}
