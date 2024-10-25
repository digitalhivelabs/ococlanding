using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ItemDTO
    {
        public int itemId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }    
        public string UnitName { get; set; }
        public string MoreInfo { get; set; }
        public string ClassificationName { get; set; }
        public string CategoryName { get; set; }

    }
}