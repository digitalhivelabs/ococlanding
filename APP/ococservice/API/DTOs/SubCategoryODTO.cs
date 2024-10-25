using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SubCategoryODTO
    {
        public int SubCategoryId { get; set; }
        public string DisplayName { get; set; }
        public List<PlaceODTO> Places { get; set; }
    }
}