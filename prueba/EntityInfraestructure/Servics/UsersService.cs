using DBTest.InvoiceManagerDB;
using GenericApplication.Interface.Services;
using GenericApplication.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utilities.GenericResponse;

namespace EntityInfraestructure.Servics
{
    public class UsersService : IUsersServices
    {
        private IPruebaSmContext _pruebaSmContext;
        public UsersService(pruebaSmContext pruebaSmContext)
        {
            _pruebaSmContext = pruebaSmContext;
        }
        public async Task<Response> AssignConsecutive(Users usersRequest)
        {

            Response response = new();
            try
            {
                List<User> lstConsecutives = _pruebaSmContext.Users.Where(x => x.CId == usersRequest.cId).ToList();


                string consecutive = ConsecutiveGenerator(lstConsecutives);


                await _pruebaSmContext.BeginTransactionAsync();
                User user = new User
                {
                    CId = usersRequest.cId,
                    Consecutive = consecutive,
                    UserName = usersRequest.userName
                };
                _pruebaSmContext.Users.Add(user);


                await _pruebaSmContext.SaveChangesAsync();
                await _pruebaSmContext.CommitTransactionAsync();
                response = GenericsResponse.OkResponse($"Se agrega usuario, el consecutivo es: {consecutive}", user, 1);

            }
            catch (Exception e)
            {
                _pruebaSmContext.RollbackTransactionAsync();
                return GenericsResponse.ErrorResponse("Ha ocurrido un error.");

            }

            return response;

        }
        public async Task<Response> CreateCustomer(CustomerRequest customerRequest)
        {
            Response response = new();
            try
            {
                var customers = await _pruebaSmContext.Customers.Where(x => x.Document == customerRequest.document).ToListAsync();

                if (customers != null && customers.Count > 0)
                {

                    return GenericsResponse.ErrorResponse("Ya existe un usuario con este documento.");
                }


                Customer customer = new Customer
                {
                    CName = customerRequest.cName,
                    Pwd = Encoding.UTF8.GetBytes(customerRequest.pwd),
                    Document = customerRequest.document
                };
                await _pruebaSmContext.BeginTransactionAsync();
                _pruebaSmContext.Customers.Add(customer);

                await _pruebaSmContext.SaveChangesAsync();
                await _pruebaSmContext.CommitTransactionAsync();
                response = GenericsResponse.OkResponse("Se ha creado", customer, 1);
            }
            catch (Exception e)
            {
                await _pruebaSmContext.RollbackTransactionAsync();
                return GenericsResponse.ErrorResponse("Ha ocurrido un error");
            }
            return response;
        }


        #region privateMethods


        private string ConsecutiveGenerator(List<User> lstConsecutives)
        {

            Random rnd = new Random();
            int consecutive = 0;
            string pattern = @"(\d)\1\1";
            do
            {
                consecutive = rnd.Next(0, 99999);


            } while (!Regex.IsMatch(consecutive.ToString().PadLeft(5,'0'), pattern) && lstConsecutives.Any(x => consecutive.ToString()
                                                                                        .Contains(x.Consecutive.ToString())));


            return consecutive.ToString().PadLeft(5,'0');

        }

        #endregion

    }
}
