using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Abonnements = new HashSet<Abonnement>();
            UtilisateurProfils = new HashSet<UtilisateurProfil>();
        }

        public int IdUtilisateur { get; set; }
        public string NomProfil { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Mdp { get; set; }
        public int? IdTypeUtilisateur { get; set; }

        public virtual TypeUtilisateur IdTypeUtilisateurNavigation { get; set; }
        public virtual ICollection<Abonnement> Abonnements { get; set; }
        public virtual ICollection<UtilisateurProfil> UtilisateurProfils { get; set; }
    }
}
