using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    private readonly SalonContext _db;
    public ClientController(SalonContext db)
    {
      _db = db;
    }
    public ActionResult Create(int id)
    {
      ViewBag.ActiveId = id;
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId","Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      Stylist entry = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
      entry.CustomerCount += 1;
      _db.Entry(entry).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index","Stylist");
    }
  }
}