using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.BindingModels
{
    public class PantryIngredientBindingModel
    {
        public int Id { get; set; }
        public int PantryId { get; set; }
        public int IngredientId { get; set; }
        public int Count { get; set; }
    }
}
