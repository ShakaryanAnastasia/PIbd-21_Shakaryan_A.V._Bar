using BarModel;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceImplement.Implementations
{
    class CocktailIngredientServiceList : ICocktailIngredientService
    {
        private DataListSingleton source;

        public CocktailIngredientServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CocktailIngredientViewModel> GetList()
        {
            List<CocktailIngredientViewModel> result = new List<CocktailIngredientViewModel>();
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                result.Add(new CocktailIngredientViewModel
                {
                    Id = source.CocktailIngredients[i].Id,
                    CocktailId = source.CocktailIngredients[i].CocktailId,
                    IngredientId = source.CocktailIngredients[i].IngredientId,
                    Count = source.CocktailIngredients[i].Count,
                    IngredientName = source.CocktailIngredients[i].IngredientName
                });
            }
            return result;
        }

        public CocktailIngredientViewModel GetElement(int id)
        {
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id == id)
                {
                    return new CocktailIngredientViewModel
                    {
                        Id = source.CocktailIngredients[i].Id,
                        IngredientName = source.CocktailIngredients[i].IngredientName
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CocktailIngredientBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id > maxId)
                {
                    maxId = source.CocktailIngredients[i].Id;
                }
                if (source.CocktailIngredients[i].IngredientName == model.IngredientName)
                {
                    throw new Exception("Уже есть ингредиент с таким именем");
                }
            }
            source.CocktailIngredients.Add(new CocktailIngredient
            {
                Id = maxId + 1,
                CocktailId = model.CocktailId,
                IngredientId = model.IngredientId,
                Count = model.Count,
                IngredientName = model.IngredientName
            });
        }

        public void UpdElement(CocktailIngredientBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.CocktailIngredients[i].IngredientName == model.IngredientName &&
                source.CocktailIngredients[i].Id != model.Id)
                {
                    throw new Exception("Уже есть ингредиент с таким именем");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.CocktailIngredients[index].IngredientName = model.IngredientName;
        }

        public void DelElement(int id)
        {
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id == id)
                {
                    source.CocktailIngredients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
