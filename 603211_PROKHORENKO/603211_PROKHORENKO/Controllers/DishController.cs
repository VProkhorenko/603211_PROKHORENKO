using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.Models;

namespace _603211_PROKHORENKO.Controllers
{

    public class DishController : Controller
    {
        //добавим поле, задающее количество записей на одну страницу:
        int pageSize = 3;

        IRepository<Dish> repository;
        public DishController(IRepository<Dish> repo)
        {
            repository = repo;
        }

        //GET: Dish
        //public ActionResult List()
        //{
        //    return View(repository.GetAll());
        //}
        //Изменим метод List для вывода нужной страницы списка(нумерация страниц начинается с 1):
        //public ActionResult List(int page = 1)
        //{
        //    var lst = repository.GetAll().OrderBy(d => d.Calories);
        //    return View(PageListViewModel<Dish>.CreatePage(lst, page, pageSize));
        //}

        public ActionResult List(string group, int page = 1)
        {
            var lst = repository.GetAll()
                .Where(d => group == null || d.GroupName.Equals(group))
                .OrderBy(d => d.Calories);

            var model = PageListViewModel<Dish>.CreatePage(lst, page, pageSize);
            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);

        }



        // Инициализация списка объектов:
        //List<Dish> dishes = new List<Dish>
        //{
        //    new Dish {DishId=1, DishName="Суп-харчо", Description="Очень острый, невкусный",Calories =200, GroupName="Супы" },
        //    new Dish {DishId=2, DishName="Борщ", Description="Много сала, без сметаны", Calories =330, GroupName="Супы" },
        //    new Dish {DishId=3, DishName="Котлета пожарская", Description="Хлеб - 80%, Морковь - 20%", Calories =635, GroupName="Вторые блюда" },
        //    new Dish {DishId=4, DishName="Макароны по-флотски", Description="С охотничьей колбаской", Calories =524, GroupName="Вторые блюда" },
        //    new Dish {DishId=5, DishName="Компот", Description="Быстро растворимый, 2 литра", Calories =180, GroupName="Напитки" }
        // };

        // GET: Dish
        //public ActionResult List()
        //{
        //    return View(dishes);
        //}

    }
    
}