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

        public IActionResult Index1()
        {
            return View();
        
    }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Movimientos(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(m => m.Id == id);
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
                return RedirectToAction(nameof(Details), new { id = usuario.Id });

            }
            return View(usuario);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user =  _context.Usuarios.FirstOrDefault(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            _context.Usuarios.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { id = user.Id });
        }


      
        public async Task<IActionResult> Details(Guid? id, string otroCampo)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                                            .Include(usuario => usuario.Movimientos)
                                            .FirstOrDefaultAsync(m => m.Id == id);
            double mTotal = 0;
            
            foreach (var mov in usuario.Movimientos) {
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



        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Usuarios.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

 
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,Contrasenia")] Usuario user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

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
                return RedirectToAction(nameof(Index));
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
        public IActionResult Index1([Bind("Id,Nombre,Contrasenia")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                if (UsuarioNameExists(usuario.Nombre))
                {
                    var user = _context.Usuarios.FirstOrDefault(m => m.Nombre == usuario.Nombre);
                    if (usuario.Contrasenia == user.Contrasenia)
                    {
                        return RedirectToAction(nameof(Details),new { id=user.Id});

                    }
                }
            }
            return View();
        }
    }

}
