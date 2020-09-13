namespace BarView
{
    partial class FormCreateBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelHabitue = new System.Windows.Forms.Label();
            this.labelCocktail = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelSum = new System.Windows.Forms.Label();
            this.comboBoxHabitue = new System.Windows.Forms.ComboBox();
            this.comboBoxCocktail = new System.Windows.Forms.ComboBox();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.habitueViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cocktailViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.habitueViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocktailViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(442, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(112, 25);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(300, 275);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(114, 26);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // labelHabitue
            // 
            this.labelHabitue.AutoSize = true;
            this.labelHabitue.Location = new System.Drawing.Point(21, 18);
            this.labelHabitue.Name = "labelHabitue";
            this.labelHabitue.Size = new System.Drawing.Size(95, 17);
            this.labelHabitue.TabIndex = 8;
            this.labelHabitue.Text = "Завсегдатай:";
            // 
            // labelCocktail
            // 
            this.labelCocktail.AutoSize = true;
            this.labelCocktail.Location = new System.Drawing.Point(23, 61);
            this.labelCocktail.Name = "labelCocktail";
            this.labelCocktail.Size = new System.Drawing.Size(74, 17);
            this.labelCocktail.TabIndex = 9;
            this.labelCocktail.Text = "Коктейль:";
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(22, 110);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(90, 17);
            this.labelCount.TabIndex = 10;
            this.labelCount.Text = "Количество:";
            // 
            // labelSum
            // 
            this.labelSum.AutoSize = true;
            this.labelSum.Location = new System.Drawing.Point(23, 163);
            this.labelSum.Name = "labelSum";
            this.labelSum.Size = new System.Drawing.Size(54, 17);
            this.labelSum.TabIndex = 11;
            this.labelSum.Text = "Сумма:";
            // 
            // comboBoxHabitue
            // 
            this.comboBoxHabitue.DataSource = this.habitueViewModelBindingSource;
            this.comboBoxHabitue.DisplayMember = "HabitueFIO";
            this.comboBoxHabitue.FormattingEnabled = true;
            this.comboBoxHabitue.Location = new System.Drawing.Point(132, 15);
            this.comboBoxHabitue.Name = "comboBoxHabitue";
            this.comboBoxHabitue.Size = new System.Drawing.Size(309, 24);
            this.comboBoxHabitue.TabIndex = 12;
            this.comboBoxHabitue.ValueMember = "Id";
            // 
            // comboBoxCocktail
            // 
            this.comboBoxCocktail.DataSource = this.cocktailViewModelBindingSource;
            this.comboBoxCocktail.DisplayMember = "CocktailName";
            this.comboBoxCocktail.FormattingEnabled = true;
            this.comboBoxCocktail.Location = new System.Drawing.Point(133, 61);
            this.comboBoxCocktail.Name = "comboBoxCocktail";
            this.comboBoxCocktail.Size = new System.Drawing.Size(309, 24);
            this.comboBoxCocktail.TabIndex = 13;
            this.comboBoxCocktail.ValueMember = "Id";
            this.comboBoxCocktail.SelectedIndexChanged += new System.EventHandler(this.comboBoxCocktail_SelectedIndexChanged);
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(133, 107);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(309, 22);
            this.textBoxCount.TabIndex = 14;
            this.textBoxCount.TextChanged += new System.EventHandler(this.textBoxCount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(132, 160);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(310, 22);
            this.textBoxSum.TabIndex = 15;
            // 
            // habitueViewModelBindingSource
            // 
            this.habitueViewModelBindingSource.DataSource = typeof(BarServiceDAL.ViewModels.HabitueViewModel);
            // 
            // cocktailViewModelBindingSource
            // 
            this.cocktailViewModelBindingSource.DataSource = typeof(BarServiceDAL.ViewModels.CocktailViewModel);
            // 
            // FormCreateBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 334);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.comboBoxCocktail);
            this.Controls.Add(this.comboBoxHabitue);
            this.Controls.Add(this.labelSum);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.labelCocktail);
            this.Controls.Add(this.labelHabitue);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Name = "FormCreateBooking";
            this.Text = "Заказ";
            this.Load += new System.EventHandler(this.FormCreateBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.habitueViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocktailViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelHabitue;
        private System.Windows.Forms.Label labelCocktail;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Label labelSum;
        private System.Windows.Forms.ComboBox comboBoxHabitue;
        private System.Windows.Forms.ComboBox comboBoxCocktail;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.BindingSource habitueViewModelBindingSource;
        private System.Windows.Forms.BindingSource cocktailViewModelBindingSource;
    }
}