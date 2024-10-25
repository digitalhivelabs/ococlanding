using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Semaphore = API.Entities.Semaphore;

namespace API.Entities
{
    public class QualityStandardItemRange
    {
        [Key]
        public int QSIRId { get; set; }
        public float LowerLim { get; set; }
        public float UpperLim { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }
        public Semaphore Semaphore { get; set; }
        public QualityStandardItem QualityStandardItem { get; set; }   

        // RelationShip
        public int QSIId { get; set; }
        public int SemaphoreId { get; set; }

    }
}