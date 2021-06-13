using Exament1_diars.BD.Mapping;
using Exament1_diars.Models;
using Exament3.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.BD
{
    public class AppBlogContext:  DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Rutina_Ejercicio> rutina_ejercicios { get; set; }
        public DbSet<Rutina> rutinas { get; set; }
        public DbSet<Ejercicios> ejercicios { get; set; }

        public AppBlogContext(DbContextOptions<AppBlogContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new Rutina_EjercicioMap());
            modelBuilder.ApplyConfiguration(new RutinaMap());
            modelBuilder.ApplyConfiguration(new EjerciciosMap());
        }
    }
}
