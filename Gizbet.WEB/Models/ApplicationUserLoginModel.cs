using System.ComponentModel.DataAnnotations;
namespace Gizbet.WEB.Models
{
    public class ApplicationUserLoginModel
    {
        public int Id { get; set; }

        [Display(Name = "Логин")]
        [Required(ErrorMessage = "Необходимо ввести имя пользователя")]
        public string UserName { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Необходимо ввести пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}