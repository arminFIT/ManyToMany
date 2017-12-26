using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class Zanr
    {
        public int ZanrId { get; set; }
        public string Naziv { get; set; }
        public List<FilmZanr> Filmovi { get; set; }
    }
}
