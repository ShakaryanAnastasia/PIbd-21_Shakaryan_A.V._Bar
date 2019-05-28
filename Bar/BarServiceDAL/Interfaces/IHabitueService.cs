using BarServiceDAL.Attributies;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System.Collections.Generic;


namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с завсегдатаями")]
    public interface IHabitueService
    {
        [CustomMethod("Метод получения списка завсегдатаев")]
        List<HabitueViewModel> GetList();

        [CustomMethod("Метод получения завсегдатая по id")]
        HabitueViewModel GetElement(int id);

        [CustomMethod("Метод добавления завсегдатая")]
        void AddElement(HabitueBindingModel model);

        [CustomMethod("Метод изменения данных по завсегдатаю")]
        void UpdElement(HabitueBindingModel model);

        [CustomMethod("Метод удаления завсегдатая")]
        void DelElement(int id);
    }
}
