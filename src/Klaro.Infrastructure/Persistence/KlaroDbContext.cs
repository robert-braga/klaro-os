using Klaro.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klaro.Infrastructure.Persistence
{
    public class KlaroDbContext : DbContext
    {
        public KlaroDbContext(DbContextOptions<KlaroDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
