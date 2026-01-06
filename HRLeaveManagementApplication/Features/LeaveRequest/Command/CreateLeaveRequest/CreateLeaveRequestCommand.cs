using HR.LeaveManagement.Application.Features.LeaveRequest.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Command.CreateLeaveRequest
{
    public class CreateLeaveRequestCommand : BaseLeaveRequest,IRequest<Unit>
    {
        public string RequsetComments { get; set; } = string.Empty;
    }
}
