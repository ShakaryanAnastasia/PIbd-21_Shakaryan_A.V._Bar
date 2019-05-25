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
    public class PantryViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [DisplayName("Название кладовой")]
        public string PantryName { get; set; }
        [DataMember]
        public List<PantryIngredientViewModel> PantryIngredients { get; set; }
    }
}
