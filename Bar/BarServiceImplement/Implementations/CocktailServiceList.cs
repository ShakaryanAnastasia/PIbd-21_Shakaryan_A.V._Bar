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
    public class CocktailServiceList : ICocktailService
    {
        private DataListSingleton source;

        public CocktailServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<CocktailViewModel> GetList()
        {
            List<CocktailViewModel> result = source.Cocktails
                .Select(rec => new CocktailViewModel
                {
                    Id = rec.Id,
                    CocktailName = rec.CocktailName,
                    Price = rec.Price,
                    CocktailIngredients = source.CocktailIngredients
                        .Where(recPC => recPC.CocktailId == rec.Id)
                        .Select(recPC => new CocktailIngredientViewModel
                        {
                            Id = recPC.Id,
                            CocktailId = recPC.CocktailId,
                            IngredientId = recPC.IngredientId,
                            IngredientName = source.Ingredients.FirstOrDefault(recC =>
    recC.Id == recPC.IngredientId)?.IngredientName,
                            Count = recPC.Count
                        })
                            .ToList()
                })
                    .ToList();

            return result;
        }

        public CocktailViewModel GetElement(int id)
        {
            Cocktail element = source.Cocktails.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CocktailViewModel
                {
                    Id = element.Id,
                    CocktailName = element.CocktailName,
                    Price = element.Price,
                    CocktailIngredients = source.CocktailIngredients
                .Where(recPC => recPC.CocktailId == element.Id)
                .Select(recPC => new CocktailIngredientViewModel
                {
                    Id = recPC.Id,
                    CocktailId = recPC.CocktailId,
                    IngredientId = recPC.IngredientId,
                    IngredientName = source.Ingredients.FirstOrDefault(recC =>
    recC.Id == recPC.IngredientId)?.IngredientName,
                    Count = recPC.Count
                })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CocktailBindingModel model)
        {
            Cocktail element = source.Cocktails.FirstOrDefault(rec => rec.CocktailName ==
         model.CocktailName);
            if (element != null)
            {
                throw new Exception("Уже есть коктейль с таким названием");
            }
            int maxId = source.Cocktails.Count > 0 ? source.Cocktails.Max(rec => rec.Id) :
            0;
            source.Cocktails.Add(new Cocktail
            {
                Id = maxId + 1,
                CocktailName = model.CocktailName,
                Price = model.Price
            });
            // ингредиенты для коктейля
            int maxPCId = source.CocktailIngredients.Count > 0 ?
            source.CocktailIngredients.Max(rec => rec.Id) : 0;
            // убираем дубли по ингредиентам
            var groupIngredients = model.CocktailIngredients
            .GroupBy(rec => rec.IngredientId)
            .Select(rec => new
            {
                IngredientId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            // добавляем ингредиенты
            foreach (var groupIngredient in groupIngredients)
            {
                source.CocktailIngredients.Add(new CocktailIngredient
                {
                    Id = ++maxPCId,
                    CocktailId = maxId + 1,

                    IngredientId = groupIngredient.IngredientId,
                    Count = groupIngredient.Count
                });
            }
        }

        public void UpdElement(CocktailBindingModel model)
        {
            Cocktail element = source.Cocktails.FirstOrDefault(rec => rec.CocktailName ==
        model.CocktailName && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть коктейль с таким названием");
            }
            element = source.Cocktails.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.CocktailName = model.CocktailName;
            element.Price = model.Price;
            int maxPCId = source.CocktailIngredients.Count > 0 ?
            source.CocktailIngredients.Max(rec => rec.Id) : 0;
            // обновляем существуюущие ингредиенты
            var compIds = model.CocktailIngredients.Select(rec =>
            rec.IngredientId).Distinct();
            var updateIngredients = source.CocktailIngredients.Where(rec => rec.CocktailId ==
            model.Id && compIds.Contains(rec.IngredientId));
            foreach (var updateIngredient in updateIngredients)
            {
                updateIngredient.Count = model.CocktailIngredients.FirstOrDefault(rec =>
                rec.Id == updateIngredient.Id).Count;
            }
            source.CocktailIngredients.RemoveAll(rec => rec.CocktailId == model.Id &&
            !compIds.Contains(rec.IngredientId));
            // новые записи
            var groupIngredients = model.CocktailIngredients
            .Where(rec => rec.Id == 0)
            .GroupBy(rec => rec.IngredientId)
            .Select(rec => new
            {
                IngredientId = rec.Key,
                Count = rec.Sum(r => r.Count)
            });
            foreach (var groupIngredient in groupIngredients)
            {
                CocktailIngredient elementPC = source.CocktailIngredients.FirstOrDefault(rec
                => rec.CocktailId == model.Id && rec.IngredientId == groupIngredient.IngredientId);
                if (elementPC != null)
                {
                    elementPC.Count += groupIngredient.Count;
                }
                else
                {
                    source.CocktailIngredients.Add(new CocktailIngredient
                    {
                        Id = ++maxPCId,
                        CocktailId = model.Id,
                        IngredientId = groupIngredient.IngredientId,
                        Count = groupIngredient.Count
                    });
                }
            }
        }

        public void DelElement(int id)
        {
            Cocktail element = source.Cocktails.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // удаяем записи по ингредиентам при удалении коктейля
                source.CocktailIngredients.RemoveAll(rec => rec.CocktailId == id);
                source.Cocktails.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
