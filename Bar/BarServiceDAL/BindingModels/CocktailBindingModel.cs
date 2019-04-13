using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.BindingModels
{
    [DataContract]
    public class CocktailBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CocktailName { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public List<CocktailIngredientBindingModel> CocktailIngredients { get; set; }
    }
}
