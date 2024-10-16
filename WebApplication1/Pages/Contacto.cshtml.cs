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

        // Propiedad enlazada que requiere el tel�fono
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el tel�fono.")]
        [Phone(ErrorMessage = "El n�mero de tel�fono no es v�lido.")]
        public string Telefono { get; set; }

        // Propiedad enlazada que requiere el correo electr�nico
        [BindProperty]
        [Required(ErrorMessage = "Se requiere el correo electr�nico.")]
        [EmailAddress(ErrorMessage = "La direcci�n de correo electr�nico no es v�lida.")]
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
                
            
            // Especificar la ruta de la carpeta donde se guardar� el archivo
            string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "form_data");
            // Aqu� se guardan los datos en un archivo de texto
            string filePath = Path.Combine(folderPath, "DatosContacto.txt");

            using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' para agregar al final del archivo
            {
                writer.WriteLine("Nombre: " + Nombre);
                writer.WriteLine("Tel�fono: " + Telefono);
                writer.WriteLine("Correo Electr�nico: " + CorreoElectronico);
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
