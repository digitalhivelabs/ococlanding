using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SpesimenI2DTO
    {
        [Required]
        public int PointId { get; set; }
        [Required]
        public DateTime SpesimenDate { get; set; }
        public string Notes { get; set; }
        
        [Required]
        public List<SpesimenItemI2DTO> Items { get; set; }
    }
}