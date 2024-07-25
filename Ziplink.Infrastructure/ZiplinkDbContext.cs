using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zipllink.Core.Entities;

namespace Ziplink.Infrastructure;
public class ZiplinkDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ZiplinkDbContext(DbContextOptions<ZiplinkDbContext> options):base(options)
    {
            
    }
    public Microsoft.EntityFrameworkCore.DbSet<EntityUrl> entityUrl { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

}
