using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.StoreProcedureReturn
{
    [Keyless]
    public class GetSpesimensByPointIdSPR
    {
        public string LabName { get; set; }
        public string Method { get; set; }
        public string ItemName { get; set; }
        public string UnitName { get; set; }
        public string Value { get; set; }
        public string UnitAbbr { get; set; }   
        public string QS_Notes { get; set; }
        public string QS_Name { get; set; }
        public string QS_Color { get; set; }
        public string QS_Hex { get; set; }
        
    }
}