using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nexify_Engineer_Test_BackEnd.Models;

namespace Nexify_Engineer_Test_BackEnd.Controllers
{
    public class MemberEntitiesController : Controller
    {
        private readonly AppDbContext _context;

        public MemberEntitiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MemberEntities
        public async Task<IActionResult> Index()
        {
              return View(await _context.MemberDataSet.ToListAsync());
        }

        // GET: MemberEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MemberDataSet == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberDataSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEntity == null)
            {
                return NotFound();
            }

            return View(memberEntity);
        }

        // GET: MemberEntities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MemberEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth,Salary,Address")] MemberEntity memberEntity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memberEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(memberEntity);
        }

        // GET: MemberEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MemberDataSet == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberDataSet.FindAsync(id);
            if (memberEntity == null)
            {
                return NotFound();
            }
            return View(memberEntity);
        }

        // POST: MemberEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth,Salary,Address")] MemberEntity memberEntity)
        {
            if (id != memberEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(memberEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberEntityExists(memberEntity.Id))
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
            return View(memberEntity);
        }

        // GET: MemberEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MemberDataSet == null)
            {
                return NotFound();
            }

            var memberEntity = await _context.MemberDataSet
                .FirstOrDefaultAsync(m => m.Id == id);
            if (memberEntity == null)
            {
                return NotFound();
            }

            return View(memberEntity);
        }

        // POST: MemberEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MemberDataSet == null)
            {
                return Problem("Entity set 'AppDbContext.MemberDataSet'  is null.");
            }
            var memberEntity = await _context.MemberDataSet.FindAsync(id);
            if (memberEntity != null)
            {
                _context.MemberDataSet.Remove(memberEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberEntityExists(int id)
        {
          return _context.MemberDataSet.Any(e => e.Id == id);
        }
    }
}
