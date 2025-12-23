using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
   public record GetLeaveTypesDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto>;
}
