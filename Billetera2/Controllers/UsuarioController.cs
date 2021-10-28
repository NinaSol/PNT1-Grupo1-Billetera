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
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.Id = Guid.NewGuid();
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

    }
}
