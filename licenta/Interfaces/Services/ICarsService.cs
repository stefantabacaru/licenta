using licenta.Models.Cars;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace licenta.Interfaces.Services
{
    public interface ICarsService
    {
        public Task<int> CreateCars(CarsSave carsSave);

        public Task<List<CarsGet>> GetCars();

        public Task<CarsGet> GetCarById(int id);

        public Task UpdateCars(CarsUpdate carsUpdate, int id);

        public Task DeleteCarById(int id);
    }
}