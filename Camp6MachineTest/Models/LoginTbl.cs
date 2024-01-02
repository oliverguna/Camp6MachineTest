using System;
using System.Collections.Generic;

namespace Camp6MachineTest.Models
{
    public partial class LoginTbl
    {
        public LoginTbl()
        {
            CustomerTbl = new HashSet<CustomerTbl>();
        }

        public decimal LId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<CustomerTbl> CustomerTbl { get; set; }
    }
}
