using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>
    /// Сколько ингредиентов хранится в кладовой
    /// </summary>
    public class PantryIngredient
    {
        public int Id { get; set; }
        public int PantryId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
