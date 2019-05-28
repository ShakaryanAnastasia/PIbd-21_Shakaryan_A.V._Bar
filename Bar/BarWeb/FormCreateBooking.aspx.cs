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
    public partial class FormCreateBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    List<HabitueViewModel> listC = APIClient.GetRequest<List<HabitueViewModel>>("api/Habitue/GetList");
                    if (listC != null)
                    {
                        DropDownListHabitue.DataSource = listC;
                        DropDownListHabitue.DataBind();
                        DropDownListHabitue.DataTextField = "HabitueFIO";
                        DropDownListHabitue.DataValueField = "Id";
                    }
                    List<CocktailViewModel> listP = APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList");
                    if (listP != null)
                    {
                        DropDownListCocktail.DataSource = listP;
                        DropDownListCocktail.DataBind();
                        DropDownListCocktail.DataTextField = "CocktailName";
                        DropDownListCocktail.DataValueField = "Id";
                    }
                    Page.DataBind();

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        private void CalcSum()
        {

            if (DropDownListCocktail.SelectedValue != null && !string.IsNullOrEmpty(TextBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(DropDownListCocktail.SelectedValue);
                    CocktailViewModel Cocktail = APIClient.GetRequest<CocktailViewModel>("api/Cocktail/Get/" + id);
                    int count = Convert.ToInt32(TextBoxCount.Text);
                    TextBoxSum.Text = (count * Cocktail.Price).ToString();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void TextBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListHabitue.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите клиента');</script>");
                return;
            }
            if (DropDownListCocktail.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите изделие');</script>");
                return;
            }
            try
            {
                APIClient.PostRequest<BookingBindingModel, bool>("api/Main/CreateBooking", new BookingBindingModel
                {
                HabitueId = Convert.ToInt32(DropDownListHabitue.SelectedValue),
                    CocktailId = Convert.ToInt32(DropDownListCocktail.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text),
                    Sum = Convert.ToDecimal(TextBoxSum.Text)
                });
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormMain.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormMain.aspx");
        }
    }
}