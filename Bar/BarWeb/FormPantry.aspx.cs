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
    public partial class FormPantry : System.Web.UI.Page
    {
        private int id;

        private string name;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    PantryViewModel view = APIClient.GetRequest<PantryViewModel>("api/Pantry/Get/" + id);
                    if (view != null)
                    {
                        name = view.PantryName;
                        dataGridView.DataSource = view.PantryIngredients;
                        dataGridView.DataBind();
                        APIClient.PostRequest<PantryBindingModel, bool>("api/Pantry/UpdElement", new PantryBindingModel
                        {
                            Id = id,
                            PantryName = ""
                        });
                        if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(textBoxName.Text))
                        {
                            textBoxName.Text = name;
                        }
                        APIClient.PostRequest<PantryBindingModel, bool>("api/Pantry/UpdElement", new PantryBindingModel
                        {
                            Id = id,
                            PantryName = name
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
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            try
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    APIClient.PostRequest<PantryBindingModel, bool>("api/Pantry/UpdElement", new PantryBindingModel
                    {
                        Id = id,
                        PantryName = textBoxName.Text
                    });
                }
                else
                {
                    APIClient.PostRequest<PantryBindingModel, bool>("api/Pantry/AddElement", new PantryBindingModel
                    {
                        PantryName = textBoxName.Text
                    });
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                Server.Transfer("FormPantrys.aspx");
            }
            Session["id"] = null;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
            Server.Transfer("FormPantrys.aspx");
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Session["id"] = null;
            Server.Transfer("FormPantrys.aspx");
        }
    }
}