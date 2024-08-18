using Microsoft.EntityFrameworkCore;
using ProjectStudent.Data;
using ProjectStudent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectStudent.Services
{
    public class CityService : ICityService
    {
        private readonly ApplicationDbContext _context;

        public CityService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetCitiesAsync()
        {
            return await _context.Cities.ToListAsync();
        }
    }
}
