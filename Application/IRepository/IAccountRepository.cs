using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {
        Task<Account> GetUserNameByAccount(string username);
        Task<Account> GetCustomerByAccountId(Guid id);

        Task<Account> GetAdminByAccountId(Guid id);

        Task<Account> GetOwnerByAccountId(Guid id);
    }
}
