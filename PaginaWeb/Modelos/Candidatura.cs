using System;
using System.Collections.Generic;

namespace PaginaWeb.Modelos
{
    public partial class Candidatura
    {
        public Candidatura()
        {
            DetalleCandidaturas = new HashSet<DetalleCandidatura>();
        }

        public int IdCandidatura { get; set; }
        public int IdCliente { get; set; }
        public string Empresa { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Usuario IdClienteNavigation { get; set; } = null!;
        public virtual ICollection<DetalleCandidatura> DetalleCandidaturas { get; set; }
    }
}
