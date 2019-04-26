using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>     
    /// Ингредиент, требуемый для изготовления коктейля
    /// </summary>
    public class Ingredient
    {

        public int Id { get; set; }
        [Required]
        public string IngredientName { get; set; }
        public virtual List<CocktailIngredient> CocktailIngredients { get; set; }
        public virtual List<PantryIngredient> PantryIngredients { get; set; }
    }
}
