using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLab.Entities;

namespace WebLab.Data
{
    public static class DbInitializer
    {
        public static async Task Seed(ApplicationDbContext context,
                             UserManager<ApplicationUser> userManager,
                             RoleManager<IdentityRole> roleManager)
        {
            // создать БД, если она еще не создана
            context.Database.EnsureCreated();

            // проверка наличия ролей
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                // создать роль admin
                await roleManager.CreateAsync(roleAdmin);
            }

           
            
            
            // проверка наличия пользователей
            if (!context.Users.Any())
            {
                // создать пользователя user@mail.ru
                var user = new ApplicationUser
                {
                    Email = "user@mail.ru",
                    UserName = "user@mail.ru"
                };
                await userManager.CreateAsync(user, "123456");
                // создать пользователя admin@mail.ru
                var admin = new ApplicationUser
                {
                    Email = "admin@mail.ru",
                    UserName = "admin@mail.ru"
                };
                await userManager.CreateAsync(admin, "123456");
                var admin1 = new ApplicationUser
                {
                    Email = "admin1@mail.ru",
                    UserName = "admin1@mail.ru"
                };
                await userManager.CreateAsync(admin1, "123456");
                // назначить роль admin
                admin = await userManager.FindByEmailAsync("admin@mail.ru");
                await userManager.AddToRoleAsync(admin, "admin");
            }

            //проверка наличия групп объектов
            if (!context.DishGroups.Any())
            {
                context.DishGroups.AddRange(
                new List<DishGroup>
                {
                new DishGroup {GroupName="Холодные закуски"},
                new DishGroup {GroupName="Салаты"},
                new DishGroup {GroupName="Супы"},
                new DishGroup {GroupName="Основные блюда"},
                new DishGroup {GroupName="Напитки"},
                new DishGroup {GroupName="Десерты"}
                });
                await context.SaveChangesAsync();
            }
            // проверка наличия объектов
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                new List<Dish>
                {
                new Dish
                    {
                        DishName = "Мясная закуска",
                        Description = "Большая закуска из мясных деликатесов",
                        Calories = 200,
                        DishGroupId = 1,
                        Image = "dish1.jpg"
                    },

                new Dish
                {
                    DishName = "Борщ",
                    Description = "Ароматный и наваристый борщ с говядиной",
                    Calories = 330,
                    DishGroupId = 3,
                    Image = "dish10.jpg"
                },

                new Dish
                {
                    DishName = "Шашлык на компанию",
                    Description = "Шашлык из свиной шеи с жареным картофелем с розмарином",
                    Calories = 635,
                    DishGroupId = 4,
                    Image = "dish3.jpg"
                },

                new Dish
                {
                    DishName = "Ассорти колбас",
                    Description = "Ассорти из фирменных колбасок собственного приготовления",
                    Calories = 524,
                    DishGroupId = 4,
                    Image = "Dish4.jpg"
                },

                new Dish
                {
                    DishName = "Салат Цезарь с креветками",
                    Description = "Маринованные креветки, томаты черри, микс салат под стружкой выдержанного твёрдого сыра с хрустящими белыми сухариками и фирменной салатной заправкой.",
                    Calories = 524,
                    DishGroupId = 2,
                    Image = "Dish8.jpg"
                },

                new Dish
                {
                    DishName = "Морс смородина & малина",
                    Description = "Собственного приготовления",
                    Calories = 180,
                    DishGroupId = 5,
                    Image = "Dish14.jpg"
                },

                new Dish
                {
                    DishName = "Салат с подкопченным цыпленком и хрустящими сухариками",
                    Description = "Cлегка подкопченное филе цыплёнка собственного приготовления, томаты черри и микс салат под стружкой твёрдого выдержанного сыра с хрустящими белыми сухариками с фирменной салатной заправкой.",
                    Calories = 180,
                    DishGroupId = 2,
                    Image = "Dish9.jpg"
                },

                new Dish
                {
                    DishName = "Торт Сливочно-клубничный с манговой карамелью",
                    Description = "Большой торт изготовим под заказ, для особого случая",
                    Calories = 2160,
                    DishGroupId = 6,
                    Image = "Dish12.jpg"
                },

                new Dish
                {
                    DishName = "Теплый яблочный штрудель",
                    Description = "Большой торт изготовим под заказ, для особого случая",
                    Calories = 120,
                    DishGroupId = 6,
                    Image = "Dish13.jpg"
                },

                new Dish
                {
                    DishName = "Солянка с мясными копченостями",
                    Description = "Традиционная солянка, сваренная на мясном бульоне с копчёностями",
                    Calories = 420,
                    DishGroupId = 3,
                    Image = "Dish11.jpg"
                },

                new Dish
                {
                    DishName = "Тар-Тар из говядины",
                    Description = "Фирменная закуска из сырой рубленой говядины, заправляется коньяком, желтком, горчицей, луком и ароматными специями",
                    Calories = 420,
                    DishGroupId = 1,
                    Image = "Dish7.jpg"
                },

                new Dish
                {
                    DishName = "Сковорода с шашлычками из креветок и лосося",
                    Description = "Сытная пивная закуска: шашлычки из креветок, лосося с сладким перцем и лимоном, в сопровождении овощей гриль - баклажан, цукини и перец, подаётся на большой сковороде с подогревом",
                    Calories = 1420,
                    DishGroupId = 4,
                    Image = "Dish6.jpg" },
                });
                await context.SaveChangesAsync();
            }

        }
    }
}

