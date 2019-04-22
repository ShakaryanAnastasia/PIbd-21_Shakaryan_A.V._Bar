using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarRestApi.Services;

namespace BarRestApi.Controllers
{
    public class MainController : ApiController
    {
        private readonly IMainService _service;

        private readonly IBartenderService _serviceBartender;
        public MainController(IMainService service, IBartenderService serviceBartender)
        {
            _service = service;
            _serviceBartender = serviceBartender;
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
        [HttpPost]
        public void CreateBooking(BookingBindingModel model)
        {
            _service.CreateBooking(model);
        }
        [HttpPost]
        public void TakeBookingInWork(BookingBindingModel model)
        {
            _service.TakeBookingInWork(model);
        }
        [HttpPost]
        public void FinishBooking(BookingBindingModel model)
        {
            _service.FinishBooking(model);
        }
        [HttpPost]
        public void PayBooking(BookingBindingModel model)
        {
            _service.PayBooking(model);
        }
        [HttpPost]
        public void PutIngredientOnPantry(PantryIngredientBindingModel model)
        {
            _service.PutIngredientOnPantry(model);
        }

        [HttpPost]
        public void StartWork()
        {
            List<BookingViewModel> bookings = _service.GetFreeBookings();
            foreach (var booking in bookings)
            {
                BartenderViewModel impl = _serviceBartender.GetFreeWorker();
                if (impl == null)
                {
                    throw new Exception("Нет барменов");
                }
                new WorkBartender(_service, _serviceBartender, impl.Id, booking.Id);
            }
        }
    }
}
