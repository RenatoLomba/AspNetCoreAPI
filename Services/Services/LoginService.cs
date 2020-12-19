using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Interfaces.RepositoryInterfaces;
using Domain.Interfaces.ServiceInterfaces;
using Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Services.Services
{
    //SERVIÇO DE AUTENTICAÇÃO DE LOGIN
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
        private readonly SigningConfigurations _signConfig;
        private readonly TokenConfigurations _tokenConfig;
        private readonly IConfiguration _config;

        public LoginService(IUserRepository userRepository, SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _signConfig = signingConfigurations;
            _tokenConfig = tokenConfigurations;
            _config = configuration;
        }

        //FAZ UMA BUSCA NO BANCO PELO USUÁRIO PELO EMAIL
        public async Task<object> GetByEmail(LoginDTO login)
        {
            var user = new UserEntity();

            user = await _userRepository.SelectAsync(login.Email);

            if (user != null)
            {
                //CRIA UM IDENTITY (CREDENCIAL)
                var identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email),
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //JTI O ID DO TOKEN SERÁ UM GUID
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.Email), //NOME DO TOKEN SERÁ O EMAIL DO USUÁRIO
                    }
                );
                DateTime createDate = DateTime.Now;
                DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfig.Seconds);
                var handler = new JwtSecurityTokenHandler();

                string token = CreateToken(identity, createDate, expirationDate, handler);
                return SuccessObject(createDate, expirationDate, token, user);
            }
            else
            {
                return null;
            }
        }

        //METODO UTILIZADO PARA CRIAÇÃO DO TOKEN
        private string CreateToken(ClaimsIdentity identity, DateTime createDate,
            DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
            var secutityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfig.Issuer,
                Audience = _tokenConfig.Audience,
                SigningCredentials = _signConfig.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate
            });

            var token = handler.WriteToken(secutityToken);
            return token;
        }

        //CRIA UM OBJETO DE SUCESSO COM O TOKEN E INFORMAÇÕES DO TOKEN
        private object SuccessObject(DateTime createDate, DateTime expirationDate, string token, UserEntity user)
        {
            return new
            {
                authenticated = true,
                message = "Usuário autenticado com sucesso",
                userEmail = user.Email,
                userName = user.Name,
                accessToken = token,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expirationDate = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
            };
        }
    }
}
