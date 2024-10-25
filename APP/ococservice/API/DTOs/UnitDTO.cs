using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UnitDTO
    {
        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Abbr { get; set; }               
        public string BaseUnitName { get; set; }
    }
}