﻿using Spotify.Domain.Conta.Agreggates;
using Spotify.Domain.Conta.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Spotify.Tests.Domain.Conta
{
    public class CartaoTest
    {
        [Fact]
        public void CriaTransacaoComSucesso()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 1500M,
                Numero = "1234567890"
            };
            cartao.CriarTransacao("star", 10M, "Pagamento plano");
            Assert.True(cartao.Transacoes.Count > 0);
        }


        [Fact]
        public void NaoCriaTransacaoComCaratoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = false,
                Limite = 1500M,
                Numero = "1234567890"
            };

            Assert.Throws<CartaoException>(() => cartao.CriarTransacao("star", 10M, "Pagamento plano"));
        }


        [Fact]
        public void NaoCriaTransacaoSemLimiteNoCaratoo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 20M,
                Numero = "1234567890"
            };

            Assert.Throws<CartaoException>(() => cartao.CriarTransacao("star", 23M, "Pagamento plano"));
        }


        [Fact]
        public void NaoCriaTransacaoDeValorDuplicadO()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 2000M,
                Numero = "6465465466",
            };

            cartao.Transacoes.Add(new Spotify.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new Spotify.Domain.Transacao.ValueObject.Merchant()
                {
                    Nome = "star"
                },
                ValorTransacao = 19M,
                Descricao = "Há uma nova compra!"
            });

            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("star", 19M, "Transacao!"));

        }

        [Fact]
        public void NaoDeveCriarTransacaoComMuitaFrequencia()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Ativo = true,
                Limite = 2000M,
                Numero = "1234567890",
            };

            cartao.Transacoes.Add(new Spotify.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-1),
                Id = Guid.NewGuid(),
                Merchant = new Spotify.Domain.Transacao.ValueObject.Merchant()
                {
                    Nome = "star"
                },
                ValorTransacao = 19M,
                Descricao = "Há uma nova compra!"
            });

            cartao.Transacoes.Add(new Spotify.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now.AddMinutes(-0.5),
                Id = Guid.NewGuid(),
                Merchant = new Spotify.Domain.Transacao.ValueObject.Merchant()
                {
                    Nome = "star"
                },
                ValorTransacao = 19M,
                Descricao = "Há uma nova compra!"
            });

            cartao.Transacoes.Add(new Spotify.Domain.Transacao.Agreggates.Transacao()
            {
                DtTransacao = DateTime.Now,
                Id = Guid.NewGuid(),
                Merchant = new Spotify.Domain.Transacao.ValueObject.Merchant()
                {
                    Nome = "star"
                },
                ValorTransacao = 19M,
                Descricao = "Há uma nova compra!"
            });


            Assert.Throws<CartaoException>(
                () => cartao.CriarTransacao("Dummy", 19M, "Dummy Transacao"));
        }
    }


}




    


