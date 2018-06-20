using CoubSharp.Managers;
using CoubSharp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoubSharp.ConsoleSample.Snippets
{
    public class SearchSnippets
    {
        public async Task<GeneralSearchResult> GeneralSearchAsync(string search)
        {
            ICoubService coubService = new CoubService(string.Empty);
            var searchResult = await coubService.GeneralSearch.SearchAsync(search, 1, 20, SearchService.GeneralSearchOrderBy.LikesCount);
            return searchResult;
        }

        public async Task<GeneralSearchResult> SearchChannelsAsync(string search)
        {
            ICoubService coubService = new CoubService(string.Empty);
            var searchResult = await coubService.GeneralSearch.SearchChannelsAsync(search, 1, 20, SearchService.ChannelSearchOrderBy.FollowersCount);
            return searchResult;
        }

        public async Task<GeneralSearchResult> SearchCoubsAsync(string search)
        {
            ICoubService coubService = new CoubService(string.Empty);
            var searchResult = await coubService.GeneralSearch.SearchCoubsAsync(search, 1, 20, SearchService.CoubSearchOrderBy.ViewsCount);
            return searchResult;
        }

        public async Task<IEnumerable<Tag>> SearchTagsAsync(string search)
        {
            ICoubService coubService = new CoubService(string.Empty);
            var searchResult = await coubService.GeneralSearch.SearchTagsAsync(search);
            return searchResult;
        }
    }
}
