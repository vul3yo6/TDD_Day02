using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookStore
    {
        public List<Book> Cart { get; private set; }

        public BookStore()
        {
            Cart = new List<Book>();
        }

        public void Add(List<Book> list)
        {
            Cart.AddRange(list);
        }

        public decimal Calculate()
        {
            decimal sum = 0m;
            foreach (var book in Cart)
            {
                sum += book.Price;
            }

            return sum;
        }
    }
}
