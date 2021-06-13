using Exament1_diars.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exament1_diars.BD.Mapping
{
    public class Rutina_EjercicioMap:IEntityTypeConfiguration<Rutina_Ejercicio>
    {
        public void Configure(EntityTypeBuilder<Rutina_Ejercicio> builder)
        {
            builder.ToTable("Rutina_Ejercicio");
            builder.HasKey(o => o.Id);
            //builder.HasOne(o => o.rutina).WithMany().HasForeignKey(o => o.Id_Rutina);
            //builder.HasOne(o => o.ejercicio).WithMany().HasForeignKey(o => o.Id_Ejercicio);
            //builder.HasOne(o => o.ejercicio).WithMany(o => o.rutina_ejercicios).HasForeignKey(o => o.Id_Ejercicio);
            //builder.HasMany(o => o.rutina_ejercicios)
            //   .WithOne()
            //   .HasForeignKey(o => o.Id_Ejercicio);
            builder.HasOne(o => o.ejercicio).WithMany().HasForeignKey(o => o.Id_Ejercicio);
        }
    }
}
