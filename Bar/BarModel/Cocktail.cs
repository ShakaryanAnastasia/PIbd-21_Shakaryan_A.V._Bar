using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>     
    /// Коктейл, изготавливаемый в баре
    /// </summary>
     public class Cocktail
    {
        public int Id { get; set; }

        public string CocktailName { get; set; }

        public decimal Price { get; set; }
    }
}
