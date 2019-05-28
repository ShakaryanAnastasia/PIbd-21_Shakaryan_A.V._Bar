using BarServiceDAL.Attributies;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System.Collections.Generic;

namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с отчетами")]
    public interface IRecordService
    {
        [CustomMethod("Метод сохранения отчета о стоимости коктейлей")]
        void SaveCocktailPrice(RecordBindingModel model);

        [CustomMethod("Метод получения списка загруженности кладовых")]
        List<PantrysLoadViewModel> GetPantrysLoad();

        [CustomMethod("Метод сохранения отчета о загруженности кладовых")]
        void SavePantrysLoad(RecordBindingModel model);

        [CustomMethod("Метод получения списка заказов завсегдатаев")]
        List<HabitueBookingsModel> GetHabitueBookings(RecordBindingModel model);

        [CustomMethod("Метод сохранения отчета о заказах завсегдатаев")]
        void SaveHabitueBookings(RecordBindingModel model);
    }
}
