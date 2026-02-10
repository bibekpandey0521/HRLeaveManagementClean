using HR.LeaveManagement.BlazorUI.Models.LeaveRequests;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public interface ILeaveRequestService
    {
        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
        Task<EmployeeRequestViewVM> GetUserLeaveRequests();
        Task<Response<Guid>> CreateLeaveRequest(LeaveRequestVM leaveRequestVM);
        Task<LeaveRequestVM> GetLeaveRequest(int id);
        Task DeleteLeaveRequest(int id);
        Task<Response<Guid>> ApproveLeaveRequest(int id, bool approved);
        Task<Response<Guid>> CancelRequest(int id);
    }
}
