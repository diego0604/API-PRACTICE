using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.GenericResponse
{
    public static class GenericsResponse
    {


        public static Response OkResponse(string message, object Object, int count)
        {

            return new Response
            {
                Code = 200,
                Message = message,
                IsSuccess = true,
                Object = Object,
                Count = count

            };
        }
        public static Response ErrorResponse(string message)
        {

            return new Response
            {
                Code = 200,
                Message = message,
                IsSuccess = false,
            };
        }
    }
}
