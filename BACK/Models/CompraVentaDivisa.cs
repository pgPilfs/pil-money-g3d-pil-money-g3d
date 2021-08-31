using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class CompraVentaDivisa
    {
        public int IdTipo { get; set; }
        public int IdExtraccion { get; set; }
        public int IdDeposito { get; set; }
        public decimal Monto { get; set; }
        public int IdMoneda { get; set; }

        public virtual Deposito IdDepositoNavigation { get; set; }
        public virtual Extraccione IdExtraccionNavigation { get; set; }
        public virtual TipoMonedum IdMonedaNavigation { get; set; }
        public virtual TiposDepExtr IdTipoNavigation { get; set; }
    }
}
