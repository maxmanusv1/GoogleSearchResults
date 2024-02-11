# Google Search Results Scraper

In V1.3.0, this tool can scrape Google search results without requiring an API key. Only Google is supported in this version. Additionally, with specific settings, you can retrieve backlinks. <br> Furthermore, with the V1.3.0 update, it's possible to scrape a website's Domain Authority (DA), Page Authority (PA), and IP address.
## Installation
Package Manager 
```bash
NuGet\Install-Package GoogleSearchResults -Version 1.3.0
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

## Usage of DA/PA Checker
To check websites DA/PA and IP address use CheckAsync() method.
```csharp
public async Task<List<CheckerResults>> CheckAsync(List<GoogleSearchResult> searchResults, ProxyOptions? proxy = null)
```
```csharp
List<GoogleSearchResults.Google.GoogleSearchResult> searchResults = new List<GoogleSearchResults.Google.GoogleSearchResult>();
List<GoogleSearchResults.Checker.CheckerResults> results = new List<CheckerResults>();
var search = new GoogleSearch();
searchResults = await search.GetSearchResults("betta fish", 20, 4, null, SearchOptions.Backlink, FocusedWebsites.Xenforo);
Checker checker = new Checker();
results = await checker.CheckAsync(searchResults);
foreach (var item in results)
{
    Console.WriteLine($"URL: {item.URL}  Title: {item.Title} DA: {item.DA} PA: {item.PA} Spam Score: {item.SpamScore} IP: {item.IP}");
}

```


# TODO
    ADD Other search engines (Yandex, DuckDuckGo)
    Multiple search with proxies