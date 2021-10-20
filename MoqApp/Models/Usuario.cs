using System;
using System.Collections.Generic;

#nullable disable

namespace MoqApp.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public string CodigoUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
