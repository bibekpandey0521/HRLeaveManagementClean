using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CommandLeaveType.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Commands.CommandLeaveType.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;


namespace HR.LeaveManagement.Application.MappingProfiles
{
    public  class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
            //destination==LeaveTypeDto
            //source == LeaveType

            CreateMap<LeaveType, LeaveTypeDetailsDto>();
            CreateMap<CreateLeaveTypeCommand, LeaveType>();
            CreateMap<UpdateLeaveTypeCommand, LeaveType>();

        }
    }
}
