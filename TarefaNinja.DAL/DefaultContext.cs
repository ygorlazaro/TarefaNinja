using Microsoft.EntityFrameworkCore;
using TarefaNinja.DAL.Abstracts;
using TarefaNinja.DAL.Models;

namespace TarefaNinja.DAL;
public class DefaultContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public DbSet<CompanyModel> Companies { get; set; }

    public DbSet<UserCompanyModel> UsersCompanies { get; set; }

    public DbSet<ProjectModel> Projects { get; set; }

    public DbSet<TaskModel> Tasks { get; set; }

    public DbSet<LabelModel> Labels { get; set; }

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        AddSoftDeleteSupport(modelBuilder);

        modelBuilder.Entity<TaskModel>().HasOne(t => t.Assignee)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.AssigneeId)
            .IsRequired(true);

        modelBuilder.Entity<TaskModel>().HasMany(t => t.Followers)
            .WithMany(u => u.Following)
            .UsingEntity(join => join.ToTable("TaskFollowers"));

        base.OnModelCreating(modelBuilder);
    }

    private static void AddSoftDeleteSupport(ModelBuilder modelBuilder)
    {
        var mutableEntityTypes = modelBuilder.Model.GetEntityTypes()
            .Where(entityType => typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType));

        foreach (var entityType in mutableEntityTypes)
        {
            entityType.AddSoftDeleteQueryFilter();
        }
    }
}
