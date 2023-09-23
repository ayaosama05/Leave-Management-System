using AutoMapper;
using LeaveManagementSystem.API.Models;
using System.Reflection;

namespace LeaveManagementSystem.API.Mapping
{ 
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // LoginDto --> Employee
            CreateMap<LoginDto,Employee>();
            // Employee <--> EmployeeDto
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            // LeaveType --> LeaveTypeDto
            CreateMap<LeaveType, LeaveTypeDto>();
            //LeaveRequest
            CreateMap<CreateLeaveRequestDto,LeaveRequest>();
            CreateMap<LeaveRequest, SubordinateLeaveRequestDto>()
                 .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name));
            CreateMap<Employee, SubordinateDto>()
                .ForMember(dest => dest.Department,opt => opt.MapFrom(src => src.Department.Name))
              .ForMember(dest => dest.LeaveRequestItemDtos, opt => opt.MapFrom(src => src.LeaveRequests));
            CreateMap<LeaveRequest, LeaveRequestItemDto>()
               .ForMember(dest => dest.LeaveTypeName, opt => opt.MapFrom(src => src.LeaveType.Name));
        }
    }

}
