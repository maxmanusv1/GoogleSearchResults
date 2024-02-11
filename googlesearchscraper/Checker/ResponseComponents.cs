using HtmlAgilityPack;
using System.Threading.Tasks;

namespace GoogleSearchResults.Checker
{
    public class ResponseComponents
    {
        public string baseUrl = "https://www.robingupta.com/wp-content/plugins/mng_domain_auth_v3/alexa.action.php";
        public string pageToken = "get_website";
        public string da = "y";
        public string ip = "y";
        public string pa = "y";
        public string s = "y";
        public string v = "1";
        public async Task<string> URLCreater(string URL)
        {
            return baseUrl + "?sitename=" + URL + "&page_token=" + pageToken + "&null&da=" + da + "&ip=" + ip + "&pa=" + pa + "&ss=" + s + "&v" + v;
        }
        public async Task<CheckerResults> ResponseDecoder(string content)
        {
            var obj = new CheckerResults();
            HtmlDocument html = new HtmlDocument();
            html.LoadHtml(content);

            var nodes = html.DocumentNode.SelectNodes("//th");
            if (nodes != null && nodes.Count >=5)
            {
                obj.URL = nodes[1].Element("a").GetAttributeValue("href", "");
                obj.DA = nodes[2].InnerText.Trim();
                obj.PA = nodes[3].InnerText.Trim(); 
                obj.SpamScore = nodes[4].InnerText.Trim();
                obj.IP = nodes[5].InnerText.Trim();
            }
            return obj;
        }

    }
}
