using BarModel;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceImplementDataBase.Implementations
{
    public class PantryServiceDB : IPantryService
    {
        private BarWebDbContext context;
        public PantryServiceDB(BarWebDbContext context)
        {
            this.context = context;
        }
        public PantryServiceDB()
        {
            this.context = new BarWebDbContext();
        }
        public List<PantryViewModel> GetList()
        {
            List<PantryViewModel> result = context.Pantrys.Select(rec => new
            PantryViewModel
            {
                Id = rec.Id,
                PantryName = rec.PantryName,
                PantryIngredients = context.PantryIngredients
            .Where(recPC => recPC.PantryId == rec.Id)
            .Select(recPC => new PantryIngredientViewModel
            {
                Id = recPC.Id,
                PantryId = recPC.PantryId,
                IngredientId = recPC.IngredientId,
                IngredientName = recPC.Ingredient.IngredientName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public PantryViewModel GetElement(int id)
        {
            Pantry ingredient = context.Pantrys.FirstOrDefault(rec => rec.Id == id);
            if (ingredient != null)
            {
                return new PantryViewModel
                {
                    Id = ingredient.Id,
                    PantryName = ingredient.PantryName,
                    PantryIngredients = context.PantryIngredients
                    .Where(recPC => recPC.PantryId == ingredient.Id)
                    .Select(recPC => new PantryIngredientViewModel
                    {
                        Id = recPC.Id,
                        PantryId = recPC.PantryId,
                        IngredientId = recPC.IngredientId,
                        IngredientName = recPC.Ingredient.IngredientName,
                        Count = recPC.Count
                    })
                    .ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(PantryBindingModel model)
        {
            Pantry ingredient = context.Pantrys.FirstOrDefault(rec => rec.PantryName ==
            model.PantryName);
            if (ingredient != null)
            {
                throw new Exception("Уже есть кладовая с таким названием");
            }
            context.Pantrys.Add(new Pantry
            {
                PantryName = model.PantryName
            });
            context.SaveChanges();
        }
        public void UpdElement(PantryBindingModel model)
        {
            Pantry ingredient = context.Pantrys.FirstOrDefault(rec => rec.PantryName ==
            model.PantryName && rec.Id != model.Id);
            if (ingredient != null)
            {
                throw new Exception("Уже есть кладовая с таким названием");
            }
            ingredient = context.Pantrys.FirstOrDefault(rec => rec.Id == model.Id);
            if (ingredient == null)
            {
                throw new Exception("Элемент не найден");
            }
            ingredient.PantryName = model.PantryName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Pantry ingredient = context.Pantrys.FirstOrDefault(rec => rec.Id == id);
            if (ingredient != null)
            {
                context.Pantrys.Remove(ingredient);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
