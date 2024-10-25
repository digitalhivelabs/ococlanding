using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CountryDTO
    {
        public int CountryId { get; set; }
        public string DisplayName { get; set; }
        public string URLImage { get; set; }
    }
}