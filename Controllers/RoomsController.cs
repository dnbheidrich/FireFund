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
        private readonly CategoriesService _cs;

        public RoomsController(RoomsService rs, CategoriesService cs)
        {
            _rs = rs;
            _cs = cs;
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

        [HttpGet("{id}/categories")]
        [Authorize]

        public ActionResult<IEnumerable<Category>> GetCategoriesByRoomId(int id)
        {
            try
            {
                 string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.GetCategoriesByRoomId(id, userId));
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

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Room> Edit(int id, [FromBody] Room updatedRoom)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                updatedRoom.UserId = userId;
                updatedRoom.Id = id;
                return Ok(_rs.Edit(updatedRoom));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Room> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_rs.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}