using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class State
    {
        [Key]
        public int StateId { get; set; }  
        [MaxLength(50)]  
        public string Name { get; set; }
        // https://es.wikipedia.org/wiki/Anexo:Abreviaciones_de_los_estados_de_Estados_Unidos
        [MaxLength(15)]
        public string Abbr { get; set; }
        public Country Country { get; set; }

        // RelationShip
        public int CountryId { get; set; }
    }
}