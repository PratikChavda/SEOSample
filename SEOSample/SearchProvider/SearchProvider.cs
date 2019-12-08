using SEOSample.Interfaces;
using SEOSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEOSample.SearchProvider
{
    public abstract class SearchProvider : ISearchProvider
    {
        public abstract Uri SearchEngineURI { get; }

        public int MaxSearchResult => 100;

        public abstract SearchResultModel GetSearchResult(SearchInputModel searchInputModel);        
    }
}
