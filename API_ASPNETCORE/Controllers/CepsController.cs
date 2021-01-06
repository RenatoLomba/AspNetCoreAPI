using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Cep;
using Domain.Interfaces.ServiceInterfaces;
using Domain.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CepsController : ControllerBase
    {
        private readonly ICepService _service;
        public CepsController(ICepService service)
        {
            _service = service;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet("{cep}")]
        public async Task<ActionResult> GetByCep(string cep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetByCep(cep);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CepDTOEntry cep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CepValidator validator = new CepValidator();
            ValidationResult valResult = validator.Validate(cep, options => options.IncludeRuleSets("Post"));

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }
            else
            {
                try
                {
                    var result = await _service.Post(cep);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (ArgumentException ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] CepDTOEntry cep)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CepValidator validator = new CepValidator();
            ValidationResult valResult = validator.Validate(cep, options => options.IncludeRuleSets("Put"));

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }
            else
            {
                try
                {
                    var result = await _service.Put(cep);
                    if (result != null)
                    {
                        return Ok(result);
                    }
                    else
                    {
                        return BadRequest();
                    }
                }
                catch (ArgumentException ex)
                {
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Delete(id);
                if (result)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
