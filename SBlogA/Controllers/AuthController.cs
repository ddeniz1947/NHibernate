using SBlogA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SBlogA.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(AuthLogin formData,string returnUrl)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }


            FormsAuthentication.SetAuthCookie(formData.Username, true);


            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToRoute("Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }
    }
}