using NHibernate;
using NHibernate.Linq;
using SBlogA.Areas.Admin.ViewModels;
using SBlogA.Infrastructure;
using SBlogA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SBlogA.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]

    public class UsersController : Controller
    {
        // GET: Admin/Users

        [SelectedTabAttiribute("users list")]
        public ActionResult Index()
        {
            return View(new UsersIndex()
            {
                Users = Database.Session.Query<User>().ToList()
            }
                );
        }
        public ActionResult New()
        {
            return View(new UsersNew
            {
            });
        }

        [HttpPost]
        public ActionResult New(UsersNew formData)
        {
            if (Database.Session.Query<User>().Any(x => x.Username == formData.Username))
                ModelState.AddModelError("Username", "Username Must Be Unique");

            if (!ModelState.IsValid)
                return View(formData);

            var user = new User
            {
                Email = formData.Email,
                Username = formData.Username
            };

            user.SetPassword(formData.Password);
            Database.Session.Save(user);

            return RedirectToAction("index");

        }

        public ActionResult Edit(int id)
        {
            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UsersEdit
            {
                Username = user.Username,
                Email = user.Email
            });
        }

        [HttpPost]
        public ActionResult Edit(int id, UsersEdit form)
        {
            //  Database.OpenSession();

            var user = Database.Session.Load<User>(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            if (Database.Session.Query<User>().Any(u => u.Username == form.Username && u.Id != id))
                ModelState.AddModelError("Username", "Username must be unique");
            if (!ModelState.IsValid)
                return View(form);
            user.Username = form.Username;
            user.Email = form.Email;
            //Database.Session.SaveOrUpdate(user);
            Database.Session.Update(user);

            return RedirectToAction("index");



        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var user = Database.Session.Load<User>(id);
            if(user == null)
            {
                return HttpNotFound();

            }
            Database.Session.Delete(user);
            return RedirectToAction("index");

        }
        
    }
}