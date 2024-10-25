using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserApproverDTO
    {
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        public string Role { get; set; }
    }
}