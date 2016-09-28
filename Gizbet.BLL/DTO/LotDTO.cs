using System;
using System.Collections.Generic;

namespace Gizbet.BLL.DTO
{
    public class LotDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Description { get; set; }

        public string ImageName { get; set; }
      
        public DateTime TimeOfPosting { get; set; }

        public int HoursDuration { get; set; }

        public decimal InitialPrice { get; set; }

        public bool IsSelling { get; set; }

        public decimal? SellingPrice { get; set; }     

        public decimal Step { get; set; }

        public bool IsSold { get; set; }

        public int CategoryId { get; set; }

        public int OwnerId { get; set; }

        public CategoryDTO Category { get; set; }

        public ApplicationUserDTO Owner { get; set; }

        public BidDTO TopBid { get; set; }

        public ICollection<BidDTO> Bids { get; set; }
    }
}
