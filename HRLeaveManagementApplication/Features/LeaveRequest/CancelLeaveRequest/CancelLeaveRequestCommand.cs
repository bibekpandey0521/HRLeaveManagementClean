using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.CancelLeaveRequest
{
    public class CancelLeaveRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
