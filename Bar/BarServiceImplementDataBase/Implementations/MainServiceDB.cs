using BarModel;
using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace BarServiceImplementDataBase.Implementations
{
    public class MainServiceDB : IMainService
    {
        private BarDbContext context;
        public MainServiceDB(BarDbContext context)
        {
            this.context = context;
        }
        public List<BookingViewModel> GetList()
        {
            List<BookingViewModel> result = context.Bookings.Select(rec => new BookingViewModel
            {
                Id = rec.Id,

                HabitueId = rec.HabitueId,
                CocktailId = rec.CocktailId,
                DateCreate = SqlFunctions.DateName("dd", rec.DateCreate) + " " +
            SqlFunctions.DateName("mm", rec.DateCreate) + " " +
            SqlFunctions.DateName("yyyy", rec.DateCreate),
                DateImplement = rec.DateImplement == null ? "" :
            SqlFunctions.DateName("dd",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("mm",
            rec.DateImplement.Value) + " " +
            SqlFunctions.DateName("yyyy",
            rec.DateImplement.Value),
                Status = rec.Status.ToString(),
                Count = rec.Count,
                Sum = rec.Sum,
                HabitueFIO = rec.Habitue.HabitueFIO,
                CocktailName = rec.Cocktail.CocktailName,
                BartenderId = rec.BartenderId,
                BartenderFIO = rec.Bartender.BartenderFIO

            })
            .ToList();
            return result;
        }
        public void CreateBooking(BookingBindingModel model)
        {
            var booking = new Booking
            {
                HabitueId = model.HabitueId,
                CocktailId = model.CocktailId,
                DateCreate = DateTime.Now,
                Count = model.Count,
                Sum = model.Sum,
                Status = BookingStatus.Принят
            };
context.Bookings.Add(booking);
            context.SaveChanges();
            var client = context.Habitues.FirstOrDefault(x => x.Id == model.HabitueId);
            SendEmail(client.Mail, "Оповещение по заказам", string.Format("Заказ №{0} от{ 1} создан успешно", booking.Id, booking.DateCreate.ToShortDateString()));
        }
        public void TakeBookingInWork(BookingBindingModel model)
        {

            using (var transaction = context.Database.BeginTransaction())
            {
                Booking element = context.Bookings.FirstOrDefault(rec => rec.Id ==
                   model.Id);
                try
                {
                   
                    if (element == null)
                    {
                        throw new Exception("Элемент не найден");
                    }
                    if ((element.Status != BookingStatus.Принят) && (element.Status != BookingStatus.НедостаточноРесурсов))
                    {
                        throw new Exception("Заказ не в статусе \"Принят\"");
                    }
                    var cocktailIngredients = context.CocktailIngredients.Include(rec => rec.Ingredient).Where(rec => rec.CocktailId == element.CocktailId);
                    // списываем
                    foreach (var cocktailIngredient in cocktailIngredients)
                    {
                        int countOnPantrys = cocktailIngredient.Count * element.Count;
                        var pantryIngredients = context.PantryIngredients.Where(rec =>
                        rec.IngredientId == cocktailIngredient.IngredientId);
                        foreach (var pantryIngredient in pantryIngredients)
                        {
                            // ингредиентов на одном слкаде может не хватать
                            if (pantryIngredient.Count >= countOnPantrys)
                            {
                                pantryIngredient.Count -= countOnPantrys;
                                countOnPantrys = 0;
                                context.SaveChanges();
                                break;
                            }
                            else
                            {
                                countOnPantrys -= pantryIngredient.Count;
                                pantryIngredient.Count = 0;
                                context.SaveChanges();
                            }
                        }
                        if (countOnPantrys > 0)
                        {
                            throw new Exception("Не достаточно компонента " +
                            cocktailIngredient.Ingredient.IngredientName + " требуется " + cocktailIngredient.Count + ", не хватает " + countOnPantrys);
                        }
                    }
                    element.BartenderId = model.BartenderId;
                    element.DateImplement = DateTime.Now;
                    element.Status = BookingStatus.Смешивается;
                    context.SaveChanges();
                    SendEmail(element.Habitue.Mail, "Оповещение по заказам",
string.Format("Заказ №{0} от {1} передеан в работу", element.Id,
element.DateCreate.ToShortDateString()));
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    element.Status = BookingStatus.НедостаточноРесурсов;
                    context.SaveChanges();
                    transaction.Commit();
                    throw;
                }
            }
        }
        public void FinishBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)

            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешивается)
            {
                throw new Exception("Заказ не в статусе \"Смешивается\"");
            }
            element.Status = BookingStatus.Смешан;
            context.SaveChanges();
            SendEmail(element.Habitue.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1} передан на оплату", element.Id, element.DateCreate.ToShortDateString()));
        }
        public void PayBooking(BookingBindingModel model)
        {
            Booking element = context.Bookings.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            if (element.Status != BookingStatus.Смешан)
            {
                throw new Exception("Заказ не в статусе \"Смешан\"");
            }
            element.Status = BookingStatus.Оплачен;
            context.SaveChanges();
            SendEmail(element.Habitue.Mail, "Оповещение по заказам", string.Format("Заказ №{ 0} от { 1} оплачен успешно", element.Id, element.DateCreate.ToShortDateString()));
        }
        public void PutIngredientOnPantry(PantryIngredientBindingModel model)
        {
            PantryIngredient element = context.PantryIngredients.FirstOrDefault(rec =>
            rec.PantryId == model.PantryId && rec.IngredientId == model.IngredientId);
            if (element != null)
            {
                element.Count += model.Count;
            }
            else
            {
                context.PantryIngredients.Add(new PantryIngredient
                {
                    PantryId = model.PantryId,
                    IngredientId = model.IngredientId,
                    Count = model.Count
                });
            }
            context.SaveChanges();
        }
        private void SendEmail(string mailAddress, string subject, string text)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpClient objSmtpClient = null;
            try
            {
                objMailMessage.From = new
                MailAddress(ConfigurationManager.AppSettings["MailLogin"]);
                objMailMessage.To.Add(new MailAddress(mailAddress));
                objMailMessage.Subject = subject;
                objMailMessage.Body = text;
                objMailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
                objMailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                objSmtpClient = new SmtpClient("smtp.gmail.com", 587);
                objSmtpClient.UseDefaultCredentials = false;
                objSmtpClient.EnableSsl = true;
                objSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                objSmtpClient.Credentials = new
                NetworkCredential(ConfigurationManager.AppSettings["MailLogin"],
                ConfigurationManager.AppSettings["MailPassword"]);
                objSmtpClient.Send(objMailMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objMailMessage = null;
                objSmtpClient = null;
            }
        }

        public List<BookingViewModel> GetFreeBookings()
        {
            List<BookingViewModel> result = context.Bookings
            .Where(x => x.Status == BookingStatus.Принят || x.Status == BookingStatus.НедостаточноРесурсов)
            .Select(rec => new BookingViewModel
            {
                Id = rec.Id
            })
            .ToList();
            return result;
        }
    }
}
