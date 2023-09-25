using AventStack.ExtentReports.Utils;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TestFrameworkAPI.Repo;
using TestFrameworkAPI.Schemas.ResponseSchemas;
using TestFrameworkAPI.TestBase;

namespace TestFrameworkAPI.SetupMethods
{
    static class CommonMethods
    {
        public static IRestRequest request = StaticObjectRepo.restRequest;

        public static void SetBaseURL()
        {
            StaticObjectRepo.BaseURL = AppReader.GetConfigValue("BaseURL");
        }

        public static void SetEndPoint(string APIType)
        {
            StaticObjectRepo.Endpoint = AppReader.GetConfigValue(APIType);

        }


        public static void CreateRequest(string RequestType, string _BaseURL, string EndPoint = "")
        {
            request = StaticObjectRepo.restRequest;
            if (String.IsNullOrEmpty(EndPoint))
                EndPoint = StaticObjectRepo.BaseURL;

            switch (RequestType.ToUpper())
            {
                case "GET":
                    request = new RestRequest(_BaseURL + EndPoint, Method.GET);
                    break;

                case "PUT":
                    request = new RestRequest(_BaseURL + EndPoint, Method.PUT);
                    break;

                case "POST":
                    request = new RestRequest(_BaseURL + EndPoint, Method.POST);
                    break;

                case "PATCH":
                    request = new RestRequest(_BaseURL + EndPoint, Method.PATCH);
                    break;

                case "DELETE":
                    request = new RestRequest(_BaseURL + EndPoint, Method.DELETE);
                    break;
            }
        }


        public static void AddHeaders(string User = "")
        {
            request.AddHeader("Content-Type", "application/json");

            Uri myuri = new Uri(StaticObjectRepo.BaseURL);
            request.AddHeader("Host", myuri.Host);
            request.AddHeader("Authorization", GetToken(User));
            request.AddHeader("Origin", myuri.Host);
            request.AddHeader("Referer", myuri.Host + "/");
            request.AddHeader("Accept-Language", "en-GB,en;q=0.9,en-US;q=0.8");

        }

        public static void AddParameters(string APIname, string RemoveParameter = "")
        {
            if(!RemoveParameter.ToLower().Equals("api-version"))
                request.AddQueryParameter("api-version", "2016-10-01", false);
            if(!RemoveParameter.ToLower().Equals("sp"))
                request.AddQueryParameter("sp", "%2Ftriggers%2Fmanual%2Frun", false);
            if(!RemoveParameter.ToLower().Equals("sv"))
                request.AddQueryParameter("sv", "1.0", false);
            if(!RemoveParameter.ToLower().Equals("sig"))
                request.AddQueryParameter("sig", GetToken(APIname).ToString(), false);
        }


        internal static void RemoveAllParameters()
        {
            for (int i = request.Parameters.Count; i >= 1; i--)
            {
                request.Parameters.RemoveAt(0);
            }
        }


        private static string GetToken(string UserType)
        {
            string TokenValue = "";

            switch (UserType.ToLower().Trim())
            {
                case "internal":
                    TokenValue = "QATokenHE";
                    break;

                case "external":
                    TokenValue = "QATokenLA";
                    break;

                default:
                    TokenValue = "InvalidToken";
                    break;
            }

                return AppReader.GetConfigValue(TokenValue);
        }


        internal static bool ValidateStatus(string statusCode)
        {
            bool StatusMatch = false; 
            switch (statusCode.ToLower())
            {
                case "ok":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().ToLower().Equals(StatusCodes.Ok.ToString().ToLower()))
                        StatusMatch = true;
                    break;

                case "accepted":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.Accepted.ToString()))
                        StatusMatch = true;
                        break;

                case "unauthorised":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.Unauthorized.ToString()))
                        StatusMatch = true;
                    break;

                case "bad request":
                    if (StaticObjectRepo.restResponse.StatusCode.ToString().Equals(StatusCodes.BadRequest.ToString()))
                        StatusMatch = true;
                    break;
            }
            return StatusMatch;

        }

        internal static void ValidateJSONResponse(string aPIType)
        {
            switch (aPIType.ToLower())
            {
                case "searchproject":
                    ValidateResponse.SearchProjectAPI();
                    break;
            }
        }
    }

}
