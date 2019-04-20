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
    public class MainServiceList : IMainService
    {
        private DataListSingleton source;

        public MainServiceList()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = source.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                HabitueId = rec.HabitueId,
                CocktailId = rec.CocktailId,
                DateCreate = rec.DateCreate.ToLongDateString(),
                DateImplement = rec.DateImplement?.ToLongDateString(),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                HabitueFIO = source.Habitues.FirstOrDefault(recC => recC.Id == rec.HabitueId)?.HabitueFIO,
                CocktailName = source.Cocktails.FirstOrDefault(recP => recP.Id == rec.CocktailId)?.CocktailName,
            }).ToList();
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = source.Bookings.Count > 0 ? source.Bookings.Max(rec => rec.Id) : 0;
            source.Bookings.Add(new Booking
            {
                Id = maxId + 1,
                HabitueId = model.HabitueId,
                CocktailId = model.CocktailId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
        }

        public void TakeBookingInWork(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            // смотрим по количеству компонентов в кладовых
            var CocktailIngredients = source.CocktailIngredients.Where(rec => rec.CocktailId
            == element.CocktailId);

            foreach (var CocktailIngredient in CocktailIngredients)
            {
                int countOnPantrys = source.PantryIngredients
                .Where(rec => rec.IngredientId ==
                CocktailIngredient.IngredientId)
                .Sum(rec => rec.Count);
                if (countOnPantrys < CocktailIngredient.Count * element.Count)
                {
                    var IngredientName = source.Ingredients.FirstOrDefault(rec => rec.Id ==
                    CocktailIngredient.IngredientId);
                    throw new Exception("Не достаточно ингредиента " +
                    IngredientName?.IngredientName + " требуется " + (CocktailIngredient.Count * element.Count) +
                    ", в наличии " + countOnPantrys);
                }
            }
            // списываем
            foreach (var CocktailIngredient in CocktailIngredients)
            {
                int countOnPantrys = CocktailIngredient.Count * element.Count;
                var PantryIngredients = source.PantryIngredients.Where(rec => rec.IngredientId
                == CocktailIngredient.IngredientId);
                foreach (var PantryIngredient in PantryIngredients)
                {
                    // компонентов в одной кладовой может не хватать
                    if (PantryIngredient.Count >= countOnPantrys)
                    {
                        PantryIngredient.Count -= countOnPantrys;
                        break;
                    }
                    else
                    {
                        countOnPantrys -= PantryIngredient.Count;
                        PantryIngredient.Count = 0;
                    }
                }
            }
            element.DateImplement = DateTime.Now;
            element.Status = BookingStatus.Смешивается;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешивается)
            {
                throw new Exception("Заказ не в статусе \"Смешивается\"");
            }
            element.Status = BookingStatus.Смешан;
        }

        public void PayBooking(BookingBindingModel model)
        {
            Booking element = source.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешан)
            {
                throw new Exception("Заказ не в статусе \"Смешан\"");
            }
            element.Status = BookingStatus.Оплачен;
        }
        public void PutIngredientOnPantry(PantryIngredientBindingModel model)
        {
            PantryIngredient element = source.PantryIngredients.FirstOrDefault(rec =>
            rec.PantryId == model.PantryId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                int maxId = source.PantryIngredients.Count > 0 ?
                source.PantryIngredients.Max(rec => rec.Id) : 0;
                source.PantryIngredients.Add(new PantryIngredient
                {
                    Id = ++maxId,
                    PantryId = model.PantryId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
        }

        public List<BookingViewModel> GetFreeBookings()
        {
            throw new NotImplementedException();
        }
    }
}
