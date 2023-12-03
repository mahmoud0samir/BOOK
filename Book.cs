using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bookstore.Domain.Entities
{
   public class Book
    {
        [Key]
        public int ISPN { set; get; }
        [Required]
        public string Title { set; get; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { set; get; }
        [Required]
        public decimal Price { set; get; }
        [Required]
        public string specialization { set; get; }
    }
}
