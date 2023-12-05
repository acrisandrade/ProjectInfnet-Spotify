﻿using Spotify.Aplication.Conta;
using Spotify.Aplication.Conta.Dto;
using Spotify.Core.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Application
{
    public class UsuarioServiceTeste
    {
        [Fact]  
        public void CriacontaComSucesso()
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
            UsuarioService service = new UsuarioService();
            service.CriarConta(criarContaDTO);

            Assert.True(criarContaDTO.Id!=Guid.Empty);
        }

        //Teste caso nao encontre a conta
        [Fact]

        public void NaocriaContaComPlanoInvalido()
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
                PlanoId =  Guid.NewGuid()
            };
            UsuarioService service = new UsuarioService();
            Assert.Throws<BussinesException>(() => service.CriarConta(criarContaDTO));

        }
    }

}
