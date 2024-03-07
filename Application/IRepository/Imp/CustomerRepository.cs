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
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<Customer> GetCustomerByAccountId(Guid id)
        {
            var customer = await _context.Set<Customer>().Include(account => account.Account)
                .FirstOrDefaultAsync(customer => customer.AccountId == id);
            return customer;
        }
    }
}
