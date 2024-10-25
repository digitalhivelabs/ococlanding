using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SpesimenItemI2DTO
    {
        [Required]
        public int ItemId { get; set; }
        [Required]
        public int UnitId { get; set; }
        [Required]
        public float Value { get; set; }
        public string Method { get; set; }
        public string LabName { get; set; }
        public string Responsible { get; set; }   
        public bool Preferent { get; set; }
        public string Notes { get; set; }

    }
}