using Microsoft.AspNetCore.Mvc;
using GraebelApp.Model;
using GraebelApp.Controller;
using System.Net;
namespace MyApi.Controllers
{
    [ApiController]
    public class JobApplicationController : ControllerBase
    {
        private dbConnection db;

        [Route("GetJobApplication/{id:int}")]
        [HttpGet]
        public ActionResult<JobApplication> GetJobApplication(int id)
        {
            try
            {
                db = new dbConnection();
                db.connectDB();
                JobApplication application = db.GetJobApplication(id);

                db.CloseDB();
                return application;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
                return NotFound();
            }
                

        }
        [Route("CreateJobApplication")]
        [HttpPost]
        public ActionResult<HttpResponseMessage> CreateJobApplication([FromBody]JobApplication application)
        {
            try
            {
                // reject bad request
                if (application == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
                // add job app
                db = new dbConnection();
                db.connectDB();
                db.AddJobApplication(application);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                db.CloseDB();
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(ex.Message);
                return response;
            }
        }
    }
}