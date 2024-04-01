using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBTest.InvoiceManagerDB
{
    public partial class User
    {
        public string? UserName { get; set; }
        public string? Consecutive { get; set; }
        public int? CId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public virtual Customer? CIdNavigation { get; set; }
    }
}
