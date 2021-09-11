using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ejemplo01.Controllers
{
    [Authorize]
    public class CuentasController : Controller
    {
        //La clase UserManager nos permite administrar y gestionar usuarios
        private readonly UserManager<IdentityUser> gestionUsuarios;
        //La clase SingInManager contiene los metodos necesarios para que el usuario inicie sesion
        private readonly SingInManager<IdentityUser> gestionLogin;

        // GET: CuentasController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CuentasController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CuentasController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CuentasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentasController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CuentasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CuentasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CuentasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
