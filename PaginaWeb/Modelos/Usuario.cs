using System;
using System.Collections.Generic;

namespace PaginaWeb.Modelos
{
    public partial class Usuario
    {
        public Usuario()
        {
            Candidaturas = new HashSet<Candidatura>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public int Telefono { get; set; }
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<Candidatura> Candidaturas { get; set; }
    }
}
