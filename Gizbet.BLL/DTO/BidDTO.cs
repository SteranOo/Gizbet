using System;

namespace Gizbet.BLL.DTO
{
    public class BidDTO
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime TimeOfBid { get; set; }

        public int ApplicationUserId { get; set; }

        public int LotId { get; set; }

        public ApplicationUserDTO ApplicationUser { get; set; }

        public LotDTO Lot { get; set; }
    }
}
