using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Context
{
    using Entities;
    using Configuration;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class CarrierContext : DbContext
    {
        public CarrierContext() : base("DB")
        {

        }

        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<County> County { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<Category> Category { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //table isimlerinde s takısını kaldırır.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CountryEntityConfiguration());
            modelBuilder.Configurations.Add(new CityEntityConfiguration());
            modelBuilder.Configurations.Add(new CountyEntityConfiguration());
            modelBuilder.Configurations.Add(new ProfileEntityConfiguration());
            modelBuilder.Configurations.Add(new CategoryEntityConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
