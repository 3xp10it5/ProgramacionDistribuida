using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication1.Pages
{
    public class confirmacion_usuarioModel : PageModel
    {
        public string Usuario { get; set; }

        public void OnGet(string usuario)
        {
            Usuario = usuario; // Asigna el nombre de usuario que se pasa en la URL
        }

    }
}
