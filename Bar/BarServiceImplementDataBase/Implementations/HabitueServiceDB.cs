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
    public class HabitueServiceDB : IHabitueService
    {
        private BarWebDbContext context;
        public HabitueServiceDB(BarWebDbContext context)
        {
            this.context = context;
        }
        public HabitueServiceDB()
        {
            this.context = new BarWebDbContext();
        }
        public List<HabitueViewModel> GetList()
        {
            List<HabitueViewModel> result = context.Habitues.Select(rec => new
            HabitueViewModel
            {
                Id = rec.Id,
                HabitueFIO = rec.HabitueFIO
            })
            .ToList();
            return result;
        }
        public HabitueViewModel GetElement(int id)
        {
            Habitue element = context.Habitues.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                return new HabitueViewModel
                {
                    Id = element.Id,
                    HabitueFIO = element.HabitueFIO
                };
                
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(HabitueBindingModel model)
        {
            Habitue element = context.Habitues.FirstOrDefault(rec => rec.HabitueFIO ==
            model.HabitueFIO);
            if (element != null)
            {
                throw new Exception("Уже есть завсегдатай с таким ФИО");
            }
            context.Habitues.Add(new Habitue
            {
                HabitueFIO = model.HabitueFIO
            });
            context.SaveChanges();
        }
        public void UpdElement(HabitueBindingModel model)
        {
            Habitue element = context.Habitues.FirstOrDefault(rec => rec.HabitueFIO ==
            model.HabitueFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть завсегдатай с таким ФИО");
            }
            element = context.Habitues.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.HabitueFIO = model.HabitueFIO;
            context.SaveChanges();
        }
        public void DelElement(int id)
        {
            Habitue element = context.Habitues.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                context.Habitues.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
