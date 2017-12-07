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
    public class CartController : Controller
    {
        // конструктор
            IRepository<Dish> repository;
            public CartController(IRepository<Dish> repo)
            {
                repository = repo;
            }

        //Опишем метод GetCart, который должен вернуть нам корзину заказа из
        //    сессии.Необходимо сначала проверить, сохранялась ли корзина раньше.   
        /// <summary>
        /// Получение корзины из сессии
        /// </summary>
        /// <returns></returns>
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        //Метод Index должен вывести список товаров корзины:
            public ActionResult Index(string returnUrl)
        {

            //var dishes = repository.GetAll().ToList();

            //return View(dishes);


            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }


        
            //Метод AddToCart должен добавлять товар в корзину.После добавления
            //товара в корзину осуществляется возврат на исходную страницу
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="id">id добавляемого элемента</param>
        /// <param name="returnUrl">URL страницы для возврата</param>
        /// <returns></returns>
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = repository.Get(id);
            if (item != null)
                GetCart().AddItem(item);
            return Redirect(returnUrl);
        }



        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }

    }
}
