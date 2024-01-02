using System;
using System.Collections.Generic;

namespace Camp6MachineTest.Models
{
    public partial class LoanDetailsTbl
    {
        public int LoanId { get; set; }
        public string LoanType { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string LoanAmount { get; set; }
        public string InterestRate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
        public int? CId { get; set; }

        public virtual CustomerTbl C { get; set; }
    }
}
