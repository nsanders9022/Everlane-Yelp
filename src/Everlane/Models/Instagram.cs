using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Everlane.Models
{
    public class Instagram
    {
        public string UserName { get; set; }
        public string Image { get; set; }

        public static List<Instagram> GetInstagram()
        {
            var client = new RestClient("https://api.instagram.comv1/users/self/media/recent/?access_token=23295033.c28206a.c07982e46a2343189debaa91dfaffd9b");

            var request = new RestRequest("Accounts/" + EnvironmentVariables.AccountSid + "/Instagram.json", Method.GET);

            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.AccountSid, EnvironmentVariables.AuthToken);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
            var instagramList = JsonConvert.DeserializeObject<List<Instagram>>(jsonResponse["url"].ToString());
            return instagramList;

        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response =>
            {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
