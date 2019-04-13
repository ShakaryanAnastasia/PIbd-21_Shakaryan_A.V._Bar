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
    public class RecordController : ApiController
    {
        private readonly IRecordService _service;
        public RecordController(IRecordService service)
        {
            _service = service;
        }
        [HttpGet]
        public IHttpActionResult GetPantrysLoad()
        {
            var list = _service.GetPantrysLoad();
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public IHttpActionResult GetHabitueBookings(RecordBindingModel model)
        {
            var list = _service.GetHabitueBookings(model);
            if (list == null)
            {
                InternalServerError(new Exception("Нет данных"));
            }
            return Ok(list);
        }
        [HttpPost]
        public void SaveCocktailPrice(RecordBindingModel model)
        {
            _service.SaveCocktailPrice(model);
        }
        [HttpPost]
        public void SavePantrysLoad(RecordBindingModel model)
        {
            _service.SavePantrysLoad(model);
        }
        [HttpPost]
        public void SaveHabitueBookings(RecordBindingModel model)
        {
            _service.SaveHabitueBookings(model);
        }
    }
}
