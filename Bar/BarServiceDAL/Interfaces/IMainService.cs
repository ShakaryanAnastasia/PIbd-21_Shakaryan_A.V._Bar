﻿using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarServiceDAL.Interfaces
{
    public interface IMainService
    {
        List<BookingViewModel> GetList();

        List<BookingViewModel> GetFreeBookings();

        void CreateBooking(BookingBindingModel model);

        void TakeBookingInWork(BookingBindingModel model);

        void FinishBooking(BookingBindingModel model);

        void PayBooking(BookingBindingModel model);

        void PutIngredientOnPantry(PantryIngredientBindingModel model);
    }
}
