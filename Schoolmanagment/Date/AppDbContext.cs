using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Date;
public class AppDbContext : IdentityDbContext<User>
{
    private IServiceProvider _serviceProvider;
    public AppDbContext(DbContextOptions<AppDbContext> options, IServiceProvider _serviceProvider) : base(options)
    {
        this.Service = _serviceProvider;
    }
    public IServiceProvider Service { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Student> Students { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration<IdentityRole>(new RoleConfiguration(Service));
    }
}
