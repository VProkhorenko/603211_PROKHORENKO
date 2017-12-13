using _603211_PROKHORENKO.DAL.Entities;
using _603211_PROKHORENKO.DAL.Interfaces;
using _603211_PROKHORENKO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _603211_PROKHORENKO.Controllers
{

    public class MenuController : Controller
    {

        IRepository<Dish> repository;
        //коллекцию исходных данных меню:
        List<MenuItem> items;

        // конструктор класса MenuController и заполните коллекцию items:
        public MenuController(IRepository<Dish> repo)
        {
            repository = repo;
        
            items = new List<MenuItem>
            {
                new MenuItem { Name = "Домой", Controller = "Home", Action = "Index", Active = string.Empty },
                new MenuItem { Name = "Меню", Controller = "Dish", Action = "List", Active = string.Empty },
                new MenuItem { Name = "Администрирование", Controller = "Admin", Action = "Index", Active = string.Empty }
                //new MenuItem { Name = "Корзина", Controller = "Cart", Action = "Index", Active = string.Empty }
            };
        }

        /*
          Измените метод Main контроллера Menu:
       Параметр “с” (Controller) автоматически передаются методу из запроса.
       Для элемента списка меню, у которого совпадают параметр Controller с
       полученным параметром, устанавливается свойство Active.
         */

        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        //public PartialViewResult Main(string a = "Index", string c = "Home")
        //{
        //    items.First(m => m.Controller == c).Active = "active";
        //    return PartialView(items);
        //}


        public PartialViewResult Main(string a = "Index", string c = "Home")
        {
            IEnumerable<MenuItem> itemCliced = items.Where<MenuItem>(m => m.Controller == c);
            if (itemCliced.Any())
                items.First(m => m.Controller == c).Active = "active";
            return PartialView(items);
        }

        /*
        public string UserInfo()
        {
            return "<span>Меню пользователя </ span > ";
        }
        */
        public PartialViewResult UserInfo()
        {
            return PartialView();
        }


        public PartialViewResult Side()
        {
            var groups = repository
                .GetAll()
                .Select(d => d.GroupName)
                .Distinct();
            return PartialView(groups);
        }


        public PartialViewResult Map()
        {
            return PartialView(items);
        }

    }

    }
