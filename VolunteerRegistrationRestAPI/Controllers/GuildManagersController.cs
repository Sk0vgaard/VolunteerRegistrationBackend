using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services.Interfaces;

namespace VolunteerRegistrationRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/GuildManagers")]
    public class GuildManagersController : Controller
    {
        private readonly IGuildManagerService _service;

        public GuildManagersController(IGuildManagerService service)
        {
            _service = service;
        }

        // GET: api/GuildManagers
        [HttpGet]
        public IEnumerable<GuildManagerBO> Get()
        {
            return _service.GetAll();
        }

        // GET: api/GuildManagers/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var entity = _service.Get(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // POST: api/GuildManagers
        [HttpPost]
        public IActionResult Post([FromBody] GuildManagerBO value)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var entity = _service.Create(value);
            return Ok(entity);
        }

        // PUT: api/GuildManagers/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GuildManagerBO value)
        {
            if (id != value.Id) return BadRequest("Id does not match guild id!");
            var entity = _service.Update(value);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (deleted == false) return NotFound();
            return Ok(deleted);
        }
    }
}