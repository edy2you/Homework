using System;
using System.Collections.Generic;
using System.Linq;

namespace RentABookPlanner.DAL
{
    public class BookRepository
    {
        private readonly List<Book> Books;

        public BookRepository()
        {
            Books = new List<Book>();
        }

        public void Add(Book book)
        {
            Books.Add(book);
        }

        public Book GetBookByTitle(string title)
        {
            return Books.First(b => b.Title == title);
        }

        public void Remove(Guid bookId)
        {
            Books.RemoveAll(b => b.Id == bookId);
        }
    }
}
