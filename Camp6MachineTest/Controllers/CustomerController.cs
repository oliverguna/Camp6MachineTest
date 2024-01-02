using Camp6MachineTest.Models;
using Camp6MachineTest.Repository;
using Camp6MachineTest.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camp6MachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerTblRepository _customerTblRepository;
        // construction Injection
        public CustomerController(ICustomerTblRepository customerRepository)
        {
            _customerTblRepository = customerRepository;
        }
        #region GEt all Customer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerTbl>>> GetCustomerAll()
        {
            return await _customerTblRepository.GetAllCustomerTbl();
        }
        #endregion
        #region Add Customer
        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] CustomerTbl customer)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    var CustomerId = await _customerTblRepository.AddCustomer(customer);
                    if (CustomerId > 0)
                    {
                        return Ok(CustomerId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region Update Customer
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerTbl customer)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    await _customerTblRepository.UpdateCustomer(customer);

                    return Ok(customer);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region GetCustomer By id
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerTbl>> GetCustomerById(int? id)
        {
            try
            {
                var customer = await _customerTblRepository.GetCustomerById(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete an Customer
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            try
            {
                var customerId = await _customerTblRepository.DeleteCustomer(id);
                if (customerId > 0)
                {
                    return Ok(customerId);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
        #region Get ViewModel Customer
        [HttpGet]
        [Route("ViewModelGetCustomer")]
        public async Task<ActionResult<IEnumerable<CustomerDetailsViewModel>>> GetCustomer()
        {
            return await _customerTblRepository.GetViewModelCustomer();
        }

        #endregion
    }
}
