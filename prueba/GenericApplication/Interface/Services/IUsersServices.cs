using GenericApplication.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.GenericResponse;

namespace GenericApplication.Interface.Services
{
    public interface IUsersServices
    {
        Task<Response> AssignConsecutive(Users usersRequest);
        Task<Response> CreateCustomer(CustomerRequest customerRequest);

    }
}
