using AutoMapper;
using steptrans.Models.Employee;

namespace steptrans.Mappers
{
    public class WebApiAutoMapperProfile : Profile
    {
        public WebApiAutoMapperProfile()
        {
           // CreateMap<EmployeeSave, EmployeeSaveDao>().ReverseMap();
        }
    }
}
