using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarModel
{
  /// <summary>    
  /// Статус заказа   
  /// </summary> 
    public enum BookingStatus
    {
        Принят = 0,

        Смешивается = 1,

        Смешан = 2,

        Оплачен = 3
    }
}
