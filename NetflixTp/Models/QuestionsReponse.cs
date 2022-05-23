using System;
using System.Collections.Generic;

#nullable disable

namespace NetflixTp.Models
{
    public partial class QuestionsReponse
    {
        public int IdQuestionReponse { get; set; }
        public string Question { get; set; }
        public string Reponse { get; set; }
    }
}
