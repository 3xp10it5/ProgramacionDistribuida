using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el nombre.")]
        public string Usuario { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Se requiere el teléfono.")]


        public string Contraseña { get; set; }
        public void OnGet()
        {

        }
    }
}
