using System;

namespace Camp6MachineTest.ViewModel
{
    public class CustomerDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Occupation { get; set; }
        public decimal Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //
        public string LoanType { get; set; }
        public string AccountNumber { get; set; }
        public string Branch { get; set; }
        public string LoanAmount { get; set; }
        public string InterestRate { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime IssueDate { get; set; }
        public string Status { get; set; }
    }
}
