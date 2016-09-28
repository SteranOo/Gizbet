using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Gizbet.WEB.Models
{
    public class ApplicationUserPublicModel
    {
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Display(Name = "Телефон")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<LotPublicModel> Lots { get; set; }
    }
}