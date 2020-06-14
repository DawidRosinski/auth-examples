using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace client.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //private readonly HttpClient _client;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            //_client = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Secret()
        {
            await AccessTokenRefreshWrapper(
                () => SercureGetRequest("https://localhost:44383/secret/index"));

            await AccessTokenRefreshWrapper(
                () => SercureGetRequest("https://localhost:44347/secret/index"));


            //var token = await HttpContext.GetTokenAsync("access_token");
            //var serverClient = _httpClientFactory.CreateClient();
            //serverClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            //var serverResponse = await serverClient.GetAsync("https://localhost:44383/secret/index");

            //await RefreshAccessToken();

            //token = await HttpContext.GetTokenAsync("access_token");
            //var apiClient = _httpClientFactory.CreateClient();
            //apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            //var apiResponse = await apiClient.GetAsync("https://localhost:44347/secret/index");

            return View();
        }

        private async Task<HttpResponseMessage> SercureGetRequest(string url)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> AccessTokenRefreshWrapper(
            Func<Task<HttpResponseMessage>> initialRequest)
        {
            var response = await initialRequest();

            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                await RefreshAccessToken();
                response = await initialRequest();
            }

            return response;
        }

        private async Task RefreshAccessToken()
        {
            var refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var refreshTokenClient = _httpClientFactory.CreateClient();

            var requestData = new Dictionary<string, string>
            {
                ["grant_type"] = "refresh_token",
                ["refresh_token"] = refreshToken
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "https://localhost:44383/oauth/token")
            {
                Content = new FormUrlEncodedContent(requestData)
            };

            var basicCredentials = "username:password";
            var encodedCredentials = Encoding.UTF8.GetBytes(basicCredentials);
            var base64Credentials = Convert.ToBase64String(encodedCredentials);

            request.Headers.Add("Authorization", $"Basic {base64Credentials}");

            var response = await refreshTokenClient.SendAsync(request);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

            var newAccessToken = responseData.GetValueOrDefault("access_token");
            var newRefreshToken = responseData.GetValueOrDefault("refresh_token");

            var authInfo = await HttpContext.AuthenticateAsync("ClientCookie");
            authInfo.Properties.UpdateTokenValue("access_token", newAccessToken);
            authInfo.Properties.UpdateTokenValue("refresh_token", newRefreshToken);

            await HttpContext.SignInAsync("ClientCookie", authInfo.Principal, authInfo.Properties);
        }
    }
}