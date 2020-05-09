﻿using Microsoft.AspNetCore.Mvc;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _service;
        public EnvironmentController(IEnvironmentService service)
        {
            _service = service;
        }

        // GET: api/Environment
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var environment = _service.Get(id);

            if (environment is null)
                return NoContent();

            return Ok(environment);
        }

        // POST: api/Environment
        [HttpPost]
        public IActionResult Post([FromBody] EnvironmentViewModel environmentDTO)
        {
            var environment = _service.Add(environmentDTO);

            if (environment is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { environment.Id }, environment);
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnvironmentViewModel environmentDTO)
        {
            bool resultUpdate = _service.Update(environmentDTO);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
