using Spotify.Domain.Conta.Exception;
using Spotify.Domain.Transacao.Agreggates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.Agreggates
{
    public class Cartao
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETIÇAO_TRANSACAO = 1;
        public Guid Id { get; set; }
        public Boolean Ativo { get; set; }
        public Decimal Limite { get; set; }
        public String Numero { get; set; }
        public List<Transacao.Agreggates.Transacao>? Transacoes { get; set; }

        public Cartao() {
            this.Transacoes = new List<Transacao.Agreggates.Transacao>();
        } 

        public void CriarTransacao(string merchant, Decimal valor, string descricao)
        {
            var erroValidacao = new CartaoException();


            //Verificando se o cartao esta ativo
            this.CartaoAtivo(erroValidacao);
            var transacao = new Transacao.Agreggates.Transacao();
            transacao.Merchant = new Transacao.ValueObject.Merchant() { Nome = merchant };
            transacao.ValorTransacao=valor;
            transacao.Descricao = descricao;
            transacao.DtTransacao=DateTime.Now;


            //Verifica o limite
            this.VerificaLimiteDisponivel(transacao, erroValidacao);
            

            //Validar a transacao, e verifica se nao ocorreu erros na validacao
            this.ValidarTransacao(transacao, erroValidacao);
            erroValidacao.TesteValidacao();

            //Criar numero de autorizacao
            transacao.Id=Guid.NewGuid();

            //Debita o valor do limite
            this.Limite = this.Limite - transacao.ValorTransacao;

            //aDICIONAR NOVA TRANSACAO
            this.Transacoes.Add(transacao);
            




        }

        private void CartaoAtivo(CartaoException erroValidacao)
        {
            if (this.Ativo == false)
            {
                erroValidacao.EnviaExcessao(new Core.Exception.BusinessValidation()
                {
                    MensagemErro = "Você não possui limite suficiente no cartão!",
                    NomeErroDefaul = nameof(CartaoException)

                });
            }
        
        }
        private void VerificaLimiteDisponivel(Transacao.Agreggates.Transacao transacao,CartaoException erroValidacao )
        {
            if (transacao.ValorTransacao > this.Limite)
            {
                erroValidacao.EnviaExcessao(new Core.Exception.BusinessValidation()
                {
                    MensagemErro = "Este cartão não está ativo!",
                    NomeErroDefaul = nameof(CartaoException)
                });
            }
        }
        private void ValidarTransacao(Transacao.Agreggates.Transacao transacao,CartaoException erroValidacao)
        {
            var transacoesRecentes = this.Transacoes.Where(x => x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (transacoesRecentes?.Count() >= 3)
            {
                erroValidacao.EnviaExcessao(new Core.Exception.BusinessValidation() { MensagemErro = "você excedeu o limite de periodo de compras do cartão!", NomeErroDefaul = nameof(CartaoException) });
            }


            if (transacoesRecentes?.Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper()
                                                   && x.ValorTransacao == transacao.ValorTransacao).Count() == REPETIÇAO_TRANSACAO)
            {
                erroValidacao.EnviaExcessao(new Core.Exception.BusinessValidation() { MensagemErro = "Transação Duplicada!", NomeErroDefaul = nameof(CartaoException) });

            }
        }

    }
}
