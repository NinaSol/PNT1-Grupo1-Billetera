﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Billetera2.Models;
using Billetera2.Context;

namespace Billetera2.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly BilleteraDatabaseContext _context;

        public MovimientoController(BilleteraDatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(Guid? id)
        {
  
            List<Movimiento> movimientos = _context.Movimientos.Where(m => m.UsuarioId == id).ToList();
            ViewBag.UsuarioID = id;
            return View(movimientos);
        }

        public IActionResult Create(Guid usuarioId)
        {
            Movimiento movimiento = new Movimiento();
            movimiento.UsuarioId = usuarioId;

            return View(movimiento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Monto,Descripcion,Fecha,TipoMovimiento,UsuarioId")] Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                movimiento.Id = Guid.NewGuid();
                _context.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { id = movimiento.UsuarioId });
            }

            return View(movimiento);
        }
    }
}
