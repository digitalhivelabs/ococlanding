using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaphore = API.Entities.Semaphore;

namespace API.DTOs
{
    public class QualityStandardItemRangeI2DTO
    {
        public float LowerLim { get; set; }
        public float UpperLim { get; set; }
        public string Notes { get; set; }
        public int SemaphoreId { get; set; }
        
    }
}