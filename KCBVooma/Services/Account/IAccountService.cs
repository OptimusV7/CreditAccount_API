using System.Collections.Generic;
using System.Threading.Tasks;
using KCBVooma.Models;
namespace KCBVooma.Services.Account
{
    public interface IAccountService
    {
        public List<AccountModel> GetAccountList();
        public AccountModel GetAccount(int Id);
        public Task<int> UpdateAccount(AccountModel account);
        public Task<int> DeleteAccount(int Id);
        public Task<int> AddAccount(AccountModel account);
        
    }
}
