using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace API.Entities;

public class Unit
{
    [Key]
    public int UnitId { get; set; }
    [MaxLength(150)]
    public string Name { get; set; }
    [MaxLength(50)]
    public string Abbr { get; set; }
    [ForeignKey("Unit")]
    public int? BaseUnitId { get; set; }
    public Unit BaseUnit { get; set; }

    // RelationShips
    public List<Item> Items { get; set; }
    public List<Conversion> ConversionSources { get; set; }
    public List<Conversion> ConversionTargets { get; set; }
    public List<QualityStandardItem> QualityStandardItems { get; set; }
    public List<SpesimenItem> SpesimenItems { get; set; }
    public List<SpesimenItem> SpesimenItemBases { get; set; }
    



}
