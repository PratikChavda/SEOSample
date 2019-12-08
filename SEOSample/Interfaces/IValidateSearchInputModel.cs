using SEOSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEOSample.Interfaces
{
    public interface IValidateSearchInputModel
    {
        bool IsValidModel(SearchInputModel searchInputModel);
    }
}
