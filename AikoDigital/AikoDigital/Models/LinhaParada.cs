namespace AikoDigital.Models
{
    public class LinhaParada
    {
        public long LinhaId { get; set; }

        public Linha? Linhas { get; set; }

        public long ParadaId { get; set; }

        public Parada? Paradas { get; set; }
    }
}
