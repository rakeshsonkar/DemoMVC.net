using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class databaseNameSize
    {
        public string DatabaseName
        {
            get; set;
        }
        
         public long DataBaseSize { get; set; }

        
    }
}