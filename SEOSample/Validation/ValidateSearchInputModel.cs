using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SEOSample.Interfaces;
using SEOSample.Models;

namespace SEOSample.Validation
{
    public class ValidateSearchInputModel : IValidateSearchInputModel
    {
        public bool IsValidModel(SearchInputModel searchInputModel)
        {
           return IsValidSearchTerm(searchInputModel.SearchTerm) && IsValidURI(searchInputModel.SearchURL);
        }

        private bool IsValidSearchTerm(string searchTerm)
        {
            if (!string.IsNullOrEmpty(searchTerm))
            {
                return true;
            }

            return false;
        }

        private bool IsValidURI(Uri uri)
        {
            if (Uri.IsWellFormedUriString(uri.ToString(),UriKind.Absolute))
            {
                return (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps); ;
            }

            return false;
        }
    }
}
