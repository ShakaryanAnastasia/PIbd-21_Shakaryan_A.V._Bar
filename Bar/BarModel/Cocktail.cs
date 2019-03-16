﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
    /// <summary>     
    /// Коктейл, изготавливаемый в баре
    /// </summary>
     public class Cocktail
    {
        public int Id { get; set; }
        [Required]
        public string CocktailName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public virtual List<Booking> Bookings { get; set; }
    }
}
