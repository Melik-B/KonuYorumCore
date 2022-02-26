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
    public class YorumScaffoldingController : Controller
    {
        private readonly BA_KonuYorumCoreContext _context;

        //public YorumScaffoldingController(BA_KonuYorumCoreContext context)
        //{
        //    _context = context;
        //}

        public YorumScaffoldingController()
        {
            _context = new BA_KonuYorumCoreContext();
        }

        // GET: YorumScaffolding
        public IActionResult Index()
        {
            var bA_KonuYorumCoreContext = _context.Yorum.Include(y => y.Konu);
            return View(bA_KonuYorumCoreContext.ToList());
        }

        // GET: YorumScaffolding/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = _context.Yorum
                .Include(y => y.Konu)
                .SingleOrDefault(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // GET: YorumScaffolding/Create
        public IActionResult Create()
        {
            ViewData["KonuId"] = new SelectList(_context.Konu, "Id", "Baslik");
            return View();
        }

        // POST: YorumScaffolding/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yorum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KonuId"] = new SelectList(_context.Konu, "Id", "Baslik", yorum.KonuId);
            return View(yorum);
        }

        // GET: YorumScaffolding/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = _context.Yorum.Find(id);
            if (yorum == null)
            {
                return NotFound();
            }
            ViewData["KonuId"] = new SelectList(_context.Konu, "Id", "Baslik", yorum.KonuId);
            return View(yorum);
        }

        // POST: YorumScaffolding/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Yorum yorum)
        {
            if (ModelState.IsValid)
            {
                _context.Update(yorum);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KonuId"] = new SelectList(_context.Konu, "Id", "Baslik", yorum.KonuId);
            return View(yorum);
        }

        // GET: YorumScaffolding/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yorum = _context.Yorum
                .Include(y => y.Konu)
                .SingleOrDefault(m => m.Id == id);
            if (yorum == null)
            {
                return NotFound();
            }

            return View(yorum);
        }

        // POST: YorumScaffolding/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var yorum = _context.Yorum.Find(id);
            _context.Yorum.Remove(yorum);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
	}
}
