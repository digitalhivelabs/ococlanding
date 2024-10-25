using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class QualityStandard
    {
        [Key]
        public int QSId { get; set; }
        [MaxLength(150)]
        public string Organization { get; set; }
        [MaxLength(50)]
        public string Abbr { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        public DateTime MDate { get; set; }

        // RelationShip
        public List<QualityStandardItem> QualityStandardItems { get; set; }
    }
}