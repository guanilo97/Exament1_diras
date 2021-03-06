using Exament1_diars.BD;
using Exament1_diars.Models;
using Exament3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Patron
{
    public class Avanzado : IRutina
    {
        private AppBlogContext context;
        public Avanzado(AppBlogContext context)
        {
            this.context = context;
        }
        public Avanzado()
        {
        }
        public void Tipo_Rutina(Rutina rutina)
        {
            Random rnd = new Random();
            var listejercicios = context.ejercicios.ToList();
            for(int i = 0; i < 15; i++)
            {
                int valor = rnd.Next(0, context.ejercicios.Count());
                var rutina_ejerc = new Rutina_Ejercicio();
                rutina_ejerc.Id_Ejercicio = listejercicios[valor].Id;
                rutina_ejerc.Id_Rutina = rutina.Id;
                rutina_ejerc.Tiempo = 120;
                context.rutina_ejercicios.Add(rutina_ejerc);
                context.SaveChanges();
            }
        }

    }
}
