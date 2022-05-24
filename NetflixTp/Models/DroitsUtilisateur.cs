using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class DroitsUtilisateur
    {
        public DroitsUtilisateur()
        {
            TypeUtilisateurDroits = new HashSet<TypeUtilisateurDroit>();
        }

        public int IdDroitsUtilisateurs { get; set; }
        public string NomDroits { get; set; }

        public virtual ICollection<TypeUtilisateurDroit> TypeUtilisateurDroits { get; set; }
    }
}
