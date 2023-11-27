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
            //Verificando se o cartao esta ativo
            this.CartaoAtivo();
            var transacao = new Transacao.Agreggates.Transacao();
            transacao.Merchant = new Transacao.ValueObject.Merchant() { Nome = merchant };
            transacao.ValorTransacao=valor;
            transacao.Descricao = descricao;
            transacao.DtTransacao=DateTime.Now;


            //Verifica o limite
            this.VerificaLimiteDisponivel(transacao);

            //Validar a transacao
            this.ValidarTransacao(transacao);


            //Criar numero de autorizacao
            transacao.Id=Guid.NewGuid();

            //aDICIONAR NOVA TRANSACAO
            this.Transacoes.Add(transacao);
        }

        private void CartaoAtivo()
        {
            if (this.Ativo == false)
            {

                //Criar excessao de negocio
            }
        
        }
        private void VerificaLimiteDisponivel(Transacao.Agreggates.Transacao transacao)
        {
            if (transacao.ValorTransacao > this.Limite)
            {
                //Criar  excecao de negocios
            }
        }
        private void ValidarTransacao(Transacao.Agreggates.Transacao transacao)
        {
            var transacoesRecentes = this.Transacoes.Where(x => x.DtTransacao >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));
            if (transacoesRecentes?.Count() >= 3)
            {
                //Criar regras de exccao
            }
            if (transacoesRecentes?.Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToUpper()
                                                   && x.ValorTransacao == transacao.ValorTransacao).Count() == REPETIÇAO_TRANSACAO)
            {

            }
        }

    }
}
