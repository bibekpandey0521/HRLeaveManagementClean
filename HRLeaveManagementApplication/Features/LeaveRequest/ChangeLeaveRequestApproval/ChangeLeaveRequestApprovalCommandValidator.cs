using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.ChangeLeaveRequestApproval
{
    public class ChangeLeaveRequestApprovalCommandValidator : AbstractValidator<ChangeLeaveRequestApprovalCommand>
    {
        public ChangeLeaveRequestApprovalCommandValidator()
        {

            RuleFor(p => p.Approved)
                .NotNull()
                .WithMessage("Approval status cannot be null");
        }
    }
}
