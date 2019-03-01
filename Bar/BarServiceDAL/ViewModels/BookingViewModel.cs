using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        public int HabitueId { get; set; }

        public string HabitueFIO { get; set; }

        public int CocktailId { get; set; }

        public string CocktailName { get; set; }

        public int Count { get; set; }

        public decimal Sum { get; set; }

        public string Status { get; set; }

        public string DateCreate { get; set; }

        public string DateImplement { get; set; }
    }
}
