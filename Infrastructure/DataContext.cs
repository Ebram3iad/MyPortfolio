using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
   public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            :base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //THIS is for the Id which that is a Guid prop and the "NEWID()" to make it Identity. It is a Fun SQL.
            modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            
            //DataSeed that is mean putting initial values in database during the creation .
            modelBuilder.Entity<Owner>().HasData(
                new Owner()
                {
                    Id = Guid.NewGuid(),
                    Avatar ="avatar.jpg",
                    FullName = "Ebram Farag",
                    ProfileTitle = ".Net Full Stack Developer"
                }
                ) ;

        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<PortfolioItem> PortfolioItems { get; set; }

    }
}
