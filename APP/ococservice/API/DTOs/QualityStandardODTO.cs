using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class QualityStandardODTO
    {
        public int QSId { get; set; }
        public string Organization { get; set; }
        public string Abbr { get; set; }
        public string Country { get; set; }

    }
}