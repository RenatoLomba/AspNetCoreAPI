using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Security
{
    //CLASSE DE CONFIGURAÇÃO DE TOKEN
    public class TokenConfigurations
    {
        public string Audience { get; set; } //PUBLICO
        public string Issuer { get; set; } //EMISSOR
        public double Seconds { get; set; } //SEGUNDOS
    }
}
