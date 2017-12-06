using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.DAL.Repositories;


namespace _603211_PROKHORENKO.Controllers
{
    public class AdminController : Controller
    {
        IRepository<Dish> repository;

        public AdminController(IRepository<Dish> repo)
        {
            repository = repo;
        }

       
        // GET: Admin
        public ActionResult Index()
        {
            var tovar = repository.GetAll().ToList();

            return View(tovar);
        }


        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Dish());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Dish dish)
        {
            try
            {
                repository.Create(dish);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dish);
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Dish dish)
        {
            try
            {
                repository.Update(dish);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dish);
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
