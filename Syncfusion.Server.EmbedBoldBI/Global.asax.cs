using Newtonsoft.Json;
using Syncfusion.Server.EmbedBoldBI.Models;
using System;
using System.IO;
using System.Collections.Genericusing System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
//using Microsoft.AspNetCore.WebApplication;

namespace Syncfusion.Server.EmbedBoldBI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var builder = new BundleConfig();

            //var builder1 = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //builder.Services.AddControllersWithViews();

            //var app = builder.Build();
            try
            {
                string BasePath = AppDomain.CurrentDomain.BaseDirectory;
                string jsonString = File.ReadAllText(BasePath + "\\app_data\\embedConfig.json");
                GlobalAppSettings.EmbedDetails = JsonConvert.DeserializeObject<EmbedDetails>(jsonString);
            }

            catch (Exception)
            {
                //app.MapControllerRoute(
                //name: "default",
                //pattern: "{controller=Home}/{action=EmbedConfigErrorLog}");
            }
        }
    }
}
