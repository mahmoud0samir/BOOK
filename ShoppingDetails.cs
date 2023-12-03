﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Entities
{
    public class ShoppingDetails
    {
        [Required(ErrorMessage ="Please enter a name ") ]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a first Address ")]
        [Display(Name="Address Line 1")]
        public string Line1 { get; set; }
        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Please enter a the City ")]
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Please enter a The Country ")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }


    }
}
