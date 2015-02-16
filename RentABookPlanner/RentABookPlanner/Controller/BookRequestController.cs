using System;
using System.Collections.Generic;
using RentABookPlanner.DAL;

namespace RentABookPlanner.Controller
{
    public class BookRequestController
    {
        public BookRequestRepository bookRequestRepository;

        public BookRequestController()
        {
            bookRequestRepository = new BookRequestRepository();
        }

        public void Create(Book book, Employee employee, DateTime startDate, DateTime endDate)
        {
            var bookRequest = new BookRequest
            {
                Book = book,
                Employee = employee,
                StartDate = startDate,
                EndDate = endDate
            };

            bookRequestRepository.Add(bookRequest);
        }

        public List<BookRequest> GetRequestsByEmployee(Employee employee)
        {
            return bookRequestRepository.GetRequestsByEmployee(employee);
        }

        public List<BookRequest> GetRequestsByPeriod(DateTime startDate, DateTime endDate)
        {
            return bookRequestRepository.GetRequestsByPeriod(startDate, endDate);
        }

        public List<BookRequest> GetRequestsByBook(Book book)
        {
            return bookRequestRepository.GetRequestsByBook(book);
        }

        public List<BookRequest> GetAllRequests()
        {
            return bookRequestRepository.GetAllRequests();
        } 

        public void Remove(Guid bookRequestId)
        {
            bookRequestRepository.Remove(bookRequestId);
        }
    }
}
