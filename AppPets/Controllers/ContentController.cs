using AppPets.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AppPets.Controllers
{
    public class ContentController : Controller
    {
        [Authorize]
        public ActionResult AddArticle()
        {
            if (User.Identity.Name == "admin")
            {
                using (UserContext db = new UserContext())
                {
                    return View();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddArticle(AddArticleModel model)
        {
            if (ModelState.IsValid)
            {
                Article article = null;
                using (ArticleContext db = new ArticleContext())
                {
                    article = db.Articles.FirstOrDefault(u => u.Content == model.Content);
                }
                if (article == null)
                {
                    using (ArticleContext db = new ArticleContext())
                    {
                        db.Articles.Add(new Article
                        {
                            UId = 1,
                            Name = model.Name,
                            Author = model.Author,
                            Date = DateTime.Now,
                            Content = model.Content
                        });
                        db.SaveChanges();

                        article = db.Articles.Where(u => u.Content == model.Content).FirstOrDefault();
                    }
                    if (article != null)
                    {
                        return RedirectToAction("ShowArticle", "Content");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Такая статья уже существует!");
                }
            }

            return View(model);
        }

        public ActionResult ShowArticle()
        {
            using (ArticleContext db = new ArticleContext())
            {
                return View(db.Articles.ToList());
            }
        }
        public ActionResult ViewArticle(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (ArticleContext db = new ArticleContext())
            {
                Article article = db.Articles.Find(id);
                if (article != null)
                {
                    return View(article);
                }
                return HttpNotFound();
            }
        }

        [Authorize]
        public ActionResult Place()
        {
            if (User.Identity.Name == "admin")
            {
                using (UserContext db = new UserContext())
                {
                    return View();
                }
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Place(PlaceModel model)
        {
            if (ModelState.IsValid)
            {
                Place place = null;
                using (PlaceContext db = new PlaceContext())
                {
                    place = db.Places.FirstOrDefault(u => u.Email == model.Email);
                }
                if (place == null)
                {
                    using (PlaceContext db = new PlaceContext())
                    {
                        db.Places.Add(new Place
                        {
                            PlaceName = model.PlaceName,
                            Website = model.Website,
                            Email = model.Email,
                            TypeOfPlace = model.TypeOfPlace,
                            PhoneNumber = model.PhoneNumber
                        });
                        db.SaveChanges();

                        place = db.Places.Where(u => u.Email == model.Email).FirstOrDefault();
                    }
                    if (place != null)
                    {
                        return RedirectToAction("Place", "Content");
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {

            using (PlaceContext db = new PlaceContext())
            {
                Place places = null;
                if (!string.IsNullOrEmpty(searchString))
                {
                    places = db.Places.Find(searchString);
                }

                return View(places);
            }
        }
    }
}