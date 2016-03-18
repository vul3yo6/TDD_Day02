using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BookStore.Test
{
    [TestClass]
    public class BookStoreTests
    {
        [TestMethod]
        public void Test_第一集買了一本_其他都沒買_價格應為100元()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
            };

            var target = new BookStore();
            var expected = 100m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
            };

            var target = new BookStore();
            var expected = 100m * 2 * 0.95m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三集各買了一本_價格應為270()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
            };

            var target = new BookStore();
            var expected = 100m * 3 * 0.9m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為320()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
                new Book() { Id = 4, Name = "第四集", Price = 100m },
            };

            var target = new BookStore();
            var expected = 100m * 4 * 0.8m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
                new Book() { Id = 4, Name = "第四集", Price = 100m },
                new Book() { Id = 5, Name = "第五集", Price = 100m },
            };

            var target = new BookStore();
            var expected = 100m * 5 * 0.75m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_一套加孤本_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
            };

            var target = new BookStore();
            var expected = (100m * 3 * 0.9m) + 100m;

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_兩套加孤本_第一集買了一本_第二三集各買了兩本_價格應為460()
        {
            //Arrange
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
            };

            var target = new BookStore();
            var expected = ((100m * 3 * 0.9m) + (100m * 2 * 0.95m));

            //Act
            target.Add(list);
            decimal actual = target.Calculate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        private IEnumerable<Book> GetInitList()
        {
            var list = new List<Book>()
            {
                new Book() { Id = 1, Name = "第一集", Price = 100m },
                new Book() { Id = 2, Name = "第二集", Price = 100m },
                new Book() { Id = 3, Name = "第三集", Price = 100m },
                new Book() { Id = 4, Name = "第四集", Price = 100m },
                new Book() { Id = 5, Name = "第五集", Price = 100m },
            };
            return list;
        }
    }
}
