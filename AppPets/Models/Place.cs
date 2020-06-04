using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AppPets.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string PlaceName { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string TypeOfPlace { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class PlaceContext : DbContext
    {
        public PlaceContext() :
            base("DefaultConnection")
        { }

        public DbSet<Place> Places { get; set; }
    }
}