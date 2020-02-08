using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Meal
    {
        public string name;
        public List<Recipe> recipe;
        public Chef chef;

        public Meal(string name, List<Recipe> recipe)
        {
            this.name = name;
            this.recipe = recipe;
        }
    }

}