using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarModel
{
    /// <summary>
    /// Бармен, выполняющий заказы клиентов
    /// </summary>
    public class Bartender
    {
        public int Id { get; set; }
        [Required]
        public string BartenderFIO { get; set; }
        [ForeignKey("BartenderId")]
        public virtual List<Booking> Bookings { get; set; }
    }
}
