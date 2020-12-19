using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Security
{
    //CLASSE DE CONFIGURAÇÃO DE LOGIN
    public class SigningConfigurations
    {
        public SecurityKey Key { get; set; } //CHAVE
        public SigningCredentials SigningCredentials { get; set; } //CREDENCIAIS DE LOGIN

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                //GERA UMA CHAVE DE SEGURANÇA RSA
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            //GERA UMA CREDENCIAL DE SEGURANÇA A PARTIR DA CHAVE
            SigningCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}
