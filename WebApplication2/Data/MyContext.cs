using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class MyContext:DbContext
    {

        public DbSet<Zanr> Zanr { get; set; }
        public DbSet<Film> Film { get; set; }
        public DbSet<FilmZanr> FilmZanr { get; set; }


        public MyContext(DbContextOptions opcije):base(opcije)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //many to many
            base.OnModelCreating(modelBuilder);
            //primarni za FZ
            modelBuilder.Entity<FilmZanr>()
                .HasKey(fz => new { fz.FilmId, fz.ZanrId });
            //povezivanje filma i FZ
            modelBuilder.Entity<FilmZanr>()
                .HasOne(fz => fz.Film)
                .WithMany(f => f.Zanrovi)
                .HasForeignKey(fz => fz.FilmId);
            //povezivanje zanra i FZ
            modelBuilder.Entity<FilmZanr>()
                .HasOne(fz => fz.Zanr)
                .WithMany(z => z.Filmovi)
                .HasForeignKey(fz => fz.ZanrId);
        }
    }
}
