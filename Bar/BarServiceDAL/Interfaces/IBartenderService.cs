using System.Collections.Generic;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using BarServiceDAL.Attributies;

namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с барменами")]
    public interface IBartenderService
    {
        [CustomMethod("Метод получения списка барменов")]
        List<BartenderViewModel> GetList();

        [CustomMethod("Метод получения бармена по id")]
        BartenderViewModel GetElement(int id);

        [CustomMethod("Метод добавления бармена")]
        void AddElement(BartenderBindingModel model);

        [CustomMethod("Метод изменения данных по бармену")]
        void UpdElement(BartenderBindingModel model);

        [CustomMethod("Метод удаления бармена")]
        void DelElement(int id);

        [CustomMethod("Метод получения свободного бармена")]
        BartenderViewModel GetFreeWorker();
    }
}
