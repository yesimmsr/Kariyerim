using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public class Category : BaseEntity
    {

        public Category()
        {
            this.Categories = new HashSet<Category>();
        }

        //sonsuz category tablosu categori tablosu kendi içerisinde bağlanacak

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }
        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        //elekronik - master category
            //bilgisayar 
            //notebook
            //mouse
    }
}
