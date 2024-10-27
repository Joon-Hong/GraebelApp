using Microsoft.AspNetCore.Mvc;
using GraebelApp.Model;
using GraebelApp.Controller;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly dbConnection db;

        [HttpGet]
        public async Task<HttpResponseMessage> GetJobApplication(int id)
        {
            try
            {
                return Ok(await db.());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateJobApplication([FromBody]JobApplication application)
        {
            try
            {
                if (application == null)
                {
                    return BadRequest();
                }
                db.AddJobApplication(application);
                return CreatedAtAction(nameof(GetJobApplication));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating new Job Application");
            }

        }

    }
}