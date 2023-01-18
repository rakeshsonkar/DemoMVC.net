using Antlr.Runtime.Misc;
using DemoMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using DemoMVC.Models;
using static DemoMVC.Models.VariableModel.VariableModel;
using System.Configuration;
using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver;

namespace DemoMVC.Controllers
{
    public class UserController : ApiController
    {
        private readonly Userservices _userservices;
        public UserController()
        {
            _userservices = new Userservices();
        }

        [Route("getUser")]
        [HttpPost]
        public HttpResponseMessage GetAllUser()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userservices.getAllUser(), Configuration.Formatters.JsonFormatter);
        }

        [Route("getUserById")]
        [HttpPost]
        public HttpResponseMessage GetUserById([FromBody] TestClass testClass)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userservices.getUserById(testClass.ID), Configuration.Formatters.JsonFormatter);
        }

        [Route("saveData")]
        [HttpPost]
        public HttpResponseMessage SaveData([FromBody] UserData userData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userservices.SaveData(userData), Configuration.Formatters.JsonFormatter);
        }

        [Route("deleteUserById")]
        [HttpPost]
        public HttpResponseMessage deleteUserById([FromBody] TestClass testClass)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userservices.deleteUserById(testClass.ID), Configuration.Formatters.JsonFormatter);
        }
        [Route("UpdateUser")]
        [HttpPost]
        public HttpResponseMessage UpdateUser([FromBody] UserData userData)
        {
            return Request.CreateResponse(HttpStatusCode.OK, _userservices.UpdateUser(userData), Configuration.Formatters.JsonFormatter);
        }

    } 
}