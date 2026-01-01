using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateAllocationCommand : IRequest<Unit>
    {
        public int LeaveTypeId { get; set; }
    }
}
