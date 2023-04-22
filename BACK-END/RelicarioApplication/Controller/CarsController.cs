using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelicarioApplication.Data;
using System.Threading.Tasks;

namespace RelicarioApplication.Controller
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CarsController(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> GetCars()
        {
            return Ok(

                new
                {
                    success = true,
                    data = await _context.Cars.ToListAsync()
                });
                
               
        }
    }
}
