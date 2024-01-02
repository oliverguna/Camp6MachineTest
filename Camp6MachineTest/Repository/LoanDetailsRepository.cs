using Camp6MachineTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Camp6MachineTest.Repository
{
    public class LoanDetailsRepository:ILoanDetailsRepository
    {
        private readonly LoanMS_dbContext _Context;

        public LoanDetailsRepository(LoanMS_dbContext context)
        {
            _Context = context;
        }

        #region Get all Details
        public async Task<List<LoanDetailsTbl>> GetAllLoanDetails()
        {
            if (_Context != null)
            {
                return await _Context.LoanDetailsTbl.ToListAsync();
            }
            return null;
        }
        #endregion

        #region add a Details
        public async Task<int> AddDetails(LoanDetailsTbl loanDetails)
        {
            if (_Context != null)
            {
                await _Context.LoanDetailsTbl.AddAsync(loanDetails);
                await _Context.SaveChangesAsync();  // commit the transction
                return loanDetails.LoanId;
            }
            return 0;
        }
        #endregion
        #region Update Details
        public async Task UpdateDetails(LoanDetailsTbl loanDetails)
        {
            if (_Context != null)
            {
                _Context.Entry(loanDetails).State = EntityState.Modified;
                _Context.LoanDetailsTbl.Update(loanDetails);
                await _Context.SaveChangesAsync();
            }
        }
        #endregion

        #region GetDetailsById
        public async Task<LoanDetailsTbl> GetDetailsById(int? id)
        {
            if (_Context != null)
            {
                var loan = await _Context.LoanDetailsTbl.FindAsync(id);   //primary key
                return loan;
            }
            return null;
        }
        #endregion

        #region Delete Details
        public async Task<int> DeleteDetails(int? id)
        {
            if (_Context != null)
            {
                var loan = await (_Context.LoanDetailsTbl.FirstOrDefaultAsync(emp => emp.LoanId == id));

                if (loan != null)
                {
                    //Delete
                    _Context.LoanDetailsTbl.Remove(loan);

                    //Commit
                    await _Context.SaveChangesAsync();
                    return loan.LoanId;
                }
            }
            return 0;
        }
        #endregion
    }
}
