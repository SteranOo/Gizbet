using System.ComponentModel.DataAnnotations;

namespace Gizbet.DAL.Entities.Abstract
{
    public abstract class Entity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
