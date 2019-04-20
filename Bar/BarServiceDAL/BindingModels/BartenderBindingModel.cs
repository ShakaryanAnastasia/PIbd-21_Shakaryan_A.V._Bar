using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace BarServiceDAL.BindingModels
{
    [DataContract]
    public class BartenderBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BartenderFIO { get; set; }
    }
}
