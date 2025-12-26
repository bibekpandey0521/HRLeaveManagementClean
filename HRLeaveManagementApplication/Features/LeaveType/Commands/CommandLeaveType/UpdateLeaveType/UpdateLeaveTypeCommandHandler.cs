using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CommandLeaveType.UpdateLeaveType
{
    internal class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommandHandler> _logger; 

        public UpdateLeaveTypeCommandHandler(IMapper mapper,
            ILeaveTypeRepository leaveTypeRepository,
            IAppLogger<UpdateLeaveTypeCommandHandler> logger
            )
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            // Validate incoming data
            var validator  =  new  UpdateLeaveTypeCommandValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Validation errors in update leave type command for id {0} - {1}",nameof(LeaveType)
                    ,request.Id);
                throw new BadRequestExeption("Invalid leave Type",validationResult);
            }

            //convert to domain entity object
            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);

            //add to database
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);
            //return Unit Value
            return Unit.Value;
        }
    }
}
