using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schoolmanagment.Entities;

namespace Schoolmanagment.Date;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public RoleConfiguration(IServiceProvider _serviceProvider) => this.Services = _serviceProvider;
    public IServiceProvider Services { get; set; }
    public void Configure(EntityTypeBuilder<IdentityRole> modelBuilder)
    {
        var roleManager = Services.GetRequiredService<RoleManager<IdentityRole>>();
        var roles = Enum.GetNames<ERole>().Select(x => new IdentityRole(x.ToUpper()) { NormalizedName = roleManager.NormalizeKey(x.ToUpper()) });
        modelBuilder.HasData(roles);
    }
}