using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.ViewModels
{
    public class RegistroModelo
    {
        [Required][EmailAddress]
        public string Email { get; set; }

        [Required][DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Repetir Password")]
        [Compare("Password", ErrorMessage ="La Password y la Password de confirmación no coinciden.")]
        public string PasswordValidar { get; set; }
    }
}
