using Exament1_diars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament3.Models
{
    public class Rutina
    {
        public int Id { get; set; }
        public string Nombre_Rutina { get; set; }
        public int Id_Usuario { get; set; }
        //public int IdTipo_rutina { get; set; }
        //public Tipo_rutina tipo { get; set; }
        //public Usuario usuario { get; set; }
        //public List<Rutina_Ejercicio> ejercicios { get; set; }
    }
}
