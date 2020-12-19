using System;
using FluentValidation.Results;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.ServiceInterfaces;
using Domain.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }

        //METODO PARA VALIDAR USUÁRIO PELO EMAIL
        [AllowAnonymous] //NÃO REQUER AUTORIZAÇÃO
        [HttpPost]
        public async Task<object> Login([FromBody] LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //CRIA O VALIDATOR
            LoginValidator validator = new LoginValidator();
            //CHAMA O VALIDATOR
            ValidationResult valResult = validator.Validate(login, options => options.IncludeRuleSets("LoginPwd"));

            //VALIDAÇÃO
            if (!valResult.IsValid)
            {
                return BadRequest(valResult.ToString("~"));
            }

            try
            {
                //BUSCA O EMAIL
                var result = await _service.GetByEmail(login);

                //CASO NÃO ENCONTRE O OBJETO, RETORNA NÃO ENCONTRADO
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

    }
}
