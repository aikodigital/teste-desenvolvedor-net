namespace Domain.Models
{
    public class RelLinhaParada
    {
        public int Id { get; set; }

        public int IdLinha { get; set; }

        public virtual Linha Linha { get; set; }

        public int IdParada { get; set; }

        public virtual Parada Parada { get; set; }
    }
}
