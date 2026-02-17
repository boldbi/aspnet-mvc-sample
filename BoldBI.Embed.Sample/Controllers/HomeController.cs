using BoldBI.Embed.Sample.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Web.Mvc;

namespace BoldBI.Embed.Sample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            bool isConfigLoaded = false;
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string jsonString = System.IO.File.ReadAllText(Path.Combine(basePath, "embedConfig.json"));
                GlobalAppSettings.EmbedDetails = JsonConvert.DeserializeObject<EmbedDetails>(jsonString);
                isConfigLoaded = true;
            }
            catch
            {
                isConfigLoaded = false;
            }

            ViewBag.IsConfigLoaded = isConfigLoaded;
            return View();
        }

        [HttpGet]
        [Route("dashboards/get")]
        public string GetDashboards()
        {
            var token = GetToken();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalAppSettings.EmbedDetails.ServerUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("Authorization", token.TokenType + " " + token.AccessToken);
                var result = client.GetAsync(GlobalAppSettings.EmbedDetails.ServerUrl + "/api/" + GlobalAppSettings.EmbedDetails.SiteIdentifier + "/v2.0/items?ItemType=2").Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                return resultContent;
            }
        }

        [HttpGet]
        [Route("DashboardListing")]
        public ActionResult DashboardListing()
        {
            return View();
        }

        public Token GetToken()
        {
            using (var client = new HttpClient())
            {
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls | System.Net.SecurityProtocolType.Tls11 | System.Net.SecurityProtocolType.Tls12;
                client.BaseAddress = new Uri(GlobalAppSettings.EmbedDetails.ServerUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("Username", GlobalAppSettings.EmbedDetails.UserEmail),
                    new KeyValuePair<string, string>("grant_type", "embed_secret"),
                    new KeyValuePair<string, string>("embed_secret", GlobalAppSettings.EmbedDetails.EmbedSecret)
                });
                var result = client.PostAsync(GlobalAppSettings.EmbedDetails.ServerUrl + "/api/" + GlobalAppSettings.EmbedDetails.SiteIdentifier + "/token", content).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<Token>(resultContent);
                return response;
            }
        }

        [HttpPost]
        [Route("TokenGeneration")]
        public string TokenGeneration()
        {
            var embedDetails = new
            {
                email = GlobalAppSettings.EmbedDetails.UserEmail,
                serverurl = GlobalAppSettings.EmbedDetails.ServerUrl,
                siteidentifier = GlobalAppSettings.EmbedDetails.SiteIdentifier,
                embedsecret = GlobalAppSettings.EmbedDetails.EmbedSecret,
                dashboard = new  // Dashboard ID property is mandatory only when using BoldBI version 14.1.11.
                {
                    id = GlobalAppSettings.EmbedDetails.DashboardId
                }
            };

            //Post call to Bold BI server
            var client = new HttpClient();
            var requestUrl = $"{embedDetails.serverurl}/api/{embedDetails.siteidentifier}/embed/authorize";

            var jsonPayload = JsonConvert.SerializeObject(embedDetails);
            var httpContent = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var result = client.PostAsync(requestUrl, httpContent).Result;
            var resultContent = result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<dynamic>(resultContent).Data.access_token;
        }
    }
}