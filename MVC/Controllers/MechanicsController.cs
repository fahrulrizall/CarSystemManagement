using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC.Interface;
using MVC.Models;

namespace MVC.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    
    public class MechanicsController : ControllerBase
    {
        private readonly MechanicsInterface _mechanicsInterface;
        public MechanicsController(MechanicsInterface mechanicsInterface)
        {
            _mechanicsInterface = mechanicsInterface;
        }

        [HttpGet]
        public async Task<List<Mechanics>> Get()
        {
            return await _mechanicsInterface.Get();
        }

        [HttpGet("{id}")]
        public async Task<Mechanics> GetDetail(int id)
        {
            return await _mechanicsInterface.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<Mechanics>> Create(Mechanics Mechanics)
        {
            var NewMechanics = await _mechanicsInterface.Create(Mechanics);
            return CreatedAtAction(nameof(GetDetail), new { id = NewMechanics.Id }, NewMechanics);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutMechanics(int id, [FromBody] Mechanics Mechanics)
        {
            await _mechanicsInterface.Update(id,Mechanics);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Mechanics = await _mechanicsInterface.GetDetails(id);
            if (Mechanics == null)
            {
                return NotFound();
            }
            await _mechanicsInterface.Delete(Mechanics.Id);
            return NoContent();
        }


    }
}
