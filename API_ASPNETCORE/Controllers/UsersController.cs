using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces.ServiceInterfaces;
using Domain.Validators;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    //http://localhost:5000/api/users
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //GET ALL USERS
        [Authorize("Bearer")] //REQUER AUTORIZAÇÃO DE VALIDAÇÃO
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            //VERIFICA SE O QUE ESTÁ VINDO DA REQUISIÇÃO É VÁLIDO, SE NÃO RETORNA UM BADREQUEST
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 Bad Request - Sintaxe Inválida
            }
            try
            {
                return Ok(await _service.GetAll()); //200 OK - Requisição Bem Sucedida
            }
            catch (ArgumentException ex) //Exceção de Argumento (Controller)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //GET USER BY ID
        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetById")] //Configura o parâmetro do método e o Nome dele na Rota
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //POST
        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity user) //RECEBE UM JSON (FROMBODY) QUE SERÁ UMA ENTIDADE USER
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserValidator validator = new UserValidator();
            ValidationResult valResult = validator.Validate(user, options => options.IncludeRuleSets("Post"));

            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }

            try
            {
                var result = await _service.Post(user); //EXECUTA O METODO POST PARA CRIAR USUÁRIO NO BANCO
                if (result != null)
                {
                    //RETORNA UMA REQUISIÇÃO 201 PASSANDO UM LINK PARA ACESSAR O GETBYID COM O NOVO OBJETO CRIADO
                    return Created(new Uri(Url.Link("GetById", new { id = result.Id })), result);
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

        //PUT
        [Authorize("Bearer")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserValidator validator = new UserValidator();
            ValidationResult valResult = validator.Validate(user, options => options.IncludeRuleSets("Put"));
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }
            try
            {
                var result = await _service.Put(user);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Tentativa de atualizar usuário não existente");
                }
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //DELETE
        [Authorize("Bearer")]
        [HttpDelete("{id}")] //ESPERA UM PARÂMETRO NA ROTA
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
