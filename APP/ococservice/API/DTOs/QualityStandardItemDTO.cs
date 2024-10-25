using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QualityStandardItemDTO
    {
        public int QSIId { get; set; }
        public ItemDTO Item { get; set; }        
        public UnitDTO Unit { get; set; }
        // public string LatLog { get; set; }    
        public List<QualityStandardItemRangeDTO> Ranges { get; set; }
    }
}