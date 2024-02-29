using HR_LeaveManagement.Domain.Common;

namespace HR_LeaveManagement.Domain {
    public class LeaveRequest: BaseEntity<int> {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime DateRequested { get; set; }
        public string? RequestComments { get; set; }
        public bool? Approved { get; set; }
        public bool Cancelled { get; set; }
        public string RequestingEmployeeID { get; set; } = string.Empty;
    }
}
