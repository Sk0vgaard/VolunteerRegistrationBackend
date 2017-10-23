using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Facade;
using VolunteerRegistrationBLL.Services;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Volunteers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Volunteers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}