using System;
using System.Collections.Generic;

namespace Sending_Emails
{
    class Program
    {
        private enum RequestOperation
        {
            Create,
            Approve,
            Reject
        }

        static readonly HolidayRequestController holidayRequestController = new HolidayRequestController();
        private static Guid requestId;

        static void Main(string[] args)
        {
            ConsoleKeyInfo consoleKey;

            var requestOperations = new Dictionary<string, RequestOperation>
            {
                {"C", RequestOperation.Create},
                {"A", RequestOperation.Approve},
                {"R", RequestOperation.Reject}
            };

            Console.WriteLine("Create holiday request - Press C");
            Console.WriteLine("Approve holiday request - Press key A");
            Console.WriteLine("Reject holiday request - Press key R");
            Console.WriteLine("Close - Press X");

            do
            {
                consoleKey = Console.ReadKey();
                if (consoleKey.Key != ConsoleKey.X)
                {
                    RunHolidayRequestAction(requestOperations[consoleKey.Key.ToString().ToUpper()]);
                }
                Console.WriteLine();

            } while (consoleKey.Key != ConsoleKey.X);
        }

        private static void RunHolidayRequestAction(RequestOperation operation)
        {
            

            switch (operation)
            {
                case RequestOperation.Create:
                    var holidayRequest = InitHolidayRequest();
                    requestId = holidayRequestController.Create(holidayRequest);
                    break;

                case RequestOperation.Approve:
                    holidayRequestController.Approve(requestId);
                    break;

                case RequestOperation.Reject:
                    holidayRequestController.Reject(requestId);
                    break;
            }
        }

        private static HolidayRequest InitHolidayRequest()
        {
            var request = new HolidayRequest
            {
                EmployeeEmail = "eduard.jarnea@iquestgroup.com",
                EmployeeName = "Eduard.Jarnea",
                From = "2014-09-01",
                To = "2014-10-01",
                ManagerEmail = "eduard.jarnea@iquestgroup.com"
            };

            return request;
        }
    }
}
