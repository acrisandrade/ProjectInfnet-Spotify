namespace Spotify.API.ErrosHandling
{
    public class ErrosHandling
    {
        public List<ErroeMessagem> Erros { get; set; } = new List<ErroeMessagem>();
        public string DescricaoErro = "Erro ao processar requisição!";
    }
    public class ErroeMessagem
    {
        public string Mensagem { get; set; }
        public string campo { get; set;}

    }

}
