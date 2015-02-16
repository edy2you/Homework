using System;
using RentABookPlanner.DAL;

namespace RentABookPlanner.Services
{
    public class BookReader : IReader<Book>
    {

        public Book Read()
        {
            Console.WriteLine("--- Add book ---");
            Console.WriteLine("Author:");
            string author = Console.ReadLine();
            Console.WriteLine("Title:");
            string title = Console.ReadLine();
            Console.WriteLine("Publisher:");
            string publisher = Console.ReadLine();

            var book = new Book {Author = author, Title = title, Publisher = publisher, PublicationDate = DateTime.Now};

            return book;
        }
    }
}
