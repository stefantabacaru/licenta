using licenta.Interfaces.Services;
using licenta.Models.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace licenta.Services
{
    public class CarsService : ICarsService
    {
        public Task<int> CreateCars(CarsSave carsSave)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CarsGet> GetCarById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CarsGet>> GetCars()
        {
            throw new NotImplementedException();
        }

        public Task UpdateCars(CarsUpdate carsSave, int id)
        {
            throw new NotImplementedException();
        }
    }
}
