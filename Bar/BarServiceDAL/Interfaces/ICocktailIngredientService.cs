using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
    public interface ICocktailIngredientService
    {
        List<CocktailIngredientViewModel> GetList();
        CocktailIngredientViewModel GetElement(int id);
        void AddElement(CocktailIngredientBindingModel model);
        void UpdElement(CocktailIngredientBindingModel model);
        void DelElement(int id);
    }
}
