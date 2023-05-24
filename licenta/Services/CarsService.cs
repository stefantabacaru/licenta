using AutoMapper;
using licenta.DAOModels;
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
        private Context.ContextDB _context;
        private readonly IMapper mapper;

        public CarsService(Context.ContextDB context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<int> CreateCars(CarsSave carSave)
        {
            var carSaveDao = mapper.Map<CarsDao>(carSave);
            _context.Cars.Add(carSaveDao);
            _context.SaveChanges();
            return carSaveDao.CarId;
        }

        public async Task DeleteCarById(int id)
        {
            var car = _context.Cars.SingleOrDefault(x => x.CarId == id);
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        public async Task<CarsGet> GetCarById(int id)
        {
            return mapper.Map<CarsGet>(_context.Cars.SingleOrDefault(x => x.CarId == id));
        }

        public async Task<List<CarsGet>> GetCars()
        {
            return mapper.Map<List<CarsGet>>(_context.Cars.ToList());
        }

        public async Task UpdateCars(CarsUpdate carsUpdate, int id)
        {

            var car = _context.Cars.SingleOrDefault(x => x.CarId == id);
            if (carsUpdate != null)
            {
                car.KmNumber = carsUpdate.KmNumber;
              
                _context.Cars.Update(car);
                _context.SaveChanges();
            }
        }
    }
}
