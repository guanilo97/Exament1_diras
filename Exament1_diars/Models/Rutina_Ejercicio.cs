using Exament3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Models
{
    public class Rutina_Ejercicio
    {
        public int Id { get; set; }
        public int Id_Rutina { get; set; }
        public int Id_Ejercicio { get; set; }
        public int Tiempo { get; set; }
        //public Rutina rutina { get; set; }
        public Ejercicios ejercicio { get; set; }

    }
}
