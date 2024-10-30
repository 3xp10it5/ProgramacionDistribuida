using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Data // Cambia esto si tu espacio de nombres es diferente
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; } // Asegúrate de que esto coincida con tu modelo
    }

    public class Usuario
    {
        [Key] // Asegúrate de que esta línea esté presente
        public int idUsuario { get; set; } // Cambia 'Id' por 'idUsuario'

        public string nombreUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string contraseña { get; set; }
    }

}
