using Bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookstore.WebUI.Models;
using Bookstore.WebUI.HtmlHelper;

namespace Bookstore.WebUI.Models
{
    public class BookListViewModel
    {
        public IEnumerable<Book> Books { set; get; }
        public PagingInfo PagingInfo { set; get; }
        public string CurrentSpeciliaztion { set; get; }
    }
}