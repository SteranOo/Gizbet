using System;
using System.ComponentModel.DataAnnotations.Schema;
using Gizbet.DAL.Entities.Identity;

namespace Gizbet.DAL.Entities
{
    public class Bid : BaseEntity
    {
        public decimal Amount { get; set; }

        public DateTime TimeOfBid { get; set; }
    
        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }

        [ForeignKey("Lot")]
        public int LotId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Lot Lot { get; set; }
    }
}
