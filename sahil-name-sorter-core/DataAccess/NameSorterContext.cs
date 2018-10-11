using Microsoft.EntityFrameworkCore;
using SahilNameSorterCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SahilNameSorterCore.DataAccess
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
