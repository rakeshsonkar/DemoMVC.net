using DemoMVC.Models;

using MongoDB.Driver;
using System.Net.Http;
using System.Web.Http;

namespace DemoMVC.Controllers
{
    public class TestMongoController : ApiController
    {
        [Route("getDataInMongo")]
        [HttpPost]
        public HttpResponseMessage getTestData()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("microservices");
            var collection = database.GetCollection<Rating_Micro>("Rating_Micro");
            var result = collection.Find(_=> true).ToList();
            return Request.CreateResponse(result);
        }

    }
}