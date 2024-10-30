using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data; // Asegúrate de que este using esté presente



namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ApplicationDbContext _context; // Contexto de la base de datos

        public LoginModel(ApplicationDbContext context)
        {
            _context = context; // Inyectar el contexto de la base de datos
        }

        [BindProperty]
        [Required(ErrorMessage = "Se requiere el usuario.")]
        public string Usuario { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Se requiere la contraseña.")]
        public string Contraseña { get; set; }

        public void OnGet()
        {
            // Lógica para cargar la página de login (puedes dejarlo vacío si no necesitas nada)
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Verificar las credenciales del usuario
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.nombreUsuario == Usuario && u.contraseña == Contraseña);

                if (usuario != null)
                {
                    // Autenticación exitosa: puedes redirigir a otra página
                    return RedirectToPage("/Index"); // Cambia "/Index" a la página que desees
                }
                else
                {
                    // Usuario o contraseña incorrectos
                    ModelState.AddModelError(string.Empty, "Usuario o contraseña incorrectos.");
                }
            }

            // Si llegamos aquí, hubo un error, regresa a la misma página
            return Page();
        }
    }
}
