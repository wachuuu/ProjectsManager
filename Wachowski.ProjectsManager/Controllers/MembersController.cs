using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Wachowski.ProjectsManager.CORE.Enums;
using Wachowski.ProjectsManager.Data;
using Wachowski.ProjectsManager.Models;

namespace Wachowski.ProjectsManager.Controllers
{
    public class MembersController : Controller
    {
        private readonly WachowskiProjectsManagerContext _context;

        public MembersController(WachowskiProjectsManagerContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index(string memberRole, string search)
        {
            ViewData["CurrentFilter"] = search;

            var roles = Enum.GetValues(typeof(Role));
            var members = _context.Members
                .Include(m => m.Project)
                .AsNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                members = members.Where(m =>
                    m.FirstName.ToLower().Contains(search)
                    || m.Project.Name.ToLower().Contains(search)
                );
            }

            if (!string.IsNullOrEmpty(memberRole))
            {
                Console.WriteLine(memberRole);

                members = members.Where(m => m.Role == (Role)Enum.Parse(typeof(Role), memberRole));
            }

            var membersRoleVM = new RoleViewModel
            {
                Members = await members.ToListAsync(),
                Roles = new SelectList(roles)
            };

            return View(membersRoleVM);
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var person = await _context.Members
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(_context.Projects.AsNoTracking(), "Id", "Name", null);
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Role,DateOfBirth,ProjectId")] Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ProjectId = new SelectList(_context.Projects.AsNoTracking(), "Id", "Name", person.ProjectId);
            return View(person);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var person = await _context.Members.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            ViewBag.ProjectId = new SelectList(_context.Projects.AsNoTracking(), "Id", "Name", person.ProjectId);
            return View(person);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Role,DateOfBirth,ProjectId")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonExists(person.Id))
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

            ViewBag.ProjectId = new SelectList(_context.Projects.AsNoTracking(), "Id", "Name", person.ProjectId);
            return View(person);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var person = await _context.Members
                .Include(m => m.Project)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'WachowskiProjectsManagerContext.Members'  is null.");
            }
            var person = await _context.Members.FindAsync(id);
            if (person != null)
            {
                _context.Members.Remove(person);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
          return _context.Members.Any(e => e.Id == id);
        }
    }
}
