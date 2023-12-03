using Bookstore.Domain.Abstract;
using Bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebUI.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IBookRepository repository;

        public AdminController(IBookRepository repo)
        {
            repository = repo;
        }
        public ViewResult Index()
        {
            return View(repository.Books);
        }

        public ViewResult Edit(int ISPN)
        {
            Book book = repository.Books.FirstOrDefault(b => b.ISPN == ISPN);
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                repository.SaveBook(book);
                TempData["message"] = book.Title + " has been Saved";
                return RedirectToAction("Index");
            }
            else
            {
                return View(book);
            }
        }
    }
}