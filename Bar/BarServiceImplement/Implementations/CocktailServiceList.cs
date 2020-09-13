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
            List<CocktailViewModel> result = new List<CocktailViewModel>();
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                // требуется дополнительно получить список ингредиентов для коктейля и их количество
                List<CocktailIngredientViewModel> CocktailIngredients = new
                List<CocktailIngredientViewModel>();
                for (int j = 0; j < source.CocktailIngredients.Count; ++j)
                {
                    if (source.CocktailIngredients[j].CocktailId == source.Cocktails[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.CocktailIngredients[j].IngredientId ==
                            source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        CocktailIngredients.Add(new CocktailIngredientViewModel
                        {
                            Id = source.CocktailIngredients[j].Id,
                            CocktailId = source.CocktailIngredients[j].CocktailId,
                            IngredientId = source.CocktailIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.CocktailIngredients[j].Count
                        });
                    }
                }
                result.Add(new CocktailViewModel
                {
                    Id = source.Cocktails[i].Id,
                    CocktailName = source.Cocktails[i].CocktailName,
                    Price = source.Cocktails[i].Price,
                    CocktailIngredients = CocktailIngredients
                });
            }
            return result;
        }

        public CocktailViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                // требуется дополнительно получить список ингредиентов для коктейля и их количество
                List<CocktailIngredientViewModel> CocktailIngredients = new
                List<CocktailIngredientViewModel>();
                for (int j = 0; j < source.CocktailIngredients.Count; ++j)
                {
                    if (source.CocktailIngredients[j].CocktailId == source.Cocktails[i].Id)
                    {
                        string IngredientName = string.Empty;
                        for (int k = 0; k < source.Ingredients.Count; ++k)
                        {
                            if (source.CocktailIngredients[j].IngredientId ==
                            source.Ingredients[k].Id)
                            {
                                IngredientName = source.Ingredients[k].IngredientName;
                                break;
                            }
                        }
                        CocktailIngredients.Add(new CocktailIngredientViewModel
                        {
                            Id = source.CocktailIngredients[j].Id,
                            CocktailId = source.CocktailIngredients[j].CocktailId,
                            IngredientId = source.CocktailIngredients[j].IngredientId,
                            IngredientName = IngredientName,
                            Count = source.CocktailIngredients[j].Count
                        });
                    }
                }
                if (source.Cocktails[i].Id == id)
                {
                    return new CocktailViewModel
                    {
                        Id = source.Cocktails[i].Id,
                        CocktailName = source.Cocktails[i].CocktailName,
                        Price = source.Cocktails[i].Price,
                        CocktailIngredients = CocktailIngredients
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }

        public void AddElement(CocktailBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                if (source.Cocktails[i].Id > maxId)
                {
                    maxId = source.Cocktails[i].Id;
                }
                if (source.Cocktails[i].CocktailName == model.CocktailName)
                {
                    throw new Exception("Уже есть коктейль с таким названием");
                }
            }
            source.Cocktails.Add(new Cocktail
            {
                Id = maxId + 1,
                CocktailName = model.CocktailName,
                Price = model.Price
            });
            // ингредиенты для коктейлей
            int maxPCId = 0;
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.CocktailIngredients[i].Id;
                }
            }
            // убираем дубли по ингредиентам
            for (int i = 0; i < model.CocktailIngredients.Count; ++i)
            {
                for (int j = 1; j < model.CocktailIngredients.Count; ++j)
                {
                    if (model.CocktailIngredients[i].IngredientId ==
                    model.CocktailIngredients[j].IngredientId)
                    {
                        model.CocktailIngredients[i].Count +=
                        model.CocktailIngredients[j].Count;
                        model.CocktailIngredients.RemoveAt(j--);
                    }
                }
            }
            // добавляем ингредиенты
            for (int i = 0; i < model.CocktailIngredients.Count; ++i)
            {
                source.CocktailIngredients.Add(new CocktailIngredient
                {
                    Id = ++maxPCId,
                    CocktailId = maxId + 1,
                    IngredientId = model.CocktailIngredients[i].IngredientId,
                    Count = model.CocktailIngredients[i].Count
                });
            }
        }

        public void UpdElement(CocktailBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                if (source.Cocktails[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Cocktails[i].CocktailName == model.CocktailName &&
                source.Cocktails[i].Id != model.Id)
                {
                    throw new Exception("Уже есть коктейль с таким названием");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Cocktails[index].CocktailName = model.CocktailName;
            source.Cocktails[index].Price = model.Price;
            int maxPCId = 0;
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].Id > maxPCId)
                {
                    maxPCId = source.CocktailIngredients[i].Id;
                }
            }
            // обновляем существуюущие ингредиенты
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].CocktailId == model.Id)
                {
                    bool flag = true;
                    for (int j = 0; j < model.CocktailIngredients.Count; ++j)
                    {
                        // если встретили, то изменяем количество
                        if (source.CocktailIngredients[i].Id ==
                        model.CocktailIngredients[j].Id)
                        {
                            source.CocktailIngredients[i].Count =
                            model.CocktailIngredients[j].Count;
                            flag = false;
                            break;
                        }
                    }
                    // если не встретили, то удаляем
                    if (flag)
                    {
                        source.CocktailIngredients.RemoveAt(i--);
                    }
                }
            }
            // новые записи
            for (int i = 0; i < model.CocktailIngredients.Count; ++i)
            {
                if (model.CocktailIngredients[i].Id == 0)
                {
                    // ищем дубли
                    for (int j = 0; j < source.CocktailIngredients.Count; ++j)
                    {
                        if (source.CocktailIngredients[j].CocktailId == model.Id &&
                        source.CocktailIngredients[j].IngredientId ==
                        model.CocktailIngredients[i].IngredientId)
                        {
                            source.CocktailIngredients[j].Count +=
                            model.CocktailIngredients[i].Count;
                            model.CocktailIngredients[i].Id =
                            source.CocktailIngredients[j].Id;
                            break;
                        }
                    }
                    // если не нашли дубли, то новая запись
                    if (model.CocktailIngredients[i].Id == 0)
                    {
                        source.CocktailIngredients.Add(new CocktailIngredient
                        {
                            Id = ++maxPCId,
                            CocktailId = model.Id,
                            IngredientId = model.CocktailIngredients[i].IngredientId,
                            Count = model.CocktailIngredients[i].Count
                        });
                    }
                }
            }
        }

        public void DelElement(int id)
        {
            // удаяем записи по ингредиентам при удалении коктейля
            for (int i = 0; i < source.CocktailIngredients.Count; ++i)
            {
                if (source.CocktailIngredients[i].CocktailId == id)
                {
                    source.CocktailIngredients.RemoveAt(i--);
                }
            }
            for (int i = 0; i < source.Cocktails.Count; ++i)
            {
                if (source.Cocktails[i].Id == id)
                {
                    source.Cocktails.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
