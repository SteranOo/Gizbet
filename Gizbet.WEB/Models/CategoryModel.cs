using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.WEB.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Необходимо ввести название")]
        [MaxLength(50, ErrorMessage = "Название должно быть не длиннее 50 символов")]
        [MinLength(3, ErrorMessage = "Название должно быть не короче 3 символов")]
        public string Name { get; set; }

        public ICollection<LotPublicModel> Lots { get; set; }
    }
}