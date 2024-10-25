using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace API.Entities
{
    public class QualityStandardItem
    {
        [Key]
        public int QSIId { get; set; }
        public QualityStandard QualityStandard { get; set; }        
        public Item Item { get; set; }        
        public Unit Unit { get; set; }
        // public string LatLog { get; set; }

        

        // RelationShip
        public int QSId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public List<QualityStandardItemRange> QualityStandardItemRanges { get; set; }
        

    }
}