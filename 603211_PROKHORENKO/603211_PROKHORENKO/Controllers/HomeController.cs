using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using _603211_PROKHORENKO.DAL.Entities;
//using _603211_PROKHORENKO.DAL.Interfaces;

namespace _603211_PROKHORENKO.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyText = "Лабораторная работа №2";

            SelectList colors = new SelectList(Enum.GetValues(typeof(System.Drawing.KnownColor)));
            ViewBag.Colors = colors;
            ViewBag.MyText = Request.QueryString["colors"] ?? "Лабораторная работа №2"; 

            return View();
        }

        public ViewResult About()
        {
            throw new NotImplementedException();
        }

        public ViewResult Contact()
        {
            throw new NotImplementedException();
        }
    }
}