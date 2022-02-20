using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Configuration
{
    using Entities;
    public class ProfileEntityConfiguration : EntityTypeConfiguration<Profile>
    {
        public ProfileEntityConfiguration()
        {
            this.HasKey(t0 => t0.ProfileId);
            this.Property(t0 => t0.FirstName).HasMaxLength(255).IsRequired();
            this.Property(t0 => t0.LastName).HasMaxLength(255).IsRequired();
            this.Property(t0 => t0.Title).HasMaxLength(100);

            this.HasOptional(t0 => t0.Country).WithMany(t0 => t0.Profiles).HasForeignKey(t0 => t0.CountryId);
            this.HasOptional(t0 => t0.City).WithMany(t0 => t0.Profiles).HasForeignKey(t0 => t0.CityId);
            this.HasOptional(t0 => t0.County).WithMany(t0 => t0.Profiles).HasForeignKey(t0 => t0.CountyId);
        }
    }
}
