using Camp6MachineTest.Models;
using Camp6MachineTest.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Camp6MachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanDetailsController : ControllerBase
    {
        private readonly ILoanDetailsRepository _loanDetailsRepository;
        // construction Injection
        public LoanDetailsController(ILoanDetailsRepository loanDetailsRepository)
        {
            _loanDetailsRepository = loanDetailsRepository;
        }
        #region GEt all Details
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDetailsTbl>>> GetDetailsAll()
        {
            return await _loanDetailsRepository.GetAllLoanDetails();
        }
        #endregion
        #region Add Details
        [HttpPost]
        public async Task<IActionResult> AddDetails([FromBody] LoanDetailsTbl loan)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    var loan_Id = await _loanDetailsRepository.AddDetails(loan);
                    if (loan_Id > 0)
                    {
                        return Ok(loan_Id);
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

        #region Update Loan
        [HttpPut]
        public async Task<IActionResult> UpdateLoan([FromBody] LoanDetailsTbl loan)
        {
            if (ModelState.IsValid)  // check the validate the code
            {
                try
                {
                    await _loanDetailsRepository.UpdateDetails(loan);

                    return Ok(loan);
                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        #endregion

        #region GetDetails By id
        [HttpGet("{id}")]
        public async Task<ActionResult<LoanDetailsTbl>> GetDetailsById(int? id)
        {
            try
            {
                var loan = await _loanDetailsRepository.GetDetailsById(id);
                if (loan == null)
                {
                    return NotFound();
                }
                return Ok(loan);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion

        #region Delete an Details
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetails(int? id)
        {
            try
            {
                var loanId = await _loanDetailsRepository.DeleteDetails(id);
                if (loanId > 0)
                {
                    return Ok(loanId);
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
    }
}
