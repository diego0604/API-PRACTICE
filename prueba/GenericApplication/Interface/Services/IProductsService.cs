using GenericApplication.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.GenericResponse;

namespace GenericApplication.Interface.Services
{
    public interface IProductsService
    {
        Task<Response> CreateProduct(Product productRequest);
    }
}
