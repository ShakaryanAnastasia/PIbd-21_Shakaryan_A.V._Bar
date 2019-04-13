using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using BarServiceImplement.Implementations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BarWeb
{
    public partial class FormCocktail : System.Web.UI.Page
    {
        private readonly ICocktailService service = new CocktailServiceList();

        private int id;

        private List<CocktailIngredientViewModel> CocktailIngredient;

        private CocktailIngredientViewModel model;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Int32.TryParse((string)Session["id"], out id))
            {
                try
                {
                    CocktailViewModel view = service.GetElement(id);
                    if (view != null)
                    {
                        textBoxName.Text = view.CocktailName;
                        textBoxPrice.Text = view.Price.ToString();
                        this.CocktailIngredient = view.CocktailIngredients;
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
                if (service.GetList().Count == 0 || service.GetList().Last().CocktailName != null)
                {
                    this.CocktailIngredient = new List<CocktailIngredientViewModel>();
                    LoadData();
                }
                else
                {
                    this.CocktailIngredient = service.GetList().Last().CocktailIngredients;
                    LoadData();
                }
            }
            if (Session["SEId"] != null)
            {
                model = new CocktailIngredientViewModel
                {
                    Id = (int)Session["SEId"],
                    CocktailId = (int)Session["SECocktailId"],
                    IngredientId = (int)Session["SEIngredientId"],
                    IngredientName = (string)Session["SEIngredientName"],
                    Count = (int)Session["SECount"]
                };
                if (Session["SEIs"] != null)
                {
                    this.CocktailIngredient[(int)Session["SEIs"]] = model;
                }
                else
                {
                    this.CocktailIngredient.Add(model);
                }
            }
            List<CocktailIngredientBindingModel> commodityIngredient = new List<CocktailIngredientBindingModel>();
            for (int i = 0; i < this.CocktailIngredient.Count; ++i)
            {
                commodityIngredient.Add(new CocktailIngredientBindingModel
                {
                    Id = this.CocktailIngredient[i].Id,
                    CocktailId = this.CocktailIngredient[i].CocktailId,
                    IngredientId = this.CocktailIngredient[i].IngredientId,
                    Count = this.CocktailIngredient[i].Count
                });
            }
            if (commodityIngredient.Count != 0)
            {
                if (service.GetList().Count == 0 || service.GetList().Last().CocktailName != null)
                {
                    service.AddElement(new CocktailBindingModel
                    {
                        CocktailName = null,
                        Price = -1,
                        CocktailIngredients = commodityIngredient
                    });
                }
                else
                {
                    service.UpdElement(new CocktailBindingModel
                    {
                        Id = service.GetList().Last().Id,
                        CocktailName = null,
                        Price = -1,
                        CocktailIngredients = commodityIngredient
                    });
                }

            }
            try
            {
                if (this.CocktailIngredient != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = this.CocktailIngredient;
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
            Session["SEId"] = null;
            Session["SECocktailId"] = null;
            Session["SEIngredientId"] = null;
            Session["SEIngredientName"] = null;
            Session["SECount"] = null;
            Session["SEIs"] = null;
        }

        private void LoadData()
        {
            try
            {
                if (CocktailIngredient != null)
                {
                    dataGridView.DataBind();
                    dataGridView.DataSource = CocktailIngredient;
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
                Session["SEId"] = model.Id;
                Session["SECocktailId"] = model.CocktailId;
                Session["SEIngredientId"] = model.IngredientId;
                Session["SEIngredientName"] = model.IngredientName;
                Session["SECount"] = model.Count;
                Session["SEIs"] = dataGridView.SelectedIndex;
                Server.Transfer("FormCocktailIngredient.aspx");
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedIndex >= 0)
            {
                try
                {
                    CocktailIngredient.RemoveAt(dataGridView.SelectedIndex);
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
            if (CocktailIngredient == null || CocktailIngredient.Count == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Заполните ингредиенты');</script>");
                return;
            }
            try
            {
                List<CocktailIngredientBindingModel> commodityIngredientBM = new List<CocktailIngredientBindingModel>();
                for (int i = 0; i < CocktailIngredient.Count; ++i)
                {
                    commodityIngredientBM.Add(new CocktailIngredientBindingModel
                    {
                        Id = CocktailIngredient[i].Id,
                        CocktailId = CocktailIngredient[i].CocktailId,
                        IngredientId = CocktailIngredient[i].IngredientId,
                        Count = CocktailIngredient[i].Count
                    });
                }
                service.DelElement(service.GetList().Last().Id);
                if (Int32.TryParse((string)Session["id"], out id))
                {
                    service.UpdElement(new CocktailBindingModel
                    {
                        Id = id,
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = commodityIngredientBM
                    });
                }
                else
                {
                    service.AddElement(new CocktailBindingModel
                    {
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = commodityIngredientBM
                    });
                }
                Session["id"] = null;
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
            if (service.GetList().Count != 0 && service.GetList().Last().CocktailName == null)
            {
                service.DelElement(service.GetList().Last().Id);
            }
            Session["id"] = null;
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