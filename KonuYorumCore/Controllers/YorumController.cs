using KonuYorumCore.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace KonuYorumCore.Controllers
{
    public class YorumController : Controller
    {
        private BA_KonuYorumCoreContext _db = new BA_KonuYorumCoreContext();

        public IActionResult Index()
        {
            List<Yorum> yorumlar = _db.Yorum.Include(yorum => yorum.Konu).OrderByDescending(yorum => yorum.Puan).ThenBy(yorum => yorum.Yorumcu).ToList();
            return View(yorumlar);
        }

        public IActionResult Details(int id)
        {
            Yorum yorum = _db.Yorum.Include(yorum => yorum.Konu).SingleOrDefault(yorum => yorum.Id == id);
            return View(yorum);
        }

        public IActionResult Create()
        {
            List<Konu> konular = _db.Konu.OrderBy(konu => konu.Baslik).ToList();

            //ViewBag.KonuId = new SelectList(konular, "Id", "Baslik");
            ViewData["KonuId"] = new SelectList(konular, "Id", "Baslik"); //Selext list -> DropDowmList, MultiSelecetList -> ListBox
            // VievBag ile ViewData birbirlerinin yerine kullanılabilir, sadece yazımları farklıdır.



            return View();
        }

        [HttpPost]
        public IActionResult Create(Yorum yorum)
        {
            if (string.IsNullOrWhiteSpace(yorum.Icerik))
            {
                ViewBag.Mesaj = "İçerik boş girilemez";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (yorum.Icerik.Length > 500)
            {
                ViewBag.Mesaj = "İçerik en fazla 500 karkater olmalıdır";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (string.IsNullOrWhiteSpace(yorum.Yorumcu))
            {
                ViewBag.Mesaj = "Yorumcu boş girilemez";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (yorum.Yorumcu.Length > 50)
            {
                ViewBag.Mesaj = "Yorumcu en fazla 50 karkater olmalıdır";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }

            //if(yorum.Puan != null)
            if (yorum.Puan.HasValue)
            {
                //if(yorum.Puan.Value > 5 ||yorum.Puan < 1)
                if (!(yorum.Puan.Value >= 1 && yorum.Puan.Value <= 5))
                {
                    ViewBag.Mesaj = "Puan 1 ile 5 arasında olmalıdır";
                    ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                    return View(yorum);
                }
            }

            _db.Yorum.Add(yorum);
            _db.SaveChanges();
            TempData["YorumMesaj"] = "Yorum başarıyla eklendi.";
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            Yorum yorum = _db.Yorum.SingleOrDefault(yorum => yorum.Id == id);
            ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(konu => konu.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
            return View(yorum);
        }

        [HttpPost]
        public IActionResult Edit(Yorum yorum)
        {
            if (string.IsNullOrWhiteSpace(yorum.Icerik))
            {
                ViewBag.Mesaj = "İçerik boş girilemez";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (yorum.Icerik.Length > 500)
            {
                ViewBag.Mesaj = "İçerik en fazla 500 karkater olmalıdır";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (string.IsNullOrWhiteSpace(yorum.Yorumcu))
            {
                ViewBag.Mesaj = "Yorumcu boş girilemez";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }
            if (yorum.Yorumcu.Length > 50)
            {
                ViewBag.Mesaj = "Yorumcu en fazla 50 karkater olmalıdır";
                ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                return View(yorum);
            }

            //if(yorum.Puan != null)
            if (yorum.Puan.HasValue)
            {
                //if(yorum.Puan.Value > 5 ||yorum.Puan < 1)
                if (!(yorum.Puan.Value >= 1 && yorum.Puan.Value <= 5))
                {
                    ViewBag.Mesaj = "Puan 1 ile 5 arasında olmalıdır";
                    ViewBag.KonuId = new SelectList(_db.Konu.OrderBy(k => k.Baslik).ToList(), "Id", "Baslik", yorum.KonuId);
                    return View(yorum);
                }
            }

            Yorum mevcutYorum = _db.Yorum.SingleOrDefault(mevcutYorum => mevcutYorum.Id == yorum.Id);
            mevcutYorum.Icerik = yorum.Icerik;
            mevcutYorum.Yorumcu = yorum.Yorumcu;
            mevcutYorum.Puan = yorum.Puan;
            mevcutYorum.KonuId = yorum.KonuId;
            _db.Yorum.Update(mevcutYorum);
            _db.SaveChanges();
            TempData["YorumMesaj"] = "Yorum başarıyla güncellendi.";
            return RedirectToAction("Index");
        }
    }
}