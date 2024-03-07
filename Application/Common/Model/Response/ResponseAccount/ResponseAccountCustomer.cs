using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Response.ResponseAccount
{
    public class ResponseAccountCustomer
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
    }
}
