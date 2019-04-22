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
    public class HabitueServiceList : IHabitueService
    {
        private DataListSingleton source;
        public HabitueServiceList()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<HabitueViewModel> GetList()
        {
            List<HabitueViewModel> result = source.Habitues.Select(rec => new
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
            Habitue element = source.Habitues.FirstOrDefault(rec => rec.Id == id);
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
            Habitue element = source.Habitues.FirstOrDefault(rec => rec.HabitueFIO ==
model.HabitueFIO);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            int maxId = source.Habitues.Count > 0 ? source.Habitues.Max(rec => rec.Id) : 0;
            source.Habitues.Add(new Habitue
            {
                Id = maxId + 1,
                HabitueFIO = model.HabitueFIO
            });
        }
        public void UpdElement(HabitueBindingModel model)
        {
            Habitue element = source.Habitues.FirstOrDefault(rec => rec.HabitueFIO ==
 model.HabitueFIO && rec.Id != model.Id);
            if (element != null)
            {
                throw new Exception("Уже есть клиент с таким ФИО");
            }
            element = source.Habitues.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            element.HabitueFIO = model.HabitueFIO;
        }
        public void DelElement(int id)
        {
            Habitue element = source.Habitues.FirstOrDefault(rec => rec.Id == id);
            if (element != null)
            {
                source.Habitues.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
    }
}
