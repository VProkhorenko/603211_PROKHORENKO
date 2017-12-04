using System;
using System.Collections.Generic;
using System.Linq;
// LAB4_DB
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _603211_PROKHORENKO.DAL.Entities
{
    class FoodContext : DbContext
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        ///// <param name="name"> имя строки подключения </param>
        public FoodContext(string name) : base(name)
        {
            Database.SetInitializer(new FoodContextInitializer());
        }
        public DbSet<Dish> Dishes { get; set; }
    }


}
