using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using mkds.Models;
using Newtonsoft.Json;

namespace mkds.Controllers
{
    public class SubscribeController : Controller
    {
        private List<Subscription> subscriptions;
        public SubscribeController()
        {
            GetMockData();
        }
        // GET: Subscribe
        public ActionResult Index()
        {
            return View(subscriptions);
        }

        public ActionResult Detail(int Id)
        {
            var subscription = subscriptions.FirstOrDefault(x => x.id == Id);
            Session["sub_id"] = Id;
            return View(subscription);
        }
        [HttpPost]
        public ActionResult BeforeCheckout(string cart_list)
        {
            double total = 0;
            int id = (int) Session["sub_id"];
            var subscription = subscriptions.FirstOrDefault(x => x.id == id);

            List <ShopCartItem> shopCart = JsonConvert.DeserializeObject<List<ShopCartItem>>(cart_list);
            Customized_Subscription customizedSubscription = new Customized_Subscription();
            foreach (var item in shopCart)
            {

                switch (item.product_id.ToLower())
                {
                    case "monday":
                    {
                        customizedSubscription.monday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.monday * subscription.price;
                        break;
                    }
                    case "tuesday":
                    {
                        customizedSubscription.tuesday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.tuesday * subscription.price;
                        break;
                    }
                    case "wednesday":
                    {
                        customizedSubscription.wednesday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.wednesday * subscription.price;
                        break;
                    }
                    case "thursday":
                    {
                        customizedSubscription.thursday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.thursday * subscription.price;
                        break;
                    }
                    case "friday":
                    {
                        customizedSubscription.friday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.friday * subscription.price;
                        break;
                    }
                    case "saturday":
                    {
                        customizedSubscription.saturday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.saturday * subscription.price;
                        break;
                    }
                    case "sunday":
                    {
                        customizedSubscription.sunday = Convert.ToInt32(item.product_quantity);
                        total += customizedSubscription.sunday * subscription.price;
                        break;
                    }
                }
            }

            int sub_id = (int) Session["sub_id"];
            customizedSubscription.subscription = subscriptions.FirstOrDefault(x => x.id == sub_id);
            customizedSubscription.total_price = total;
            Session["shop_cart"] = shopCart;
            Session["customized_subscription"] = customizedSubscription;
            return View(shopCart);
        }
        [HttpPost]
        public ActionResult Checkout(string address,string note,string schedule_time)
        {
            List<ShopCartItem> shopCart = Session["shop_cart"] as List<ShopCartItem>;
            Customized_Subscription customizedSubscription =
                Session["customized_subscription"] as Customized_Subscription;
            customizedSubscription.address = address;
            customizedSubscription.notes = note;
            customizedSubscription.schedule_time = schedule_time;
            Session["customized_subscription"] = customizedSubscription;
            
            return View(shopCart);
        }
        [HttpPost]
        public ActionResult Summary(string name,string card_number,string expire_month,string expire_year,string ccv)
        {
            User user = Session["user"] as User;
            Customer customer = user as Customer;;
            Customized_Subscription customizedSubscription = Session["customized_subscription"] as Customized_Subscription;
            Payment payment = new Payment(customizedSubscription, customer,new Payment_Option(),customizedSubscription.total_price);
            Session["payment"] = payment;
            return View(customizedSubscription);
        }
        public List<Subscription> GetMockData()
        {
            Ingredient ingredient = new Ingredient("Test");

            Recipe_Ingredient recipeIngredient1 = new Recipe_Ingredient(ingredient,1,EUnit.kg);

            Chef chef = new Chef("Şef1","Steak");
            Chef chef2 = new Chef("Şef1", "Main");


            Recipe recipe1 = new Recipe("Lasagna", "","","lasagna.jpg", recipeIngredient1,chef);
            Recipe recipe2 = new Recipe("Risotto", "","","risotto.jpg", recipeIngredient1, chef);
            Recipe recipe3 = new Recipe("Meatballs", "", "","meatballs.jpg", recipeIngredient1, chef);
            Recipe recipe4 = new Recipe("Sausage Pizzas", "","","sausagepizzas.jpg", recipeIngredient1, chef);
            Recipe recipe5 = new Recipe("Oysters Rockefeller", "", "","oystersrockefeller.jpg",recipeIngredient1, chef);
            Recipe recipe6 = new Recipe("Shrimp Wiggle", "","","shrimpwiggle.jpg",recipeIngredient1,chef);
            Recipe recipe7 = new Recipe("Fajita", "", "", "fajita.jpg",recipeIngredient1, chef);
            Recipe recipe8 = new Recipe("Blueberries and Cream Coffee Cake","","","blueberries.jpg",recipeIngredient1,chef);
            Recipe recipe9 = new Recipe("Ratatouille","","", "ratatouille.jpg",recipeIngredient1, chef);
            Recipe recipe10 = new Recipe("Tuna Salad", "", "", "tunasalad.jpg",recipeIngredient1, chef);


            List<Recipe> recipeListForChef1 = new List<Recipe> { recipe1,recipe2};
            List<Recipe> recipeListForChef2 = new List<Recipe> { recipe3};
            List<Recipe> recipeListForChef3 = new List<Recipe> { recipe4, recipe5 };
            List<Recipe> recipeListForChef4 = new List<Recipe> { recipe7, recipe8 };

            List<Recipe> recipeListForVegatarian1 = new List<Recipe> { recipe9, recipe10 };
            List<Recipe> recipeListForVegatarian2 = new List<Recipe> { recipe9 };
            List<Recipe> recipeListForVegatarian3 = new List<Recipe> { recipe1, recipe2 };

            List<Recipe> recipeListLow1 = new List<Recipe> { recipe1 };
            List<Recipe> recipeListLow2 = new List<Recipe> { recipe6 };
            List<Recipe> recipeListLow3 = new List<Recipe> { recipe10 };
            List<Recipe> recipeListLow4 = new List<Recipe> { recipe9 };

            Meal mealChef1 = new Meal("Meal", recipeListForChef1);
            Meal mealChef2 = new Meal("Meal", recipeListForChef2);
            Meal mealChef3 = new Meal("Meal", recipeListForChef3);
            Meal mealChef4 = new Meal("Meal", recipeListForChef4);

            Meal mealVegatarian = new Meal("Meal", recipeListForVegatarian1);
            Meal mealVegatarian2 = new Meal("Meal", recipeListForVegatarian2);
            Meal mealVegatarian3 = new Meal("Meal", recipeListForVegatarian3);

            Meal mealLow1 = new Meal("Meal", recipeListLow1);
            Meal mealLow2 = new Meal("Meal", recipeListLow2);
            Meal mealLow3 = new Meal("Meal", recipeListLow3);
            Meal mealLow4 = new Meal("Meal", recipeListLow4);

            Subscription subscription1 =
                new Subscription(1,"Chef Choice", "Carefully selected meals by our master chefs", 7,
                    mealChef1, mealChef2, mealChef3, mealChef4, mealChef1, mealChef3, mealChef4);
            Subscription subscription2 =
                new Subscription(2,"Vegetarian", "Meat-free (red meat, poultry, seafood, and the flesh of any other animal) delicious meals for vegetarians", 5,
                    mealVegatarian, mealVegatarian2, mealVegatarian3, mealVegatarian, mealVegatarian2, mealVegatarian3, mealVegatarian);
            Subscription subscription3 =
                new Subscription(3, "Calorie-Conscious", "Low calorie tasty meals for those who pay attention to the calorie.", 6,
                    mealLow1, mealLow2, mealLow3, mealLow1, mealLow4, mealLow3, mealLow1);

            subscriptions = new List<Subscription>
            {
              subscription1,subscription2,subscription3
            };
           
            return subscriptions;
        }
    }
}