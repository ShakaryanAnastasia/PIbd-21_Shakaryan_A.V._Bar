using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>    
    /// Заказ завсегдатая  
    /// </summary> 
    public class Booking
    {
        public int Id { get; set; }

        public int HabitueId { get; set; }

        public int CocktailId { get; set; }

        public int? BartenderId { get; set; }
        public int Count { get; set; }

        public decimal Sum { get; set; }

        public BookingStatus Status { get; set; }

        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }
        public virtual Habitue Habitue { get; set; }
        public virtual Cocktail Cocktail { get; set; }
        public virtual Bartender Bartender { get; set; }
    }
}
