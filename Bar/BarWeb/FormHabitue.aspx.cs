using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarServiceImplement.Implementations;
using BarServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace BarWeb
{
    public partial class FormHabitue : System.Web.UI.Page
    {
        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    HabitueViewModel view = APIClient.GetRequest<HabitueViewModel>("api/Habitue/Get/" + id);
                    if (view != null)
                    {
                        name = view.HabitueFIO;
                        APIClient.PostRequest<HabitueBindingModel, bool>("api/Habitue/UpdElement", new HabitueBindingModel
                        {
                            Id = id,
                            HabitueFIO = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(textBoxName.Text))
                        {
                            textBoxName.Text = name;
                        }
                        APIClient.PostRequest<HabitueBindingModel, bool>("api/Habitue/UpdElement", new HabitueBindingModel
                        {
                            Id = id,
                            HabitueFIO = name
                        });
                    }
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ФИО');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    APIClient.PostRequest<HabitueBindingModel, bool>("api/Habitue/UpdElement", new HabitueBindingModel
                    {
                        Id = id,
                        HabitueFIO = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<HabitueBindingModel, bool>("api/Habitue/AddElement", new HabitueBindingModel
                    {
                        HabitueFIO = textBoxName.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FormHabitues.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FormHabitues.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormHabitues.aspx");
        }
    }
}