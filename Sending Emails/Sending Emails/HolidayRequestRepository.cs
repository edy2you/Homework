using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Sending_Emails
{
    public class HolidayRequestRepository
    {
        public List<HolidayRequest> holidayRequests = new List<HolidayRequest>();
        public Email email;

        public void Add(HolidayRequest holidayRequest)
        {
            holidayRequests.Add(holidayRequest);
            SendMailToPM(holidayRequest);
        }

        public void Remove(Guid Id)
        {
            holidayRequests.RemoveAll(r => r.Id == Id);
        }

        public HolidayRequest GetRequestById(Guid Id)
        {
            var holidayRequest = holidayRequests.Single(r => r.Id == Id);
            return holidayRequest;
        }

        public void ApproveRequestById(Guid Id)
        {
            holidayRequests.Single(r => r.Id == Id).Approve();
            var holidayRequest = holidayRequests.Single(r => r.Id == Id);
            SendMailToHr(holidayRequest);
        }

        public void RejectRequestById(Guid Id)
        {
            holidayRequests.Single(r => r.Id == Id).Reject();
            var holidayRequest = holidayRequests.Single(r => r.Id == Id);
            SendMailToEmployee(holidayRequest);
        }

        private void SendMailToHr(HolidayRequest holidayRequest)
        {
            string hrEmail = ConfigurationManager.AppSettings["HrEmail"];
            string pmEmail = ConfigurationManager.AppSettings["PmEmail"];
            string subject = ConfigurationManager.AppSettings["HrSubject"];
            string body = GetApprovedMailMessage(holidayRequest);
            email = new Email(pmEmail, hrEmail, subject, body);
            email.Send();
        }

        private void SendMailToPM(HolidayRequest holidayRequest)
        {
            string pmEmail = ConfigurationManager.AppSettings["PmEmail"];
            string employeeEmail = ConfigurationManager.AppSettings["EmployeeEmail"];
            string subject = ConfigurationManager.AppSettings["PmSubject"];
            string body = GetCreatedMailMessage(holidayRequest);
            email = new Email(employeeEmail, pmEmail, subject, body);
            email.Send();
        }

        private void SendMailToEmployee(HolidayRequest holidayRequest)
        {
            string pmEmail = ConfigurationManager.AppSettings["PmEmail"];
            string employeeEmail = ConfigurationManager.AppSettings["EmployeeEmail"];
            string subject = ConfigurationManager.AppSettings["EmployeeSubject"];
            string body = GetRejectMailMessage(holidayRequest);
            email = new Email(pmEmail, employeeEmail, subject, body);
            email.Send();
        }

        private string GetApprovedMailMessage(HolidayRequest holidayRequest)
        {
            return String.Format("Cererea de concediu din data de {0} pana in data de {1} a fost aprobata",
                holidayRequest.From, holidayRequest.To);
        }

        private string GetRejectMailMessage(HolidayRequest holidayRequest)
        {
            return String.Format("Cererea de concediu din data de {0} pana in data de {1} nu a fost aprobata",
                holidayRequest.From, holidayRequest.To);
        }

        private string GetCreatedMailMessage(HolidayRequest holidayRequest)
        {
            return String.Format("Subsemnatul {0} angajat al Iquest Solutions, solicit a mi se aproba cererea de concediu din data de {1} pana in data de {2}",
                holidayRequest.EmployeeName, holidayRequest.From, holidayRequest.To);
        }
    }
}
