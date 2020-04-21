using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly RoomsService _rs;
        public RoomsController(RoomsService rs)
        {
            _rs = rs;
        }
        [HttpGet]
        [Authorize]

        public ActionResult<IEnumerable<Room>> Get()
        {
           try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_rs.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Room> GetById(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_rs.GetById(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public ActionResult<Room> Post([FromBody] Room newRoom)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newRoom.UserId = userId;
                return Ok(_rs.Create(newRoom));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}