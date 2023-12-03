using Bookstore.WebUI.infrastructure.Abstract;
using Bookstore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        public AccountController(IAuthProvider auth)
        {
            authProvider = auth;
        }

        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model,string returnUrl )
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.Username, model.Paassword))
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                else
                {
                    ModelState.AddModelError("", "Correct Username or Password");
                    return View();
                }
            }
            else
                return View();
        }
    }
}