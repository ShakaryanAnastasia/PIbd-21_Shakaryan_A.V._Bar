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
    public class PantryServiceList : IPantryService
    {
        private DataListSingleton source;
        public PantryServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PantryViewModel> GetList()
        {
            List<PantryViewModel> result = source.Pantrys
            .Select(rec => new PantryViewModel
            {
                Id = rec.Id,
                PantryName = rec.PantryName,
                PantryIngredients = source.PantryIngredients
            .Where(recPC => recPC.PantryId == rec.Id)
            .Select(recPC => new PantryIngredientViewModel
            {
                Id = recPC.Id,
                PantryId = recPC.PantryId,
                IngredientId = recPC.IngredientId,
                IngredientName = source.Ingredients
            .FirstOrDefault(recC => recC.Id ==
            recPC.IngredientId)?.IngredientName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public PantryViewModel GetElement(int id)
        {
            Pantry element = source.Pantrys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new PantryViewModel
                {
                    Id = element.Id,
                    PantryName = element.PantryName,
                    PantryIngredients = source.PantryIngredients
                .Where(recPC => recPC.PantryId == element.Id)
                .Select(recPC => new PantryIngredientViewModel
                {
                    Id = recPC.Id,
                    PantryId = recPC.PantryId,
                    IngredientId = recPC.IngredientId,
                    IngredientName = source.Ingredients
                .FirstOrDefault(recC => recC.Id ==
                recPC.IngredientId)?.IngredientName,
                    Count = recPC.Count
                })
                .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(PantryBindingModel model)
        {
            Pantry element = source.Pantrys.FirstOrDefault(rec => rec.PantryName ==

            model.PantryName);
            if (element != null)
            {
                throw new Exception("Уже есть кладовая с таким названием");
            }
            int maxId = source.Pantrys.Count > 0 ? source.Pantrys.Max(rec => rec.Id) : 0;
            source.Pantrys.Add(new Pantry
            {
                Id = maxId + 1,
                PantryName = model.PantryName
            });
        }
        public void UpdElement(PantryBindingModel model)
        {
            Pantry element = source.Pantrys.FirstOrDefault(rec =>
            rec.PantryName == model.PantryName && rec.Id !=
            model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть кладовая с таким названием");
            }
            element = source.Pantrys.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.PantryName = model.PantryName;
        }
        public void DelElement(int id)
        {
            Pantry element = source.Pantrys.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                // при удалении удаляем все записи о ингредиентах на удаляемой кладовой
                source.PantryIngredients.RemoveAll(rec => rec.PantryId == id);
                source.Pantrys.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
