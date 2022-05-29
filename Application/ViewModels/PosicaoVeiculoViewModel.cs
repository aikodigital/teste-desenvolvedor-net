using System;

namespace Application.ViewModels
{
    public class PosicaoVeiculoViewModel
    {
        public int Id { get; set; }

        public virtual IdNomeViewModel Veiculo { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public DateTime? DataPosicao { get; set; }
    }
}
