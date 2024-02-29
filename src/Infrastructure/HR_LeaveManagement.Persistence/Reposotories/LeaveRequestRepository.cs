using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence.Reposotories {
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository {
        public LeaveRequestRepository(HrDatabaseContext context) : base(context) {
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync() {
            
            var leaveRequests = await _context.LeaveRequests
                .Include(lr => lr.LeaveType)
                .ToListAsync();
            return leaveRequests;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync(string name) {
            
            var leaveRequests = await _context.LeaveRequests
                .Where(lr => lr.RequestingEmployeeID == name)
                .Include(lr => lr.LeaveType)
                .ToListAsync();

            return leaveRequests;
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id) {
            
            var leaveRequests = await _context.LeaveRequests
                .Include(lr => lr.LeaveType)
                .FirstOrDefaultAsync(lr => lr.Id == id);

            return leaveRequests;
        }
    }
}
