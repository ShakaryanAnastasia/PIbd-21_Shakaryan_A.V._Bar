using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarWeb
{
    public partial class FormPutOnPantry : System.Web.UI.Page
    {
        private readonly IPantryService serviceS = new PantryServiceList();

        private readonly IIngredientService serviceI = new IngredientServiceList();

        private readonly IMainService serviceM = new MainServiceList();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    List<IngredientViewModel> listI = serviceI.GetList();
                    if (listI != null)
                    {
                        DropDownListIngredient.DataSource = listI;
                        DropDownListIngredient.DataBind();
                        DropDownListIngredient.DataTextField = "IngredientName";
                        DropDownListIngredient.DataValueField = "Id";
                    }
                    List<PantryViewModel> listS = serviceS.GetList();
                    if (listS != null)
                    {
                        DropDownListPantry.DataSource = listS;
                        DropDownListPantry.DataBind();
                        DropDownListPantry.DataTextField = "PantryName";
                        DropDownListPantry.DataValueField = "Id";
                    }
                    Page.DataBind();
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxCount.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните поле количество');</script>");
                return;
            }
            if (DropDownListIngredient.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите ингредиент');</script>");
                return;
            }
            if (DropDownListPantry.SelectedValue == null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Выберите кладовую');</script>");
                return;
            }
            try
            {
                serviceM.PutIngredientOnPantry(new PantryIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(DropDownListIngredient.SelectedValue),
                    PantryId = Convert.ToInt32(DropDownListPantry.SelectedValue),
                    Count = Convert.ToInt32(TextBoxCount.Text)
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