using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Conversion
    {
        public int Id { get; set; }
        
        public Unit SourceUnit { get; set; }
        public Unit TargetUnit { get; set; }
        [MaxLength(250)]
        public string Operator { get; set; }
        public float Factor { get; set; }
        public string Formula { get; set; }

        // RelationShip
        public int SourceUnitId { get; set; }
        public int TargetUnitId { get; set; }

    }
}