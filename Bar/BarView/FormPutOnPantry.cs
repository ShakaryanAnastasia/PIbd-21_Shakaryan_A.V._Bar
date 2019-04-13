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
    public partial class FormPutOnPantry : Form
    {
        public FormPutOnPantry()
        {
            InitializeComponent();
        }
        private void FormPutOnPantry_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> listC = APIHabitue.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                if (listC != null)
                {
                    comboBoxIngredient.DisplayMember = "IngredientName";
                    comboBoxIngredient.ValueMember = "Id";
                    comboBoxIngredient.DataSource = listC;
                    comboBoxIngredient.SelectedItem = null;
                }
                List<PantryViewModel> listS = APIHabitue.GetRequest<List<PantryViewModel>>("api/Pantry/GetList");
                if (listS != null)
                {

                    comboBoxPantry.DisplayMember = "PantryName";
                    comboBoxPantry.ValueMember = "Id";
                    comboBoxPantry.DataSource = listS;
                    comboBoxPantry.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxIngredient.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxPantry.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIHabitue.PostRequest<PantryIngredientBindingModel,
                bool>("api/Main/PutIngredientOnPantry", new PantryIngredientBindingModel
                {
                    IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                    PantryId = Convert.ToInt32(comboBoxPantry.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)
                });
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
