using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class CocktailIngredientViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CocktailId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        public string IngredientName { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
