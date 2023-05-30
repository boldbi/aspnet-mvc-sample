using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using BoldBI.Embed.Sample.Models;
using System.Security.Cryptography;
using System.IO;

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
        [Route("AuthorizationServer")]
        public ActionResult AuthorizationServer(string embedQuerString, string dashboardServerApiUrl)
        {
            embedQuerString += "&embed_user_email=" + GlobalAppSettings.EmbedDetails.UserEmail;
            var embedDetailsUrl = "/embed/authorize?" + embedQuerString.ToLower() + "&embed_signature=" + GetSignatureUrl(embedQuerString.ToLower());

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(dashboardServerApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();

                var result = client.GetAsync(dashboardServerApiUrl + embedDetailsUrl).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;
                return Json(resultContent);
            }
        }


        public string GetSignatureUrl(string message)
        {
            var encoding = new System.Text.UTF8Encoding();
            var keyBytes = encoding.GetBytes(GlobalAppSettings.EmbedDetails.EmbedSecret);
            var messageBytes = encoding.GetBytes(message);
            using (var hmacsha1 = new HMACSHA256(keyBytes))
            {
                var hashMessage = hmacsha1.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashMessage);
            }
        }
    }
}