using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SEOSample.Interfaces;
using SEOSample.Models;
using SEOSample.Validation;

namespace SEOSample.Controllers
{
    public class SearchController : Controller
    {
        private ISearchProvider _searchProvider;
        private IValidateSearchInputModel _validateSearchInputModel;

        public SearchController(ISearchProvider searchProvider, IValidateSearchInputModel validateSearchInputModel)
        {
            _searchProvider = searchProvider;
            _validateSearchInputModel = validateSearchInputModel;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateModel]
        public IActionResult GetSearchIndex(SearchInputModel searchInputModel)
        {
            if (_validateSearchInputModel.IsValidModel(searchInputModel))
            {
                SearchResultModel result = _searchProvider.GetSearchResult(searchInputModel);
                return View(result);
            }

            return View(new SearchResultModel { Error = "Input Model is incorrect. Please Provide Valid Model" });

        }
    }
}