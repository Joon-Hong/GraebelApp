using Microsoft.AspNetCore.Mvc;
using GraebelApp.Model;
using GraebelApp.Controller;
using System.Net;
using System.Net.Http;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly dbConnection db;

        [HttpGet]
        public HttpResponseMessage GetJobApplication(int id)
        {
            try
            {
                db.connectDB();
                JobApplication application = db.GetJobApplication(id);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(application.ToString());
                db.CloseDB();
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
                return response;
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateJobApplication([FromBody]JobApplication application)
        {
            try
            {
                if (application == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                db.connectDB();
                db.AddJobApplication(application);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                db.CloseDB();
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
                return response;
            }
        }
    }
}