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
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(FootBall_PitchContext context) : base(context)
        {
        }

        public async Task<Admin> GetAdminByAccountId(Guid id)
        {
            var account = await _context.Admins.Include(a => a.Account).FirstOrDefaultAsync(a => a.AccountId == id);
            return account;
        }
    }
}
