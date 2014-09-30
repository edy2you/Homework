using NUnit.Framework;

namespace Sending_Emails.Test
{
    [TestFixture]
    public class SendingEmailsTest
    {
        public HolidayRequestController controller = new HolidayRequestController();
        public HolidayRequest holidayRequest;
        
        [SetUp]
        public void Setup()
        {
            holidayRequest = InitHolidayRequest();
        }
        
        
        [Test]
        public void If_new_request_is_created_status_is_waiting_for_approval()
        {
            var id = controller.Create(holidayRequest);
            var request = controller.holidayRequests.GetRequestById(id);
            
            Assert.AreEqual(request.Status , RequestStatus.WaitingForApproval);
        }

        public  HolidayRequest InitHolidayRequest()
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
