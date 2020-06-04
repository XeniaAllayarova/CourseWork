using System.Collections.Generic;
using System.Data.Entity;

namespace AppPets.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Pet { get; set; }
        public string PetName { get; set; }
        public string Status { get; set; }
    }
    public class UserContext : DbContext
    {
        public UserContext() :
            base("DefaultConnection")
        { }

        public DbSet<User> Users { get; set; }
    }
}