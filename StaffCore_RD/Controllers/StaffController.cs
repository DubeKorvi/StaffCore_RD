using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffCoreRD.Data;
using StaffCoreRD.Models;

namespace StaffCoreRD.Controllers
{
    [Authorize]
    public class StaffController : Controller
    {
        private readonly StaffDbContext _context;

        public StaffController(StaffDbContext context)
        {
            _context = context;
        }

        // GET: Staff
        public async Task<IActionResult> Index()
        {
            var lista = await _context.Personal
                .Where(s => s.Activo)
                .OrderBy(s => s.Nombre)
                .ToListAsync();

            return View(lista);
        }

        // GET: Staff/Create
        [Authorize(Roles = "Administrador,RRHH")]
        public IActionResult Create()
        {
            return View(new Staff());
        }

        // POST: Staff/Create
        [HttpPost]
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (!ModelState.IsValid)
                return View(staff);

            _context.Personal.Add(staff);
            await _context.SaveChangesAsync();

            TempData["Exito"] = "Empleado creado correctamente.";
            return RedirectToAction(nameof(Index));
        }


        // GET: Staff/Edit/5
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var staff = await _context.Personal.FindAsync(id);
            if (staff == null) return NotFound();

            return View(staff);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        [Authorize(Roles = "Administrador,RRHH")]
        public async Task<IActionResult> Edit(int id, Staff staff)
        {
            if (id != staff.Id) return NotFound();

            if (!ModelState.IsValid)
                return View(staff);

            _context.Update(staff);
            await _context.SaveChangesAsync();

            TempData["Exito"] = "Empleado actualizado correctamente.";
            return RedirectToAction(nameof(Index));
        }
    }
}
