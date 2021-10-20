using System;
using System.Collections.Generic;

#nullable disable

namespace MoqApp.Models
{
    public partial class Transaccione
    {
        public string CodigoUsuario { get; set; }
        public string CodigoCuenta { get; set; }
        public int LineaTransaccion { get; set; }
        public double Monto { get; set; }

        public virtual Cuenta Codigo { get; set; }
    }
}
