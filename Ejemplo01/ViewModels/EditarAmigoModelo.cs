using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.Models
{
    public class EditarAmigoModelo : CrearAmigoModelo
    {
        public int Id { get; set; }
        public string RutaFotoExistente { get; set; }
    }
}
