using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoogleSearchResults.Google
{
    public class GoogleSearch
    {
        public string DefaultUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36";
        public string endPoint = "http://www.google.com/search?q=";
        /// <summary>
        /// Get Google Search Results. 
        /// </summary>
        /// <param name="Query">Search Query</param>
        /// <param name="ProxyOptions">Proxy to use, leave it null if you dont want to use. <see cref="ProxyOptions"/></param>
        /// <param name="maximumCount">Maximum number of return objects.</param>
        /// <param name="pageCount">Maximum number of pages to use.</param>
        /// <param name="searchOptions">Search options to use. <see cref="SearchOptions"/> to see options.</param>
        /// <param name="websites">Focus websites for extended search. <see cref="FocusedWebsites"/></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<List<GoogleSearchResult>> GetSearchResults(string Query, int maximumCount, int pageCount, ProxyOptions? proxy = null, SearchOptions searchOptions = SearchOptions.Normal, FocusedWebsites websites = FocusedWebsites.Any)
        {
            List<GoogleSearchResult> results = new List<GoogleSearchResult>();

            if (string.IsNullOrWhiteSpace(Query))
                throw new ArgumentNullException();
            string replacedQuery = Query.Replace(" ", "+");
            string endPoint = await BuildLink(replacedQuery, maximumCount, searchOptions, websites);
            try
            {
                string proxyURL = proxy != null ? "http://" + proxy.IP + ":" + proxy.Port : string.Empty;

                var httpclientHandler = new HttpClientHandler()
                {
                    Proxy = proxy == null ? null : new WebProxy(proxyURL) { Credentials = new NetworkCredential(proxy.Username, proxy.Password) },
                    UseProxy = proxy == null ? false : proxy.UseProxy
                };
                var httpClient = new HttpClient(httpclientHandler);
                httpClient.DefaultRequestHeaders.UserAgent.ParseAdd(DefaultUserAgent);
                for (int i = 1; i < pageCount; i++)
                {
                    var response = await httpClient.GetStringAsync(endPoint);
                    var htmldoc = new HtmlDocument();
                    htmldoc.LoadHtml(response);
                    var nodes = htmldoc.DocumentNode.SelectNodes("//div[@class='yuRUbf']");
                    if (nodes == null)
                        throw new Exception("Probably captcha error, try to use proxy.");
                    foreach (var tag in nodes)
                    {
                        var resultObject = new GoogleSearchResult
                        {
                            URL = tag.Descendants("a").FirstOrDefault()?.Attributes["href"]?.Value,
                            Title = tag.Descendants("h3").FirstOrDefault()?.InnerText

                        };
                        results.Add(resultObject);
                    }
                }
                return results;
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + Environment.NewLine + ex.Source);
            }
        }
        private async Task<string> BuildLink(string query,int count, SearchOptions options, FocusedWebsites websites)
        {
            switch (options)
            {
                case SearchOptions.Normal:
                    endPoint += "+"+ query;
                    break;
                case SearchOptions.Forum:
                    endPoint += "inurl:showthread+" + query;
                    break;
                case SearchOptions.Backlink:
                    endPoint += "intext:showthread+" + query;
                    break;
                case SearchOptions.INTEXT:
                    endPoint += "intext:+" + query;
                    break;
                case SearchOptions.INURL:
                    endPoint += "inurl:+" + query;
                    break;
                case SearchOptions.DEFINE:
                    endPoint += "define:+" + query;
                    break;
                case SearchOptions.RELATED:
                    endPoint += "related:+" + query;
                    break;
                default:
                    endPoint += "+"+ query;
                    break;
            }
            switch (websites)
            {
                case FocusedWebsites.Any:
                    break;
                case FocusedWebsites.Reddit:
                    endPoint += "+reddit";
                    break;
                case FocusedWebsites.Xenforo:
                    endPoint += "+xenforo";
                    break;
                case FocusedWebsites.vBulletin:
                    endPoint += "+vbulletin";
                    break;
                case FocusedWebsites.FluxBB:
                    endPoint += "+FluxBB";
                    break;
                case FocusedWebsites.SMF:
                    endPoint += "+SMF";
                    break;
                default:
                    break;
            }
            endPoint += $"&num={count}&start=1";
            return endPoint;
        }
    }
}
