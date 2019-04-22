using System;
using System.Collections.Generic;
using System.Linq;
using BarModel;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;

namespace BarServiceImplementDataBase.Implementations
{
    public class BartenderServiceDB : IBartenderService
    {
        private BarDbContext context;
        public BartenderServiceDB(BarDbContext context)
        {
            this.context = context;
        }
        public List<BartenderViewModel> GetList()
        {
            List<BartenderViewModel> result = context.Bartenders
            .Select(rec => new BartenderViewModel
            {
                Id = rec.Id,
                BartenderFIO = rec.BartenderFIO
            })
            .ToList();
            return result;
        }
        public BartenderViewModel GetElement(int id)
        {
            Bartender element = context.Bartenders.FirstOrDefault(rec => rec.Id ==
            id);
            if (element != null)
            {
                return new BartenderViewModel
                {
                    Id = element.Id,
                    BartenderFIO = element.BartenderFIO
                };
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(BartenderBindingModel model)
        {
            Bartender element = context.Bartenders.FirstOrDefault(rec =>
            rec.BartenderFIO == model.BartenderFIO);
            if (element != null)
            {
                throw new Exception("Уже есть бармен с таким ФИО");
            }
            context.Bartenders.Add(new Bartender
            {
                BartenderFIO = model.BartenderFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(BartenderBindingModel model)
        {
            Bartender element = context.Bartenders.FirstOrDefault(rec =>
            rec.BartenderFIO == model.BartenderFIO &&
            rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть бармен с таким ФИО");
            }
           
        element = context.Bartenders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.BartenderFIO = model.BartenderFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Bartender element = context.Bartenders.FirstOrDefault(rec => rec.Id ==
            id);
            if (element != null)
            {
                context.Bartenders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public BartenderViewModel GetFreeWorker()
        {
            var bookingsWorker = context.Bartenders
            .Select(x => new
            {
                ImplId = x.Id,
                Count = context.Bookings.Where(o => o.Status == BookingStatus.Смешивается && o.BartenderId == x.Id).Count()
            })
            .OrderBy(x => x.Count)
            .FirstOrDefault();
            if (bookingsWorker != null)
            {
                return GetElement(bookingsWorker.ImplId);
            }
            return null;
        }
    }
}
