using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class TypeFilm
    {
        public TypeFilm()
        {
            Films = new HashSet<Film>();
        }

        public int IdTypeFilm { get; set; }
        public string NomTypeFilm { get; set; }

        public virtual ICollection<Film> Films { get; set; }
    }
}
