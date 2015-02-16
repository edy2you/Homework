using System;
using System.Collections.Generic;
using RentABookPlanner.Controller;
using RentABookPlanner.DAL;
using RentABookPlanner.Services;

namespace RentABookPlanner
{
    class Program
    {
        private static EmployeeRepository employeeRepository;
        private static BookRepository bookRepository;
        private static LocationRepository locationRepository;
        private static BookRequestController bookRequestController;

        static void Main(string[] args)
        {
            ConsoleKey key;

            bookRequestController = new BookRequestController();
            employeeRepository = new EmployeeRepository();
            bookRepository = new BookRepository();
            locationRepository = new LocationRepository();

            ShowMessage();

            do
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.E:
                        var employeeReader = new EmployeeReader();
                        employeeRepository.Add(employeeReader.Read());
                        break;

                    case ConsoleKey.L:
                        var locationReader = new LocationReader();
                        locationRepository.Add(locationReader.Read());
                        break;

                    case ConsoleKey.B:
                        var bookReader = new BookReader();
                        bookRepository.Add(bookReader.Read());
                        break;

                    case ConsoleKey.R:
                        AddRequest();
                        break;

                    case ConsoleKey.S:
                        ShowRequests();
                        break;
                }

                ShowMessage();
            } while (key != ConsoleKey.Escape);
        }

        public static void AddRequest()
        {
            Console.WriteLine("--- Add request ---");
            Console.WriteLine("Book title:");
            string bookTitle = Console.ReadLine();
            Book book = bookRepository.GetBookByTitle(bookTitle);

            if (book == null)
            {
                Console.WriteLine();
            }


            Console.WriteLine("Employee name:");
            string employeeName = Console.ReadLine();
            Employee employee = employeeRepository.GetEmployeeByName(employeeName);

            if (employee == null)
            {
                Console.WriteLine();
            }

            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;

            bookRequestController.Create(book, employee, startDate, endDate);
        }

        public static void ShowRequests()
        {
            List<BookRequest> requests = bookRequestController.GetAllRequests();

            foreach (var request in requests)
            {
                Console.WriteLine(request.Employee.Name + " - " + request.Book.Title + " between " + request.StartDate + " - " + request.EndDate);
            }

            Console.WriteLine();
        }

        public static void ShowMessage()
        {
            Console.WriteLine("Press key");
            Console.WriteLine("e: add Employee | l: add Location | b: add Book | r: add Request | s: show requests | Esc: exit");
            Console.WriteLine();
        }
    }
}
