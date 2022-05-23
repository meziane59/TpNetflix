using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Abonnement
    {
        public int IdAbonnement { get; set; }
        public DateTime? DebutAbonnement { get; set; }
        public DateTime? FinAbonnement { get; set; }
        public bool? AbonnementActif { get; set; }
        public int? IdUtilisateur { get; set; }

        public virtual Utilisateur IdUtilisateurNavigation { get; set; }
    }
}
