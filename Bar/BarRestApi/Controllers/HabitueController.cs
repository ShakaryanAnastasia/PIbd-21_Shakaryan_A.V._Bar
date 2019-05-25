using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BarRestApi.Controllers
{
    public class HabitueController : ApiController
    {
        private readonly IHabitueService _service;
        public HabitueController(IHabitueService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetList()
        {
            var list = _service.GetList();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var element = _service.GetElement(id);
            if (element == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(element);
        }

[HttpPost]
        public void AddElement(HabitueBindingModel model)
        {
            _service.AddElement(model);
        }
        [HttpPost]
        public void UpdElement(HabitueBindingModel model)
        {
            _service.UpdElement(model);
        }
        [HttpPost]
        public void DelElement(HabitueBindingModel model)
        {
            _service.DelElement(model.Id);
        }
    }
}
