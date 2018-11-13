using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AngularDemoF18.Models
{
    public class AngularDemoF18Context : IdentityDbContext<User>
    {
        public AngularDemoF18Context (DbContextOptions<AngularDemoF18Context> options)
            : base(options)
        {
        }

        public DbSet<AngularDemoF18.Models.Product> Product { get; set; }
    }
}
