using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            this.Counties = new HashSet<County>();
            this.Profiles = new HashSet<Profile>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }

        //Ülke ilişki için
        public int CountryId { get; set; }
        public Country Country { get; set; }

        //Bir şehrin birden fazla ilçesi olabilir
        public virtual ICollection<County> Counties { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
