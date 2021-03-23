using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly SalonContext _db;
    public ClientsController(SalonContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      List<Client> clients = _db.Clients.ToList();
      Dictionary<int,string> stylistNames = new Dictionary<int,string>();
      foreach (Stylist stylist in _db.Stylists.ToList())
      {
        stylistNames.Add(stylist.StylistId,stylist.Name);
      }

      ViewBag.Stylists = stylistNames;
      return View(clients);
    }
    public ActionResult Create()
    {
      List<SelectListItem> items = new SelectList(_db.Stylists, "StylistId","Name").ToList();
      items.Insert(0, (new SelectListItem { Text = "No Stylist", Value = "0" }));
      ViewBag.StylistId = items;
      return View();
    }
    [HttpPost]
    public ActionResult Create(Client client)
    {
      _db.Clients.Add(client);
      if (client.StylistId != 0)
      {
        Stylist entry = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
        entry.CustomerCount += 1;
        _db.Entry(entry).State = EntityState.Modified;
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      return View(_db.Clients.FirstOrDefault(client => client.ClientId == id));
    }
    
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      if (client.StylistId != 0)
      {
        Stylist changedStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
        changedStylist.CustomerCount -= 1;
        _db.Entry(changedStylist).State = EntityState.Modified;
      }
      _db.Clients.Remove(client);
      _db.SaveChanges();
      return  RedirectToAction("Index");
    }
    public ActionResult Edit(int id)
    {
      Client client = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      if (client.StylistId != 0)
      {
        Stylist changedStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
        changedStylist.CustomerCount -= 1;
        _db.Entry(changedStylist).State = EntityState.Modified;
        _db.SaveChanges();
      }
      List<SelectListItem> items = new SelectList(_db.Stylists, "StylistId","Name").ToList();
      items.Insert(0, (new SelectListItem { Text = "No Stylist", Value = "0" }));
      ViewBag.Stylists = items;
      return View(client);
    }
    [HttpPost]
    public ActionResult Edit(Client client)
    {
      if (client.StylistId != 0)
      {
        Stylist changedStylist = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == client.StylistId);
        changedStylist.CustomerCount += 1;
        _db.Entry(changedStylist).State = EntityState.Modified;
        _db.SaveChanges();
      }
      _db.Entry(client).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}