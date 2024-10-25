using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QualityStandardItemIDTO
    {
        public int ItemId { get; set; }        
        public int UnitId { get; set; }
        // public string LatLog { get; set; }    
        public List<QualityStandardItemRangeIDTO> Ranges { get; set; }
        
    }
}