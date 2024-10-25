using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SpesimenDashboardDTO
    {
        public string SpecimenDate { get; set; }
        public string Laboratory { get; set; }
        public string Point { get; set; }
        public string Place { get; set; }
        public string Parameter { get; set; }
        public float value { get; set; }
        public string displayValue { get; set; }
        public string Tendency { get; set; }
        public string TendencyIcon { get; set; }

        /*specimenDate": "12/28/2023",
      "laboratory": "PFEA",
      "point": "Cañada Azteca",
 "place": "Tijuana",
      "parameter": "Enterococo",
      "value": 1081,
 "displayValue": "> 1081"
      "tendency": "+ 1500",
      "tendencyIcon":*/
    }
}