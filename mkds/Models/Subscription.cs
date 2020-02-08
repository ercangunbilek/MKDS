using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Subscription
    {
        public int id;
        public string name;
        public string description;
        public double price;
        public Meal monday_meal;
        public Meal tuesday_meal;
        public Meal wednesday_meal;
        public Meal thursday_meal;
        public Meal friday_meal;
        public Meal saturday_meal;
        public Meal sunday_meal;

        public Subscription(int id,string name,string description, double price, Meal mondayMeal, Meal tuesdayMeal, Meal wednesdayMeal, Meal thursdayMeal, Meal fridayMeal, Meal saturdayMeal, Meal sundayMeal)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            monday_meal = mondayMeal;
            tuesday_meal = tuesdayMeal;
            wednesday_meal = wednesdayMeal;
            thursday_meal = thursdayMeal;
            friday_meal = fridayMeal;
            saturday_meal = saturdayMeal;
            sunday_meal = sundayMeal;
        }

      
    }
}