using licenta.Models.Cars;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICarsService
    {
        public Task<int> CreateCars(CarsSave carsSave);

        public Task<CarsSave> GetCars();
    }
}