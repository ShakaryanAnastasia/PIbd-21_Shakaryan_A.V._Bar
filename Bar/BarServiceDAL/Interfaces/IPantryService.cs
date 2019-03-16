using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
    public interface IPantryService
    {
        List<PantryViewModel> GetList();
        PantryViewModel GetElement(int id);
        void AddElement(PantryBindingModel model);
        void UpdElement(PantryBindingModel model);
        void DelElement(int id);
    }
}
