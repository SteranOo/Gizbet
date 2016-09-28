using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gizbet.DAL.Entities.Identity;

namespace Gizbet.DAL.Entities
{
    public class Lot : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(3000)]
        public string Description { get; set; }

        public string ImageName { get; set; }

        public DateTime TimeOfPosting { get; set; }

        public int HoursDuration { get; set; }

        public decimal InitialPrice { get; set; }

        public decimal Step { get; set; }

        public bool IsSelling { get; set; }
        
        public decimal? SellingPrice { get; set; }

        public bool IsSold { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [ForeignKey("Owner")]
        public int OwnerId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}
