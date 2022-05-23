using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Profil
    {
        public Profil()
        {
            ProfilFilms = new HashSet<ProfilFilm>();
            UtilisateurProfils = new HashSet<UtilisateurProfil>();
        }

        public int IdProfil { get; set; }
        public string TypeProfil { get; set; }
        public string NomProfil { get; set; }

        public virtual ICollection<ProfilFilm> ProfilFilms { get; set; }
        public virtual ICollection<UtilisateurProfil> UtilisateurProfils { get; set; }
    }
}
