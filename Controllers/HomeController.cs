using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace SteelToeConfiguration.Controllers
{
    public class HomeController : BaseController
    {

        private readonly string MongoDbName;
        private readonly string MongoDbCollectionName;

        public HomeController(IConfigurationRoot configuration, IMongoClient mongoClient) : base(configuration, mongoClient)
        {
            MongoDbName = Configuration["PCFUSER_MONGODB_DATABASE"];
            MongoDbCollectionName = Configuration["PCFUSER_MONGODB_COLLECTION_NAME"];
        }

        public IActionResult Index()
        {
            var mongoDb = MongoClient.GetDatabase(MongoDbName);
            var collection = mongoDb.GetCollection<BsonDocument>(MongoDbCollectionName);

            if(collection == null)
            {
                var collectionOptions = new CreateCollectionOptions();
                mongoDb.CreateCollection(MongoDbCollectionName, collectionOptions);
            }
                            
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
