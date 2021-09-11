using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ejemplo01.Models;
using Ejemplo01.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Ejemplo01.Controllers
{
    public class HomeController : Controller
    {
        private IAmigoAlmacen amigoAlmacen;
        private readonly IWebHostEnvironment _webHostEnvironment;
         

        public HomeController(IAmigoAlmacen amigoAlmacen, IWebHostEnvironment webHostEnvironment)
        {
            this.amigoAlmacen = amigoAlmacen; 
            _webHostEnvironment = webHostEnvironment;
        }

         
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            List<Amigo> modelo = amigoAlmacen.DameTodosLosAmigos();
            return View(modelo);
            //return View("~/Misvistas/Index.cshtml", modelo);
        } 

        [Route("Home/Details/{id?}")]
        public ViewResult Details(int? id)
        {
            //ViewData["Cabecera"] = "LISTA DE AMIGOS";
            //ViewData["Amigo"] = modelo;
            //ViewBag.Titulo = "LISTA AMIGOS ViewBag";
            //ViewBag.Amigo = modelo; 

            DetallesView detalle = new DetallesView()
            {
                Titulo = "LISTA DE AMIGOS VIEW MODELS",
                SubTitulo = "EJEMPLO",
                Amigo = amigoAlmacen.DameDatosAmigo(id?? 0),
            };

            if(detalle.Amigo == null)
            {
                Response.StatusCode = 404;
                return View("AmigoNoEncontrado", id);
            }



            return View(detalle);
        }

        [Route("Home/Create")]
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CrearAmigoModelo a)
        {
            if (ModelState.IsValid)
            {
                string guidImagen = null;
                if(a.Foto != null)
                {
                    string ficherosImagenes = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    guidImagen = Guid.NewGuid().ToString() + a.Foto.FileName;
                    string rutaDefinitiva = Path.Combine(ficherosImagenes, guidImagen);
                    a.Foto.CopyTo(new FileStream(rutaDefinitiva, FileMode.Create));
                }
                 
                Amigo nuevoAmigo = new Amigo();
                nuevoAmigo.Nombre = a.Nombre;
                nuevoAmigo.Email = a.Email;
                nuevoAmigo.Ciudad = a.Ciudad;
                nuevoAmigo.RutaFoto = guidImagen;
                amigoAlmacen.Nuevo(nuevoAmigo);
                 
                return RedirectToAction("Details", new { id = nuevoAmigo.Id });
            }
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Amigo amigo = amigoAlmacen.DameDatosAmigo(id);
            EditarAmigoModelo amigoEditar = new EditarAmigoModelo()
            {
                Id = amigo.Id,
                Nombre = amigo.Nombre,
                Email = amigo.Email,
                Ciudad = amigo.Ciudad,
                RutaFotoExistente = amigo.RutaFoto
            };
            return View(amigoEditar);
        }
        [HttpPost]
        public IActionResult Edit(EditarAmigoModelo model)
        {
            if (ModelState.IsValid)
            {
                Amigo amigo = amigoAlmacen.DameDatosAmigo(model.Id);
                amigo.Nombre = model.Nombre;
                amigo.Email = model.Email;
                amigo.Ciudad = model.Ciudad;

                if(model.Foto != null)
                {
                    //Si el usuario sube una foto debe borrarse la anterior
                    if(model.RutaFotoExistente != null)
                    {
                        string ruta = Path.Combine(this._webHostEnvironment.WebRootPath, "images", model.RutaFotoExistente);
                        System.IO.File.Delete(ruta);
                    }
                    //Guardamos la foto en wwwroot/images
                    amigo.RutaFoto = SubirImagen(model);
                }

                Amigo amigoModificado = amigoAlmacen.Modificar(amigo);
                return RedirectToAction("index");
            }
            return View(model);
        }
        private string SubirImagen(EditarAmigoModelo model)
        {
            string nombreFichero = null;
            if(model.Foto != null)
            {
                string carpetaSubida = Path.Combine(this._webHostEnvironment.WebRootPath, "images");
                nombreFichero = Guid.NewGuid().ToString() + "_" + model.Foto.FileName;
                string ruta = Path.Combine(carpetaSubida, nombreFichero);
                using (var fileStream = new FileStream(ruta, FileMode.Create))
                {
                    model.Foto.CopyTo(fileStream);
                } 
            }
            return nombreFichero;
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            amigoAlmacen.Borrar(id);
            return RedirectToAction("index");
        }


    }
}
