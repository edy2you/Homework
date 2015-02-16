using System;
using System.Collections.Generic;
using System.Linq;

namespace RentABookPlanner.DAL
{
    public class BookRequestRepository
    {
        private readonly List<BookRequest> requests;

        public BookRequestRepository()
        {
            requests = new List<BookRequest>();
        }

        public void Add(BookRequest bookRequest)
        {
            requests.Add(bookRequest);
        }

        public List<BookRequest> GetRequestsByEmployee(Employee employee)
        {
            return requests.Where(r => r.Employee.Name == employee.Name).ToList();
        }

        public List<BookRequest> GetRequestsByPeriod(DateTime startDate, DateTime endDate)
        {
            return requests.Where(r => r.StartDate >= startDate && r.EndDate <= endDate).ToList();
        }

        public List<BookRequest> GetRequestsByBook(Book book)
        {
            return requests.Where(r => r.Book.Id == book.Id).ToList();
        }

        public List<BookRequest> GetAllRequests()
        {
            return requests;
        } 

        public void Remove(Guid bookRequestId)
        {
            requests.RemoveAll(r => r.Id == bookRequestId);
        }
    }
}
