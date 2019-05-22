using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System.Collections.Generic;

namespace BarServiceDAL.Interfaces
{
    public interface IRecordService
    {
        void SaveCocktailPrice(RecordBindingModel model);
        List<PantrysLoadViewModel> GetPantrysLoad();
        void SavePantrysLoad(RecordBindingModel model);
        List<HabitueBookingsModel> GetHabitueBookings(RecordBindingModel model);
        void SaveHabitueBookings(RecordBindingModel model);
    }
}
