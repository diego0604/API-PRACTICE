using System;
using System.Collections.Generic;

namespace DBTest.InvoiceManagerDB
{
    public partial class Product
    {
        public int PId { get; set; }
        public int? CId { get; set; }
        public string? PDescription { get; set; }

        public virtual Customer? CIdNavigation { get; set; }
    }
}
