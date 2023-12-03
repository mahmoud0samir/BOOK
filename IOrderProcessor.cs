using Bookstore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Domain.Abstract
{
   public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShoppingDetails ShoppingDetails);
    }
}
