using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PruebasMVC.Models;

namespace PruebasMVC.Data
{
    public class PruebasMVCContext : DbContext
    {
        public PruebasMVCContext (DbContextOptions<PruebasMVCContext> options)
            : base(options)
        {
        }

        public DbSet<PruebasMVC.Models.Alumno> Alumno { get; set; } = default!;
        public DbSet<PruebasMVC.Models.Curso> Curso { get; set; } = default!;
    }
}
