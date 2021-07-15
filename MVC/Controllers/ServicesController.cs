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
    public class ServicesController : ControllerBase
    {
        private readonly ServiceInterface _serviceInterface;
        public ServicesController(ServiceInterface serviceInterface)
        {
            _serviceInterface = serviceInterface;
        }

        [HttpGet]
        public async Task<List<CarServices>> Get()
        {
            return await _serviceInterface.Get();
        }

        [HttpGet("{id}")]
        public async Task<CarServices> GetDetail(int id)
        {
            return await _serviceInterface.GetDetails(id);
        }

        [HttpPost]
        public async Task<ActionResult<CarServices>> Create(CarServices CarServices)
        {
            var NewCarServices = await _serviceInterface.Create(CarServices);
            return CreatedAtAction(nameof(GetDetail), new { id = NewCarServices.Id }, NewCarServices);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutServices(int id, [FromBody] CarServices CarServices)
        {
            await _serviceInterface.Update(id,CarServices);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Services = await _serviceInterface.GetDetails(id);
            if (Services == null)
            {
                return NotFound();
            }
            await _serviceInterface.Delete(Services.Id);
            return NoContent();
        }



    }
}
