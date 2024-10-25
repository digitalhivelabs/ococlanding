using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class PlaceODTO
    {
        public int PlaceID { get; set; }
        public string DisplayName { get; set;}
        public string URLImage { get; set; }
        public string Distance { get; set; }
        public int NumPoints { get; set; }
    }
}