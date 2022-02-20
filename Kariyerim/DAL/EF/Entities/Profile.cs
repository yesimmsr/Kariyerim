using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public class Profile : BaseEntity
    {
        
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Gender { get; set; }
        public string Title { get; set; }

        //public string Country { get; set; }
        //public string City { get; set; }
        //public string County { get; set; }

        public int? CountryId { get; set; }
        public Country Country { get; set; }

        public int? CityId { get; set; }
        public City City{ get; set; }
        public int? CountyId { get; set; }
        public County County { get; set; }
    }
}
