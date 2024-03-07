using Application.IGenericRepository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepository
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        Task<Owner> GetOwnerById(Guid ownerId);

        Task<Owner> GetOwnerByAccountId(Guid id);
    }
}
