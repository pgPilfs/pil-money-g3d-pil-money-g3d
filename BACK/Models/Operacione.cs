using System;
using System.Collections.Generic;

#nullable disable

namespace Prueba.Models
{
    public partial class Operacione
    {
        public int IdOperacion { get; set; }
        public int? Cvu { get; set; }
        public DateTime? FechaOperacion { get; set; }
        public TimeSpan? HoraOprecion { get; set; }
        public int? IdDeposito { get; set; }
        public int? IdExtraccion { get; set; }
        public int? IdTransferencia { get; set; }
        public int? IdInversion { get; set; }
        public int? IdPago { get; set; }

        public virtual Cuenta CvuNavigation { get; set; }
        public virtual Deposito IdDepositoNavigation { get; set; }
        public virtual Extraccione IdExtraccionNavigation { get; set; }
        public virtual Inversione IdInversionNavigation { get; set; }
        public virtual Pago IdPagoNavigation { get; set; }
        public virtual Transferencia IdTransferenciaNavigation { get; set; }
    }
}
