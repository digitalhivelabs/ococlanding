using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Spesimen
    {
        public int SpesimenId { get; set; }
        public DateTime SpesimenDate { get; set; }
        // public string LocationName { get; set; }
        // public string LocationLatLon { get; set; }
        public Point Point { get; set; }
        public DateTime CDate { get; set; } = DateTime.Now;
        public User CreatedBy { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }

        // RelationShip
        public int PointId { get; set; }
        public List<SpesimenItem> SpesimenItems { get; set; }
        public int CreatedById { get; set; }


    }
}