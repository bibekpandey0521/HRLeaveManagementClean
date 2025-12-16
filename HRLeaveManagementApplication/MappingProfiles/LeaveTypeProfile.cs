using AutoMapper;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRLeaveManagementApplication.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
        }
    }
}
