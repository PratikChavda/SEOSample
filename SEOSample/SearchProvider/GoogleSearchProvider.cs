using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SEOSample.Models;

namespace SEOSample.SearchProvider
{
    public class GoogleSearchProvider : SearchProvider
    {
        public override Uri SearchEngineURI => new Uri("https://www.google.com.au/search");

        public override SearchResultModel GetSearchResult(SearchInputModel searchInputModel)
        {
            using (WebClient webClient = new WebClient())
            {
                NameValueCollection nameValueCollection = new NameValueCollection();
                nameValueCollection.Add("q", searchInputModel.SearchTerm);
                nameValueCollection.Add("num", MaxSearchResult.ToString());

                webClient.QueryString.Add(nameValueCollection);

                //I have not used async operation here, assuming this is only called from single thread.
                string resultInHtml = webClient.DownloadString(SearchEngineURI);
                string result = GetResultIndexesAsStrings(resultInHtml, searchInputModel.SearchURL.ToString());

                return new SearchResultModel { SearchResultIndex = result };

            }

        }

        private string GetResultIndexesAsStrings(string html, string URL)
        {
            const string pattern = "<a href=\"/url\\?q=(\\w+[a-zA-Z0-9.\\-?=/:]*)";

            var regex = new Regex(pattern);

            var matches = regex.Matches(html).Cast<Match>().ToList();

            var indexes = matches.Select((x, i) => new { i, x })
                .Where(x => x.ToString().Contains(URL))
                .Select(x => x.i + 1)
                .ToList();
            if (indexes.Any())
            {
                return string.Join(",", indexes);
            }

            return "0";

        }
    }
}
