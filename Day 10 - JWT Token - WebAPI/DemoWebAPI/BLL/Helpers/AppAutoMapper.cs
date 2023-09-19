using AutoMapper;
using BLL.Models.DTOs;
using DAL.Entities;

namespace BLL.Helpers
{
    public class AppAutoMapper :Profile
    {
        public AppAutoMapper() 
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
        }
    }
}
