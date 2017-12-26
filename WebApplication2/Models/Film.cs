using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Film
    {
        public int FilmId { get; set; }
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public List<FilmZanr> Zanrovi { get; set; }
    }
}
