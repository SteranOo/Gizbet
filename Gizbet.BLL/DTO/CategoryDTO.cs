using System.Collections.Generic;

namespace Gizbet.BLL.DTO
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<LotDTO> Lots { get; set; }
    }
}
