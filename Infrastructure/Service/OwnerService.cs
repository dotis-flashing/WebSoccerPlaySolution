using Application.Common.Model.Request.RequestAccount;
using Application.Common.Model.Response.ResponseAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public interface OwnerService
    {
        Task<ResponseAccountOwner> CreateOwner(RequestAccountOwner request);
    }
}
