﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarServiceDAL.ViewModels;
using BarServiceDAL.Interfaces;

namespace BarView
{
    public partial class FormCocktailIngredient : Form
    {
        public CocktailIngredientViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }

        private CocktailIngredientViewModel model;

        public FormCocktailIngredient()
        {
            InitializeComponent();
        }

        private void FormCocktailIngredient_Load(object sender, EventArgs e)
        {
            try
            {
                List<IngredientViewModel> list = APIClient.GetRequest<List<IngredientViewModel>>("api/Ingredient/GetList");
                if (list != null)
                {
                    comboBoxIngredient.DisplayMember = "IngredientName";
                    comboBoxIngredient.ValueMember = "Id";
                    comboBoxIngredient.DataSource = list;
                    comboBoxIngredient.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxIngredient.Enabled = false;
                comboBoxIngredient.SelectedValue = model.IngredientId;
                textBoxCount.Text = model.Count.ToString();
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
                MessageBox.Show("Выберите ингредиент", "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)
                {
                    model = new CocktailIngredientViewModel
                    {
                        IngredientId = Convert.ToInt32(comboBoxIngredient.SelectedValue),
                        IngredientName = comboBoxIngredient.Text,
                        Count = Convert.ToInt32(textBoxCount.Text)
                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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
