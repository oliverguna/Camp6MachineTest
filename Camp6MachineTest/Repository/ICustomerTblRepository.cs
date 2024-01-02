using Camp6MachineTest.Models;
using Camp6MachineTest.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camp6MachineTest.Repository
{
    public interface ICustomerTblRepository
    {
        Task<List<CustomerTbl>> GetAllCustomerTbl();

        Task<int> AddCustomer(CustomerTbl customer);

        Task UpdateCustomer(CustomerTbl customer);

        //Find an customer - Get customer by id

        Task<CustomerTbl> GetCustomerById(int? id);

        //Delete an customer
        Task<int> DeleteCustomer(int? id);

        Task<List<CustomerDetailsViewModel>> GetViewModelCustomer();
    }
}
