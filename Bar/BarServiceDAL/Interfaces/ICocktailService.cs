using BarServiceDAL.Attributies;
using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
    [CustomInterface("Интерфейс для работы с коктейлями")]
    public interface ICocktailService
    {
        [CustomMethod("Метод получения списка коктейлей")]
        List<CocktailViewModel> GetList();

        [CustomMethod("Метод получения коктейля по id")]
        CocktailViewModel GetElement(int id);

        [CustomMethod("Метод добавления коктейля")]
        void AddElement(CocktailBindingModel model);

        [CustomMethod("Метод изменения данных по коктейлю")]
        void UpdElement(CocktailBindingModel model);

        [CustomMethod("Метод удаления коктейля")]
        void DelElement(int id);
    }
}
