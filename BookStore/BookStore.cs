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
            var groupList = new List<BookGroup>();
            foreach (var book in Cart)
            {
                var group = groupList.Find(x => x.ContainsKey(book.Id) == false);
                if (group == null)  // 第一次
                {
                    var newGroup = new BookGroup();
                    newGroup.Add(book);
                    groupList.Add(newGroup);
                }
                else
                {
                    group.Add(book);
                    //if (group.ContainsKey(book.Id) == false)
                    //{
                    //}
                    //else
                    //{
                    //    var newGroup = new BookGroup();
                    //    newGroup.Add(book);
                    //    groupList.Add(newGroup);
                    //}
                }
            }

            decimal sum = groupList.Sum(x => x.Calculate());
            //decimal sum = 0m;
            //foreach (var book in Cart)
            //{
            //    sum += book.Price;
            //}

            //if (dic4Qty.Count == 2)
            //{
            //    sum *= 0.95m;
            //}
            //else if (dic4Qty.Count == 3)
            //{
            //    sum *= 0.9m;
            //}
            //else if (dic4Qty.Count == 4)
            //{
            //    sum *= 0.8m;
            //}
            //else if (dic4Qty.Count == 5)
            //{
            //    sum *= 0.75m;
            //}

            return sum;
        }
    }
}
