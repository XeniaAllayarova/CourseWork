using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPets.Models
{
    public class AddArticleModel
    {
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Содержание")]
        public string Content { get; set; }
    }

    public class ShowArticleModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
    }

    public class PlaceModel
    {
        [Required]
        [Display(Name = "Название")]
        public string PlaceName { get; set; }

        [Display(Name = "Сайт")]
        public string Website { get; set; }

        [Required]
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Вид заведения")]
        public string TypeOfPlace { get; set; }

        [Required]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }
}