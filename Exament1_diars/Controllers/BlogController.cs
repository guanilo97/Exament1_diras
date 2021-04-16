using Exament1_diars.BD;
using Exament1_diars.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.Controllers
{
    public class BlogController : Controller
    {
        public class BlogDetalle
        {
            public Blog blog1 { get; set; }
            public List<Comentario> Comentarios { get; set; }
        }
        private AppBlogContext context;
        public BlogController(AppBlogContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
           
                var blog = context.blogs;
                return View("Index", blog);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            //var blog = context.blogs;
            return View (new Blog()); 
    
        }
        [HttpPost]
        public IActionResult Crear(Blog blog)
        {
            blog.Fecha = DateTime.Now;
            context.blogs.Add(blog);
            context.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            //var blog = context.blogs;

            var blo = context.blogs.FirstOrDefault(item => item.Id == id);
            List<Comentario> comentarios = context.Comentarios.Where(o => o.BlogId == id).ToList();
            //var detalle = new BlogDetalle
            //{
            //    blog1 =blo,
            //    Comentarios = comentarios
            //};
            ViewBag.titulo = blo.Titulo;
            ViewBag.autor = blo.Autor;
            ViewBag.contenido = blo.Contenido;
            ViewBag.fecha = blo.Fecha;
            ViewBag.id = blo.Id;
            return View(comentarios);
        }
        [HttpPost]
        public RedirectToActionResult AddComentario(Comentario comentario,int id)
        {
            comentario.Fecha = DateTime.Now;
            comentario.BlogId = id;
            context.Comentarios.Add(comentario);
            context.SaveChanges();

            // vamos a redireccionar al metodo Detalle
            // necesito mandar un objeto anonimo
            // var o = new { id = comentario.BookId }; //objeto anonimo
            return RedirectToAction("Detalle", new { id = comentario.BlogId });
        }
    }
}
