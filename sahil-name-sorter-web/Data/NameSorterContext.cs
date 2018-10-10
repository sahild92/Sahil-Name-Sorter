using Microsoft.EntityFrameworkCore;
using sahilNameSorterWeb.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sahilNameSorterWeb.Data
{
    public class NameSorterContext : DbContext
    {
        public NameSorterContext(DbContextOptions<NameSorterContext> options): base(options)
        {

        }
        public DbSet<PersonFullNames> PersonFullNames { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonFullNames>()
                .HasData(new PersonFullNames()
                {
                    ID = 1,
                    FirstName = "Sahil",
                    LastName = "Deshpande"
                });
        }
    }
}
