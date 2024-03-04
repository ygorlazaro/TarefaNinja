using Microsoft.EntityFrameworkCore;

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
        modelBuilder.Entity<TaskModel>().HasOne(t => t.Assignee)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.AssigneeId)
            .IsRequired(true);

        modelBuilder.Entity<TaskModel>().HasMany(t => t.Followers)
            .WithMany(u => u.Following)
            .UsingEntity(join => join.ToTable("TaskFollowers"));

        base.OnModelCreating(modelBuilder);
    }
}
