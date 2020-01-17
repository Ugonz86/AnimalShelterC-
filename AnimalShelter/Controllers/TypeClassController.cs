using Microsoft.AspNetCore.Mvc;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Controllers
{
  public class TypeClassGroupController : Controller
  {
    private readonly AnimalShelterContext _db;

    public TypeClassGroupController(AnimalShelterContext _db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<TypeClass> model = _db.TypeClassGroup.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(TypeClass typeClass)
    {
      _db.TypeClassGroup.Add(typeClass);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      TypeClass thisTypeClass = _db.TypeClassGroup.FirstOrDefault(typeClass => typeClass.TypeClassId == id);
      return View(thisTypeClass);
    }

    public ActionResult Edit(int id)
    {
      var thisTypeClass = _db.TypeClassGroup.FirstOrDefault(typeClass => typeClass.TypeClassId == id);
      return View(thisTypeClass);
    }

    [HttpPost]
    public ActionResult Edit(TypeClass typeClass)
    {
      _db.Entry(typeClass).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisTypeClass = _db.TypeClassGroup.FirstOrDefault(typeClass => typeClass.TypeClassId == id);
      return View(thisTypeClass);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisTypeClass = _db.TypeClassGroup.FirstOrDefault(typeClass => typeClass.TypeClassId == id);
      _db.TypeClassGroup.Remove(thisTypeClass);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteAll()
    {
      var allTypeClassGroup = _db.TypeClassGroup.ToList();
      return View();
    }

    [HttpPost, ActionName("DeleteAll")]
    public ActionResult DeleteAllConfirmed()
    {
      var allTypeClassGroup = _db.TypeClassGroup.ToList();

      foreach (var typeClass in allTypeClassGroup)
      {
      _db.TypeClassGroup.Remove(typeClass);
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}