using Camp6MachineTest.Models;
using System.Runtime.Intrinsics.X86;

namespace Camp6MachineTest.Repository
{
    public interface ILoginRepository
    {
        public LoginTbl ValidataeUser(string un, string pwd);
    }
}
