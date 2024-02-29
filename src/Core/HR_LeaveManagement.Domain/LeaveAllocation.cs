using HR_LeaveManagement.Domain.Common;

namespace HR_LeaveManagement.Domain {
    public class LeaveAllocation: BaseEntity<int> {
        public int NumberOfDays { get; set; }
        public LeaveType? LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
        public string EmployeeId { get; set; } = string.Empty;
        public int Period { get; set; } 
    }
}
