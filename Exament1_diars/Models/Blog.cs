﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }

        public string Contenido { get; set; }
        public DateTime Fecha  { get; set; }
    }
}
