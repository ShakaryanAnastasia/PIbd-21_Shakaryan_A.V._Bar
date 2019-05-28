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
    public class CocktailServiceDB : ICocktailService
    {
        private BarWebDbContext context;
        public CocktailServiceDB(BarWebDbContext context)
        {
            this.context = context;
        }
        public CocktailServiceDB()
        {
            this.context = new BarWebDbContext();
        }
        public List<CocktailViewModel> GetList()
        {
            List<CocktailViewModel> result = context.Cocktails.Select(rec => new
            CocktailViewModel
            {
                Id = rec.Id,
                CocktailName = rec.CocktailName,
                Price = rec.Price,
                CocktailIngredients = context.CocktailIngredients
            .Where(recPC => recPC.CocktailId == rec.Id)
            .Select(recPC => new CocktailIngredientViewModel
            {
                Id = recPC.Id,
                CocktailId = recPC.CocktailId,
                IngredientId = recPC.IngredientId,
                IngredientName = recPC.Ingredient.IngredientName,
                Count = recPC.Count
            })
            .ToList()
            })
            .ToList();
            return result;
        }
        public CocktailViewModel GetElement(int id)
        {
            Cocktail element = context.Cocktails.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new CocktailViewModel

                {
                    Id = element.Id,
                    CocktailName = element.CocktailName,
                    Price = element.Price,
                    CocktailIngredients = context.CocktailIngredients
.Where(recPC => recPC.CocktailId == element.Id)
.Select(recPC => new CocktailIngredientViewModel
{
    Id = recPC.Id,
    CocktailId = recPC.CocktailId,
    IngredientId = recPC.IngredientId,
    IngredientName = recPC.Ingredient.IngredientName,
    Count = recPC.Count
})
.ToList()
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(CocktailBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cocktail element = context.Cocktails.FirstOrDefault(rec =>
                    rec.CocktailName == model.CocktailName);
                    if (element != null)
                    {
                        throw new Exception("Уже есть коктейль с таким названием");
                    }
                    element = new Cocktail
                    {
                        CocktailName = model.CocktailName,
                        Price = model.Price
                    };
                    context.Cocktails.Add(element);
                    context.SaveChanges();
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
                        context.CocktailIngredients.Add(new CocktailIngredient
                        {
                            CocktailId = element.Id,
                            IngredientId = groupIngredient.IngredientId,
                            Count = groupIngredient.Count
                        });
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;

                }
            }
        }
        public void UpdElement(CocktailBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cocktail element = context.Cocktails.FirstOrDefault(rec =>
                    rec.CocktailName == model.CocktailName && rec.Id != model.Id);
                    if (element != null)
                    {
                        throw new Exception("Уже есть коктейль с таким названием");
                    }
                    element = context.Cocktails.FirstOrDefault(rec => rec.Id == model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    element.CocktailName = model.CocktailName;
                    element.Price = model.Price;
                    context.SaveChanges();
                    // обновляем существуюущие ингредиенты
                    var compIds = model.CocktailIngredients.Select(rec =>
                    rec.IngredientId).Distinct();
                    var updateIngredients = context.CocktailIngredients.Where(rec =>
                    rec.CocktailId == model.Id && compIds.Contains(rec.IngredientId));
                    foreach (var updateIngredient in updateIngredients)
                    {
                        updateIngredient.Count =
                        model.CocktailIngredients.FirstOrDefault(rec => rec.Id == updateIngredient.Id).Count;
                    }
                    context.SaveChanges();
                    context.CocktailIngredients.RemoveRange(context.CocktailIngredients.Where(rec =>
                    rec.CocktailId == model.Id && !compIds.Contains(rec.IngredientId)));
                    context.SaveChanges();
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
                        CocktailIngredient elementPC =
                        context.CocktailIngredients.FirstOrDefault(rec => rec.CocktailId == model.Id &&
                        rec.IngredientId == groupIngredient.IngredientId);
                        if (elementPC != null)
                        {
                            elementPC.Count += groupIngredient.Count;
                            context.SaveChanges();
                        }
                        else
                        {
                            context.CocktailIngredients.Add(new CocktailIngredient
                            {
                                CocktailId = model.Id,

                                IngredientId = groupIngredient.IngredientId,
                                Count = groupIngredient.Count
                            });
                            context.SaveChanges();
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void DelElement(int id)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Cocktail element = context.Cocktails.FirstOrDefault(rec => rec.Id ==
                    id);
                    if (element != null)
                    {
                        // удаяем записи по ингредиентам при удалении коктейля
                        context.CocktailIngredients.RemoveRange(context.CocktailIngredients.Where(rec =>
                        rec.CocktailId == id));
                        context.Cocktails.Remove(element);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Элемент не найден");
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
