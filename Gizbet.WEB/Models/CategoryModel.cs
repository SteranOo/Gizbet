using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.WEB.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public ICollection<LotPublicModel> Lots { get; set; }
    }
}