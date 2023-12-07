using Microsoft.Extensions.Logging;
using Spotify.API.Controllers;
using Spotify.Aplication.Conta.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Controller
{
    public class usuarioControllerTest
    {
        [Fact]
        public void ChamaMetodoPostCriarUsuario()
        {
            CriarContaDTO criarContaDTO = new CriarContaDTO()
            {
                Nome = "Leia",
                CPF = "311.945.920-82",
                Cartao = new CartaoDTO()
                {
                    Ativo = true,
                    Limite = 1000,
                    Numero = "5349 8913 9384 1193"
                },
                PlanoId = new Guid("b2a55062-bc07-45dc-b4b2-6754877c1c31")
            };
        
        }
    }
}
