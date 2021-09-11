using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.Models
{
    public class MockAmigoRepositorio : IAmigoAlmacen
    {
        private List<Amigo> amigosLista;

        public MockAmigoRepositorio()
        {
            amigosLista = new List<Amigo>();
            amigosLista.Add(new Amigo { Id = 1, Nombre = "Pedro ", Ciudad = Provincia.Madrid, Email = "pedro@email.com"});
            amigosLista.Add(new Amigo { Id = 2, Nombre = "Juan", Ciudad = Provincia.Toledo, Email = "juan@email.com" });
            amigosLista.Add(new Amigo { Id = 3, Nombre = "Sara", Ciudad = Provincia.Cuenca, Email = "sara@email.com" }); 
        }

        public Amigo Borrar(int id)
        {
            Amigo amigo = amigosLista.FirstOrDefault(e => e.Id == id);
            if(amigo != null)
            {
                amigosLista.Remove(amigo);
            }
            return amigo;
        }

        public Amigo DameDatosAmigo(int id)
        {
            return this.amigosLista.FirstOrDefault(e => e.Id == id);
        }

        public List<Amigo> DameTodosLosAmigos()
        {
            return amigosLista;
        }

        public Amigo Modificar(Amigo modificarAmigo)
        {
            Amigo amigo = amigosLista.FirstOrDefault(e => e.Id == modificarAmigo.Id);
            if(amigo != null)
            {
                amigo.Nombre = modificarAmigo.Nombre;
                amigo.Email =  modificarAmigo.Email;
                amigo.Ciudad = modificarAmigo.Ciudad;
            }
            return amigo; 
        }

        public Amigo Nuevo(Amigo amigo)
        {
            amigo.Id = this.amigosLista.Max(a => a.Id) + 1;
            this.amigosLista.Add(amigo);
            return amigo; 
        }
    }
}
