using System.ComponentModel.DataAnnotations;

namespace API.Entities;

public class ClassificationItem
{
    public int Id { get; set; }
    [MaxLength(100)]
    public string Name { get; set; }    
    [MaxLength(50)]
    public string Abbr { get; set; }

    public List<Item> Items { get; set; }

}
