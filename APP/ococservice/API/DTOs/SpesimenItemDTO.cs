using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SpesimenItemDTO
    {
        public int SIId { get; set; }
        public string ItemName { get; set; }
        public string ItemAbbr { get; set; }
        public string UnitName { get; set; }
        public string UnitAbbr { get; set; }
        public float Value { get; set; }
        public string UnitBaseName { get; set; }
        public float ValueBase { get; set; }
        public string Method { get; set; }
        public string LabName { get; set; }
        public string Responsible { get; set; }   
        public bool Preferent { get; set; }
        public string Notes { get; set; }

    }
}