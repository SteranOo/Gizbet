using System.ComponentModel.DataAnnotations;
using System.Web;
using Gizbet.WEB.Attributes;

namespace Gizbet.WEB.Models
{
    public class LotAddModel
    {
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Необходимо ввести название")]
        [MaxLength(50, ErrorMessage = "Название должно быть не длиннее 50 символов")]
        [MinLength(5, ErrorMessage = "Название должно быть не короче 5 символов")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Необходимо ввести описание")]
        [MaxLength(3000, ErrorMessage = "Описание должно быть не длиннее 3000 символов")]
        [MinLength(10, ErrorMessage = "Описание должно быть не короче 10 символов")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Необходимо выбрать категорию")]
        public int CategoryId { get; set; }

        [DataType(DataType.Upload)]
        [FileSizeValidate(5000000)]
        [FileTypesValidate("jpg,jpeg,png")]
        [Display(Name = "Фото")]
        public HttpPostedFileBase UploadImage { get; set; }
        
        [Display(Name = "Длительность(ч)")]
        [Required(ErrorMessage = "Необходимо ввести длительность аукциона")]
        [Range(12, 72, ErrorMessage = "Допустимая длительность аукциона от 12 до 72 ч.")]
        public int HoursDuration { get; set; }

        [Display(Name = "Стартовая цена")]
        [Required(ErrorMessage = "Необходимо ввести стартовую цену")]
        [Range(1, 10000000, ErrorMessage = "Допустимая сумма от 1 до 10000000 грн.")]
        public decimal InitialPrice { get; set; }

        [Display(Name = "Шаг")]
        [Required(ErrorMessage = "Необходимо ввести шаг аукциона")]
        [Range(1, 1000000, ErrorMessage = "Допустимая сумма от 1 до 1000000 грн.")]
        public decimal Step { get; set; }

        [Display(Name = "Выкуп")]
        public bool IsSelling { get; set; }

        [Display(Name = "Цена выкупа")]
        [Range(1, 10000000, ErrorMessage = "Допустимая сумма от 1 до 10000000 грн.")]
        public decimal? SellingPrice { get; set; }
    }
}