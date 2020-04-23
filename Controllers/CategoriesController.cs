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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoriesService _cs;
        public CategoriesController(CategoriesService cs)
        {
            _cs = cs;
        }
        [HttpGet]
        [Authorize]

        public ActionResult<IEnumerable<Category>> Get()
        {
           try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.Get(userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Category> GetById(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                return Ok(_cs.GetById(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Authorize]
        public ActionResult<Category> Post([FromBody] Category newCategory)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newCategory.UserId = userId;
                return Ok(_cs.Create(newCategory));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // [HttpPut("{id}")]
        // [Authorize]
        // public ActionResult<Category> Edit(int id, [FromBody] Category updatedCategory)
        // {
        //     try
        //     {
        //         string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        //         // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
        //         updatedCategory.UserId = userId;
        //         updatedCategory.Id = id;
        //         return Ok(_cs.Edit(updatedCategory));
        //     }
        //     catch (Exception e)
        //     {
        //         return BadRequest(e.Message);
        //     }
        // }

        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Category> Delete(int id)
        {
            try
            {
                string userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // NOTE DONT TRUST THE USER TO TELL YOU WHO THEY ARE!!!!
                return Ok(_cs.Delete(id, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}