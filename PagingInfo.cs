using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bookstore.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { set; get; }
        public int ItemPerPage { set; get; }
        public int CurrentPage { set; get; }
        public int TotalPages {
            get { return (int)Math.Ceiling ((decimal)TotalItems / ItemPerPage); }
        }
    }
}