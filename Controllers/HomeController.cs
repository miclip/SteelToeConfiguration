using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace SteelToeConfiguration.Controllers
{
    public class HomeController : Controller
    {

        private readonly string MongoDbName = Environment.GetEnvironmentVariable("MONGODB_DATABASE");
        private readonly string MongoDbCollectionName = Environment.GetEnvironmentVariable("MONGODB_COLLECTION_NAME");

        public IConfigurationRoot Configuration {get;}
        public IMongoClient MongoClient {get;}
        public HomeController(IConfigurationRoot configuration, IMongoClient mongoClient)
        {
            Configuration = configuration;
            MongoClient = mongoClient;
        }

        public IActionResult Index()
        {
            var mongoDb = MongoClient.GetDatabase(MongoDbName);
            var collectionOptions = new CreateCollectionOptions();

            mongoDb.CreateCollection(MongoDbCollectionName, collectionOptions);
            var collection = mongoDb.GetCollection<BsonDocument>(MongoDbCollectionName);
            
            ViewBag.MongoDbDatabase = MongoDbName; 
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
