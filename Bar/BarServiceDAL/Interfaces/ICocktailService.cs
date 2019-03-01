using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
   public interface ICocktailService
    {
        List<CocktailViewModel> GetList();
        CocktailViewModel GetElement(int id);
        void AddElement(CocktailBindingModel model);
        void UpdElement(CocktailBindingModel model);
        void DelElement(int id);
    }
}
