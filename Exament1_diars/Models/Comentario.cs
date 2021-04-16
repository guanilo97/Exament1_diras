using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Detalle { get; set; }
        public DateTime Fecha { get; set; }
    }
}
