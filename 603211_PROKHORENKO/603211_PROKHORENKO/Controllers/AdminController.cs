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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IRepository<Dish> repository;
        public AdminController(IRepository<Dish> repo)
        {
            repository = repo;
        }

       
        // GET: Admin МОИ ПРАВКИ ДЛЯ АДМИНА
        //public ActionResult Index()
        //{
        //    return View(repository.GetAll());//lab8
        //    //var dishes = repository.GetAll().ToList();
        //    //return View(dishes);
        //}
        public ActionResult Index(string group)
        {
            var lst = repository.GetAll()
                .Where(d => group == null || d.GroupName.Equals(group))
                .OrderBy(d => d.Calories);

            //var model = PageListViewModel<Dish>.CreatePage(lst, page, pageSize);
            //if (Request.IsAjaxRequest())
            //{
            //    return PartialView("ListPartial", model);
            //}
            //return View(model);
            return View(lst);
        }
        public PartialViewResult Side()
        {
            var groups = repository
                .GetAll()
                .Select(d => d.GroupName)
                .Distinct();
            return PartialView(groups);
        }



        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Dish());
        }

        // POST: Admin/Create
        //[HttpPost]
        //public ActionResult Create(Dish dish)
        //{
        //    try
        //    {
        //        repository.Create(dish);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(dish);
        //    }
        //}
        [HttpPost]
        public ActionResult Create(Dish dish, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
          {
                if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                dish.Image = new byte[count];
                imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                dish.MimeType = imageUpload.ContentType;
            }
            try
            {
                repository.Create(dish);
                return RedirectToAction("Index");
            }
            catch
            {
               // return View();
                return View(dish);
                }
         }
            else return View(dish);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Edit/5
        //[HttpPost]
        //public ActionResult Edit(Dish dish)
        //{
        //    try
        //    {
        //        repository.Update(dish);
        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View(dish);
        //    }
        //}
        [HttpPost]
        public ActionResult Edit(Dish dish, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
          {
                if (imageUpload != null)
            {
                var count = imageUpload.ContentLength;
                dish.Image = new byte[count];
                imageUpload.InputStream.Read(dish.Image, 0, (int)count);
                dish.MimeType = imageUpload.ContentType;
            }
            try
            {
                // TODO: Add update logic here
                repository.Update(dish);
                return RedirectToAction("Index");
            }
            catch
            {
                    //return View(dish);
                return View(dish); //lab8
                }
            }
            else return View(dish);
        }



        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                repository.Delete(id);//lab8
                return RedirectToAction("Index");
            }
            catch
            {
                return View(repository.Get(id));
                //return View(); //lab8
            }
        }
    }
}
