using System;
using System.Collections.Generic;
using System.Net;
using Beddit.Net.Model;
using Beddit.Net.RequestModel;
using Beddit.Net.ResponseModel;
using RestSharp;
using RestSharp.Deserializers;

namespace Beddit.Net
{
    public class BedditService
    {
        private const string ApiUrl = "https://cloudapi.beddit.com/api/v1";
        private const string AuthorizePost = "/auth/authorize";
        private const string TokenInfoGet = "/auth/token_info";
        private const string PasswordResetPost = "/user/password_reset";
        private const string SleepDataGet = "/user/{0}/sleep";

        private BedditAuthorizationResponse auth = null;

        private void ErrorHandler(IRestResponse response)
        {
            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response.  Check inner details for more info.";
                throw new BedditException(message, response.ErrorException) { Description = response.ErrorMessage };
            }

            if (response.StatusCode == HttpStatusCode.OK)
                return;

            var deserializer = new JsonDeserializer();
            var exception = deserializer.Deserialize<BedditException>(response);

            throw exception;

        }

        public BedditAuthorizationResponse AuthorizeUser(BedditAuthorizationRequest authorizationRequest)
        {
            var client = new RestClient(ApiUrl)
            {
                Authenticator = new SimpleAuthenticator("username", authorizationRequest.UserName, "password", authorizationRequest.Password)
            };

            var request = new RestRequest(AuthorizePost, Method.POST);
            request.AddParameter("grant_type", authorizationRequest.GrantType);

            var response = client.Execute<BedditAuthorizationResponse>(request);

            ErrorHandler(response);

            auth = response.Data;
            return response.Data;
        }

        public BedditPasswordResetResponse PasswordReset(BedditPasswordResetRequest resetRequest)
        {
            throw new NotImplementedException("Application tokens not implemented.");
        }

        public BedditTokenInfoResponse GetTokenInfo()
        {
            if (auth == null || string.IsNullOrEmpty(auth.AccessToken))
                throw new BedditException("Not Authorized", "The user is not authroized.");

            var client = new RestClient(ApiUrl)
            {
                //NOTE: auth.TokenType is "user" - which is returned from the api - yet we require "UserToken" as the parameter.
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(auth.AccessToken, "UserToken")
            };

            var request = new RestRequest(TokenInfoGet, Method.GET);
            var response = client.Execute<BedditTokenInfoResponse>(request);

            ErrorHandler(response);

            return response.Data;
        }

        public List<BedditSleepData> GetSleepData(BedditSleepDataStartAndEndDateRequest sleepRequest)
        {
            if (auth == null || string.IsNullOrEmpty(auth.AccessToken))
                throw new BedditException("Not Authorized", "The user is not authroized.");

            var client = new RestClient(ApiUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(auth.AccessToken, "UserToken")
            };

            var requestUrl = string.Format(SleepDataGet, auth.User);
            var request = new RestRequest(requestUrl, Method.GET);
            request.AddParameter("start_date", sleepRequest.StartDate.ToString("yyyy-MM-dd"));
            request.AddParameter("end_date", sleepRequest.EndDate.ToString("yyyy-MM-dd"));

            var response = client.Execute<List<BedditRawSleepDataResponse>>(request);

            ErrorHandler(response);

            return response.Data.ToBedditSleepData();
        }

        public List<BedditSleepData> GetSleepData(BedditSleepDataUpdatedAfterRequest sleepRequest)
        {
            if (auth == null || string.IsNullOrEmpty(auth.AccessToken))
                throw new BedditException("Not Authorized", "The user is not authroized.");

            var client = new RestClient(ApiUrl)
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(auth.AccessToken, "UserToken")
            };

            var requestUrl = string.Format(SleepDataGet, auth.User);
            var request = new RestRequest(requestUrl, Method.GET);
            request.AddParameter("updated_after", sleepRequest.UpdatedAfter);

            var response = client.Execute<List<BedditRawSleepDataResponse>>(request);

            ErrorHandler(response);

            return response.Data.ToBedditSleepData();
        }

        
    }
}