using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.Data;
using WebLab.Entities;
using WebLab.Extensions;
using WebLab.Models;

namespace WebLab.Controllers

{
    
    public class ProductController : Controller
    {
        ApplicationDbContext _context;
        //public List<Dish> _dishes;
        //List<DishGroup> _dishGroups;
        //private ILogger _logger;
        int _pageSize;
        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            //_logger = logger;
        }
        
        
        //public ProductController()
        //{
        //    _pageSize = 3;
        //    SetupData();
        //}
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]
        public IActionResult Index(int? group, int pageNo = 1)
        {
            //var groupMame = group.HasValue
            //? _context.DishGroups.Find(group.Value)?.GroupName
            //: "all groups";
            //_logger.LogInformation($"info: group={group}, page={pageNo}");
            var dishesFiltered = _context.Dishes
            .Where(d => !group.HasValue || d.DishGroupId == group.Value);
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.DishGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            return View(ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize));

            //var model = ListViewModel<Dish>.GetModel(dishesFiltered, pageNo, _pageSize);
            //if (Request.Headers["x-requested-with"]
            //.ToString().ToLower().Equals("xmlhttprequest"))
            //    return PartialView("_listpartial", model);
            //if (Request.IsAjaxRequest())
            //    return PartialView("_listpartial", model);
            //else
            //    return View(model);



        }
            /// <summary>
            /// Инициализация списков
            /// </summary>
            
        //private void SetupData()
        //{
        //    _dishGroups = new List<DishGroup>
        //    {
        //        new DishGroup {DishGroupId=1, GroupName="Бутерброды"},
        //        new DishGroup {DishGroupId=2, GroupName="Десерты"},
        //        new DishGroup {DishGroupId=3, GroupName="Напитки"},
        //        new DishGroup {DishGroupId=4, GroupName="Основные блюда"},
        //        new DishGroup {DishGroupId=5, GroupName="Завтраки"},
        //    };
        //    _dishes = new List<Dish>
        //    {
        //        new Dish {DishId = 1, DishName="Бутерброды постные",
        //        Description="Просто бутерброды с яйцом",
        //        Calories =200, DishGroupId=1, Image="b1.jpg" },
        //        new Dish { DishId = 2, DishName="Бутерброды сладкие",
        //        Description="С бананом и черникой",
        //        Calories =330, DishGroupId=1, Image="b2.jpg" },
        //        new Dish { DishId = 3, DishName="Классический бутерброд",
        //        Description="Хлеб - 80%, Масло - 20%",
        //        Calories =160, DishGroupId=1, Image="b3.jpg" },


        //        new Dish {DishId = 4, DishName="Круасан",
        //        Description="Хорошо к чаю",
        //        Calories =200, DishGroupId=2, Image="d1.jpg" },
        //        new Dish { DishId = 5, DishName="Венские вафли",
        //        Description="С шариком мороженого",
        //        Calories =330, DishGroupId=2, Image="d2.jpg" },
        //        new Dish { DishId = 6, DishName="Пончики",
        //        Description="С шоколодом",
        //        Calories =160, DishGroupId=2, Image="d3.jpg" },

        //        new Dish {DishId = 7, DishName="Кофе",
        //        Description="Эспрессо",
        //        Calories =200, DishGroupId=3, Image="n1.jpg" },
        //        new Dish { DishId = 8, DishName="Сок",
        //        Description="Апельсиновый",
        //        Calories =330, DishGroupId=3, Image="n2.jpg" },
        //        new Dish { DishId = 9, DishName="Компот",
        //        Description="Клубничный",
        //        Calories =160, DishGroupId=3, Image="n3.jpg" },


        //        new Dish {DishId = 10, DishName="Яичница",
        //        Description="С овощами",
        //        Calories =200, DishGroupId=4, Image="os1.jpg" },
        //        new Dish { DishId = 11, DishName="Лаваш",
        //        Description="С овощами",
        //        Calories =330, DishGroupId=4, Image="os2.jpg" },



        //        new Dish {DishId = 12, DishName="Творог",
        //        Description="С клубникой",
        //        Calories =200, DishGroupId=5, Image="z1.jpg" },
        //        new Dish { DishId = 13, DishName="Хлопья",
        //        Description="Кукурузные",
        //        Calories =330, DishGroupId=5, Image="z2.jpg" },



        //    };
        //}
    }
}
