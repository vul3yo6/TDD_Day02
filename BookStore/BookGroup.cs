using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore
{
    public class BookGroup
    {
        protected Dictionary<int, decimal> discountRules = new Dictionary<int, decimal>()
        {
            { 1, 1m },
            { 2, 0.95m },
            { 3, 0.9m },
            { 4, 0.8m },
            { 5, 0.75m },
        };
        protected Dictionary<int, Book> group = new Dictionary<int, Book>();
        public int Count { get; private set; }
        public decimal OriginalPrice { get; private set; }

        public void Add(Book book)
        {
            if (group.ContainsKey(book.Id))
            {
                throw new Exception("duplicate Id");
            }

            group[book.Id] = book;
            Count++;
            OriginalPrice += book.Price;
        }

        public bool ContainsKey(int id)
        {
            return group.ContainsKey(id);
        }

        public decimal Calculate()
        {
            int count = 1;
            if (discountRules.ContainsKey(group.Count))
            {
                count = group.Count;
            }
            decimal discount = discountRules[count];
            return OriginalPrice * discount;
        }
    }
}
