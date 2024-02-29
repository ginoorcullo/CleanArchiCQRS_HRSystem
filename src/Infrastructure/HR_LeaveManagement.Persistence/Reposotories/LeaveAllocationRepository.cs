using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR_LeaveManagement.Persistence.Reposotories {
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository {
        public LeaveAllocationRepository(HrDatabaseContext context) : base(context) {
        }

        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id) {
            
            var leaveAllocation = await _context.LeaveAllocations
                .Include(la => la.LeaveType)
                .FirstOrDefaultAsync(la => la.Id == id);

            return leaveAllocation;
        }

        public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails() {
            
            var leaveAllocations = _context.LeaveAllocations
                .Include(la => la.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId) {
            
            var leaveAllocations = await _context.LeaveAllocations
                .Where(la => la.EmployeeId == userId)
                .Include(la => la.LeaveType)
                .ToListAsync();

            return leaveAllocations;
        }

        public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId) {
            var leaveAllocation = await _context.LeaveAllocations.
                FirstOrDefaultAsync(la => la.EmployeeId == userId 
                                    && la.LeaveTypeId == leaveTypeId);

            return leaveAllocation;
        }
        public async Task AddAllocations(List<LeaveAllocation> allocations) {
            await _context.AddRangeAsync(allocations);
        }

        public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period) {
            
            bool isExist = await _context.LeaveAllocations.AnyAsync(la => 
                                        la.EmployeeId == userId
                                        && la.LeaveTypeId == leaveTypeId 
                                        && la.Period == period);

            return isExist;
        }
    }
}
