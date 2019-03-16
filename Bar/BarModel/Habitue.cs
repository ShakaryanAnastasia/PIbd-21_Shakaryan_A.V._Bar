using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{ 
  /// <summary> 
  /// Завсегдатай бара  
  /// </summary>
    public class Habitue
    {
        public int Id { get; set; }

        [Required]
        public string HabitueFIO { get; set; }

        [ForeignKey("HabitueId")]
        public virtual List<Booking> Bookings { get; set; }
    }
}
