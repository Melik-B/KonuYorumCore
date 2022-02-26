using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KonuYorumCore.DataAccess;

namespace KonuYorumCore.Controllers
{
    public class KonuScaffoldingController : Controller
    {
        private readonly BA_KonuYorumCoreContext _context;

        //public KonuScaffoldingController(BA_KonuYorumCoreContext context)
        //{
        //    _context = context;
        //}

        public KonuScaffoldingController()
        {
            _context = new BA_KonuYorumCoreContext();
        }

        // GET: KonuScaffolding
        public IActionResult Index()
        {
            return View(_context.Konu.ToList());
        }

        // GET: KonuScaffolding/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = _context.Konu
                .SingleOrDefault(m => m.Id == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // GET: KonuScaffolding/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KonuScaffolding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Konu konu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: KonuScaffolding/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = _context.Konu.Find(id);
            if (konu == null)
            {
                return NotFound();
            }
            return View(konu);
        }

        // POST: KonuScaffolding/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Konu konu)
        {
            if (ModelState.IsValid)
            {
                _context.Update(konu);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(konu);
        }

        // GET: KonuScaffolding/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var konu = _context.Konu
                .SingleOrDefault(m => m.Id == id);
            if (konu == null)
            {
                return NotFound();
            }

            return View(konu);
        }

        // POST: KonuScaffolding/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var konu = _context.Konu.Find(id);
            _context.Konu.Remove(konu);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
	}
}
