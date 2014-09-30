using System;

namespace Sending_Emails
{
    public class HolidayRequest
    {
        public Guid Id;
        public string EmployeeName;
        public string EmployeeEmail;
        public string ManagerEmail;

        public string From;
        public string To;
        public RequestStatus Status;

        public HolidayRequest()
        {
            Id = Guid.NewGuid();
            Status = RequestStatus.WaitingForApproval;
        }

        public void Approve()
        {
            Status = RequestStatus.Approved;
        }

        public void Reject()
        {
            Status = RequestStatus.Rejected;
        }
    }
}
