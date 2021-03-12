using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System.Linq;
using System;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    private readonly SalonContext _db;
    public StylistController(SalonContext db)
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
  }
}