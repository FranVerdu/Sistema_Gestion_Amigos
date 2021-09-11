using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.Models
{
    public class Amigo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Obligatorio"), MaxLength(100, ErrorMessage = "No más de 100 carácteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Email")]
        [RegularExpression(@"^(([^<>()\[\]\\.,;:\s@”]+(\.[^<>()\[\]\\.,;:\s@”]+)*)|(“.+”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|(([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una ciudad")]
        public Provincia? Ciudad { get; set; }

        public string RutaFoto {get;set;}
    }
}
