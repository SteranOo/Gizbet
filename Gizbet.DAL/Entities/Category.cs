using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.DAL.Entities
{
    public class Category : BaseEntity
    {
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Lot> Lots { get; set; }
    }
}
