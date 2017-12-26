using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class MovieZanrViewModel
    {
        public string Naziv { get; set; }
        public int Trajanje { get; set; }
        public List<CheckBoxListItem> Zanrovi { get; set; }
    }
}
