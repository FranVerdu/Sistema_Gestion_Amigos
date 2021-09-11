using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Ejemplo01.Models
{
    public class CrearAmigoModelo
    {   public string Nombre { get; set; }
        [Required(ErrorMessage = "Obligatorio")]
        [Display(Name = "Email")]
        [RegularExpression(@"^(([^<>()\[\]\\.,;:\s@”]+(\.[^<>()\[\]\\.,;:\s@”]+)*)|(“.+”))@((\[[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}\.[0–9]{1,3}])|(([a-zA-Z\-0–9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Formato incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una ciudad")]
        public Provincia? Ciudad { get; set; }

        public IFormFile Foto { get; set; }
    }
}
