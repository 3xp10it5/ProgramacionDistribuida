using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Data; // Aseg�rate de que este using est� presente



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
        [Required(ErrorMessage = "Se requiere la contrase�a.")]
        public string Contrase�a { get; set; }

        public void OnGet()
        {
            // L�gica para cargar la p�gina de login (puedes dejarlo vac�o si no necesitas nada)
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Verificar las credenciales del usuario
                var usuario = _context.Usuarios
                    .FirstOrDefault(u => u.nombreUsuario == Usuario && u.contrase�a == Contrase�a);

                if (usuario != null)
                {
                    // Autenticaci�n exitosa: puedes redirigir a otra p�gina
                    return RedirectToPage("/Index"); // Cambia "/Index" a la p�gina que desees
                }
                else
                {
                    // Usuario o contrase�a incorrectos
                    ModelState.AddModelError(string.Empty, "Usuario o contrase�a incorrectos.");
                }
            }

            // Si llegamos aqu�, hubo un error, regresa a la misma p�gina
            return Page();
        }
    }
}
