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

namespace CoubSharp.ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(async () =>
            {

                IAuthorizationService authorizationService = new AuthorizationService("", "");
                LocalhostServerCodeReceiver receiver = new LocalhostServerCodeReceiver("http://localhost:54325/");

                var code = await authorizationService.AuthorizeCodeWithReceiverAsync(receiver, new string[] { AuthorizationService.Scope.LoggedIn, AuthorizationService.Scope.Recoub, AuthorizationService.Scope.Create, AuthorizationService.Scope.ChannelEdit, AuthorizationService.Scope.Follow });
                var token = await authorizationService.AuthorizeTokenAsync("http://localhost:54325/", code);

                ICoubService coubService = new CoubService(token.AccessToken);
                var timeLineCannel = await coubService.Timelines.GetChannelTimelineAsync("royal.coubs", 1, 20, TimelineManager.ChannelTimelineOrderBy.LikesCount);

                var timeLine = await coubService.Timelines.GetUserTimelineAsync(1, 20);
                var coub = await coubService.Coubs.GetCoubAsync("xyz");
                var coubEdit = await coubService.Coubs.EditCoubAsync(coub.Permalink, new EditCoub() { Title = "New title", ChannelId = coub.ChannelId, OriginalVisibilityType = OriginalVisibilityType.@public.ToString(), Tags = new string[] { "new", "tags" } });
            }).Wait();
            
        }
    }
}
