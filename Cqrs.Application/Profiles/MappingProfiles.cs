using AutoMapper;
using Cqrs.Application.DTOs;
using Cqrs.Application.DTOs.LeaveRequest;
using Cqrs.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cqrs.Application.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            #region LeaveRequest Mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>()
                .ForMember(dest => dest.DateRequested, opt => opt.MapFrom(src => src.DateCreated))
                .ReverseMap();
            //CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
            //CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
            //CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
            //CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
            //CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        }
    }
}
