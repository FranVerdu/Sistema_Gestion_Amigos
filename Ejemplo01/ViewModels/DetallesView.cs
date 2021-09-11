using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo01.Models;

namespace Ejemplo01.ViewModels
{
    public class DetallesView
    {
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public Amigo Amigo { get; set; }
    }
}
