using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VolunteerRegistrationBLL.BusinessObjects;
using VolunteerRegistrationBLL.Services.Interfaces;

namespace VolunteerRegistrationRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Guilds")]
    public class GuildController : Controller
    {
        private readonly IGuildService _guildService;

        public GuildController(IGuildService guildService)
        {
            // The IBLLFacade will "magically" be instatiated from the Startup -> ConfigureServices -> services.AddScoped!
            _guildService = guildService;
        }

        // GET: api/Guild
        [HttpGet]
        public IEnumerable<GuildBO> Get()
        {
            return _guildService.GetAll();
        }

        // GET: api/Guild/5
        [HttpGet("{id}", Name = "GetGuilds")]
        public IActionResult Get(int id)
        {
            var guild = _guildService.Get(id);
            if (guild == null) return NotFound();
            return Ok(guild);
        }
        
        // POST: api/Guild
        [HttpPost]
        public IActionResult Post([FromBody]GuildBO guild)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var createdGuild = _guildService.Create(guild);
            return Ok(createdGuild);
        }
        
        // PUT: api/Guild/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]GuildBO guild)
        {
            if (id != guild.Id) return BadRequest("Id does not match guild id!");
            var updatedGuild = _guildService.Update(guild);
            if (updatedGuild == null) return NotFound();
            return Ok(updatedGuild);
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _guildService.Delete(id);
            if (deleted == false) return NotFound();
            return Ok();
        }
    }
}
