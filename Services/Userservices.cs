using DemoMVC.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Results;
using static DemoMVC.Models.VariableModel.VariableModel;

namespace DemoMVC.Services
{
    public class Userservices
    {
        private readonly IMongoCollection<UserModel> collection;

        public Userservices() {
            string ratingString = ConfigurationManager.ConnectionStrings["RatingString"].ConnectionString;
            string userDatabase = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
            string userCollection = ConfigurationManager.ConnectionStrings["UserCollection"].ConnectionString;
            var client = new MongoClient(ratingString);
            var database = client.GetDatabase(userDatabase);
            collection = database.GetCollection<UserModel>(userCollection);
        }

        public List<UserData> getAllUser()
        {
           List<UserModel> user= collection.Find(_ => true).ToList();
            var users = new List<UserData>();
            user.ForEach(data =>
            {
                var userData = new UserData();
                userData.ID = data.Id;
                userData.name = data.Name;
                string v = Encoding.ASCII.GetString(data.DataByte);
                userData.bytedata=  v;
                users.Add(userData);

            });
            return users;
            

        }
        public UserData getUserById(string id)
        {
            UserModel user = collection.Find(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return null;
                    }
            else
            {
                var userData = new UserData();
                userData.ID = user.Id;
                userData.name = user.Name;
                string v = Encoding.ASCII.GetString(user.DataByte);
                userData.bytedata = v;

                return userData;
            }
              


        }

        public string deleteUserById(string id)
        {
            try
            {
                collection.DeleteOne(x => x.Id == id);
                return "Deleted suceessfully this id "+ id;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
           
        }

        public string SaveData(UserData userData)
        {
            if (userData == null)
            {
                return "please provide User details";
            }
            else
            {
                 byte[] bytes = Encoding.ASCII.GetBytes(userData.bytedata);
               // byte[] bytes = Convert.FromBase64String(userData.bytedata);
                  var user = new UserModel();
                user.Name = userData.name;
                user.DataByte = bytes;
                 collection.InsertOne(user);

                return "save data successsfully";
            }
        }

        public object UpdateUser(UserData userData)
        {
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(userData.bytedata);
                var user = new UserModel();
                user.Name = userData.name;
                user.Id= userData.ID;
                user.DataByte = bytes;
                collection.ReplaceOne(x => x.Id == userData.ID, user);
                return "updated  successfull";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
    }
}