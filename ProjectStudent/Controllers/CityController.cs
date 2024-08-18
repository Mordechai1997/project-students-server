using Microsoft.AspNetCore.Mvc;
using ProjectStudent.Models;
using ProjectStudent.Services;

namespace ProjectStudent.Controllers
{
    [ApiController]
    [Route("api")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet("cities")]
        public async Task<ActionResult<IEnumerable<City>>> GetCities()
        {
            try
            {
                var cities = await _cityService.GetCitiesAsync();
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
