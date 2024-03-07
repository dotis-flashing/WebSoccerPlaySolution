using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Model.Request.RequestAccount
{
    public class RequestAccountAdmin
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }
        [Required] public string FullName { get; set; }

        [Required] public string Phone { get; set; }

        [Required] public string Address { get; set; }

        [EmailAddress] public string Email { get; set; }
    }
}
