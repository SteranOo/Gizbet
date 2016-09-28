using System.Data.Entity;
using Gizbet.DAL.Entities;
using Gizbet.DAL.Entities.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Gizbet.DAL.EF
{
    internal class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {
        public ApplicationDbContext() : base("GizbetDbContext")
        {
        }

        public ApplicationDbContext(string conectionString) : base(conectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Response>()
                    .HasRequired(m => m.Author)
                    .WithMany(t => t.SentResponses)
                    .HasForeignKey(m => m.AuthorId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Response>()
                        .HasRequired(m => m.Recipient)
                        .WithMany(t => t.ReceivedResponses)
                        .HasForeignKey(m => m.RecipientId)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Lot>()
                       .HasRequired(m => m.Owner)
                       .WithMany(t => t.Lots)
                       .HasForeignKey(m => m.OwnerId)
                       .WillCascadeOnDelete(false);
        }

        public DbSet<Bid> Bids { get; set; }
        public DbSet<Lot> Lots { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Response> Responses { get; set; }
    }
}
