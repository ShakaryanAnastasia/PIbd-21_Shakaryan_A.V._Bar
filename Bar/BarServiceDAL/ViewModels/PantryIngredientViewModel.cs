using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.ViewModels
{
    public class PantryIngredientViewModel
    {
        public int Id { get; set; }
        public int PantryId { get; set; }
        public int IngredientId { get; set; }
        [DisplayName("Название ингредиента")]
        public string IngredientName { get; set; }
        [DisplayName("Количество")]
        public int Count { get; set; }
    }
}
