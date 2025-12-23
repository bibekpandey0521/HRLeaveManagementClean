using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails
{
    public class GetLeaveTypeDetailsQueryHandler : IRequestHandler<GetLeaveTypesDetailsQuery, LeaveTypeDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public GetLeaveTypeDetailsQueryHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDto> Handle(GetLeaveTypesDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            //query the database
            var leaveTypes = await _leaveTypeRepository.GetByIdAsync(request.Id);

            //convert data object to DTO object
            var data = _mapper.Map<LeaveTypeDetailsDto> (leaveTypes);

            //return DTO object
            return data;
        }
    }
}
