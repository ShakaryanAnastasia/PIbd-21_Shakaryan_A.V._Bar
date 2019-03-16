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
    public class IngredientServiceDB : IIngredientService
    {
        private BarDbContext context;
        public IngredientServiceDB(BarDbContext context)
        {
            this.context = context;
        }
        public List<IngredientViewModel> GetList()
        {
            List<IngredientViewModel> result = context.Ingredients.Select(rec => new
            IngredientViewModel
            {
                Id = rec.Id,
                IngredientName = rec.IngredientName
            })
            .ToList();
            return result;
        }
        public IngredientViewModel GetElement(int id)
        {
            Ingredient ingredient = context.Ingredients.FirstOrDefault(rec => rec.Id == id);
            if (ingredient != null)
            {
                return new IngredientViewModel
                {
                    Id = ingredient.Id,
                    IngredientName = ingredient.IngredientName
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(IngredientBindingModel model)
        {
            Ingredient ingredient = context.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
            model.IngredientName);
            if (ingredient != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            context.Ingredients.Add(new Ingredient
            {
                IngredientName = model.IngredientName
            });
            context.SaveChanges();
        }
        public void UpdElement(IngredientBindingModel model)
        {
            Ingredient ingredient = context.Ingredients.FirstOrDefault(rec => rec.IngredientName ==
            model.IngredientName && rec.Id != model.Id);
            if (ingredient != null)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            ingredient = context.Ingredients.FirstOrDefault(rec => rec.Id == model.Id);
            if (ingredient == null)
            {
                throw new Exception("Элемент не найден");
            }
            ingredient.IngredientName = model.IngredientName;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Ingredient Ingredient = context.Ingredients.FirstOrDefault(rec => rec.Id == id);
            if (Ingredient != null)
            {
                context.Ingredients.Remove(Ingredient);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
