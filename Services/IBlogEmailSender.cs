using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogFinal.Services
{
    public interface IBlogEmailSender : IEmailSender
    {

        Task SendContactEmailAsync(string emailFrom, string name, string subject, string htmlMessage);

    }
}
