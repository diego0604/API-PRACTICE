using GenericApplication.Interface.Services;
using GenericApplication.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using Utilities.GenericResponse;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private IProductsService _productsService;
        private IUsersServices _usersServices;
        public TestController(IProductsService productsService, IUsersServices usersServices)
        {
            _productsService = productsService;
            _usersServices = usersServices;
        }


        /// <summary>
        /// Encargado de crear usuario y asignar consecutivos
        /// </summary>
        /// <param name="usersRequest"></param>
        /// <returns></returns>
        [HttpPost("AssignConsecutive")]
        public async Task<IActionResult> AssignConsecutive(Users usersRequest)
        {
            Response response = await _usersServices.AssignConsecutive(usersRequest);
            return Ok(response);
        }

        /// <summary>
        /// Encargado de crear productos
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(Product productRequest)
        {

            Response response = await _productsService.CreateProduct(productRequest);
            return Ok(response);    

        }

        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerRequest customerRequest) {
            Response response = await _usersServices.CreateCustomer(customerRequest);
            return Ok(response);


        }

    }
}

