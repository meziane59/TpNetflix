using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Film
    {
        public Film()
        {
            Episodes = new HashSet<Episode>();
            FilmFilmCategories = new HashSet<FilmFilmCategorie>();
            ProfilFilms = new HashSet<ProfilFilm>();
        }

        public int IdFilm { get; set; }
        public string Titre { get; set; }
        public string AnneeFilm { get; set; }
        public string CommentaireFilm { get; set; }
        public int? IdTypeFilm { get; set; }

        public virtual TypeFilm IdTypeFilmNavigation { get; set; }
        public virtual ICollection<Episode> Episodes { get; set; }
        public virtual ICollection<FilmFilmCategorie> FilmFilmCategories { get; set; }
        public virtual ICollection<ProfilFilm> ProfilFilms { get; set; }
    }
}
