using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEOSample.Models
{
    public class SearchInputModel
    {
        [Required]
        public string SearchTerm { get; set; }

        [Url]
        [Required]
        public Uri  SearchURL { get; set; }
    }
}
