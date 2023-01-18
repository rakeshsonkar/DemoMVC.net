using DemoMVC.Models;
using DemoMVC.Services;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static DemoMVC.Models.VariableModel.VariableModel;

namespace DemoMVC.Controllers
{
    
    public class RatingController : ApiController
    {
        private RatingService _ratingService;
        public RatingController() 
        {
            _ratingService = new RatingService();
        }
     

     
        [Route("getAllRating")]
        [HttpPost]
        public  HttpResponseMessage getAllRating()
        {
         
            return Request.CreateResponse(HttpStatusCode.OK, _ratingService.getAllRating(),Configuration.Formatters.JsonFormatter);
        }

        [Route("getSingleRating")]
        [HttpPost]
        public  HttpResponseMessage GetSingleRating([FromBody] TestClass obj)
        {
            
            return Request.CreateResponse(HttpStatusCode.OK, _ratingService.GetSingleRating(obj.ID),Configuration.Formatters.JsonFormatter);
        }

        [Route("saveRating")]
        [HttpPost]
        public HttpResponseMessage SaveRating([FromBody] Rating_Micro rating_Micro)
        {

            return Request.CreateResponse(HttpStatusCode.OK, _ratingService.SaveRating(rating_Micro), Configuration.Formatters.JsonFormatter);
        }
    }
}