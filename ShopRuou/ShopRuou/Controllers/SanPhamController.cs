using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ShopRuou.Models;

namespace ShopRuou.Controllers
{
    public class SanPhamController : Controller
    {
        private ShopRuouEntities db = new ShopRuouEntities();

        // GET: SanPham
        public ActionResult Index()
        {
            var sanPham = db.SanPham.Include(s => s.Hang).Include(s => s.Loai).Include(s => s.NoiSanXuat);
            return View(sanPham.ToList());
        }

        // GET: SanPham/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // GET: SanPham/Create
        public ActionResult Create()
        {
            ViewBag.Hang_ID = new SelectList(db.Hang, "id", "TenHang");
            ViewBag.Loai_ID = new SelectList(db.Loai, "ID", "TenLoai");
            ViewBag.NoiSanXuat_ID = new SelectList(db.NoiSanXuat, "id", "XuatXu");
            return View();
        }

        // POST: SanPham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Loai_ID,Hang_ID,NoiSanXuat_ID,TenSanPham,NgayNhap,DonGia,SoLuong,GioiGianBaoHanh,MoTa,HinhAnhBia")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPham.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Hang_ID = new SelectList(db.Hang, "id", "TenHang", sanPham.Hang_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai, "ID", "TenLoai", sanPham.Loai_ID);
            ViewBag.NoiSanXuat_ID = new SelectList(db.NoiSanXuat, "id", "XuatXu", sanPham.NoiSanXuat_ID);
            return View(sanPham);
        }

        // GET: SanPham/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.Hang_ID = new SelectList(db.Hang, "id", "TenHang", sanPham.Hang_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai, "ID", "TenLoai", sanPham.Loai_ID);
            ViewBag.NoiSanXuat_ID = new SelectList(db.NoiSanXuat, "id", "XuatXu", sanPham.NoiSanXuat_ID);
            return View(sanPham);
        }

        // POST: SanPham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Loai_ID,Hang_ID,NoiSanXuat_ID,TenSanPham,NgayNhap,DonGia,SoLuong,GioiGianBaoHanh,MoTa,HinhAnhBia")] SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Hang_ID = new SelectList(db.Hang, "id", "TenHang", sanPham.Hang_ID);
            ViewBag.Loai_ID = new SelectList(db.Loai, "ID", "TenLoai", sanPham.Loai_ID);
            ViewBag.NoiSanXuat_ID = new SelectList(db.NoiSanXuat, "id", "XuatXu", sanPham.NoiSanXuat_ID);
            return View(sanPham);
        }

        // GET: SanPham/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPham.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // POST: SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham sanPham = db.SanPham.Find(id);
            db.SanPham.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
