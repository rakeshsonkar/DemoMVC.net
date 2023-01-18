using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DemoMVC.Models.VariableModel
{
    public class VariableModel
    {

        public class TestClass
        {
            public string ID { get; set; }
        }

        public class UserData
        {
            public string ID { get; set; } = null;
            public string name { get; set; }
            public string bytedata { get; set; }

        }
    }
}