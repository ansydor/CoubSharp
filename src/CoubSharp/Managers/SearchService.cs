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
    public class SearchService : IDisposable
    {
        #region constants
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
        #endregion
        internal const string SearchUrlBase = "search";
        internal const string SearchTagsUrlBase = "tags/search";

        internal HttpClient _httpClient;

        public SearchService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public SearchService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(CoubService.ApiUrlBase);
        }

        public async Task<GeneralSearchResult> SearchAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{SearchUrlBase}?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
            return searchResult;
        }

        public async Task<GeneralSearchResult> SearchChannelsAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{SearchUrlBase}/channels?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
            return searchResult;
        }

        public async Task<GeneralSearchResult> SearchCoubsAsync(string search, int page, int perPage, string orderBy)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            if (page < 0) throw new ArgumentOutOfRangeException("page", "page can't be negative");
            if (perPage < 0) throw new ArgumentOutOfRangeException("perPage", "perPage can't be negative");
            var url = $"{SearchUrlBase}/coubs?q={search}&page={page}&per_page={perPage}&order_by={orderBy}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<GeneralSearchResult>(json);
            return searchResult;
        }

        public async Task<IEnumerable<Tag>> SearchTagsAsync(string search)
        {
            if (string.IsNullOrWhiteSpace(search)) throw new ArgumentNullException("search", "search can't be null or empty");
            var url = $"{SearchTagsUrlBase}?title={search}";
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var searchResult = JsonConvert.DeserializeObject<IEnumerable<Tag>>(json);
            return searchResult;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
