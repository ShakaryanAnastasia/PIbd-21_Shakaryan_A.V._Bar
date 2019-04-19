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
            List<BookingViewModel> result = new List<BookingViewModel>();
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                string HabitueFIO = string.Empty;
                for (int j = 0; j < source.Habitues.Count; ++j)
                {
                    if (source.Habitues[j].Id == source.Bookings[i].HabitueId)
                    {
                        HabitueFIO = source.Habitues[j].HabitueFIO;
                        break;
                    }
                }
                string CocktailName = string.Empty;
                for (int j = 0; j < source.Cocktails.Count; ++j)
                {
                    if (source.Cocktails[j].Id == source.Bookings[i].CocktailId)
                    {
                        CocktailName = source.Cocktails[j].CocktailName;
                        break;
                    }
                }
                result.Add(new BookingViewModel
                {
                    Id = source.Bookings[i].Id,
                    HabitueId = source.Bookings[i].HabitueId,
                    HabitueFIO = HabitueFIO,
                    CocktailId = source.Bookings[i].CocktailId,
                    CocktailName = CocktailName,
                    Count = source.Bookings[i].Count,
                    Sum = source.Bookings[i].Sum,
                    DateCreate = source.Bookings[i].DateCreate.ToLongDateString(),
                    DateImplement = source.Bookings[i].DateImplement?.ToLongDateString(),
                    Status = source.Bookings[i].Status.ToString()
                });
            }
            return result;
        }

        public void CreateBooking(BookingBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id > maxId)
                {
                    maxId = source.Bookings[i].Id;
                }
            }
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
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Принят)
            {
                throw new Exception("Заказ не в статусе \"Принят\"");
            }
            source.Bookings[index].DateImplement = DateTime.Now;
            source.Bookings[index].Status = BookingStatus.Смешивается;
        }

        public void FinishBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Смешивается)
            {
                throw new Exception("Заказ не в статусе \"Смешивается\"");
            }
            source.Bookings[index].Status = BookingStatus.Смешан;
        }

        public void PayBooking(BookingBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Bookings.Count; ++i)
            {
                if (source.Bookings[i].Id == model.Id)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            if (source.Bookings[index].Status != BookingStatus.Смешан)
            {
                throw new Exception("Заказ не в статусе \"Смешан\"");
            }
            source.Bookings[index].Status = BookingStatus.Оплачен;
        }
    }
}
