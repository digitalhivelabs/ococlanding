using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities;

public class Item
{
    [Key]
    public int itemId { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Abbr { get; set; }    
    public Unit Unit { get; set; }
    public ClassificationItem Classification { get; set; }    
    public string MoreInfo { get; set; }
    public Category Category { get; set; }

    // RelationShip
    public int UnitId { get; set; }
    public int CategoryId { get; set; }
    public int? ClassificationItemId { get; set; }
    public List<QualityStandardItem> QualityStandardItems { get; set; }
    public List<SpesimenItem> SpesimenItems { get; set; }

}
