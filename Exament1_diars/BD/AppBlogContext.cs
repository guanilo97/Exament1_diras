using Exament1_diars.BD.Mapping;
using Exament1_diars.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.BD
{
    public class AppBlogContext:  DbContext
    {
        public DbSet<Blog> blogs { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }
        public AppBlogContext(DbContextOptions<AppBlogContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BlogMap());
            modelBuilder.ApplyConfiguration(new ComentarioMap());
        }
    }
}
