using BarModel;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private BarDbContext context;
        public MainServiceDB(BarDbContext context)
        {
            this.context = context;
        }
        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,
                HabitueId = rec.HabitueId,
                CocktailId = rec.CocktailId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
            rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                HabitueFIO = rec.Habitue.HabitueFIO,
                CocktailName = rec.Cocktail.CocktailName
            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            context.Bookings.Add(new Booking
            {
                HabitueId = model.HabitueId,
                CocktailId = model.CocktailId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            });
            context.SaveChanges();
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {
            
        using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Booking element = context.Bookings.FirstOrDefault(rec => rec.Id ==
                    model.Id);
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if (element.Status != BookingStatus.Принят)
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var CocktailIngredients = context.CocktailIngredients.Include(rec => rec.Ingredient).Where(rec => rec.CocktailId == element.CocktailId);
                    // списываем
                    foreach (var CocktailIngredient in CocktailIngredients)
                    {
                        int countOnPantrys = CocktailIngredient.Count * element.Count;
                        var PantryIngredients = context.PantryIngredients.Where(rec =>
                        rec.IngredientId == CocktailIngredient.IngredientId);
                        foreach (var PantryIngredient in PantryIngredients)
                        {
                            // компонентов на одном слкаде может не хватать
                            if (PantryIngredient.Count >= countOnPantrys)
                            {
                                PantryIngredient.Count -= countOnPantrys;
                                countOnPantrys = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnPantrys -= PantryIngredient.Count;
                                PantryIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnPantrys > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                            CocktailIngredient.Ingredient.IngredientName + " требуется " + CocktailIngredient.Count + ", не хватает " + countOnPantrys);
                        }
                    }
                    element.DateImplement = DateTime.Now;
                    element.Status = BookingStatus.Смешивается;
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
               
        {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешивается)
            {
                throw new Exception("Заказ не в статусе \"Выполняется\"");
            }
            element.Status = BookingStatus.Смешан;
            context.SaveChanges();
        }
        public void PayBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешан)
            {
                throw new Exception("Заказ не в статусе \"Готов\"");
            }
            element.Status = BookingStatus.Оплачен;
            context.SaveChanges();
        }
        public void PutIngredientOnPantry(PantryIngredientBindingModel model)
        {
            PantryIngredient element = context.PantryIngredients.FirstOrDefault(rec =>
            rec.PantryId == model.PantryId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.PantryIngredients.Add(new PantryIngredient
                {
                    PantryId = model.PantryId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
    }
}
