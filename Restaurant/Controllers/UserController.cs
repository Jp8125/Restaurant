using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private List<User> users= new List<User>()
        {
            new User(){Id=1,Name="Owner"},
            new User(){Id=2,Name="Nirmal"},
            new User(){Id=3,Name="Pradumana"}
        }; 
        public UserController()
        {
           
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public ActionResult Get(string name)
        {
            var userData= users.Find(obj => obj.Name == name);
            if (userData != null)
            {
                return Ok(userData);
            }
            else
            {
                return BadRequest("no data found");
            }
        }
    }
}