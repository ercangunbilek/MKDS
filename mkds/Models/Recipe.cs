using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mkds.Models
{
    public class Recipe
    {
        public string name;
        public string description;
        public string instruction;
        public string url;
        public Recipe_Ingredient recipe_ingredient;
        public Chef chef;

        public Recipe(string name,string description, string instruction, string url, Recipe_Ingredient recipeIngredient, Chef chef)
        {
            this.name = name;
            this.description = description;
            this.instruction = instruction;
            this.url = url;
            recipe_ingredient = recipeIngredient;
            this.chef = chef;
        }
    }
}