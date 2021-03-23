using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System.Linq;
using System;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly SalonContext _db;
    public StylistsController(SalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Stylist> model = _db.Stylists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      DateTime currentDate = DateTime.Now;
      stylist.CustomerCount = 0;
      stylist.StartDate = (string) $"{currentDate.Year}/{currentDate.Month}/{currentDate.Day}";
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.stylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      ViewBag.clients = _db.Clients.Where(client => client.StylistId == id).ToList();
      return View();
    }

    public ActionResult Delete(int id)
    {
      return View(_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id));
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      _db.Stylists.Remove(_db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id));
      List<Client> Clients = _db.Clients.Where(client => client.StylistId == id).ToList();
      foreach(Client client in Clients)
      {
        client.StylistId = 0;
        _db.Entry(client).State = EntityState.Modified;
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}