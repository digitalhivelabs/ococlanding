using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Category // InterestArea
    { // Category
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public string URLImage { get; set; }
        public int Order { get; set; }
        public bool Main { get; set; }

        // Relationship
        public List<SubCategory> SubCategories { get; set; }
        public List<Item> Items { get; set; }
    }
}