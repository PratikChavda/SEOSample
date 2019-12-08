"# SEOSample" 
This sample application is get an index of the searched URL from google search result. 

This application takes two parameters 
1. Search Term : any string value
2. Search URL : valid URL i.e. https://www.domainname.com, https://www.domainname.com.au

The return result is the string of Index(es) seperated by "," i.e. 1,10,15 etc

Only first 100 pages are searched for google search result. 

Project Solution Structure: 
 1. Controller 
    a. SearchController : Action : Index is the default action
                          Action : GetSearchIndex : Takes SearchInputModel as parameter and return SearchResultModel, it uses SearchProvider to get result from google Search.
 
 2. Interfaces
    a. ISearchProvider 
    b. IValidateSearchInputModel
 
 3. Models
    a. SearchInputModel : 
    b. SearchResultModel : 
    c. ErrorViewModel
    
 4. SearchProvider 
    a. SearchProvider : abstract class which inherits ISearchProvider, this class act as a base class for different SearchProvider i.e. Google, Bing etc
    b. GoogleSearchProvider : This class inherits SearchProvider and use SearchEngineURI to return result from Google Search. 
    
 5. Validation
    a. ValidateSearchInputModel : Inherits IValidateSearchInputModel and returns bool if both the parameter i.e. SearchTerm and SearchURL are valid.
    b. ValidateModelAttribute : This class developed to provide attribute on Controller Action. Unfortunetly, this alwyas return ModelState.IsValid false for correct URL. So I have commented attribute on Action. I have kept this class in solutio to show that validation can be achieved with Attribute and we don't need seperate class for Validation (i.e. ValidateSearchInputModel), which is injected from ConfigureServices in Startup.cs
    
 6. Views
    a. Search : Index is the default view. Client side validation is implemented over here. 
                GetSearchIndex, will display result of Index(es) return by google search seperated by "," i.e. 1,10,15 etc
