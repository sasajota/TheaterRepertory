using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheaterRepertory.Data;
using TheaterRepertory.Models;

namespace TheaterRepertory.Controllers
{
    public class PlaysController : Controller
    {
        private readonly TheaterRepertoryContext _context;

        public PlaysController(TheaterRepertoryContext context)
        {
            _context = context;
        }

        // GET: Plays
        public async Task<IActionResult> Index()
        {
            return View(await _context.Play.ToListAsync());
        }

        // GET: Plays/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play
                .FirstOrDefaultAsync(m => m.Id == id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // GET: Plays/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Plays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Desc,ScheduleTime,ActorsList,Image")] Play play)
        {
            if (ModelState.IsValid)
            {
                _context.Add(play);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(play);
        }

        // GET: Plays/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play.FindAsync(id);
            if (play == null)
            {
                return NotFound();
            }
            return View(play);
        }

        // POST: Plays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Desc,ScheduleTime,ActorsList,Image")] Play play)
        {
            if (id != play.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(play);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlayExists(play.Id))
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
            return View(play);
        }

        // GET: Plays/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var play = await _context.Play
                .FirstOrDefaultAsync(m => m.Id == id);
            if (play == null)
            {
                return NotFound();
            }

            return View(play);
        }

        // POST: Plays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var play = await _context.Play.FindAsync(id);
            _context.Play.Remove(play);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlayExists(int id)
        {
            return _context.Play.Any(e => e.Id == id);
        }
    }
}
