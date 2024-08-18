using ProjectStudent.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectStudent.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
    }
}
