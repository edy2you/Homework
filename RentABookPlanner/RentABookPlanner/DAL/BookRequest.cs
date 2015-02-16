using System;

namespace RentABookPlanner.DAL
{
    public class BookRequest
    {
        public Guid Id { get; set; }
        public Book Book { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public BookRequest()
        {
            Id = Guid.NewGuid();
        }

        public BookRequest(Book book, Employee employee, DateTime startDate, DateTime endDate)
        {
            Book = book;
            Employee = employee;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
