using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class BookingViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int HabitueId { get; set; }
        [DataMember]
        public string HabitueFIO { get; set; }
        [DataMember]
        public int CocktailId { get; set; }
        [DataMember]
        public string CocktailName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string DateImplement { get; set; }
    }
}
