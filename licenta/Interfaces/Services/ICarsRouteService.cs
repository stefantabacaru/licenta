using licenta.Models.CarsRoute;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICarsRouteService
    {
        public Task<int> CreateCarsRoute(CarsRoute carsRoute);

        public Task<CarsRoute> GetCarsRoute();
    }
}
