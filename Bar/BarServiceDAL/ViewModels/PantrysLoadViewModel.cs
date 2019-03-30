using System;
using System.Collections.Generic;

namespace BarServiceDAL.ViewModels
{
    public class PantrysLoadViewModel
    {
        public string PantryName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}
