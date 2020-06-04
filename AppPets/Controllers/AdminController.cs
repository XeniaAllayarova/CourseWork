using AppPets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppPets.Controllers
{
    public class AdminController : Controller
    { 
        [Authorize]
        public ActionResult AllUsers()
        {
            if (User.Identity.Name == "admin")
            {
                using (UserContext db = new UserContext())
                {
                    return View(db.Users.ToList());
                }
            }
            else
            {
                return HttpNotFound();
            }                 
        }

        [HttpGet]
        [Authorize]
        public ActionResult Block(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            using (UserContext db = new UserContext())
            {
                User user = db.Users.Find(id);
                if (user != null)
                {
                    return View(user);
                }
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult Block(User user)
        {
            using (UserContext db = new UserContext())
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("AllUsers");
        }

    }
}