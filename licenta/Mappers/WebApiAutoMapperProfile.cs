using AutoMapper;
using licenta.DAOModels;
using steptrans.DtoModels.Employee;
using steptrans.Models.Employee;

namespace steptrans.Mappers
{
    public class WebApiAutoMapperProfile : Profile
    {
        public WebApiAutoMapperProfile()
        {
           CreateMap<EmployeeSave, EmployeeSaveDto>().ReverseMap();

            CreateMap<EmployeeSave, EmployeeDao>().ReverseMap();
        }
    }
}
