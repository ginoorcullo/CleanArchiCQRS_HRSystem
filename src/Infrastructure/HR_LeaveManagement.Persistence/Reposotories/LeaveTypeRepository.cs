using HR_LeaveManagement.Application.Contracts.Persistence;
using HR_LeaveManagement.Domain;
using HR_LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_LeaveManagement.Persistence.Reposotories {
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository {
        public LeaveTypeRepository(HrDatabaseContext context): base(context) {
        }
        
        public async Task<bool> IsLeaveTypeUnique(string name) {
            return await _context.LeaveTypes.AnyAsync(l => l.Name == name);
        }
    }
}
