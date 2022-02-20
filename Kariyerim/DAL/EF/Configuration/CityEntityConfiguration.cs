using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Configuration
{
    using Entities;
    using System.Data.Entity.ModelConfiguration;

    public class CityEntityConfiguration : EntityTypeConfiguration<City>
    {
        public CityEntityConfiguration()
        {
            this.HasKey(t0 => t0.CityId);
            this.Property(t0 => t0.CityName).HasMaxLength(100).IsRequired();

            //Bire çok bir ilişki
            this.HasRequired(t0 => t0.Country).WithMany(t0 => t0.Cities).HasForeignKey(t2 => t2.CountryId);
        }
    }
}
