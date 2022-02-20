using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
            this.Profiles = new HashSet<Profile>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; }

        //Navigation property -- virtua yapma nedeni katılım alan nesneler ezebilsin
        public virtual ICollection<City> Cities { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

    }
}
