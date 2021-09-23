using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Diagnostics;
using System.Net;
using TokenProject.MvcUI.Models;

namespace TokenProject.MvcUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public AccessToken GetToken()
        {
            AccessToken accessToken = new AccessToken();

            var restClient = new RestClient("https://localhost:44378/api");
            var restRequest = new RestRequest("/tests/1", Method.POST);

            var userForLoginDto = new UserForLoginDto()
            {
                Email = "alazodkay@gmail.com",
                Password = "12345"
            };
            var jsonToSend = JsonConvert.SerializeObject(userForLoginDto);

            restRequest.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            restRequest.RequestFormat = DataFormat.Json;
            try
            {
                var response = restClient.Execute(restRequest);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    accessToken = JsonConvert.DeserializeObject<AccessToken>(response.Content);
                }
                else
                {
                    accessToken = new AccessToken();
                }
            }
            catch (Exception)
            {
            }
            return accessToken;
        }

        [Obsolete]
        public void TokenVarGecilmez()
        {
            var restClient = new RestClient("https://localhost:44378/api");
            var restRequest = new RestRequest("/tests/getlist", Method.GET);
            restRequest.RequestFormat = DataFormat.Json;

            try
            {
                restClient.ExecuteAsync(restRequest, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultData = response.Content;
                    }
                    else
                    {
                        var durum = response.StatusDescription;
                    }
                });
            }
            catch (Exception)
            {

            }
        }

        [Obsolete]
        public void TokenVarGec()
        {
            var getToken = GetToken();

            var restClient = new RestClient("https://localhost:44378/api");
            var restRequest = new RestRequest("/tests/getlist", Method.GET);
            restRequest.AddHeader("Authorization", "Bearer " + getToken.Token);
            restRequest.RequestFormat = DataFormat.Json;

            try
            {
                restClient.ExecuteAsync(restRequest, response =>
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var resultData = response.Content;
                    }
                    else
                    {
                        var durum = response.StatusDescription;
                    }
                });
            }
            catch (Exception)
            {

            }
        }
    }
}
