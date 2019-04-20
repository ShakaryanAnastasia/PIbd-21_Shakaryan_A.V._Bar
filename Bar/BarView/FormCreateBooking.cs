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
    public partial class FormCreateBooking : Form
    {
        public FormCreateBooking()
        {
            InitializeComponent();
        }
        private void FormCreateBooking_Load(object sender, EventArgs e)
        {
            try
            {
                List<HabitueViewModel> listC = APIClient.GetRequest<List<HabitueViewModel>>("api/Habitue/GetList");
                if (listC != null)
                {
                    comboBoxHabitue.DisplayMember = "HabitueFIO";
                    comboBoxHabitue.ValueMember = "Id";
                    comboBoxHabitue.DataSource = listC;
                    comboBoxHabitue.SelectedItem = null;
                }
                List<CocktailViewModel> listP = APIClient.GetRequest<List<CocktailViewModel>>("api/Cocktail/GetList");
                if (listP != null)
                {
                    comboBoxCocktail.DisplayMember = "CocktailName";
                    comboBoxCocktail.ValueMember = "Id";
                    comboBoxCocktail.DataSource = listP;
                    comboBoxCocktail.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void CalcSum()
        {
            if (comboBoxCocktail.SelectedValue != null &&
            !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxCocktail.SelectedValue);
                    CocktailViewModel Cocktail = APIClient.GetRequest<CocktailViewModel>("api/Cocktail/Get/" + id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * Cocktail.Price).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void comboBoxCocktail_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxHabitue.SelectedValue == null)
            {
                MessageBox.Show("Выберите завсегдатая", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            if (comboBoxCocktail.SelectedValue == null)
            {
                MessageBox.Show("Выберите коктейль", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                APIClient.PostRequest<BookingBindingModel,
                bool>("api/Main/CreateBooking", new BookingBindingModel
                {
                    HabitueId = Convert.ToInt32(comboBoxHabitue.SelectedValue),
                    CocktailId = Convert.ToInt32(comboBoxCocktail.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text)
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
