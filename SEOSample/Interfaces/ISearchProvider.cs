using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEOSample.Models;

namespace SEOSample.Interfaces
{
    public interface ISearchProvider
    {
        int MaxSearchResult { get; }
        Uri SearchEngineURI { get; }

        SearchResultModel GetSearchResult(SearchInputModel searchInputModel);
    }
}
