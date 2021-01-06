using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Municipio;
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
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipioService _service;
        public MunicipiosController(IMunicipioService service)
        {
            _service = service;
        }

        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetAll();
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
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
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetCompleteById(id);
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
        [HttpGet("{codIBGE}")]
        public async Task<ActionResult> GetCompleteByIBGE(int codIBGE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetCompleteByIBGE(codIBGE);
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
        public async Task<ActionResult> Post([FromBody] MunicipioDTOEntry municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MunicipioValidator validator = new MunicipioValidator();
            ValidationResult valResult = validator.Validate(municipio, options => options.IncludeRuleSets("Post"));

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            } else
            {
                try
                {
                    var result = await _service.Post(municipio);
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
        public async Task<ActionResult> Put([FromBody] MunicipioDTOEntry municipio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MunicipioValidator validator = new MunicipioValidator();
            ValidationResult valResult = validator.Validate(municipio, options => options.IncludeRuleSets("Put"));

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }
            else
            {
                try
                {
                    var result = await _service.Put(municipio);
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
