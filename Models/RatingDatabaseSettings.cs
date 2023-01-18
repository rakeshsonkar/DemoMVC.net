using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoMVC.Models
{
    public class RatingDatabaseSettings 
    {
        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; } 

        public string CollectionName { get; set; }
    }
}