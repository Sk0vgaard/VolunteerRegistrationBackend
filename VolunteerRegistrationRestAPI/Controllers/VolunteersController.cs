using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services.Interfaces;

namespace VolunteerRegistrationRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Volunteers")]
    public class VolunteersController : Controller
    {
        private readonly IVolunteerService _service;

        public VolunteersController(IVolunteerService service)
        {
            // The IBLLFacade will "magically" be instatiated from the Startup -> ConfigureServices -> services.AddScoped!
            _service = service;
        }

        // GET: api/Volunteers
        [HttpGet]
        public IEnumerable<VolunteerBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/Volunteers/5
        [HttpGet("{id}", Name = "GetVolunteers")]
        public IActionResult Get(int id)
        {
            var volunteer = _service.Get(id);
            if (volunteer == null) return NotFound();
            return Ok(volunteer);
        }

        // POST: api/Volunteers
        [HttpPost]
        public IActionResult Post([FromBody] VolunteerBO volunteer)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_service.Create(volunteer));
        }

        // PUT: api/Volunteers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] VolunteerBO volunteer)
        {
            if (id != volunteer.Id) return BadRequest("Id does not match volunteer id!");
            var updatedVolunteer = _service.Update(volunteer);
            if (updatedVolunteer == null) return NotFound();
            return Ok(updatedVolunteer);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (deleted == false) return NotFound();
            return Ok();
        }
    }
}