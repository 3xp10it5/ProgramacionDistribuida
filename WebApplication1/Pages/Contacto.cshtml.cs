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
        // Propiedad enlazada que requiere el nombre
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el nombre.")]
        public string Nombre { get; set; }

        // Propiedad enlazada que requiere el teléfono
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el teléfono.")]
        [Phone(ErrorMessage = "El número de teléfono no es válido.")]
        public string Telefono { get; set; }

        // Propiedad enlazada que requiere el correo electrónico
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el correo electrónico.")]
        [EmailAddress(ErrorMessage = "La dirección de correo electrónico no es válida.")]
        public string CorreoElectronico { get; set; }

        // Propiedad enlazada que requiere el mensaje
        [BindProperty]
        [Required(ErrorMessage = "Se requiere elegir un asunto.")]
        public string Asunto { get; set; }
       
        // Propiedad enlazada que requiere el mensaje
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
                
            
            // Especificar la ruta de la carpeta donde se guardará el archivo
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "form_data");
            // Aquí se guardan los datos en un archivo de texto
            string filePath = Path.Combine(folderPath, "DatosContacto.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' para agregar al final del archivo
            {
                writer.WriteLine("Nombre: " + Nombre);
                writer.WriteLine("Teléfono: " + Telefono);
                writer.WriteLine("Correo Electrónico: " + CorreoElectronico);
                writer.WriteLine("Asunto: " + Asunto);
                writer.WriteLine("Mensaje: " + Mensaje);
                writer.WriteLine("Fecha: " + DateTime.Now);
                writer.WriteLine("----------------------------------------"); // Separador entre entradas
            }
            // Process form submission (e.g., save to database, send an email)

            TempData["SuccessMessage"] = "Formulario enviado exitosamente!";

            return RedirectToPage();

        }

    }
}
