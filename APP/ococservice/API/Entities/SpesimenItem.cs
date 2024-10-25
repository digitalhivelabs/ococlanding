using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class SpesimenItem
    {
        [Key]
        public int SIId { get; set; }
        public Spesimen Spesimen { get; set; }
        public Item Item { get; set; }
        public Unit Unit { get; set; }
        public float Value { get; set; }
        public Unit UnitBase { get; set; }
        public float ValueBase { get; set; }
        [MaxLength(50)]
        public float DisplayValue { get; set; }
        [MaxLength(150)]
        public string Method { get; set; }
        [MaxLength(150)]
        public string LabName { get; set; }
        [MaxLength(150)]
        public string Responsible { get; set; }   
        public bool Preferent { get; set; }
        [MaxLength(350)]
        public string Notes { get; set; }

        // RelationShip
        public int SpesimenId { get; set; }
        public int ItemId { get; set; }
        public int UnitId { get; set; }
        public int UnitBaseId { get; set; }

    }
}