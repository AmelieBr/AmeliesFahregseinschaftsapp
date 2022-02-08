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
    [Route("api/carpoolusers")]
    [ApiController]
    public class CarpoolUsersController : ControllerBase
    {
        private readonly ICarpoolUsersContext _context;

        public CarpoolUsersController(ICarpoolUsersContext context)
        {
            _context = context;
        }

        // Get: api/get --> get all CarpoolUsers
        [HttpGet("Get all CarpoolUsers")]
        public async Task<ActionResult<IEnumerable<CarpoolUsers>>> GetCarpoolsUsers()
        {
            return await _context.GetAllAsync();
        }


        // GET: api/CarpoolUsers/x --> Get all Users of one Carpool with ID
        [HttpGet("Get all Users of a Carpool/{Carpoolid}")]
        public async Task<ActionResult<IEnumerable<CarpoolUsers>>> GetCarpoolUsers(int carpoolid)
        {
            var carpoolusers = await _context.GetSingleCarpoolUsersAsync(carpoolid);

            if (carpoolusers == null)
            {
                return NotFound();
            }

            return carpoolusers;
        }

        // GET: api/CarpoolUsers/x --> Get all Carpools a User takes part in
        [HttpGet("Get all used Carpools of a User/{Userid}")]
        public async Task<ActionResult<IEnumerable<CarpoolUsers>>> GetCarpoolsUser(int Userid)
        {
            var carpoolusers = await _context.GetSingleUserinCarpoolsAsync(Userid);

            if (carpoolusers == null)
            {
                return NotFound();
            }

            return carpoolusers;
        }

            // GET: api/CarpoolUsers/x/x --> Get one Carpool the User takes part in
        [HttpGet("Get one Carpool used by on User/{Userid}/{Carpoolid}")]
        public async Task<ActionResult<CarpoolUsers>> GetCarpoolUser(int userid, int carpoolid)
        {
            var carpooluser = await _context.GetSingleUserinSingleCarpoolAsync(userid, carpoolid);

            if (carpooluser == null)
            {
                return NotFound();
            }

            return carpooluser;
        }


        // POST: api/CarpoolUsers
        [HttpPost]
        public async Task<ActionResult<CarpoolUsers>> PostCarpoolUser(CarpoolUsers carpooluser)
        {
            return await _context.AddCarpoolUserAsync(carpooluser);
        }
        

        // Delete: api/Users/x --> Delete all Users of the Carpool
        [HttpDelete("{Carpoolid}")]
        public async Task<ActionResult<IEnumerable<CarpoolUsers>>> DeleteCarpoolUsers(int carpoolid)
        {
            var carpoolusers = await _context.DeleteSingleCarpoolUsersAsync(carpoolid);

            if (carpoolusers == null)
            {
                return NotFound();
            }

            return carpoolusers;
        }

        // Delete: api/CarpoolUsers/x --> Delete the User out of all Carpools a User takes part in
        [HttpDelete("{Userid}")]
        public async Task<ActionResult<IEnumerable<CarpoolUsers>>> DeleteCarpoolsUser(int userid)
        {
            var carpoolusers = await _context.DeleteSingleUserinCarpoolsAsync(userid);

            if (carpoolusers == null)
            {
                return NotFound();
            }

            return carpoolusers;
        }

            // Delete: api/CarpoolUsers/x/x --> Delete one Carpool the User takes part in
        [HttpDelete("{Userid}/{Carpoolid}")]
        public async Task<ActionResult<CarpoolUsers>> DeleteCarpoolUser(int userid, int carpoolid)
        {
            var carpooluser = await _context.DeleteSingleUserinSingleCarpoolAsync(userid, carpoolid);

            if (carpooluser == null)
            {
                return NotFound();
            }

            return carpooluser;
        }
    }
}