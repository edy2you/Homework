using System;

namespace RentABookPlanner.DAL
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }


        public Book()
        {
            Id = Guid.NewGuid();
        }

        public  Book(string author, string title, string publisher, DateTime publicationDate)
        {
            Author = author;
            Title = title;
            Publisher = publisher;
            PublicationDate = publicationDate;
        }
    }
}
