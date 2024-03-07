using Application.IGenericRepository;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository.Imp
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<Account> GetUserNameByAccount(string username)
        {
            var account = await _context.Set<Account>()!.FirstOrDefaultAsync(a => a.UserName == username);
            return account;
        }

        public async Task<Account> GetCustomerByAccountId(Guid id)
        {
            var account = await _context.Set<Account>()!.Include(c => c.Customers)
                .FirstOrDefaultAsync(a => a.AccountId == id);
            return account;
        }

        public async Task<Account> GetAdminByAccountId(Guid id)
        {
            var account = await _context.Set<Account>()!.Include(a => a.Admins).FirstOrDefaultAsync(a => a.AccountId == id);
            return account;
        }

        public async Task<Account> GetOwnerByAccountId(Guid id)
        {
            var account = await _context.Set<Account>()!.Include(o => o.Owners).FirstOrDefaultAsync(a => a.AccountId == id);
            return account;
        }
    }
}
