using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Promp.Options
{
    public class SmtpOptions
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
    }
}
