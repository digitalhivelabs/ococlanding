using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }
        /// <summary>
        /// ISO 3166-1 alfa3 
        /// https://www.datosmundial.com/codigos-de-pais.php        
        /// </summary>        
        [MaxLength(3)]
        public string CountryCode { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Abbr { get; set; }

        // RelationShip
        public List<State> States { get; set; }
    }
}