using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billetera2.Models;
using Billetera2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Billetera2.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly BilleteraDatabaseContext _context;

        public MovimientoController(BilleteraDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);
            List<Movimiento> movimientos = _context.Movimientos.Where(m => m.UsuarioId == usuario.Id).ToList();
            ViewBag.UsuarioID = usuario.Id;

            return View(movimientos);
        }

        public List<Movimiento> GetAllMovimientos()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return new List<Movimiento>();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);
            List<Movimiento> movimientos = _context.Movimientos.Where(m => m.UsuarioId == usuario.Id).ToList();
            ViewBag.UsuarioID = usuario.Id;
            return movimientos.ToList();
        }

        public IActionResult Create()
        {
            var session = HttpContext.Session.GetString("usuarioSession");
            if (session == null)
            {
                return NotFound();
            }
            var usuario = JsonConvert.DeserializeObject<Usuario>(session);

            Movimiento movimiento = new Movimiento();
            movimiento.UsuarioId = usuario.Id;

            return View(movimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,Descripcion,Fecha,TipoMovimiento,UsuarioId")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                movimiento.Id = Guid.NewGuid();
                var session = HttpContext.Session.GetString("usuarioSession");
                if (session == null)
                {
                    return NotFound();
                }
                var usuario = JsonConvert.DeserializeObject<Usuario>(session);
                var movimientos = _context.Movimientos
                                            .Where(m => m.UsuarioId == usuario.Id);
                double mTotal = 0;
                foreach (var mov in movimientos)
                {
                    if (mov.TipoMovimiento == Movimiento.Tipo.Egreso)
                    {
                        mTotal -= mov.Monto;
                    }
                    else
                    {
                        mTotal += mov.Monto;
                    }
                }
                if (movimiento.TipoMovimiento == Movimiento.Tipo.Egreso)
                {
                    if (movimiento.Monto <= mTotal)
                    {
                        _context.Add(movimiento);

                    }
                }
                else
                {
                    _context.Add(movimiento);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(movimiento);
        }

        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimiento =  _context.Movimientos.FirstOrDefault(m => m.Id == id);
            if (movimiento == null)
            {
                return NotFound();
            }

            return View(movimiento);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);
            _context.Movimientos.Remove(movimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mov = await _context.Movimientos.FindAsync(id);
            if (mov == null)
            {
                return NotFound();
            }
            return View(mov);
        }

      
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Monto,Descripcion,Fecha,UsuarioId,TipoMovimiento")] Movimiento mov)
        {
            if (id != mov.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mov);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoExists(mov.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { id = mov.UsuarioId });
            }
            return View(mov);
        }

        private bool MovimientoExists(Guid id)
        {
            return _context.Movimientos.Any(e => e.Id == id);
        }
    }
}
