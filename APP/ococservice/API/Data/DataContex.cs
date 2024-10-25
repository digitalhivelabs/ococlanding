using API.Entities;
using API.StoreProcedureReturn;
using Microsoft.EntityFrameworkCore;
using Semaphore = API.Entities.Semaphore;

namespace API.Data;

public class DataContex : DbContext
{
    public DataContex(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SpesimenItem>()
            .HasOne(x => x.Unit) // Atributo tipo Unidad dentro de SurveyItem
            .WithMany(x => x.SpesimenItems) // Atributo tipo SurveyItem dentro de Unit
            .HasForeignKey(x => x.UnitId) // Atributo tipo Int dentro de SurveyItem
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SpesimenItem>()
            .HasOne(x => x.UnitBase) // Atributo tipo Unidad dentro de SurveyItem
            .WithMany(x => x.SpesimenItemBases) // Atributo tipo SurveyItem dentro de Unit
            .HasForeignKey(x => x.UnitBaseId) // Atributo tipo Int dentro de SurveyItem
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Conversion>()
            .HasOne(x => x.SourceUnit) // Atributo tipo Unidad dentro de Conversion
            .WithMany(x => x.ConversionSources) // Atributo tipo Conversion dentro de Unit
            .HasForeignKey(x => x.SourceUnitId) // Atributo tipo Int dentro de Conversion
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Conversion>()
            .HasOne(x => x.TargetUnit) // Atributo tipo Unidad dentro de Conversion
            .WithMany(x => x.ConversionTargets) // Atributo tipo Conversion dentro de Unit
            .HasForeignKey(x => x.TargetUnitId) // Atributo tipo Int dentro de Conversion
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Documento>()
            .HasOne(x => x.UserUploader) // Atributo tipo FK dentro de "Entity"
            .WithMany(x => x.Documents) // Atributo tipo "Entity" dentro de tabla FK
            .HasForeignKey(x => x.UserUploaderId) // Atributo tipo Int dentro de "Entity"
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QualityStandardItem>()
            .HasOne(x => x.QualityStandard) // Atributo tipo FK dentro de "Entity"
            .WithMany(x => x.QualityStandardItems) // Atributo tipo "Entity" dentro de tabla FK
            .HasForeignKey(x => x.QSId) // Atributo tipo Int dentro de "Entity"
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<QualityStandardItemRange>()
            .HasOne(x => x.QualityStandardItem) // Atributo tipo FK dentro de "Entity"
            .WithMany(x => x.QualityStandardItemRanges) // Atributo tipo "Entity" dentro de tabla FK
            .HasForeignKey(x => x.QSIId) // Atributo tipo Int dentro de "Entity"
            .OnDelete(DeleteBehavior.Restrict);

        /*
        modelBuilder.Entity<Documento>()
            .HasOne(x => x.UserMDate) // Atributo tipo FK dentro de "Entity"
            .WithMany(x => x.DocumentUpdates) // Atributo tipo "Entity" dentro de tabla FK
            .HasForeignKey(x => x.UserMDateId) // Atributo tipo Int dentro de "Entity"
            .OnDelete(DeleteBehavior.Restrict);*/
        

    }

    public DbSet<User> Users { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Conversion> Conversions { get; set; }
    public DbSet<ClassificationItem> ClassificationItems { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<QualityStandard> QualityStandards { get; set; }
    public DbSet<QualityStandardItem> QualityStandardItems { get; set; }
    public DbSet<QualityStandardItemRange> QualityStandardItemRanges { get; set; }
    public DbSet<Semaphore> Semaphores { get; set; }
    
    public DbSet<Spesimen> Spesimens { get; set; }
    public DbSet<SpesimenItem> SpesimenItems { get; set; }

    public DbSet<Documento> Documentos { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<State> States { get; set; }
    public DbSet<Place> Places { get; set; }
    public DbSet<Point> Points { get; set; }

    // Store Pocerures
    public DbSet<GetSubCategoriesAndPointsSPR> SP_SubCategoriesAndPoints { get; set; }
    public DbSet<GetSpesimensByPointIdSPR> SP_SpesimensByPointIdSPR { get; set; }

}
