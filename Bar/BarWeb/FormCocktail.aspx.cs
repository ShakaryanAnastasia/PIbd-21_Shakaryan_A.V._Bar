using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarServiceImplement.Implementations;
using BarServiceImplementDataBase.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Unity;

namespace BarWeb
{
    public partial class FormCocktail : System.Web.UI.Page
    {
        private int id;

        private List<CocktailIngredientViewModel> cocktailIngredients;

        private CocktailIngredientViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CocktailViewModel view = APIClient.GetRequest<CocktailViewModel>("api/Cocktail/Get/" + id);
                    if (view != null)
                    {
                        if (!Page.IsPostBack)
                        {
                            textBoxName.Text = view.CocktailName;
                            textBoxPrice.Text = view.Price.ToString();
                        }
                        this.cocktailIngredients = view.CocktailIngredients;
                        LoadData();
                    }

                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                this.cocktailIngredients = new List<CocktailIngredientViewModel>();

            }
            if (Session["SEId"] != null)
            {
                if ((Session["SEIs"] != null) && (Session["Change"].ToString() != "0"))
                {
                    model = new CocktailIngredientViewModel
                    {
                        Id = (int)Session["SEId"],
                        CocktailId = (int)Session["SECocktailId"],
                        IngredientId = (int)Session["SEIngredientId"],
                        IngredientName = (string)Session["SEIngredientName"],
                        Count = (int)Session["SECount"]
                    };
                    this.cocktailIngredients[(int)Session["SEIs"]] = model;
                    Session["Change"] = "0";
                }
                else
                {
                    model = new CocktailIngredientViewModel
                    {
                        CocktailId = (int)Session["SECocktailId"],
                        IngredientId = (int)Session["SEIngredientId"],
                        IngredientName = (string)Session["SEIngredientName"],
                        Count = (int)Session["SECount"]
                    };
                    this.cocktailIngredients.Add(model);
                }
                Session["SEId"] = null;
                Session["SECocktailId"] = null;
                Session["SEIngredientId"] = null;
                Session["SEIngredientName"] = null;
                Session["SECount"] = null;
                Session["SEIs"] = null;
            }
            List<CocktailIngredientBindingModel> cocktailIngredientBM = new List<CocktailIngredientBindingModel>();
            for (int i = 0; i < this.cocktailIngredients.Count; ++i)
            {
                cocktailIngredientBM.Add(new CocktailIngredientBindingModel
                {
                    Id = this.cocktailIngredients[i].Id,
                    CocktailId = this.cocktailIngredients[i].CocktailId,
                    IngredientId = this.cocktailIngredients[i].IngredientId,
                    Count = this.cocktailIngredients[i].Count
                });
            }
            if (cocktailIngredientBM.Count != 0)
            {
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/UpdElement", new CocktailBindingModel
                    {
                        Id = id,
                        CocktailName = "Введите название",
                        Price = 0,
                        CocktailIngredients = cocktailIngredientBM
                    });
                }
                else
                {
                    APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/AddElement", new CocktailBindingModel
                    {
                        CocktailName = "Введите название",
                        Price = 0,
                        CocktailIngredients = cocktailIngredientBM
                    });
                    Session["id"] = APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList").Last().Id.ToString();
                    Session["Change"] = "0";
                }
            }
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (cocktailIngredients != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = cocktailIngredients;
                    dataGridView.DataBind();
                    dataGridView.ShowHeaderWhenEmpty = true;
                    dataGridView.SelectedRowStyle.BackColor = Color.Silver;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                }
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            Server.Transfer("FormCocktailIngredient.aspx");
        }

        protected void ButtonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                model = APIClient.GetRequest<CocktailViewModel>("api/Cocktail/Get/" + id).CocktailIngredients[dataGridView.SelectedIndex];
                Session["SEId"] = model.Id;
                Session["SECocktailId"] = model.CocktailId;
                Session["SEIngredientId"] = model.IngredientId;
                Session["SEIngredientName"] = model.IngredientName;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Session["Change"] = "0";
                Server.Transfer("FormCocktailIngredient.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    cocktailIngredients.RemoveAt(dataGridView.SelectedIndex);
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
                }
                LoadData();
            }
        }

        protected void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните название');</script>");
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните цену');</script>");
                return;
            }
            if (cocktailIngredients == null || cocktailIngredients.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ингредиенты');</script>");
                return;
            }
            try
            {
                List<CocktailIngredientBindingModel> cocktailIngredientBM = new List<CocktailIngredientBindingModel>();
                for (int i = 0; i < cocktailIngredients.Count; ++i)
                {
                    cocktailIngredientBM.Add(new CocktailIngredientBindingModel
                    {
                        Id = cocktailIngredients[i].Id,
                        CocktailId = cocktailIngredients[i].CocktailId,
                        IngredientId = cocktailIngredients[i].IngredientId,
                        Count = cocktailIngredients[i].Count
                    });
                }
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/UpdElement", new CocktailBindingModel
                    {
                        Id = id,
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = cocktailIngredientBM
                    });
                }
                else
                {
                    APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/AddElement", new CocktailBindingModel
                    {
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = cocktailIngredientBM
                    });
                }
                Session["id"] = null;
                Session["Change"] = null;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Сохранение прошло успешно');</script>");
                Server.Transfer("FormCocktails.aspx");
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('" + ex.Message + "');</script>");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList").Count != 0 && APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList").Last().CocktailName == null)
            {
                APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/DelElement", new CocktailBindingModel { Id = APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList").Last().Id });
            }
            if (!String.Equals(Session["Change"], null))
            {
                APIClient.PostRequest<CocktailBindingModel, bool>("api/Cocktail/DelElement", new CocktailBindingModel { Id = id });

            }
            Session["id"] = null;
            Session["Change"] = null;
            Server.Transfer("FormCocktails.aspx");
        }

        protected void dataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Visible = false;
            e.Row.Cells[2].Visible = false;
            e.Row.Cells[3].Visible = false;
        }
    }
}