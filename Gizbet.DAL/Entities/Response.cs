using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Gizbet.DAL.Entities.Identity;

namespace Gizbet.DAL.Entities
{
    public class Response : BaseEntity
    {
        public bool IsPositive { get; set; }

        [StringLength(500)]
        public string Text { get; set; }

        public DateTime ResponseDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [ForeignKey("Recipient")]
        public int RecipientId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}
