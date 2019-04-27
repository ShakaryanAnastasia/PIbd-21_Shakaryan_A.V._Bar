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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BarView
{
    public partial class FormHabitue : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormHabitue()
        {
            InitializeComponent();
        }

        private void FormHabitue_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    HabitueViewModel habitue =
                    APIClient.GetRequest<HabitueViewModel>("api/Habitue/Get/" + id.Value);
                    textBoxFIO.Text = habitue.HabitueFIO;
                    textBoxMail.Text = habitue.Mail;
                    dataGridView.DataSource = habitue.Messages;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[4].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
                catch (Exception ex)
                {
                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                    }
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string fio = textBoxFIO.Text;
            string mail = textBoxMail.Text;
            if (!string.IsNullOrEmpty(mail))
            {
                if (!Regex.IsMatch(mail, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$"))
                {
                    MessageBox.Show("Неверный формат для электронной почты", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (id.HasValue)
            {
                APIClient.PostRequest<HabitueBindingModel,
                bool>("api/Habitue/UpdElement", new HabitueBindingModel
                {
                    Id = id.Value,
                    HabitueFIO = fio,
                    Mail = mail
                });
            }
            else
            {
                APIClient.PostRequest<HabitueBindingModel,
                bool>("api/Habitue/AddElement", new HabitueBindingModel
                {
                    HabitueFIO = fio,
                    Mail = mail
                });
            }
            MessageBox.Show("Сохранение прошло успешно", "Сообщение",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
