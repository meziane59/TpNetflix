using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class UtilisateurProfil
    {
        public int IdUtilisateur { get; set; }
        public int IdProfil { get; set; }

        public virtual Profil IdProfilNavigation { get; set; }
        public virtual Utilisateur IdUtilisateurNavigation { get; set; }
    }
}
