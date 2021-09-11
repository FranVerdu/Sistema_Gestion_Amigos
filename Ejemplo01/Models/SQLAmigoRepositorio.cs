using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejemplo01.Models
{
    public class SQLAmigoRepositorio : IAmigoAlmacen
    {
        private readonly AppDbContext contexto;
        private List<Amigo> amigosLista;

        public SQLAmigoRepositorio(AppDbContext contexto)
        {
            this.contexto = contexto;
        }

        public Amigo Borrar(int id)
        {
            Amigo amigo = DameDatosAmigo(id);
            if(amigo != null)
            {
                contexto.Amigos.Remove(amigo);
                contexto.SaveChanges();
            }
            return amigo;
        }

        public Amigo DameDatosAmigo(int id)
        {
            return contexto.Amigos.Find(id);
        }

        public List<Amigo> DameTodosLosAmigos()
        {
            amigosLista = contexto.Amigos.ToList<Amigo>();
            return amigosLista;
        }

        public Amigo Modificar(Amigo modificarAmigo)
        {
            var amigo = contexto.Amigos.Attach(modificarAmigo);
            amigo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            contexto.SaveChanges(); 
            return modificarAmigo;
        }

        public Amigo Nuevo(Amigo amigo)
        {
            contexto.Amigos.Add(amigo);
            contexto.SaveChanges();
            return amigo;
        }
    }
}
