using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaphore = API.Entities.Semaphore;

namespace API.DTOs
{
    public class QualityStandardItemRangeIDTO
    {
        public float LowerLim { get; set; }
        public float UpperLim { get; set; }
        public string Notes { get; set; }
        // public SemaphoreDTO Semaphore { get; set; }
        public int SemaphoreId { get; set; }
        
    }
}