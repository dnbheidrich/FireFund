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
    public class ItemsController : ControllerBase
    {
        private readonly ItemsService _ls;
        public ItemsController(ItemsService ls)
        {
            _ls = ls;
        }
        [HttpGet]
        [Authorize]

        public ActionResult<IEnumerable<Item>> Get()
        {
           try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ls.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Item> GetById(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_ls.GetById(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        


        [HttpPost]
        [Authorize]
        public ActionResult<Item> Post([FromBody] Item newItem)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newItem.UserId = userId;
                return Ok(_ls.Create(newItem));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut("{id}")]
        // [Authorize]
        // public ActionResult<Item> Edit(int id, [FromBody] Item updatedItem)
        // {
        //     try
        //     {
        //         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //         // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
        //         updatedItem.UserId = userId;
        //         updatedItem.Id = id;
        //         return Ok(_cs.Edit(updatedItem));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Item> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_ls.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}