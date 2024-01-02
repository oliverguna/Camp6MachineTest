using Camp6MachineTest.Models;
using Camp6MachineTest.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Camp6MachineTest.Repository
{
    public class CustomerRepository: ICustomerTblRepository
    {
        private readonly LoanMS_dbContext _Context;

        public CustomerRepository(LoanMS_dbContext context)
        {
            _Context = context;
        }

        #region Get all Customer
         public async Task<List<CustomerTbl>> GetAllCustomerTbl()
        {
            if (_Context != null)
            {
                return await _Context.CustomerTbl.ToListAsync();
            }
            return null;
        }
        #endregion

        #region add a customer
        public async Task<int> AddCustomer(CustomerTbl customer)
        {
            if (_Context != null)
            {
                await _Context.CustomerTbl.AddAsync(customer);
                await _Context.SaveChangesAsync();  // commit the transction
                return customer.CId;
            }
            return 0;
        }
        #endregion
        #region Update Customer
        public async Task UpdateCustomer(CustomerTbl customer)
        {
            if (_Context != null)
            {
                _Context.Entry(customer).State = EntityState.Modified;
                _Context.CustomerTbl.Update(customer);
                await _Context.SaveChangesAsync();
            }
        }
        #endregion

        #region GetCustomerById
        public async Task<CustomerTbl> GetCustomerById(int? id)
        {
            if (_Context != null)
            {
                var customer = await _Context.CustomerTbl.FindAsync(id);   //primary key
                return customer;
            }
            return null;
        }
        #endregion

        #region Delete Customer
        public async Task<int> DeleteCustomer(int? id)
        {
            if (_Context != null)
            {
                var customer = await (_Context.CustomerTbl.FirstOrDefaultAsync(emp => emp.CId == id));

                if (customer != null)
                {
                    //Delete
                    _Context.CustomerTbl.Remove(customer);

                    //Commit
                    await _Context.SaveChangesAsync();
                    return customer.CId;
                }
            }
            return 0;
        }
        #endregion
        #region CustomerDetails
        public async Task<List<CustomerDetailsViewModel>> GetViewModelCustomer()
        {
            if (_Context != null)
            {
                // Linq Joining
                return await (from LC in _Context.CustomerTbl
                              from LD in _Context.LoanDetailsTbl
                              where LC.CId == LD.CId
                              select new CustomerDetailsViewModel
                              {
                                  FirstName = LC.FirstName,
                                  LastName = LC.LastName,
                                  City = LC.City,
                                  Occupation = LC.Occupation,
                                  Age = LC.Age,
                                  Gender  = LC.Gender,
                                  Address = LC.Address,
                                  PhoneNumber = LC.PhoneNumber,
                                  LoanType =LD.LoanType,
                                  AccountNumber = LD.AccountNumber,
                                  Branch = LD.Branch,
                                  LoanAmount = LD.LoanAmount,
                                  InterestRate = LD.InterestRate,
                                  RequestedDate = LD.RequestedDate,
                                  IssueDate = LD.IssueDate,
                                  Status = LD.Status,

                              }).ToListAsync();
            }
            return null;
        }

        #endregion
    }
}
