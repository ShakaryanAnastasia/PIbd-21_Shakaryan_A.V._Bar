using BarServiceDAL.BindingModels;
using BarServiceDAL.Interfaces;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BarView
{
    public partial class FormCocktail : Form
    {

        public int Id { set { id = value; } }

        private int? id;

        private List<CocktailIngredientViewModel> CocktailIngredients;

        public FormCocktail()
        {
            InitializeComponent();
        }

        private void FormCocktail_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    CocktailViewModel view = APIHabitue.GetRequest<CocktailViewModel>("api/Cocktail/Get/" + id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.CocktailName;
                        textBoxPrice.Text = view.Price.ToString();
                        CocktailIngredients = view.CocktailIngredients;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
            else
            {
                CocktailIngredients = new List<CocktailIngredientViewModel>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (CocktailIngredients != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = CocktailIngredients;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = new FormCocktailIngredient();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.CocktailId = id.Value;
                    }
                    CocktailIngredients.Add(form.Model);
                }
                LoadData();
            }
        }

        private void buttonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = new FormCocktailIngredient();
                form.Model =
                CocktailIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CocktailIngredients[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                    form.Model;
                    LoadData();
                }
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        CocktailIngredients.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (CocktailIngredients == null || CocktailIngredients.Count == 0)
            {
                MessageBox.Show("Заполните ингредиенты", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<CocktailIngredientBindingModel> CocktailIngredientBM = new
                List<CocktailIngredientBindingModel>();
                for (int i = 0; i < CocktailIngredients.Count; ++i)
                {
                    CocktailIngredientBM.Add(new CocktailIngredientBindingModel
                    {
                        Id = CocktailIngredients[i].Id,
                        CocktailId = CocktailIngredients[i].CocktailId,
                        IngredientId = CocktailIngredients[i].IngredientId,
                        Count = CocktailIngredients[i].Count
                    });
                }
                if (id.HasValue)
                {
                    APIHabitue.PostRequest<CocktailBindingModel,
                    bool>("api/Cocktail/UpdElement", new CocktailBindingModel
                    {
                        Id = id.Value,
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = CocktailIngredientBM
                    });
                }
                else
                {
                    APIHabitue.PostRequest<CocktailBindingModel,
                    bool>("api/Cocktail/AddElement", new CocktailBindingModel
                    {
                        CocktailName = textBoxName.Text,
                        Price = Convert.ToInt32(textBoxPrice.Text),
                        CocktailIngredients = CocktailIngredientBM
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
