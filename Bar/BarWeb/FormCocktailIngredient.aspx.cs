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
    public partial class FormCocktailIngredient : System.Web.UI.Page
    {
        private CocktailIngredientViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {

            try { 
                if (!Page.IsPostBack)
            
                {
                    List<IngredientViewModel> list = APIClient.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                    if (list != null)
                    {
                        DropDownListIngredient.DataSource = list;
                        DropDownListIngredient.DataValueField = "Id";
                        DropDownListIngredient.DataTextField = "IngredientName";
                        DropDownListIngredient.SelectedIndex = -1;
                        Page.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
            if (Session["SEId"] != null)
            {
                model = new CocktailIngredientViewModel
                {
                    IngredientId = Convert.ToInt32(Session["SEIngredientId"]),
                    IngredientName = Session["SEIngredientName"].ToString(),
                    Count = Convert.ToInt32(Session["SECount"].ToString())
                };
                DropDownListIngredient.Enabled = false;
                DropDownListIngredient.SelectedValue = Session["SEIngredientId"].ToString();
            }

            if ((Session["SEId"] != null) && (!Page.IsPostBack))
            {
                TextBoxCount.Text = Session["SECount"].ToString();
            }

        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле Количество');</script>");
                return;
            }
            if (DropDownListIngredient.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите ингредиент');</script>");
                return;
            }
            try
            {
                if (Session["SEId"] == null)
                {
                    model = new CocktailIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(DropDownListIngredient.SelectedValue),
                        IngredientName = DropDownListIngredient.SelectedItem.Text,
                        Count = Convert.ToInt32(TextBoxCount.Text)
                    };
                    Session["SEId"] = model.Id;
                    Session["SECocktailId"] = model.CocktailId;
                    Session["SEIngredientId"] = model.IngredientId;
                    Session["SEIngredientName"] = model.IngredientName;
                    Session["SECount"] = model.Count;
                }
                else
                {
                    model.Count = Convert.ToInt32(TextBoxCount.Text);
                    Session["SEId"] = model.Id;
                    Session["SEServiceId"] = model.CocktailId;
                    Session["SEIngredientId"] = model.IngredientId;
                    Session["SEIngredientName"] = model.IngredientName;
                    Session["SECount"] = model.Count;
                    Session["Change"] = "1";
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormCocktail.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormCocktail.aspx");
        }
    }
}