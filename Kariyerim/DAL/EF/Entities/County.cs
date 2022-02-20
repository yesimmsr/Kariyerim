using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public class County : BaseEntity
    {

        public County()
        {
            this.Profiles = new HashSet<Profile>();
        }

        public int CountyId { get; set; }
        public string CountyName { get; set; }


        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ICollection<Profile> Profiles { get; set; }

    }
}
