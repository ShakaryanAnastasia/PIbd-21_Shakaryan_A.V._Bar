using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.ViewModels
{
    public class PantryViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название кладовой")]
        public string PantryName { get; set; }
        public List<PantryIngredientViewModel> PantryIngredients { get; set; }
    }
}
