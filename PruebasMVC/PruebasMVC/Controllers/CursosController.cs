using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasMVC.Data;
using PruebasMVC.Models;
using System.Collections;

namespace PruebasMVC.Controllers
{
    public class CursosController : Controller
    {
        private readonly PruebasMVCContext _context;

        public CursosController (PruebasMVCContext context)
        {
            _context = context;
        }

        //GET: Cursos
        public async Task<IActionResult> Index(string orden, string filtro)
        {
            if(orden == null)
            {
                orden = "asc";
            }

            if(filtro == null)
            {
                filtro = "";
            }

            var datos = await _context.Curso.ToListAsync();

            if (orden == "asc")
            {
                datos = datos.OrderBy(m => m.Nombre).ToList();
            }
            else
            {
                datos = datos.OrderByDescending(m => m.Nombre).ToList();
            }

            if( filtro != "")
            {
                datos = datos.Where( c => c.Nombre.ToLower().Contains(filtro.ToLower())).ToList();
            }

            ViewData["filtro"] = filtro;

            ViewData["orden"] = orden;

            return View(datos);
        }

        //GET: Cursos/Details/2
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.Id == id);
            if(curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        //GET: Cursos/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Cursos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind ("Id, Nombre")] Curso curso)
        {
            if(ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Curso.FindAsync(id);
            if(curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        //POST: Cursos/Edit/3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!CursoExists(curso.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }   

            return View(curso);
        }

        //GET: Cursos/Delete/1
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var curso = await _context.Curso
                .FirstOrDefaultAsync(m => m.Id == id);

            if(curso == null) { return NotFound(); }

            return View(curso);
        }

        // POST: Cursos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.Curso.FindAsync(id);
            if(curso == null)
            {
                return NotFound();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        public bool CursoExists(int id)
        {
            return _context.Curso.Any(e => e.Id == id);
        }
    }
}
