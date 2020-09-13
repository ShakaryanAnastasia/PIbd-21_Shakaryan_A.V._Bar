using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.BindingModels
{
    public class CocktailIngredientBindingModel
    {
        public int Id { get; set; }

        public int CocktailId { get; set; }

        public int IngredientId { get; set; }

        public string IngredientName { get; set; }

        public int Count { get; set; }

    }
}
