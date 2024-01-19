using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_TransSP.Models
{
    public class ParadaModel
    {
        #region Atributos
        public long Id { get; private set; }
        public string Name { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public IList<LinhaModel> Linhas { get; private set; }
        #endregion


    }
}
