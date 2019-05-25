using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class PantryIngredientViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int PantryId { get; set; }
        [DataMember]
        public int IngredientId { get; set; }
        [DataMember]
        [DisplayName("Название ингредиента")]
      
        public string IngredientName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
 
        public int Count { get; set; }
    }
}
