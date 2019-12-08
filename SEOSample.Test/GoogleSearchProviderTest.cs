using NUnit.Framework;
using SEOSample.Models;

namespace SEOSample.SearchProvider.Tests
{
    public class GoogleSearchProviderTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void GoogleSearch_HappyPath()
        {
            GoogleSearchProvider sut = new GoogleSearchProvider();
            SearchInputModel searchInputModel = new SearchInputModel { SearchTerm = "online title search", SearchURL = new System.Uri("https://www.infotrack.com.au") };
            SearchResultModel result = sut.GetSearchResult(searchInputModel);

            Assert.AreNotEqual(result.SearchResultIndex,"0");
        }
    }
}