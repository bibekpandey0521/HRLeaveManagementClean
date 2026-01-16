using HR.LeaveManagement.BlazorUI.Contracts;
using HR.LeaveManagement.BlazorUI.Services.Base;

namespace HR.LeaveManagement.BlazorUI.Services
{
    public class LeaveTypeService : BaseHttpService, ILeaveTypeService
    {
        protected IClient _client;
        public LeaveTypeService(IClient client) : base(client)
        {
            _client = client;
        }
    }
}
