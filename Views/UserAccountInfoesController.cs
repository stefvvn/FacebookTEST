#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacebookTEST.Models;

namespace FacebookTEST.Views
{
    public class UserAccountInfoesController : Controller
    {
        private readonly FacebookContext _context;

        public UserAccountInfoesController(FacebookContext context)
        {
            _context = context;
        }

        // GET: UserAccountInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserAccountInfos.ToListAsync());
        }

        // GET: UserAccountInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountInfo = await _context.UserAccountInfos
                .FirstOrDefaultAsync(m => m.UserIdNumber == id);
            if (userAccountInfo == null)
            {
                return NotFound();
            }

            return View(userAccountInfo);
        }

        // GET: UserAccountInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserAccountInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserIdNumber,UserName,EmailAddress,FirstName,LastName,City,Gender,DateOfBirth,ProfileDescription,DateMade")] UserAccountInfo userAccountInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccountInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userAccountInfo);
        }

        // GET: UserAccountInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountInfo = await _context.UserAccountInfos.FindAsync(id);
            if (userAccountInfo == null)
            {
                return NotFound();
            }
            return View(userAccountInfo);
        }

        // POST: UserAccountInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserIdNumber,UserName,EmailAddress,FirstName,LastName,City,Gender,DateOfBirth,ProfileDescription,DateMade")] UserAccountInfo userAccountInfo)
        {
            if (id != userAccountInfo.UserIdNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAccountInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAccountInfoExists(userAccountInfo.UserIdNumber))
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
            return View(userAccountInfo);
        }

        // GET: UserAccountInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userAccountInfo = await _context.UserAccountInfos
                .FirstOrDefaultAsync(m => m.UserIdNumber == id);
            if (userAccountInfo == null)
            {
                return NotFound();
            }

            return View(userAccountInfo);
        }

        // POST: UserAccountInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userAccountInfo = await _context.UserAccountInfos.FindAsync(id);
            _context.UserAccountInfos.Remove(userAccountInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAccountInfoExists(int id)
        {
            return _context.UserAccountInfos.Any(e => e.UserIdNumber == id);
        }
    }
}
