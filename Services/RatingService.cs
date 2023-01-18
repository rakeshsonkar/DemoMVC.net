using DemoMVC.Models;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Results;

namespace DemoMVC.Services
{
    public class RatingService
    {
        private readonly IMongoCollection<Rating_Micro> collection;


        public RatingService() {
            string ratingString = ConfigurationManager.ConnectionStrings["RatingString"].ConnectionString;
            string ratingDatabase = ConfigurationManager.ConnectionStrings["RatingDatabase"].ConnectionString;
            string ratingCollection = ConfigurationManager.ConnectionStrings["RatingCollection"].ConnectionString;
            var client = new MongoClient(ratingString);
            var database = client.GetDatabase(ratingDatabase);
             collection = database.GetCollection<Rating_Micro>(ratingCollection);
        }
        
        public  List<Rating_Micro> getAllRating()
        {
            return collection.Find(_ => true).ToList();
        }


        public Rating_Micro GetSingleRating(string id)
        {
            return collection.Find(x => x.Id == id).FirstOrDefault();

        }
            

        public Rating_Micro SaveRating(Rating_Micro rating_Micro)
        {
            collection.InsertOne(rating_Micro);
           // ApiRespnose apiRespnose = new Models.ApiRespnose();
           // apiRespnose

          //  string stringjson = JsonConvert.SerializeObject();
            return rating_Micro;
        }
            

        public async Task UpdateAsync(string id, Rating_Micro rating_Micro) =>
            await collection.ReplaceOneAsync(x => x.Id == id, rating_Micro);

        public async Task RemoveAsync(string id) =>
            await collection.DeleteOneAsync(x => x.Id == id);

    }
}