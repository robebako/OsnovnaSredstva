using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using OsnovnaSredstva.Models;

namespace OsnovnaSredstva.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OsnSredstvo>(entity => {
                entity.HasIndex(o => o.InventurniBroj).IsUnique();
            });
        }

        public DbSet<OsnovnaSredstva.Models.Grupa> Grupa { get; set; }
        public DbSet<OsnovnaSredstva.Models.OsnSredstvo> OsnSredstvo { get; set; }
    }
}
