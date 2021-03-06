﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.User;
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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        //GET ALL USERS
        [Authorize("Bearer", Roles = "Administrador")] //REQUER AUTORIZAÇÃO DE VALIDAÇÃO
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
                var result = await _service.GetAll();
                return Ok(result); //200 OK - Requisição Bem Sucedida
            }
            catch (ArgumentException ex) //Exceção de Argumento (Controller)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //GET USER BY ID
        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet("{id}")] //Configura o parâmetro do método e o Nome dele na Rota
        public async Task<ActionResult> GetById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Get(id);
                if(result != null)
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

        //GET BY EMAIL
        [Authorize("Bearer", Roles = "Administrador")]
        [HttpGet("{email}")] //Configura o parâmetro do método e o Nome dele na Rota
        public async Task<ActionResult> GetByEmail(string email)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.GetByEmail(email);
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

        //POST
        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserDTOEntry user) //RECEBE UM JSON (FROMBODY) QUE SERÁ UMA ENTIDADE USER
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
            } else
            {
                try
                {
                    var result = await _service.Post(user); //EXECUTA O METODO POST PARA CRIAR USUÁRIO NO BANCO
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

        //PUT
        [Authorize("Bearer", Roles = "Administrador")]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserDTOEntry user)
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
            } else
            {
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
            
        }

        //DELETE
        [Authorize("Bearer", Roles = "Administrador")]
        [HttpDelete("{id}")] //ESPERA UM PARÂMETRO NA ROTA
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _service.Delete(id);
                if(result)
                {
                    return Ok(result);
                } else
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
