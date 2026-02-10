using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Identity;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IUserService _userService;
        public CreateLeaveAllocationCommandHandler(IMapper mapper,
            ILeaveAllocationRepository leaveAllocationRepository,
            ILeaveTypeRepository leaveTypeRepository,IUserService userService)
        {
            this._mapper = mapper;
            this._leaveAllocationRepository = leaveAllocationRepository;
            this._leaveTypeRepository = leaveTypeRepository;
            this._userService = userService;
        }
        public async Task<Unit> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request",validationResult);

            // Get Leave type for allocation
            var leaveType = await  _leaveTypeRepository.GetByIdAsync(request.LeaveTypeId);

            // Get Employees 
            var employees = await _userService.GetEmployees();
            // Get Period
            var period = DateTime.Now.Year;

            // Assign Allocations IF an allocation doesn't already exist for period and leaveType
            var allocations = new List<Domain.LeaveAllocation>();
            foreach(var emp in employees)
            {
                var allocationExists = await _leaveAllocationRepository.AllocationExists(emp.Id,request.LeaveTypeId,
                    period);
                if (allocationExists == false)
                {
                    allocations.Add(new Domain.LeaveAllocation
                    {
                        EmployeeId   = emp.Id,
                        LeaveTypeId  = leaveType.Id,
                        NumberOfDays = leaveType.DefaultDays,
                        Period       = period
                    });
                }
            }

            await _leaveAllocationRepository.AddAllocations(allocations);

            //var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request);
            //await _leaveAllocationRepository.CreateAsync(leaveAllocation);


            return Unit.Value;
        }
    }
}
