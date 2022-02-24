using KCBVooma.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KCBVooma.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<AccountService> _logger;

        public AccountService(ApplicationDbContext applicationDbContext, ILogger<AccountService> logger)
        {
            _context = applicationDbContext;
            _logger = logger;
        }
        public async Task<int> AddAccount(AccountModel account)
        {
            var acc = new AccountModel
            {
                BankCode = account.BankCode,
                Iban = account.Iban,
                CustomerId = account.CustomerId,
            };
            _context.Accounts.Add(acc);
            var results = await _context.SaveChangesAsync();
            if (results > 0)
            {
                _logger.LogInformation(results.ToString());
            }
            _logger.LogInformation(results.ToString());
            return 200;
        }

        public async Task<int> DeleteAccount(int Id)
        {
            var accdata = _context.Accounts.FirstOrDefault(x => x.Id == Id);
            if (accdata != null)
            {
                _context.Accounts.Remove(accdata);
                return await _context.SaveChangesAsync();
            }
            return 400;
        }

        public AccountModel GetAccount(int Id)
        {
            try
            {
                var data = _context.Accounts.Where(x => x.Id == Id).ToList().SingleOrDefault();
                return data;
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                throw;
            }

            
        }

        public List<AccountModel> GetAccountList()
        {
            var acclist = (from Account in _context.Accounts
                            select new AccountModel
                            {
                                BankCode = Account.BankCode,
                                Iban = Account.Iban,
                                CustomerId= Account.CustomerId,
                                Id = Account.Id,
                            }).ToList();
            return acclist;
        }

        public async Task<int> UpdateAccount(AccountModel account)
        {
            var accdata = _context.Accounts.FirstOrDefault(x => x.Id == account.Id);
            if (accdata != null)
            {
                accdata.BankCode = account.BankCode;
                accdata.Iban = account.Iban;
                accdata.CustomerId = account.CustomerId;

                return await _context.SaveChangesAsync();
            }
            return 400;
        }
    }
}
