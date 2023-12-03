using Bookstore.Domain.Abstract;
using Bookstore.Domain.Entities;
using Bookstore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookstore.WebUI.Controllers
{
    public class CartControllerController : Controller
    {
        private IBookRepository repository;
        private IOrderProcessor orderProcessor;

        public CartControllerController(IBookRepository repo,IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int ISPN, string returnUrl)
        {
            Book book =repository.Books.FirstOrDefault(b => b.ISPN == ISPN);
            if(book != null)
            {
                cart.AddItem(book);
            }
            return RedirectToAction("Index", new { returnUrl });//Index
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int ISPN, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.ISPN == ISPN);
            if (book != null)
            {
                cart.RemoveLine(book);
            }
            return RedirectToAction("Index", new{ returnUrl});//Index
        }

        public PartialViewResult Summury(Cart cart)
        {
            return PartialView(cart);
        }


        public ViewResult Checkout()
        {
            return View(new ShoppingDetails());
        }
        [HttpPost]
        public ViewResult Checkout(Cart cart ,ShoppingDetails shoppingDetails)
        {
            if (cart.Lines.Count() == 0)
                ModelState.AddModelError("","Sorry Your Cart is Empty");
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shoppingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shoppingDetails);
            }
        }
     
    }
}