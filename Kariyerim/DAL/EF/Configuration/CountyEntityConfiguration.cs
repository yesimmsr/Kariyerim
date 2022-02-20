using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Configuration
{
    using Entities;
    public class CountyEntityConfiguration : EntityTypeConfiguration<County>
    {
        public CountyEntityConfiguration()
        {
            this.HasKey(t0 => t0.CountyId);
            this.Property(t0 => t0.CountyName).HasMaxLength(100).IsRequired();
            this.HasRequired(t0 => t0.City).WithMany(t1 => t1.Counties).HasForeignKey(t2 => t2.CityId);
        }
    }
}
