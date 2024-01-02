using Camp6MachineTest.Models;
using System.Linq;
using System.Runtime.Intrinsics.X86;

namespace Camp6MachineTest.Repository
{
    public class LoginRepository: ILoginRepository
    {
        private readonly LoanMS_dbContext _Context;

        public LoginRepository(LoanMS_dbContext context)
        {
            _Context = context;
        }
        #region Find Login By Credentials
        public LoginTbl ValidataeUser(string un, string pwd)
        {
            if (_Context != null)
            {
                LoginTbl login = _Context.LoginTbl.FirstOrDefault(login => login.Username == un && login.Password == pwd);
                if (login != null)
                {
                    return login;
                }
            }
            return null;
        }

        #endregion
    }
}
