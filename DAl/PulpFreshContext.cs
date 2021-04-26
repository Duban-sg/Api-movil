using System;
using Entidad;
using Microsoft.EntityFrameworkCore;

namespace DAl
{
    public class PulpFreshContext: DbContext
    {

        public PulpFreshContext(DbContextOptions Options):base(Options){
            
        }

        public DbSet<Product> Products{get;set;}
        public DbSet<Presentation> Presentations{get;set;}
        public DbSet<Category> Categories{get;set;}
        public DbSet<Person> Persons{get;set;}
        public DbSet<Client> Clients{get;set;}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Client>()
            .HasOne(p=>p.Person)
            .WithOne(b=>b.Client)
            .HasForeignKey<Client>(p => p.Identificacion);


            modelBuilder.Entity<Product>()
            .HasMany(p=>p.Presentations)
            .WithMany(p=>p.Products)
            .UsingEntity(j => j.ToTable("ProductPresentations"));


        }

    }
}
