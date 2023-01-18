using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using System.Xml.Linq;
using System.ComponentModel.DataAnnotations;
using DemoMVC.Models;
using System.ServiceProcess;
using System.Collections.ObjectModel;
using MongoDB.Bson;

namespace DemoMVC.Controllers
{
    public class DatabaseActiveController : ApiController
    {
        [Route("GetDatabaseLiveOrNot")]
        [HttpPost]
        public string GetDatabaseLiveOrNot([FromBody] string valueData)
        {
           // DataLayer obj = new DataLayer();
            //string data = obj.GetData_BYID(value);
            //obj = null;
            return "data";
        }


        [Route("checkServices")]
        [HttpPost]
        public string CheckServices()
        {

            // ServiceController services = new  ServiceController("MongoDB");
            // var servicesStatus = services.ToDictionary(s => s.ServiceName, s => s.Status);
            // return "test  "+servicesStatus;

            ServiceController sc = new ServiceController("MongoDB");

            switch (sc.Status)
            {
                case ServiceControllerStatus.Running:
                    return "Running";
                case ServiceControllerStatus.Stopped:
                    return "Stopped";
                case ServiceControllerStatus.Paused:
                    return "Paused";
                case ServiceControllerStatus.StopPending:
                    return "Stopping";
                case ServiceControllerStatus.StartPending:
                    return "Starting";
                default:
                    return "Status Changing";
            }

        }

        [Route("getAllDataBase")]
        [HttpPost]
        public List<string> getAllDataBase()
        {
                string ConnectionStringUrl = ConfigurationManager.ConnectionStrings["ConnectionStringUrl"].ConnectionString;
                var client = new MongoClient(ConnectionStringUrl);
              /*    ;
                List<string> list = new List<string>();
                foreach (string databaseName in databaseNames)
                {
                    list.Add(databaseName);
                }*/
                return client.ListDatabaseNames().ToList();
        }
        [Route("CheckDatabaseExits")]
        [HttpPost]
        public string  CheckDatabaseExits()

        {
            string DatabaseName = "testData1";
            string ConnectionStringUrl = ConfigurationManager.ConnectionStrings["ConnectionStringUrl"].ConnectionString;
            var client = new MongoClient(ConnectionStringUrl);
            if (DatabaseName.ToLower()=="testdata")
            {
                var database = client.GetDatabase("TestDB");
                var collection = database.GetCollection<TestDb>("TestingDbCollection");
        

                collection.InsertOne(new TestDb { Name = "Rakesh Sonkar" });
                return "Data instered if Block   "+ DatabaseName.ToLower();
            }
            else
            {
                
                var database = client.GetDatabase("TestDB");
                var collection = database.GetCollection<TestDb>("TestingDbCollection");
                /* var options = new CreateCollectionOptions { Capped = true, MaxSize = 1024 * 1024 };
                 database.CreateCollection("cappedBar", options);*/
                collection.InsertOne(new TestDb {Name = DatabaseName});
                return "Data instered else Block";
            }

            //string ConnectionStringUrl = ConfigurationManager.ConnectionStrings["ConnectionStringUrl"].ConnectionString;
           // var client = new MongoClient(ConnectionStringUrl);
            /*    ;
              List<string> list = new List<string>();
              foreach (string databaseName in databaseNames)
              {
                  list.Add(databaseName);
              }*/
            
        }


    }
   /* public class SignClassFile
    {
        [Required]
        public string dataByte { get; set; }
        [Required]
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Message { get; set; }
    }*/
}


//      [Route("GetDatabaseLiveOrNot")]
//      [HttpPost]
//      public HttpResponseMessage GetDatabaseLiveOrNot()
//      {
//          /* try
//           {
//               string ratingString = ConfigurationManager.ConnectionStrings["RatingString"].ConnectionString;
//               var isAlive = ProbeForMongoDbConnection(ratingString);
//               return Request.CreateResponse(HttpStatusCode.OK, , Configuration.Formatters.JsonFormatter);
//           }
//           catch (Exception ex) {

//               return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message, Configuration.Formatters.JsonFormatter);

//           }*/

//          ///bool dbIsRunning;

//          string ratingString = ConfigurationManager.ConnectionStrings["RatingString"].ConnectionString;
//          string UserDatabase = ConfigurationManager.ConnectionStrings["UserDatabase"].ConnectionString;
//          var m = new MongoClient(ratingString);



//          var dbList = m.ListDatabases().ToList();

//          var server = m.GetServer();
//          Array data = server.GetDatabaseNames().ToArray();

//          // server.GetType(); "MongoDB.Driver.MongoServer, MongoDB.Driver.Legacy, Version=2.18.0.0, Culture=neutral, PublicKeyToken=null"

//          /*  server.Settings.Servers
//            [
//                {
//                            "_host": "localhost",
//                    "_port": 27017
//                }
//            ]
//*/
//          // host server.Settings.Servers.First().Host     "localhost"

//          //port server.Settings.Servers.First().Port 27017 
//          // check  database Exists  or  not       server.DatabaseExists()


//          // var db = m.GetDatabase(UserDatabase);


//          // var server = m.GetServer();
//          /*   try
//             {
//                 //server.Ping();
//                 /Console.WriteLine("Connected"); //or form2.show();
//             }
//             catch (Exception ex)
//             {

//                 Console.WriteLine("Failed");
//             }*/


//          /* int count = 0;
//           var client = new MongoClient(ratingString);
//           // This while loop is to allow us to detect if we are connected to the MongoDB server
//           // if we are then we miss the execption but after 5 seconds and the connection has not
//           // been made we throw the execption.
//           while (client.Cluster.Description.State.ToString() == "Disconnected")
//           {
//               Thread.Sleep(100);
//               if (count++ >= 50)
//               {
//                   throw new Exception("Unable to connect to the database. Please make sure that "
//                       + client.Settings.Server.Host + " is online");
//               }
//           }*/
//          //String message = null;

//          //  var command = new CommandDocument("ping", 1);
//          /*var col = ((MongoDatabase)db).GetCollectionNames();
//          try
//          {

//              // var state = _client.Cluster.Description.State;
//              // db.RunCommand({ serverStatus: 1, repl: 0, metrics: 0, locks: 0 });
//              message = "run";
//          }
//          catch (Exception ex)
//          {
//              // ping failed

//              message = ex.ToString();

//          }*/
//          //server.Ping();


//          return Request.CreateResponse(HttpStatusCode.OK, server, Configuration.Formatters.JsonFormatter);


//      }

