using DBTest.InvoiceManagerDB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication.Interface.Services
{
    public interface IPruebaSmContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<User> Users { get; set; } 

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql);
        Task<int> ExecuteSqlRawAsync(string sql);

    }
}
