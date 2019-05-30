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
        private BarDbContext context;
        public HabitueServiceDB(BarDbContext context)
        {
            this.context = context;
        }
        public List<HabitueViewModel> GetList()
        {
            List<HabitueViewModel> result = context.Habitues.Select(rec => new
            HabitueViewModel
            {
                Id = rec.Id,
                HabitueFIO = rec.HabitueFIO,
                Mail = rec.Mail
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
                    HabitueFIO = element.HabitueFIO,
                    Mail = element.Mail,
                    Messages = context.MessageInfos
.Where(recM => recM.HabitueId == element.Id)
.Select(recM => new MessageInfoViewModel
{
    MessageId = recM.MessageId,
    DateDelivery = recM.DateDelivery,
    Subject = recM.Subject,
    Body = recM.Body
})
.ToList()
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
            element.Mail = model.Mail;
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
