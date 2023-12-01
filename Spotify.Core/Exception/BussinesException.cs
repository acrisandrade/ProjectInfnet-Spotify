using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Core.Exception
{
    public class BussinesException : System.Exception
    {
        public List<BusinessValidation> Erros {  get; set; } = new List<BusinessValidation>();

        public BussinesException() { }

        public  BussinesException(BusinessValidation validation)
        {
            this.EnviaExcessao(validation);
        }

        public void EnviaExcessao(BusinessValidation validation)
        {
           this.Erros.Add(validation); 
        }

        public void TesteValidacao()
        {
            if (this.Erros.Any())
                throw this;
        }

    }

    public class BusinessValidation
    {
        public string NomeErroDefaul { get; set; } = "Erro de validaçâo!";
        public string MensagemErro { get; set; }
    }
}
