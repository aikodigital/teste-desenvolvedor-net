using System;
using System.Collections;
using System.Collections.Generic;

namespace Server_TransSP.Models
{
    public class LinhaModel
    {
        #region Atributos
        public long Id { get; private set; }
		public string Name { get; private set; }
		public IList<ParadaModel> Paradas { get; private set; }
        public IList<VeiculoModel> Veiculos { get; private set; }
        #endregion

    }
}
