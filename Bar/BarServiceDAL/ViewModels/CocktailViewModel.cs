using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.ViewModels
{
   public class CocktailViewModel
    {
        public int Id { get; set; }
        public string CocktailName { get; set; }
        public decimal Price { get; set; }
        public List<CocktailIngredientViewModel> CocktailIngredients { get; set; }
    }
}
