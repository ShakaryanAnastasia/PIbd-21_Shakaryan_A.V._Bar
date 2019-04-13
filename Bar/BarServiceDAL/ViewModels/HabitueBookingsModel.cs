using System.Runtime.Serialization;
namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class HabitueBookingsModel
    {
        [DataMember]
        public string HabitueName { get; set; }
        [DataMember]
        public string DateCreate { get; set; }
        [DataMember]
        public string CocktailName { get; set; }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal Sum { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
