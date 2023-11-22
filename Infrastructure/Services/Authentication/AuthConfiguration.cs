using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Authentication
{
    public class AuthConfiguration
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string SecretKey { get; set; }
        public string EncryptionKey { get; set; }
        public int ExpireInDays { get; set; }
        public int NoOfFailedTrials { get; set; }
    }
}
