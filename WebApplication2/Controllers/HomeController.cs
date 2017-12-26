using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Data;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Zanr> zanrovi = _context.Zanr.ToList();
            MovieZanrViewModel model = new MovieZanrViewModel();
            model.Zanrovi = new List<CheckBoxListItem>();
            foreach(var item in zanrovi)
            {
                model.Zanrovi.Add(new CheckBoxListItem()
                {
                    Id = item.ZanrId,
                    Display = item.Naziv,
                    IsChecked = false
                });
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(MovieZanrViewModel model)
        {
            if (ModelState.IsValid)
            {
                Film film = new Film();
                film.Naziv = model.Naziv;
                film.Trajanje = model.Trajanje;
                film.Zanrovi = new List<FilmZanr>();

                List<Zanr> list = _context.Zanr.ToList();

                for(int i = 0; i< list.Count;i++)
                {
                    if (model.Zanrovi[i].IsChecked)
                    {
                        film.Zanrovi.Add(new FilmZanr()
                        {
                            Film = film,
                            Zanr = list[i]
                        });
                    }
                }
                _context.Film.Add(film);
                _context.SaveChanges();
            }
            return View();
        }

        public IActionResult About()
        {
            List<FilmZanroviViewModel> list = new List<FilmZanroviViewModel>();
            var temp = _context.Film.Include(f => f.Zanrovi).Where(f => f.Zanrovi.Any(z => z.Zanr.ZanrId == z.ZanrId)).ToList();
                          

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
