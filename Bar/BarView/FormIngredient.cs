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
    public partial class FormIngredient : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormIngredient()
        {
            InitializeComponent();
        }

        private void FormIngredient_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    IngredientViewModel view = APIHabitue.GetRequest<IngredientViewModel>("api/Ingredient/Get/" + id.Value);
                    textBoxName.Text = view.IngredientName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните Название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIHabitue.PostRequest<IngredientBindingModel,
                   bool>("api/Ingredient/UpdElement", new IngredientBindingModel
                   { Id = id.Value, IngredientName = textBoxName.Text });
                }
                else
                {
                    APIHabitue.PostRequest<IngredientBindingModel,
                    bool>("api/Ingredient/AddElement", new IngredientBindingModel { IngredientName = textBoxName.Text });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information); DialogResult = DialogResult.OK; Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
