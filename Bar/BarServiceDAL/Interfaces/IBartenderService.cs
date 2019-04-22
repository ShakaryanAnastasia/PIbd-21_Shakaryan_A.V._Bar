using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;

namespace BarServiceDAL.Interfaces
{
    public interface IBartenderService
    {
        List<BartenderViewModel> GetList();
        BartenderViewModel GetElement(int id);
        void AddElement(BartenderBindingModel model);
        void UpdElement(BartenderBindingModel model);
        void DelElement(int id);
        BartenderViewModel GetFreeWorker();
    }
}
