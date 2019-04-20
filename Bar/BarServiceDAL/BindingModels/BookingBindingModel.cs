using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.BindingModels
{
    [DataContract]
    public class BookingBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HabitueId { get; set; }
        [DataMember]
        public int CocktailId { get; set; }
        [DataMember]
        public int? BartenderId { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
    }
}
