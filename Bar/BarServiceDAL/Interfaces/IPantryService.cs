using BarServiceDAL.Attributies;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;

namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с кладовыми")]
    public interface IPantryService
    {
        [CustomMethod("Метод получения списка кладовой")]
        List<PantryViewModel> GetList();

        [CustomMethod("Метод получения кладовой по id")]
        PantryViewModel GetElement(int id);

        [CustomMethod("Метод добавления кладовой")]
        void AddElement(PantryBindingModel model);

        [CustomMethod("Метод изменения данных по кладовой")]
        void UpdElement(PantryBindingModel model);

        [CustomMethod("Метод удаления кладовой")]
        void DelElement(int id);
    }
}
