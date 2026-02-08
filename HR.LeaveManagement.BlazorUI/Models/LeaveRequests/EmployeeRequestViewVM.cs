using HR.LeaveManagement.BlazorUI.Models.LeaveAllocations;

namespace HR.LeaveManagement.BlazorUI.Models.LeaveRequests
{
    public class EmployeeRequestViewVM
    {
        public List<LeaveAllocationVM> LeaveAllocations { get; set; }
        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
