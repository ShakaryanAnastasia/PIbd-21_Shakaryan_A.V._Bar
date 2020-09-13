using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
    public interface IHabitueService
    {
        List<HabitueViewModel> GetList();

        HabitueViewModel GetElement(int id);

        void AddElement(HabitueBindingModel model);

        void UpdElement(HabitueBindingModel model);

        void DelElement(int id);
    }
}
