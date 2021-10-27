using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBlogFinal.ViewModels
{
    public class MailSettings
    {

        //So we can configure and use and smtp server
        //from hetzner for example

        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

    }
}
