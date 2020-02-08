using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Recipe_Ingredient
    {
        public Ingredient ingredient;
        public double amount;
        public EUnit unit;

        public Recipe_Ingredient(Ingredient ingredient, double amount, EUnit unit)
        {
            this.ingredient = ingredient;
            this.amount = amount;
            this.unit = unit;
        }
    }
}