#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using ShareARide.Models;

namespace ShareARide.Controllers
{
    [Route("api/carpools")]
    [ApiController]
    public class CarpoolsController : ControllerBase
    {
        private readonly ICarpoolsContext _context;

        public CarpoolsController(ICarpoolsContext context)
        {
            _context = context;
        }

        // Get: api/get --> get all Carpools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carpools>>> GetCarpools()
        {
            return await _context.GetAllAsync();
        }


        // GET: api/Carpools/x --> Get one Carpool with ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Carpools>> GetCarpool(int id)
        {
            var carpool = await _context.GetSingleAsync(id);

            if (carpool == null)
            {
                return NotFound();
            }

            return carpool;
        }

        // POST: api/Carpools
        [HttpPost]
        public async Task<ActionResult<Carpools>> PostCarpool(Carpools carpool)
        {
            return await _context.AddCarpoolAsync(carpool);
        }

        // PUT: api/Carpools/x --> Edit a Carpool 
        [HttpPut("{id}")]
        public async Task<Carpools> PutCarpool(int id, Carpools carpool)
        {

            return await _context.EditCarpoolAsync(id, carpool);
        }
        

        // Delete: api/Users/x --> Delete a Carpool
        [HttpDelete("{id}")]
        public async Task<Carpools> DeleteCarpool(int id)
        {
            
            return await _context.DeleteaCarpoolAsync(id);
        }
    }
}