using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace SteelToeConfiguration.Controllers
{
    public class HomeController : Controller
    {
        public IConfigurationRoot Configuration {get;}
        public IMongoClient MongoClient {get;}
        public HomeController(IConfigurationRoot configuration, IMongoClient mongoClient)
        {
            Configuration = configuration;
            MongoClient = mongoClient;
        }

        public IActionResult Index()
        {
            ViewBag.ApplicationName = Configuration["vcap:application:application_name"];
            ViewBag.InstanceId = Configuration["vcap:application:instance_id"];
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
