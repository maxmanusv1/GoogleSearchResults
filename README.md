# Google Search Results Scraper

Scraps google search results without api key. Only Google supported in this version: V1.2.0 <br>
With the specific settings you can get Backlinks too. 
## Installation

.NET CLI
```bash
dotnet tool install --global GoogleSearchResults --version 1.2.0
```
Package Manager 
```bash
NuGet\Install-Package GoogleSearchResults -Version 1.2.0
```
## Usage
GoogleSearchResult class contains target website URL and title.
```csharp 
using GoogleSearchResults;
using GoogleSearchResults.Google;
public async Task Main(string[] args)
{
    List<GoogleSearchResult> searchResults = new List<GoogleSearchResult>();
    var search = new GoogleSearch();
    searchResults = await search.GetSearchResults("query",20,4,null,SearchOptions.Backlink, FocusedWebsites.Xenforo);
    foreach(var item in searchResults){
            Console.WriteLine("Url:" + item.Url + "Title:" + item.Title);
    }
    Console.ReadKey();
}
```
To use proxy: Use ProxyOptions class to specify your proxy and credentials.
```csharp
var proxyOptions = new ProxyOptions() { 
    UseProxy = true,
    IP = "IP",
    Port = "PORT",
    Username = "username",
    Password = "password",
};
    // and use it in method.
await GetSearchResults(string Query, int maximumCount, int pageCount, proxyOptions, SearchOptions searchOptions = SearchOptions.Normal, FocusedWebsites websites = FocusedWebsites.Any);

```
GetSearchResults() Method. Specify proxy null if you dont want to use.
```csharp
public async Task GetSearchResults(string Query, int maximumCount, int pageCount, ProxyOptions proxy = null, SearchOptions searchOptions = SearchOptions.Normal, FocusedWebsites websites = FocusedWebsites.Any)
```
## SearchOptions
    Normal : Gets all results pointed to specifed query,
    Forum : Returns forum websites with query word you provided,
    Backlink : It points to related web sites & forums to scrap results,
    INTEXT : Google will return pages that contain the query word you provided,
    INURL : Google will only show you pages that have that term in the URL,
    DEFINE : Google will return definitions for the term from different sites,
    RELATED : Google will return related websites

## FocusedWebsites
    Any,
    Reddit,
    Xenforo,
    vBulletin,
    FluxBB,
    SMF

# TODO
    ADD Other search engines (Yandex, DuckDuckGo)
    Multiple search with proxies
    .NET Core & .NET Framework implementation