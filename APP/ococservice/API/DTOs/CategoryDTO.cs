using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }
        public string DisplayName { get; set; }
        public string URLImage { get; set; }
        
    }
}