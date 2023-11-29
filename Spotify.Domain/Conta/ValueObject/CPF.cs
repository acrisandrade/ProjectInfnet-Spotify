using Spotify.Domain.Conta.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Domain.Conta.ValueObject
{
    public class CPF
    {
        private CPFException _validacaoErro = new CPFException();
        public CPF (string numero)
        {
            this.Numero = numero;
            if(this.ValidarCPF() == false )
            {

                this._validacaoErro.AdicionaErro(new Core.Exception.BusinessValidation()
                {
                    MensagemErro="CPF Invalido!",NomeErroDefaul=nameof(CPFException)
                });
            }
        }
        public String Numero { get; set; }

        public string NumeroFormatado ()
        { 
        return Convert.ToInt64(this.Numero).ToString("###.###.###-##"); 
        }  
        //Valida se o numero inserio,e um CPF valido
        public bool ValidarCPF()
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            var cpf = this.Numero.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}
