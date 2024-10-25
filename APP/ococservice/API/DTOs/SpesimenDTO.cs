using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SpesimenDTO
    {
        public int SpesimenId { get; set; }
        public DateTime CDate { get; set; }
        public DateTime SpecimenDate { get; set; }
        public string LocationName { get; set; }
        public string LocationLatLon { get; set; }
        public string Notes { get; set; }

        // RelationShip
        public List<SpesimenItemDTO> SpesimenItems { get; set; }
    }
}