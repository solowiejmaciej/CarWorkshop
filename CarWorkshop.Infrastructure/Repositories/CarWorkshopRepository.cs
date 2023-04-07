using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Repositories
{
    internal class CarWorkshopRepository : ICarWorkshopRepository
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopRepository(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Domain.Entities.CarWorkshop carWorkshop)
        {
            _dbContext.CarWorkshops.Add(carWorkshop);
            await _dbContext.SaveChangesAsync();
        }

        public Task<Domain.Entities.CarWorkshop?> GetByName(string name)
        {
            return _dbContext.CarWorkshops.FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
        }

        public async Task<IEnumerable<Domain.Entities.CarWorkshop>> GetAll()
        {
            return await _dbContext.CarWorkshops.ToListAsync();
        }

        public Task<Domain.Entities.CarWorkshop> GetByEncodedName(string encodedName)
        {
            return _dbContext.CarWorkshops.FirstOrDefaultAsync(c => c.EncodedName == encodedName);
        }

        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}