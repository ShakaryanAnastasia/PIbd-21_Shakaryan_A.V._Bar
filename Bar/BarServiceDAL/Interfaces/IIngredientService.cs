using BarServiceDAL.Attributies;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System.Collections.Generic;

namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с ингредиентами")]
    public interface IIngredientService
    {
        [CustomMethod("Метод получения списка ингредиентов")]
        List<IngredientViewModel> GetList();

        [CustomMethod("Метод получения ингредиента по id")]
        IngredientViewModel GetElement(int id);

        [CustomMethod("Метод добавления ингредиента")]
        void AddElement(IngredientBindingModel model);

        [CustomMethod("Метод изменения данных по ингредиентам")]
        void UpdElement(IngredientBindingModel model);

        [CustomMethod("Метод удаления ингредиента")]
        void DelElement(int id);
    }
}
