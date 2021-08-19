using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Data.Entities;

namespace Task.Data
{
    public class TaskContext : DbContext
    {
        private readonly IConfiguration _config;

        public TaskContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet <Organisation> Organisations{ get; set; }
        public DbSet <BookingOrganisation> BookingOrganisations{ get; set; }
        public DbSet <ItemSupplier> ItemSuppliers{ get; set; }
        public DbSet <OrganisationNumber> OrganisationNumbers { get; set; }
        public DbSet <ContactRelationship> ContactRelationships{ get; set; }
        public DbSet <OrganisationRelationship> OrganisationRelationships{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:TaskContextDb"]);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<OrganisationNumber>()
            //    .HasOne(b => b.Organisation).WithMany(ba => ba.OrganisationNumbers)
            //    .HasForeignKey(k => k.OrganisationNumberID);
           
        }
    }
}
