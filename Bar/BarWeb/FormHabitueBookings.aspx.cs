using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarServiceImplementDataBase.Implementations;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Web.UI;
using Unity;

namespace BarWeb
{
    public partial class FormHabitueBookings : System.Web.UI.Page
    {
        protected void ButtonMake_Click(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate >= Calendar2.SelectedDate)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllertDate", "<script>alert('Дата начала должна быть меньше даты окончания');</script>");
                return;
            }
            try
            {
                ReportParameter parameter = new ReportParameter("ReportParameterPeriod",
                                               "c " + Calendar1.SelectedDate.ToShortDateString() +
                                               " по " + Calendar2.SelectedDate.ToShortDateString());


                ReportViewer1.LocalReport.SetParameters(parameter);

                List<HabitueBookingsModel> response = APIClient.PostRequest<RecordBindingModel,
                List<HabitueBookingsModel>>("api/Record/GetHabitueBookings", new RecordBindingModel
                {
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });

                ReportDataSource source = new ReportDataSource("DataSetBookings", response);
                ReportViewer1.LocalReport.DataSources.Add(source);
                ReportViewer1.DataBind();
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonToPdf_Click(object sender, EventArgs e)
        {
            string path = "C:\\Users\\anast\\Desktop\\HabitueBookings.pdf";
            Response.Clear();

            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "filename=HabitueBookings.pdf");
            Response.ContentType = "application/vnd.ms-word";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            try
            {
                APIClient.PostRequest<RecordBindingModel, bool>("api/Record/SaveHabitueBookings", new RecordBindingModel
                {
                    FileName = path,
                    DateFrom = Calendar1.SelectedDate,
                    DateTo = Calendar2.SelectedDate
                });
                Response.WriteFile(path);
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ScriptAllert", "<script>alert('" + ex.Message + "');</script>");
            }
            Response.End();
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}