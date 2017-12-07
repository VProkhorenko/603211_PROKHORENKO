using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace _603211_PROKHORENKO.DAL.Entities
{
    public class Dish
    {
        //public int DishId { get; set; } // id блюда
        //public string DishName { get; set; } // название блюда
        //public string Description { get; set; } // описание блюда
        //public int Calories { get; set; } // кол. калорий на порцию
        //public string GroupName { get; set; } // группа блюд (например, первые блюда, напитки и т.д.)
        //public byte[] Image { get; set; } // данные изображения
        //public string MimeType { get; set; } // Mime - тип данных изображения

        [HiddenInput]
        public int DishId { get; set; } // id блюда

        [Required(ErrorMessage = "Введите название")]
        [Display(Name = "Название блюда")]
        public string DishName { get; set; } // название блюда

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string Description { get; set; } // описание блюда

        [Required]
        [Range(minimum: 0, maximum: 1500)]
        public int Calories { get; set; } // кол. калорий на порцию

        [Required]
        [Display(Name = "Группа")]
        public string GroupName { get; set; } // группа блюд (например, первые блюда, напистки и т.д.)

        [ScaffoldColumn(false)]
        public byte[] Image { get; set; } // данные изображения
        [ScaffoldColumn(false)]
        public string MimeType { get; set; } // Mime - тип данных изображения

    }
}
