using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.BindingModels
{
    public class BookingBindingModel
    {
        public int Id { get; set; }

        public int HabitueId { get; set; }

        public int CocktailId { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }
    }
}
