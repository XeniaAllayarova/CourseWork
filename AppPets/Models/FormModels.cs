using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppPets.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name ="Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Город")]
        public string City { get; set; }

        [Display(Name = "Домашнее животное")]
        public string Pet { get; set; }

        [Display(Name = "Имя питомца")]
        public string PetName { get; set; }

        [Required]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Повторить пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }    
}