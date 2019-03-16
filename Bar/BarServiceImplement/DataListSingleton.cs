using BarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceImplement
{
    class DataListSingleton
    {

        private static DataListSingleton instance;
        public List<Habitue> Habitues { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Cocktail> Cocktails { get; set; }
        public List<CocktailIngredient> CocktailIngredients { get; set; }
        public List<Pantry> Pantrys { get; set; }
        public List<PantryIngredient> PantryIngredients { get; set; }
        private DataListSingleton()
        {
            Habitues = new List<Habitue>();
            Ingredients = new List<Ingredient>();
            Bookings = new List<Booking>();
            Cocktails = new List<Cocktail>();
            CocktailIngredients = new List<CocktailIngredient>();
            Pantrys = new List<Pantry>();
            PantryIngredients = new List<PantryIngredient>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
