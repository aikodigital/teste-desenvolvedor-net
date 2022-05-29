namespace Application.ViewModels
{
    public class SaidaViewModel
    {
        public SaidaViewModel()
        {

        }

        public SaidaViewModel(object dados)
        {
            Sucesso = true;
            Mensagem = "Operação executada com sucesso!";
            Dados = dados;
        }

        public SaidaViewModel(string mensagem, object dados)
        {
            Sucesso = true;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }

        public string Mensagem { get; set; }

        public object Dados { get; set; }
    }
}
