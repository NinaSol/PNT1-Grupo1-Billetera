using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Billetera2.Context;
using Billetera2.Models;
using Billetera2.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Billetera2.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly BilleteraDatabaseContext _context;

        public UsuarioController(BilleteraDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Usuarios.ToList());
        }

        public IActionResult Login()
        {
            return View();
        
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("usuarioSession");
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Movimientos(Guid id)
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);
            Movimiento movimiento = new Movimiento();
            movimiento.UsuarioId = id;

            return View(movimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Contrasenia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("usuarioSession", JsonConvert.SerializeObject(usuario));
                return RedirectToAction(nameof(Details));

            }
            return View(usuario);
        }

        public IActionResult Delete()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);

            var user =  _context.Usuarios.FirstOrDefault(m => m.Id == usuario.Id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed()
        {
            var usuario = JsonConvert.DeserializeObject<Usuario>(HttpContext.Session.GetString("usuarioSession"));
            var user = await _context.Usuarios.FindAsync(usuario.Id);
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = user.Id });
        }


      
        public IActionResult Details()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);
            

            var movimientos =  _context.Movimientos
                                            .Where(m => m.UsuarioId == usuario.Id);
            double mTotal = 0;
            
            foreach (var mov in movimientos) {
                if (mov.TipoMovimiento == Movimiento.Tipo.Egreso)
                {
                    mTotal -= mov.Monto;
                }
                else
                {
                    mTotal += mov.Monto;
                }
            }
            

            if (usuario == null)
            {
                return NotFound();
            }

            ViewBag.total = mTotal;
            ViewData["total"] = mTotal;
            return View(usuario);
        }



        public IActionResult Edit()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);
            return View(usuario);
        }

 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id,Nombre,Contrasenia")] Usuario user)
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(user.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Details));
            }
            return View(user);
        }

        private bool UsuarioExists(Guid id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        private bool UsuarioNameExists(string nombre)
        {
            return _context.Usuarios.Any(e => e.Nombre == nombre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Id,Nombre,Contrasenia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                if (UsuarioNameExists(usuario.Nombre))
                {
                    var user = _context.Usuarios.FirstOrDefault(m => m.Nombre == usuario.Nombre);
                    if (usuario.Contrasenia == user.Contrasenia)
                    {
                        HttpContext.Session.SetString("usuarioSession", JsonConvert.SerializeObject(user));
                        return RedirectToAction(nameof(Details));

                    }
                }
            }
            return View();
        }
    }

}
