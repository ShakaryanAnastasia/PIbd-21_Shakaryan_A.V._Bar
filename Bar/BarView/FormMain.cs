using BarServiceDAL.BindingModels;
using BarServiceDAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace BarView
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                List<BookingViewModel> list = APIHabitue.GetRequest<List<BookingViewModel>>("api/Main/GetList");
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    dataGridView.Columns[5].Visible = false;
                    dataGridView.Columns[1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }

        private void завсегдатаиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormHabitues();
            form.ShowDialog();
        }

        private void ингредиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormIngredients();
            form.ShowDialog();
        }

        private void коктейлиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormCocktails();
            form.ShowDialog();
        }
        private void кладовыеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPantrys();
            form.ShowDialog();
        }

        private void пополнитьКладовуюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPutOnPantry();
            form.ShowDialog();
        }

        private void прайсКоктейлейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "doc|*.doc|docx|*.docx"
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    APIHabitue.PostRequest<RecordBindingModel,
                    bool>("api/Record/SaveCocktailPrice", new RecordBindingModel
                    {
                        FileName = sfd.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void загруженностьКладовыхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormPantrysLoad();
            form.ShowDialog();
        }
        private void заказыЗавсегдатаевToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormHabitueBookings();
            form.ShowDialog();
        }

        private void buttonCreateBooking_Click(object sender, EventArgs e)
        {
            var form = new FormCreateBooking();
            form.ShowDialog();
            LoadData();
        }

        private void buttonTakeBookingInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIHabitue.PostRequest<BookingBindingModel,
                    bool>("api/Main/TakeBookingInWork", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBookingReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIHabitue.PostRequest<BookingBindingModel,
                    bool>("api/Main/FinishBooking", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonPayBooking_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    APIHabitue.PostRequest<BookingBindingModel,
                    bool>("api/Main/PayBooking", new BookingBindingModel
                    {
                        Id = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
