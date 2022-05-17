using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevProjeto.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevProjeto.API.Persistence
{
    public class devProjContext : DbContext
    {
        public devProjContext(DbContextOptions<devProjContext> options):base (options) {
        }
        public DbSet<Packege> Packeges { get; set; }
        public DbSet<PackegeUpdate> PackegeUpdates { get; set;}

        protected override void OnModelCreating(ModelBuilder builer) {
            builer.Entity<Packege>(e => {

                e.HasKey(p => p.Id);

                e.HasMany(p => p.Updates)
                .WithOne()
                .HasForeignKey(pu => pu.PackegeId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            builer.Entity<PackegeUpdate>(e => {
                e.HasKey(p => p.Id);

            });

        }
        
        
    }
}