using NUnit.Framework;
using SEOSample.Models;
using SEOSample.Validation;

namespace SEOSample.Test
{
    public class ValidationSearchInputModelTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void ValidationSearchInputeModel_IsValidModel_Returns_True()
        {
            ValidateSearchInputModel validateSearchInputModel = new ValidateSearchInputModel();
            SearchInputModel searchInputModel = new SearchInputModel
            {
                SearchTerm = "online title search",
                SearchURL = new System.Uri("https://www.infotrack.com.au")
            };

            bool result = validateSearchInputModel.IsValidModel(searchInputModel);
            Assert.AreEqual(true, result);
        }
    }
}
