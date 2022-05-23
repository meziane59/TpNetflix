using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class Saison
    {
        public Saison()
        {
            Episodes = new HashSet<Episode>();
        }

        public int IdSaison { get; set; }
        public string NomSaison { get; set; }
        public string CommentaireSaison { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; }
    }
}
