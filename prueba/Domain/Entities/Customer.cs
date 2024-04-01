using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBTest.InvoiceManagerDB
{
    public partial class Customer
    {
        public Customer()
        {
            Users = new HashSet<User>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }
        public string? Document { get; set; }
        public string? CName { get; set; }
        public byte[]? Pwd { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
