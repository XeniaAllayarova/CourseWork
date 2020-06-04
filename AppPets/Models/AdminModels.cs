using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppPets.Models
{
    public class AllUsersModel
    {
        public int Id { get; set; }
        [Display(Name ="Имя")]
        public string Name { get; set; }
        public string Email { get; set; }
        [Display(Name = "Роль")]
        public string Status { get; set; }
    }
}