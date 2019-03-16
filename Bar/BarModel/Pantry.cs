using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>
    /// Кладовая компонентов в баре
    /// </summary>
    public class Pantry
    {
        public int Id { get; set; }
        [Required]
        public string PantryName { get; set; }
        public virtual List<PantryIngredient> PantryIngredients { get; set; }
    }
}
