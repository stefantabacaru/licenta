using AutoMapper;
using licenta.DAOModels;
using licenta.DtoModels.Cars;
using licenta.DtoModels.CarsRoute;
using licenta.DtoModels.Company;
using licenta.DtoModels.Customer;
using licenta.DtoModels.Employee;
using licenta.DtoModels.EmployeeRoute;
using licenta.DtoModels.Repairs;
using licenta.DtoModels.Routes;
using licenta.Models.Cars;
using licenta.Models.CarsRoute;
using licenta.Models.Company;
using licenta.Models.Customer;
using licenta.Models.Employee;
using licenta.Models.EmployeeRoute;
using licenta.Models.Repairs;
using licenta.Models.Routes;
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
            CreateMap<EmployeeGet, EmployeeGetDto>().ReverseMap();
            CreateMap<EmployeeGet, EmployeeDao>().ReverseMap();
            CreateMap<EmployeeUpdate, EmployeeSaveDto>().ReverseMap();
            CreateMap<EmployeeUpdate,EmployeeDao>().ReverseMap();

            CreateMap<CarsSave, CarsSaveDto>().ReverseMap();
            CreateMap<CarsSave, CarsDao>().ReverseMap();
            CreateMap<CarsGet, CarsGetDto>().ReverseMap();
            CreateMap<CarsGet, CarsDao>().ReverseMap();
            CreateMap<CarsUpdate, CarsSaveDto>().ReverseMap();
            CreateMap<CarsUpdate, CarsDao>().ReverseMap();

            CreateMap<CarsRoute, CarsRouteDto>().ReverseMap();
            CreateMap<CarsRoute, CarsRouteDao>().ReverseMap();

            CreateMap<CompanyGet, CompanyGetDto>().ReverseMap();
            CreateMap<CompanyGet, CompanyDao>().ReverseMap();

            CreateMap<CustomerGet, CustomerGetDto>().ReverseMap();
            CreateMap<CustomerGet, CustomerDao>().ReverseMap();
            CreateMap<CustomerSave, CustomerSaveDto>().ReverseMap();
            CreateMap<CustomerSave, CustomerDao>().ReverseMap();

            CreateMap<EmployeeRoute, EmployeeRouteDto>().ReverseMap();
            CreateMap<EmployeeRoute, EmployeeRouteDao >().ReverseMap();

            CreateMap<RepairsGet, RepairsGetDto>().ReverseMap();
            CreateMap<RepairsGet, RepairsDao>().ReverseMap();
            CreateMap<RepairsSave, RepairsSaveDto>().ReverseMap();
            CreateMap<RepairsSave, RepairsDao>().ReverseMap();
            CreateMap<RepairsUpdate, RoutesUpdateDto>().ReverseMap();
            CreateMap<RepairsUpdate, RepairsDao>().ReverseMap();

            CreateMap<RoutesGet, RoutesGetDto>().ReverseMap();
            CreateMap<RoutesGet, RoutesDao>().ReverseMap();
            CreateMap<RoutesSave, RoutesSaveDto>().ReverseMap();
            CreateMap<RoutesSave, RoutesDao>().ReverseMap();
            CreateMap<RoutesUpdate, RoutesUpdateDto>().ReverseMap();
            CreateMap<RoutesUpdate, RoutesDao>().ReverseMap();
        }
    }
}
