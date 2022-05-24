using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Episode
    {
        public int IdEpisode { get; set; }
        public string NomEpisode { get; set; }
        public string CommentaireEpisode { get; set; }
        public string AnneeEpisode { get; set; }
        public string Realisateur { get; set; }
        public int? Duree { get; set; }
        public string AgeVisualisation { get; set; }
        public string LienVideo { get; set; }
        public int? NbVues { get; set; }
        public int? IdFilm { get; set; }
        public int? IdSaison { get; set; }

        public virtual Film IdFilmNavigation { get; set; }
        public virtual Saison IdSaisonNavigation { get; set; }
    }
}
