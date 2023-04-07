using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWorkshop.Infrastructure.Persistent;

namespace CarWorkshop.Infrastructure.Seeders
{
    public class CarWorkshopSeeder
    {
        private readonly CarWorkshopDbContext _dbContext;

        public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Seed()
        {
            if (await _dbContext.Database.CanConnectAsync())
            {
                if (!_dbContext.CarWorkshops.Any())
                {
                    var exampleCarWorkShop = new Domain.Entities.CarWorkshop()
                    {
                        Name = "Mazda ASO",
                        Description = "Autoryzowany serwis Mazda",
                        ContactDetails = new()
                        {
                            City = "Poznań",
                            PostalCode = "62-005",
                            EmailAddress = "serwis.aso@mazda.com",
                            PhoneNumber = "+555666777"
                        }
                    };
                    exampleCarWorkShop.EncodeName();
                    _dbContext.CarWorkshops.Add(exampleCarWorkShop);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }
    }
}