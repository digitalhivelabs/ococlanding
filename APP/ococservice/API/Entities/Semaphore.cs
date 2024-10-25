using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
// using Semaphore = API.Entities.Semaphore;

namespace API.Entities
{
    public class Semaphore
    {
        public int SemaphoreId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Color { get; set; }   
        [MaxLength(15)]
        public string Hex { get; set; }

        // RelationShip
        public List<QualityStandardItemRange> QualityStandardItemRanges { get; set; }

    }
}