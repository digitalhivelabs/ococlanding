using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Semaphore = API.Entities.Semaphore;

namespace API.DTOs
{
    public class SemaphoreIDTO
    {
        public string Name { get; set; }
        public string Color { get; set; }   
        public string Hex { get; set; }        
    }
}