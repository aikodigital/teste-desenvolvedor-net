using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server_TransSP.Models
{
    public class VeiculoModel
    {
        #region Atributos
        public long Id { get; set; }
        public string Name { get; private set; }
        public string Modelo { get; private set; }
        public long Linhaid { get; private set; }
        #endregion


    }
}
