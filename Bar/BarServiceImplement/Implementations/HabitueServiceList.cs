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
            List<HabitueViewModel> result = new List<HabitueViewModel>();
            for (int i = 0; i < source.Habitues.Count; ++i)
            {
                result.Add(new HabitueViewModel
                {
                    Id = source.Habitues[i].Id,
                    HabitueFIO = source.Habitues[i].HabitueFIO
                });
            }
            return result;
        }
        public HabitueViewModel GetElement(int id)
        {
            for (int i = 0; i < source.Habitues.Count; ++i)
            {
                if (source.Habitues[i].Id == id)
                {
                    return new HabitueViewModel
                    {
                        Id = source.Habitues[i].Id,
                        HabitueFIO = source.Habitues[i].HabitueFIO
                    };
                }
            }
            throw new Exception("Элемент не найден");
        }
        public void AddElement(HabitueBindingModel model)
        {
            int maxId = 0;
            for (int i = 0; i < source.Habitues.Count; ++i)
            {
                if (source.Habitues[i].Id > maxId)
                {
                    maxId = source.Habitues[i].Id;
                }
                if (source.Habitues[i].HabitueFIO == model.HabitueFIO)
                {
                    throw new Exception("Уже есть завсегдатай с таким ФИО");
                }
            }
            source.Habitues.Add(new Habitue
            {
                Id = maxId + 1,
                HabitueFIO = model.HabitueFIO
            });
        }
        public void UpdElement(HabitueBindingModel model)
        {
            int index = -1;
            for (int i = 0; i < source.Habitues.Count; ++i)
            {
                if (source.Habitues[i].Id == model.Id)
                {
                    index = i;
                }
                if (source.Habitues[i].HabitueFIO == model.HabitueFIO &&
                source.Habitues[i].Id != model.Id)
                {
                    throw new Exception("Уже есть завсегдатай с таким ФИО");
                }
            }
            if (index == -1)
            {
                throw new Exception("Элемент не найден");
            }
            source.Habitues[index].HabitueFIO = model.HabitueFIO;
        }
        public void DelElement(int id)
        {
            for (int i = 0; i < source.Habitues.Count; ++i)
            {
                if (source.Habitues[i].Id == id)
                {
                    source.Habitues.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
    }
}
