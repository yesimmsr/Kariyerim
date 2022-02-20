using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    using Entities;
    public class CountryEntityConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryEntityConfiguration()
        {
            this.HasKey(t0 => t0.CountryId);
            this.Property(t0 => t0.CountryName).HasMaxLength(100).IsRequired();
        }
    }
}
