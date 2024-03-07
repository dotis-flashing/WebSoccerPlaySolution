using Application.Common.Model.Request.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security.Token
{
    public interface IMailService
    {
        Task SendEmail(Mail request);
    }
}
