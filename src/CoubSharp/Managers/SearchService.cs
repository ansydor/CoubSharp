using CoubSharp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.Managers
{
    public class SearchService
    {
        public static class GeneralSearchOrderBy
        {
            public const string LikesCount = "likes_count";
            public const string ViewsCount = "views_count";
            public const string NewestPopular = "newest_popular";
            public const string Newest = "newest";
            public const string Oldest = "oldest";
        }

        public static class ChannelSearchOrderBy
        {
            public const string FollowersCount = "followers_count";
            public const string Newest = "newest";
        }

        public static class CoubSearchOrderBy
        {
            public const string LikesCount = "likes_count";
            public const string ViewsCount = "views_count";
            public const string NewestPopular = "newest_popular";
            public const string Newest = "newest";
            public const string Oldest = "oldest";
        }

        internal const string SearchUrlBase = "/api/v2/search";

        public SearchService()
        {
        }

        public async Task<GeneralSearchResult> SearchAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{SearchUrlBase}?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
                return searchResult;
            }
        }

        public async Task<GeneralSearchResult> SearchChannelsAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{SearchUrlBase}/channels?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
                return searchResult;
            }
        }

        public async Task<GeneralSearchResult> SearchCoubsAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{CoubService.ApiUrlBase}{SearchUrlBase}/coubs?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
                return searchResult;
            }
        }
    }
}
