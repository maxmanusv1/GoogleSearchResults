using GoogleSearchResults.Google;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GoogleSearchResults.Checker
{
    public class Checker 
    {
        RequestComponents requestComponents = new RequestComponents(); 
        ResponseComponents responseComponents = new ResponseComponents();
        /// <summary>
        /// Check the Domain Authority (DA), Page Authority (PA), and IP addresses of websites within this method.
        /// </summary>
        /// <param name="searchResults">List the returned values from the GetSearchResults() method.</param>
        /// <param name="proxy">Leave the proxy parameter null if you don't want to use one.</param>
        /// <returns></returns>
        public async Task<List<CheckerResults>> CheckAsync(List<GoogleSearchResult> searchResults, ProxyOptions? proxy = null)
        {
            List<CheckerResults> results = new List<CheckerResults>();
            CheckerResults checkerResults;

            string proxyURL = proxy != null ? "http://" + proxy.IP + ":" + proxy.Port : string.Empty;

            var httpclientHandler = new HttpClientHandler()
            {
                Proxy = proxy == null ? null : new WebProxy(proxyURL) { Credentials = new NetworkCredential(proxy.Username, proxy.Password)},
                UseProxy = proxy == null ? false : proxy.UseProxy
            };
            using (HttpClient client = new HttpClient(httpclientHandler))
            {
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Mobile Safari/537.36");
                client.DefaultRequestHeaders.Add("Origin", "https://www.robingupta.com");
                client.DefaultRequestHeaders.Add("Referer", "https://www.robingupta.com/bulk-domain-authority-checker.html");
                int count = searchResults.Count % 9 == 0 ? (searchResults.Count / 9) : (searchResults.Count / 9) + 1;
                for (int i = 0; i < searchResults.Count; i++)
                {
                    List<GoogleSearchResult> tobePayloaded = searchResults.Skip(i * 9).Take(9).ToList();
                    string payload = await requestComponents.CreatePayload(tobePayloaded);
                    var content = new StringContent(payload,Encoding.UTF8);
                    await PostRequest(client, content);
                    tobePayloaded.Clear();
                }
                for (int z = 0; z < searchResults.Count; z++)
                {
                    checkerResults = new CheckerResults();
                    checkerResults = await GetRequest(client, searchResults[z].URL);
                    checkerResults.Title = searchResults[z].Title;
                    results.Add(checkerResults);
                }
                return results;
            }
        }
        public async Task<string> PostRequest(HttpClient client, StringContent content)
        {
            try
            {
                var response = await client.PostAsync("https://www.robingupta.com/wp-content/plugins/mng_domain_auth_v3//alexa.action.php", content);
                return await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException(e.Message, e);   
            }
        }
        public async Task<CheckerResults> GetRequest(HttpClient client, string url)
        {
            try
            {
                var obj = new CheckerResults();
                string createdURL = await responseComponents.URLCreater(url);
                HttpResponseMessage response = await client.GetAsync(createdURL);
                string responseString = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(responseString))
                    obj = await responseComponents.ResponseDecoder(responseString);
                return obj;
            }
            catch (HttpRequestException e)
            {
                throw new HttpRequestException($"{e.Message}", e);  
            }
           
        }
    }
}
