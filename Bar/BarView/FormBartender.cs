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
    public partial class FormBartender : Form
    {
        public int Id { set { id = value; } }

        private int? id;

        public FormBartender()
        {
            InitializeComponent();
        }

        private void FormBartender_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    BartenderViewModel Bartender =
                    APIClient.GetRequest<BartenderViewModel>("api/Bartender/Get/" + id.Value);
                    textBoxFIO.Text = Bartender.BartenderFIO;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFIO.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
            try
            {
                if (id.HasValue)
                {
                    APIClient.PostRequest<BartenderBindingModel,
                    bool>("api/Bartender/UpdElement", new BartenderBindingModel
                    { Id = id.Value, BartenderFIO = textBoxFIO.Text });
                }
                else
                {
                    APIClient.PostRequest<BartenderBindingModel,
                    bool>("api/Bartender/AddElement", new BartenderBindingModel
                    {
                        BartenderFIO = textBoxFIO.Text
                    });
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
