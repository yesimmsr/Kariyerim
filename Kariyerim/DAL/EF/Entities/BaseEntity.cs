using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DAL.EF.Entities
{
    public abstract class BaseEntity 
    {
        public DateTime? RecordDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
