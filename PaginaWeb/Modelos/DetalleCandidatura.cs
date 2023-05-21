using System;
using System.Collections.Generic;

namespace PaginaWeb.Modelos
{
    public partial class DetalleCandidatura
    {
        public int IdDetalleCandidatura { get; set; }
        public int IdCandidatura { get; set; }
        public int IdProceso { get; set; }

        public virtual Candidatura IdCandidaturaNavigation { get; set; } = null!;
        public virtual Proceso IdProcesoNavigation { get; set; } = null!;
    }
}
