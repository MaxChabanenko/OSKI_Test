﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OSKI_Test.Data;
using OSKI_Test.Models;

namespace OSKI_Test.Controllers
{
    public class QuizsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizsController(ApplicationDbContext context)
        {
            _context = context;
        }

    //    // GET: Quizs
    //    public async Task<IActionResult> Index()
    //    {
    //          return _context.Quizzes != null ? 
    //                      View(await _context.Quizzes.ToListAsync()) :
    //                      Problem("Entity set 'ApplicationDbContext.Quizzes'  is null.");
    //    }

    //    // GET: Quizs/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null || _context.Quizzes == null)
    //        {
    //            return NotFound();
    //        }

    //        var quiz = await _context.Quizzes
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (quiz == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(quiz);
    //    }

    //    // GET: Quizs/Create
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    // POST: Quizs/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,AssignedUserId,UserCompleted")] Quiz quiz)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(quiz);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(quiz);
    //    }

    //    // GET: Quizs/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null || _context.Quizzes == null)
    //        {
    //            return NotFound();
    //        }

    //        var quiz = await _context.Quizzes.FindAsync(id);
    //        if (quiz == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(quiz);
    //    }

    //    // POST: Quizs/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,AssignedUserId,UserCompleted")] Quiz quiz)
    //    {
    //        if (id != quiz.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(quiz);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!QuizExists(quiz.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(quiz);
    //    }

    //    // GET: Quizs/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _context.Quizzes == null)
    //        {
    //            return NotFound();
    //        }

    //        var quiz = await _context.Quizzes
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (quiz == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(quiz);
    //    }

    //    // POST: Quizs/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_context.Quizzes == null)
    //        {
    //            return Problem("Entity set 'ApplicationDbContext.Quizzes'  is null.");
    //        }
    //        var quiz = await _context.Quizzes.FindAsync(id);
    //        if (quiz != null)
    //        {
    //            _context.Quizzes.Remove(quiz);
    //        }
            
    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool QuizExists(int id)
    //    {
    //      return (_context.Quizzes?.Any(e => e.Id == id)).GetValueOrDefault();
    //    }
    }
}
