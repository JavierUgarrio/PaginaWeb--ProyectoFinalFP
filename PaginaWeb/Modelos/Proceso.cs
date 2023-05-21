using System;
using System.Collections.Generic;

namespace PaginaWeb.Modelos
{
    public partial class Proceso
    {
        public Proceso()
        {
            DetalleCandidaturas = new HashSet<DetalleCandidatura>();
        }

        public int IdProceso { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Cliente { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<DetalleCandidatura> DetalleCandidaturas { get; set; }
    }
}
