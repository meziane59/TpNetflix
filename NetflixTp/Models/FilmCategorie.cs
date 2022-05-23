using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class FilmCategorie
    {
        public FilmCategorie()
        {
            FilmFilmCategories = new HashSet<FilmFilmCategorie>();
        }

        public int IdFilmCategorie { get; set; }
        public string NomCategorie { get; set; }

        public virtual ICollection<FilmFilmCategorie> FilmFilmCategories { get; set; }
    }
}
