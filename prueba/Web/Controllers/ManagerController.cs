
using Microsoft.AspNetCore.Mvc;
using Models.Request;

namespace Web.Controllers
{
    public class ManagerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody]CustomerRequest customerRequest)
        {
            try
            {
                HttpClient httpClient = new HttpClient("");
            }
            catch (Exception)
            {

                throw;
            }

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody]Product productRequest)
        {


            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AssignConsecutive([FromBody]Users userRequest)
        {
            return Ok();
        }

    }
}
