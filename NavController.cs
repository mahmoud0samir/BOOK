using Bookstore.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IBookRepository repository;
        public NavController(IBookRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string Specialization= null)
        {
            ViewBag.SelectedSpec = Specialization;
            IEnumerable<string> spec = repository.Books.Select(b => b.specialization).Distinct();
            return PartialView(spec);
        }
    }
}