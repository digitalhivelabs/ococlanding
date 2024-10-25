using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QualityStandardItemODTO
    {
        public int QSIId { get; set; }
        public int ItemId { get; set; }        
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string UnitName { get; set; }
        public List<QualityStandardItemRangeDTO> Ranges { get; set; }        
    }
}