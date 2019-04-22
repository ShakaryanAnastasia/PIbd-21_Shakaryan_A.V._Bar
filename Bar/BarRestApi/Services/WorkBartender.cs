using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using System.Threading;

namespace BarRestApi.Services
{
    public class WorkBartender
    {
        private readonly IMainService _service;
        private readonly IBartenderService _serviceBartender;
        private readonly int _bartenderId;
        private readonly int _bookingId;
        // семафор
        static Semaphore _sem = new Semaphore(3, 3);
        Thread myThread;
        public WorkBartender(IMainService service, IBartenderService
        serviceBartender, int bartenderId, int bookingId)
        {
            _service = service;
            _serviceBartender = serviceBartender;
            _bartenderId = bartenderId;
            _bookingId = bookingId;
            try
            {
                _service.TakeBookingInWork(new BookingBindingModel
                {
                    Id = _bookingId,
                    BartenderId = _bartenderId
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            myThread = new Thread(Work);
            myThread.Start();
        }
        public void Work()
        {
            try
            {
                // забиваем мастерскую
                _sem.WaitOne();
                // Типа выполняем
                Thread.Sleep(1000);
                _service.FinishBooking(new BookingBindingModel
            {
                    Id = _bookingId
            });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // освобождаем мастерскую
                _sem.Release();
            }
        }
    }
}