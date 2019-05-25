using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class CocktailViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CocktailName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<CocktailIngredientViewModel> CocktailIngredients { get; set; }
    }
}
