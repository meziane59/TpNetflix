using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class TypeUtilisateur
    {
        public TypeUtilisateur()
        {
            TypeUtilisateurDroits = new HashSet<TypeUtilisateurDroit>();
            Utilisateurs = new HashSet<Utilisateur>();
        }

        public int IdTypeUtilisateur { get; set; }
        public bool? IsAdmin { get; set; }

        public virtual ICollection<TypeUtilisateurDroit> TypeUtilisateurDroits { get; set; }
        public virtual ICollection<Utilisateur> Utilisateurs { get; set; }
    }
}
