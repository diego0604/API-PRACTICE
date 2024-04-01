using AutoMapper.Configuration;
using DataAccess;
using GenericApplication.Interface.Services;
using GenericApplication.Request;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography.X509Certificates;
using Utilities.GenericResponse;

namespace EntityInfraestructure.Servics
{
    public class ProductsServices : IProductsService
    {
        private string _conn = string.Empty;
        Data dl; 

        public ProductsServices(IConfiguration configuration) {
            dl = new Data(configuration["Settings:Connection"]); 
        }

        public async Task<Response> CreateProduct(Product productRequest)
        {
            string sql = $"INSERT INTO products (cId, pDescription)\r\nVALUES( {productRequest.cId}, '{productRequest.pDescription}')";
            await dl.ConsultAsync(sql);

            return GenericsResponse.OkResponse("Se ha insertado producto",0, 0);

        }
    }
}
