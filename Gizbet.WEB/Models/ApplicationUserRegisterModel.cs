using System;
using System.ComponentModel.DataAnnotations;
using Gizbet.WEB.Attributes;

namespace Gizbet.WEB.Models
{
    public class ApplicationUserRegisterModel
    {
        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Необходимо ввести логин")]
        [MaxLength(30, ErrorMessage = "Логин должен быть не длиннее 30 символов")]
        [MinLength(3, ErrorMessage = "Логин должен быть не короче 3 символов")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [MinLength(6, ErrorMessage = "Пароль должен быть не короче 6 символов")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Повторите пароль")]
        [Required(ErrorMessage = "Необходимо повторить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Необходимо ввести email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email имеет неверный формат")]
        public string Email { get; set; }

        [Display(Name = "Имя")]
        [MaxLength(30, ErrorMessage = "Имя должно быть не длиннее 30 символов")]
        [Required(ErrorMessage = "Необходимо ввести имя")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [MaxLength(30, ErrorMessage = "Фамилия должна быть не длиннее 30 символов")]
        [Required(ErrorMessage = "Необходимо ввести фамилию")]
        public string LastName { get; set; }

        [Display(Name = "Отчество")]
        [MaxLength(30, ErrorMessage = "Отчество должно быть не длиннее 30 символов")]
        [Required(ErrorMessage = "Необходимо ввести отчество")]
        public string Patronymic { get; set; }

        [Display(Name = "Дата рождения")]
        [Required(ErrorMessage = "Необходимо ввести дату рождения")]
        [DataType(DataType.Date)]
        [DateRangeValidate(ErrorMessage = "Некорректная дата рождения")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Необходимо ввести номер телефона")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Номер телефона имеет неверный формат")]
        public string PhoneNumber { get; set; }
    }
}