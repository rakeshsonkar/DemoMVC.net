using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System;

namespace DemoMVC.Models
{
    public class Rating_Micro
    {
        [BsonElement("_Id")]
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("userId")]
        public string UserId { get; set; }
        [BsonElement("hotelId")]
        public string HotelId { get; set; }
       
        [BsonElement("rating")]
        public int Rating { get; set; }
        [BsonElement("feedBack")]
        public string FeedBack { get; set; }
        [BsonElement("_class")]
        public string testclass { get; set; }

        public static explicit operator Rating_Micro(Task<Rating_Micro> v)
        {
            throw new NotImplementedException();
        }
    }

}