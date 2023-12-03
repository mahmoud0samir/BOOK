using Bookstore.Domain.Abstract;
using Bookstore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace Bookstore.WebUI.Controllers
{
    public class BookController : Controller
    {
        private IBookRepository repositery;
        public int PageSize = 4;
        public BookController(IBookRepository bookRep)

        {
            repositery = bookRep;

        }
        public ViewResult List(string speciliaztion, int Pageno = 1)
        {
            BookListViewModel model = new BookListViewModel { Books = repositery.Books.Where(b => speciliaztion == null || b.specialization == speciliaztion)
                .OrderBy(b => b.ISPN)
                .Skip((Pageno - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new Models.PagingInfo
                {
                    CurrentPage = Pageno,
                    ItemPerPage = PageSize,
                    TotalItems = speciliaztion == null ? repositery.Books.Count() : repositery.Books.Where(b => b.specialization == speciliaztion).Count()
                },
                CurrentSpeciliaztion = speciliaztion
                 };
            return View(model);

        }

        public ViewResult ListAll()
        {
            return View(repositery.Books);
        }

    }
}