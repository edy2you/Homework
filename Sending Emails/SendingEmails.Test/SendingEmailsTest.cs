using System;
using System.Net.Mail;
using NUnit.Framework;
using Sending_Emails;
using System.Configuration;

namespace SendingEmails.Test
{
    [TestFixture]
    public class SendingEmailsTest
    {
        public HolidayRequestController controller = new HolidayRequestController();
        public HolidayRequest holidayRequest;
        public Guid Id;

        [SetUp]
        public void Setup()
        {
            holidayRequest = InitHolidayRequest();
        }

        [Test]
        public void New_created_request_is_not_null()
        {
           Assert.NotNull(holidayRequest);
        }

        [Test]
        public void If_new_request_is_created_status_is_waiting_for_approval()
        {
            var id = controller.Create(holidayRequest);
            var request = controller.holidayRequests.GetRequestById(id);

            Assert.AreEqual(request.Status, RequestStatus.WaitingForApproval);
        }

        [Test]
        public void If_request_is_approved_status_is_Approved()
        {
            var id = controller.Create(holidayRequest);
            controller.Approve(id);
            var request = controller.holidayRequests.GetRequestById(id);

            Assert.AreEqual(request.Status , RequestStatus.Approved);
        }

        [Test]
        public void If_request_is_rejected_status_is_Rejected()
        {
            var id = controller.Create(holidayRequest);
            controller.Reject(id);
            var request = controller.holidayRequests.GetRequestById(id);

            Assert.AreEqual(request.Status, RequestStatus.Rejected);
        }

        [Test]
        public void If_request_is_created_is_added_to_repository()
        {
            var id = controller.Create(holidayRequest);

            Assert.AreEqual(id , holidayRequest.Id);
        }

        [Test]
        public void Request_fields_are_not_empty()
        {
            controller.Create(holidayRequest);

            Assert.IsNotEmpty(holidayRequest.EmployeeName);
            Assert.IsNotEmpty(holidayRequest.EmployeeEmail);
            Assert.IsNotEmpty(holidayRequest.From);
            Assert.IsNotEmpty(holidayRequest.To);
            Assert.IsNotEmpty(holidayRequest.ManagerEmail);
            Assert.AreNotEqual(Guid.Empty, holidayRequest.Id);
            Assert.IsNotNull(holidayRequest.Status);
        }

        [Test]
        public void If_request_is_created_email_is_send_to_PM()
        {
            controller.Create(holidayRequest);
            MailMessage message = controller.GetMailMessage();

            Assert.AreEqual(message.To.ToString(), ConfigurationManager.AppSettings["PmEmail"]);
        }

        [Test]
        public void If_request_is_approved_email_is_send_to_HR()
        {
            var id = controller.Create(holidayRequest);
            controller.Approve(id);
            
            MailMessage message = controller.GetMailMessage();
            Assert.AreEqual(message.To.ToString(), ConfigurationManager.AppSettings["HrEmail"]);
        }

        [Test]
        public void If_request_is_approved_email_is_send_to_Employee()
        {
            var id = controller.Create(holidayRequest);
            controller.Reject(id);

            MailMessage mailMessage = controller.GetMailMessage();
            Assert.AreEqual(mailMessage.To.ToString(), ConfigurationManager.AppSettings["EmployeeEmail"]);
        }

        [Test]
        public void If_request_is_created_email_is_formated_properly()
        {
            controller.Create(holidayRequest);

            MailMessage mailMessage = controller.GetMailMessage();
            string body = GetCreatedMailMessage(holidayRequest);

            Assert.AreEqual(mailMessage.From.ToString() , holidayRequest.EmployeeEmail);
            Assert.AreEqual(mailMessage.To.ToString() , ConfigurationManager.AppSettings["PmEmail"]);
            Assert.AreEqual(mailMessage.Subject, ConfigurationManager.AppSettings["PmSubject"]);
            Assert.AreEqual(mailMessage.Body, body);
        }

        [Test]
        public void If_request_is_approved_email_is_formated_properly()
        {
            var id = controller.Create(holidayRequest);
            controller.Approve(id);
            var request = controller.holidayRequests.GetRequestById(id);

            MailMessage mailMessage = controller.GetMailMessage();
            string body = GetApprovedMailMessage(request);

            Assert.AreEqual(mailMessage.From.ToString(), ConfigurationManager.AppSettings["PmEmail"]);
            Assert.AreEqual(mailMessage.To.ToString(), ConfigurationManager.AppSettings["HrEmail"]);
            Assert.AreEqual(mailMessage.Subject, ConfigurationManager.AppSettings["HrSubject"]);
            Assert.AreEqual(mailMessage.Body, body);
        }

        [Test]
        public void If_request_is_rejected_email_is_formated_properly()
        {
            var id = controller.Create(holidayRequest);
            controller.Reject(id);
            var request = controller.holidayRequests.GetRequestById(id);

            MailMessage mailMessage = controller.GetMailMessage();
            string body = GetRejectMailMessage(request);

            Assert.AreEqual(mailMessage.From.ToString(), ConfigurationManager.AppSettings["PmEmail"]);
            Assert.AreEqual(mailMessage.To.ToString(), ConfigurationManager.AppSettings["EmployeeEmail"]);
            Assert.AreEqual(mailMessage.Subject, ConfigurationManager.AppSettings["EmployeeSubject"]);
            Assert.AreEqual(mailMessage.Body, body);
        }

        public HolidayRequest InitHolidayRequest()
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

        private string GetApprovedMailMessage(HolidayRequest request)
        {
            return String.Format("Cererea de concediu din data de {0} pana in data de {1} a fost aprobata",
                request.From, request.To);
        }

        private string GetRejectMailMessage(HolidayRequest request)
        {
            return String.Format("Cererea de concediu din data de {0} pana in data de {1} nu a fost aprobata",
                request.From, request.To);
        }

        private string GetCreatedMailMessage(HolidayRequest request)
        {
            return String.Format("Subsemnatul {0} angajat al Iquest Solutions, solicit a mi se aproba cererea de concediu din data de {1} pana in data de {2}",
                request.EmployeeName, request.From, request.To);
        }
    }
}
