using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Configuration
{
    using Entities;
    using Configuration;
    public class CategoryEntityConfiguration : EntityTypeConfiguration<Category>
    {
        public CategoryEntityConfiguration()
        {
            this.HasKey(t0 => t0.CategoryId);
            this.Property(t0 => t0.CategoryName).HasMaxLength(100).IsRequired();
            this.HasOptional(t0 => t0.ParentCategory).WithMany(t0 => t0.Categories).HasForeignKey(t0 => t0.ParentCategoryId);
        }

    }
}
