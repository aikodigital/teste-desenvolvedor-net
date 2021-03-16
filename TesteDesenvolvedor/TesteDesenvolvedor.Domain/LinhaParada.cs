namespace TesteDesenvolvedor.Domain
{
    public class LinhaParada
    {
        public long LinhaId { get; set; }
        public Linha Linha { get; set; }
        public long ParadaId { get; set; }
        public Parada Parada { get; set; }
    }
}