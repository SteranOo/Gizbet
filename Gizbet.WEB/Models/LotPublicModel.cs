using System;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.WEB.Models
{
    public class LotPublicModel
    {
        public int Id { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        public CategoryModel Category { get; set; }

        [Display(Name = "Фото")]
        public string ImageName { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Опубликовано")]
        public DateTime TimeOfPosting { get; set; }

        [Display(Name = "Длительность(ч)")]
        public int HoursDuration { get; set; }

        [Display(Name = "Стартовая цена")]
        public decimal InitialPrice { get; set; }
      
        [Display(Name = "Шаг")]
        public decimal Step { get; set; }

        [Display(Name = "Выкуп")]
        public bool IsSelling { get; set; }

        [Display(Name = "Цена выкупа")]
        public decimal? SellingPrice { get; set; }

        [Display(Name = "Продано")]
        public bool IsSold { get; set; }

        [Display(Name = "Владелец")]
        public ApplicationUserPublicModel Owner { get; set; }

        [Display(Name = "Последняя ставка")]
        public BidModel TopBid { get; set; }
    }
}