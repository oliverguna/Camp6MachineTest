using System;
using System.Collections.Generic;

namespace Camp6MachineTest.Models
{
    public partial class CustomerTbl
    {
        public CustomerTbl()
        {
            LoanDetailsTbl = new HashSet<LoanDetailsTbl>();
        }

        public int CId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }
        public decimal Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? LId { get; set; }

        public virtual LoginTbl L { get; set; }
        public virtual ICollection<LoanDetailsTbl> LoanDetailsTbl { get; set; }
    }
}
