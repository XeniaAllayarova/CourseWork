using AppPets.Models;
using System;
using System.Data.Entity;

namespace AppPets.Models
{

    public class Article
    {
        public int UId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }

    public class ArticleContext : DbContext
    {
        public ArticleContext() :
            base("DefaultConnection")
        { }

        public DbSet<Article> Articles { get; set; }
    }

}