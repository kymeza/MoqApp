using System;
using System.Collections.Generic;

#nullable disable

namespace MoqApp.Models
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Logs = new HashSet<Log>();
            Transacciones = new HashSet<Transaccione>();
        }

        public string CodigoUsuario { get; set; }
        public string CodigoCuenta { get; set; }
        public string DescripcionCuenta { get; set; }

        public virtual Usuario CodigoUsuarioNavigation { get; set; }
        public virtual ICollection<Log> Logs { get; set; }
        public virtual ICollection<Transaccione> Transacciones { get; set; }
    }
}
