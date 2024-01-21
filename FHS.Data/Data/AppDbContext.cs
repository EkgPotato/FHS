using FHS.Entities.Dto;
using FHS.Entities.Dto.Dict;
using FHS.Entities.Dto.Features;
using Microsoft.EntityFrameworkCore;

namespace DataService.Data;

public class AppDbContext : DbContext
{
    public AppDbContext() 
    {
         

    }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false; 
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    public virtual DbSet<DictExpenseCategory> DictExpenseCategories { get; set; }

    public virtual DbSet<DictIncomeCategory> DictIncomeCategories { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasOne(e => e.DictIncomeCategory)
                .WithMany(p => p.Incomes)
                .HasForeignKey(d => d.DictIncomeCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"PK_{nameof(Income)}_{nameof(DictIncomeCategory)}");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasOne(e => e.DictExpenseCategory)
                .WithMany(p => p.Expenses)
                .HasForeignKey(d => d.DictExpenseCategoryId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"PK_{nameof(Expense)}_{nameof(DictExpenseCategory)}");
        });
    }
}