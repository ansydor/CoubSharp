CoubSharp
===================
Coub APIs Client Library for .NET
For coub on https://coub.com

Setup and usage
===================
#### Setup
* Available on NuGet: https://www.nuget.org/packages/CoubSharp/
* Install into your PCL project and/or Client projects.

#### Usage

Authorize code and access token
```csharp
//Create an instance of AuthorizationService to get code and access token
IAuthorizationService authorizationService = new AuthorizationService("yourCoubAppId", "yourCoubAppSecret");
//Now we can generate URL to get authorize code
//It comes to redirect URL with additional parameter http://yourWebSite.domain/authorize/?code=0x0x0x0x0
var urlToGetAuthorizeCode = authorizationService.AuthorizationCodeUrlAsync("http://yourWebSite.domain/authorize/", new string[] { AuthorizationService.Scope.LoggedIn, AuthorizationService.Scope.Recoub, AuthorizationService.Scope.Create, AuthorizationService.Scope.ChannelEdit, AuthorizationService.Scope.Follow });

//With code we can get an access token
var token = await authorizationService.AuthorizeTokenAsync("http://yourWebSite.domain/authorize/", code);
```

Create `CoubService` with access token
```csharp
//Now we can create an instance of CoubService wit access token
ICoubService coubService = new CoubService(token.AccessToken);
```

Get coubs from timelines
```csharp
//Getting Channel Timeline coubs ordered be likes count
//Can be done without access token
var timeLineCannel = await coubService.Timelines.GetChannelTimelineAsync("royal.coubs", 1, 20, TimelineManager.ChannelTimelineOrderBy.LikesCount);
//Can get user timeline
var timeLine = await coubService.Timelines.GetUserTimelineAsync(1, 20);
```

Get coub by permalink
```csharp	
//Getting coub by its permalink https://coub.com/view/xyz
var coub = await coubService.Coubs.GetCoubAsync("xyz");
```
