using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BarServiceDAL.ViewModels
{
    [DataContract]
    public class PantrysLoadViewModel
    {
        [DataMember]
        public string PantryName { get; set; }
        [DataMember]
        public int TotalCount { get; set; }
        [DataMember]
        public IEnumerable<Tuple<string, int>> Ingredients { get; set; }
    }
}
