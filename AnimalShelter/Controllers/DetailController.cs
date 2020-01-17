using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AnimalShelter.Controllers
{
    public class DetailGroupController : Controller
    {
        private readonly AnimalShelterContext _db;

        public DetailGroupController(AnimalShelterContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            List<Detail> model = _db.DetailGroup.Include(detailGroup => detailGroup.TypeClass).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.TypeClassId = new SelectList(_db.TypeClassGroup, "TypeClassId", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Detail detail)
        {
            _db.DetailGroup.Add(detail);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Detail thisDetail = _db.DetailGroup.FirstOrDefault(detailGroup => detailGroup.DetailId == id);
            return View(thisDetail);
        }

        public ActionResult Edit(int id)
        {
            var thisDetail = _db.DetailGroup.FirstOrDefault(detailGroup => detailGroup.DetailId == id);
            ViewBag.TypeClassId = new SelectList(_db.TypeClassGroup, "TypeClassId", "Name");
            return View(thisDetail);
        }

        [HttpPost]
        public ActionResult Edit(Detail detail)
        {
            _db.Entry(detail).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var thisDetail = _db.DetailGroup.FirstOrDefault(detailGroup => detailGroup.DetailId == id);
            return View(thisDetail);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisDetail = _db.DetailGroup.FirstOrDefault(detailGroup => detailGroup.DetailId == id);
            _db.DetailGroup.Remove(thisDetail);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAll()
        {
            var allDetailGroup = _db.DetailGroup.ToList();
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
            public ActionResult DeleteAllConfirmed()
        {
            var allDetailGroup = _db.DetailGroup.ToList();

        foreach (var detail in allDetailGroup)
        {
            _db.DetailGroup.Remove(detail);
        }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}