using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PointDTO
    {
        public int PointId { get; set; }
        public string Name { get; set; }
        // De Norte-Sur (Gajos) (verticales)
        public float Lat { get; set; }
        // De Este-Oeste (Rodajas) (horizontales)
        public float Lon { get; set; }
        public string Code { get; set; }

    }
}