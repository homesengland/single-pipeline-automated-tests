using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.Schemas.RequestSchemas;
using TestFrameworkAPI.Schemas.ResponseSchemas;

namespace TestFrameworkAPI.SetupMethods
{
    class ValidateResponse
    {
        public static void SearchProjectAPI()
        {
            //var responseJSON = SimpleJson.DeserializeObject<SearchProjectResponse>(StaticObjectRepo.restResponse.Content);
            //foreach (SearchResult item in responseJSON.searchResults)
            //{
            //    //Assert.IsTrue(item.bidId.Contains(SearchText));
            //}
        }
    }
}
