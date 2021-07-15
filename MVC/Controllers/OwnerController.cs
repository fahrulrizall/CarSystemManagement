using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Interface;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : Controller
    {
        private readonly OwnerInterface _ownerInterface;
        public OwnerController(OwnerInterface ownerInterface)
        {
            _ownerInterface = ownerInterface;
        }

        [HttpGet]
        public async Task<List<CarOwner>> Get()
        {

            return await _ownerInterface.Get();
        }

        [HttpGet("{id}")]
        public async Task<CarOwner> GetDetail(int id)
        {
            return await _ownerInterface.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<CarOwner>> Create(CarOwner carOwner)
        {
            var NewCarOwner = await _ownerInterface.Create(carOwner);
            return CreatedAtAction(nameof(GetDetail), new { id = NewCarOwner.Id }, NewCarOwner);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutOwner (int id,[FromBody]CarOwner carOwner)
        {
            await _ownerInterface.Update(id,carOwner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var Owner = await _ownerInterface.GetDetails(id);
            if (Owner == null)
            {
                return NotFound();
            }
            await _ownerInterface.Delete(Owner.Id);
            return NoContent();
        }


    }
}
