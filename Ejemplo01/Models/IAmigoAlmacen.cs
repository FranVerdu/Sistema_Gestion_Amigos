using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.Models
{
    public interface IAmigoAlmacen
    {
        Amigo DameDatosAmigo(int id);
        List<Amigo> DameTodosLosAmigos();
        Amigo Nuevo(Amigo amigo);

        Amigo Modificar(Amigo modificarAmigo);
        Amigo Borrar(int id);
    }
}
