using HR_LeaveManagement.Domain;

namespace HR_LeaveManagement.Application.Contracts.Persistence {
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest> {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync();
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetailsAsync(string name);

    }
}
