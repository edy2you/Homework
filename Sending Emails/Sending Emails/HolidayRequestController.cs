using System;
using System.Net.Mail;

namespace Sending_Emails
{
    public class HolidayRequestController
    {
        public HolidayRequestRepository holidayRequests = new HolidayRequestRepository();

        public Guid Create(HolidayRequest request)
        {
            holidayRequests.Add(request);
            return request.Id;
        }

        public void Approve(Guid Id)
        {
            holidayRequests.ApproveRequestById(Id);
        }

        public void Reject(Guid Id)
        {
            holidayRequests.RejectRequestById(Id);
        }

        public MailMessage GetMailMessage()
        {
            return holidayRequests.email.mailMessage;
        }
    }
}
