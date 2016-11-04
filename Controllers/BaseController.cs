using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;
using System;

namespace SteelToeConfiguration.Controllers
{
    public class BaseController : Controller
    {
        public IConfigurationRoot Configuration {get;}
        public IMongoClient MongoClient {get;}
        public BaseController(IConfigurationRoot configuration, IMongoClient mongoClient)
        {
            Configuration = configuration;
            MongoClient = mongoClient;
        }
    }
}
