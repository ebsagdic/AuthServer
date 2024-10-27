using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Core.DTO_s
{
    public class UserAppDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }   

        public string? City { get; set; }
    }
}
