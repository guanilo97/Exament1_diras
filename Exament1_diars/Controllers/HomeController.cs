using Exament1_diars.BD;
using Exament1_diars.Models;
using Exament1_diars.Patron;
using Exament3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Controllers
{
    public class HomeController : Controller
    {
        private IRutina miRutina;
        private AppBlogContext context;
        public HomeController(AppBlogContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var ejercicios = context.rutinas.Where(o => o.Id_Usuario == getlooged().Id).ToList();
            return View(ejercicios);
        }
        [HttpGet]
        public IActionResult Ejercicios(int id)
        {
            List<MiEjercicio> listEjercicios=new List<MiEjercicio>();
            var ejercicios = context.rutina_ejercicios.Include(a=>a.ejercicio).Where(u=>u.Id_Rutina==id).ToList();
            for (int i = 0; i < ejercicios.Count;i++)
            {
                Ejercicios ejer = context.ejercicios.FirstOrDefault(a => a.Id == ejercicios[i].Id_Ejercicio);

                MiEjercicio ejercicioF = new MiEjercicio();
                ejercicioF.Id = ejer.Id;
                int cont = i;
                ejercicioF.Numero =cont+1;
                ejercicioF.Nombre_ejercicio = ejer.Nombre_ejercicio;
                ejercicioF.Tiempo = ejercicios[i].Tiempo;
                ejercicioF.Video = ejer.Video;
                listEjercicios.Add(ejercicioF);
            }
            return View(listEjercicios);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(new Rutina());
        }
        [HttpPost]
        public IActionResult Create(Rutina rutina, string TipoRutina)
        {
            rutina.Id_Usuario = getlooged().Id;
            context.rutinas.Add(rutina);
            context.SaveChanges();

            if (TipoRutina == "Avanzado")
            {
                miRutina = new Avanzado(context);
            }
            if (TipoRutina == "Principiante")
            {
                miRutina = new Principiante(context);
            }
            if (TipoRutina == "Intermedio")
            {
                miRutina = new Intermedio(context);
            }

            miRutina.Tipo_Rutina(rutina);

            return RedirectToAction("Index", "Home");
        }
        private Usuario getlooged()
        {
            var claims = HttpContext.User.Claims.First();
            string username = claims.Value;
            var user = context.usuarios.First(o => o.Username == username);
            return user;
        }
    }
}
