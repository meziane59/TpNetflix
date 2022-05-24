using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class FilmFilmCategorie
    {
        public int IdFilm { get; set; }
        public int IdFilmCategorie { get; set; }

        public virtual FilmCategorie IdFilmCategorieNavigation { get; set; }
        public virtual Film IdFilmNavigation { get; set; }
    }
}
