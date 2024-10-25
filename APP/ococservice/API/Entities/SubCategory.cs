using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public Category Category { get; set; }

        // RelationShip
        public int CategoryId { get; set; }
        public List<Place> Places { get; set; }
    }
}