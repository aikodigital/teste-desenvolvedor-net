using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_TransSP.Models
{
    public class PosicaoVeiculoModel
    {

        #region Atributos
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public long VeiculoId { get; private set; }
        #endregion

    }
}
