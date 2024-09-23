using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;


namespace WebApplication1.Pages
{
    public class ContactoModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el nombre.")]
        public string Nombre { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Se requiere el teléfono.")]

        [EmailAddress(ErrorMessage = "Invalid email address.")]

        public string Telefono { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Se requiere el correo electrónico")]

        public string CorreoElectronico { get; set; }

        [BindProperty]

        [Required(ErrorMessage = "Se requiere el mensaje.")]

        public string Mensaje { get; set; }


        public void OnGet()
        {
        }


        public IActionResult OnPost()

        {

            if (!ModelState.IsValid)

            {

                return Page();

            }

            // Process form submission (e.g., save to database, send an email)

            TempData["SuccessMessage"] = "Your message has been sent successfully!";

            return RedirectToPage();

        }

    }
}
