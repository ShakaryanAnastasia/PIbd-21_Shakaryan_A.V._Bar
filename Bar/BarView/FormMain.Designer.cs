namespace BarView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.завсегдатаиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ингредиентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коктейльToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кладовыеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.барменыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьКладовуюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсКоктейлейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыЗавсегдатаевToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.запускРаботToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitueIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habitueFIODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cocktailIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cocktailNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateImplementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookingViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьКладовуюToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(905, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.завсегдатаиToolStripMenuItem,
            this.ингредиентыToolStripMenuItem,
            this.коктейльToolStripMenuItem,
            this.кладовыеToolStripMenuItem,
            this.барменыToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(115, 24);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // завсегдатаиToolStripMenuItem
            // 
            this.завсегдатаиToolStripMenuItem.Name = "завсегдатаиToolStripMenuItem";
            this.завсегдатаиToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.завсегдатаиToolStripMenuItem.Text = "Завсегдатаи";
            this.завсегдатаиToolStripMenuItem.Click += new System.EventHandler(this.завсегдатаиToolStripMenuItem_Click);
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // коктейльToolStripMenuItem
            // 
            this.коктейльToolStripMenuItem.Name = "коктейльToolStripMenuItem";
            this.коктейльToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.коктейльToolStripMenuItem.Text = "Коктейль";
            this.коктейльToolStripMenuItem.Click += new System.EventHandler(this.коктейлиToolStripMenuItem_Click);
            // 
            // кладовыеToolStripMenuItem
            // 
            this.кладовыеToolStripMenuItem.Name = "кладовыеToolStripMenuItem";
            this.кладовыеToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.кладовыеToolStripMenuItem.Text = "Кладовые";
            this.кладовыеToolStripMenuItem.Click += new System.EventHandler(this.кладовыеToolStripMenuItem_Click);
            // 
            // барменыToolStripMenuItem
            // 
            this.барменыToolStripMenuItem.Name = "барменыToolStripMenuItem";
            this.барменыToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.барменыToolStripMenuItem.Text = "Бармены";
            this.барменыToolStripMenuItem.Click += new System.EventHandler(this.барменыToolStripMenuItem_Click);
            // 
            // пополнитьКладовуюToolStripMenuItem
            // 
            this.пополнитьКладовуюToolStripMenuItem.Name = "пополнитьКладовуюToolStripMenuItem";
            this.пополнитьКладовуюToolStripMenuItem.Size = new System.Drawing.Size(170, 24);
            this.пополнитьКладовуюToolStripMenuItem.Text = "Пополнить кладовую";
            this.пополнитьКладовуюToolStripMenuItem.Click += new System.EventHandler(this.пополнитьКладовуюToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсКоктейлейToolStripMenuItem,
            this.загруженностьСкладовToolStripMenuItem,
            this.заказыЗавсегдатаевToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // прайсКоктейлейToolStripMenuItem
            // 
            this.прайсКоктейлейToolStripMenuItem.Name = "прайсКоктейлейToolStripMenuItem";
            this.прайсКоктейлейToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.прайсКоктейлейToolStripMenuItem.Text = "Прайс коктейлей";
            this.прайсКоктейлейToolStripMenuItem.Click += new System.EventHandler(this.прайсКоктейлейToolStripMenuItem_Click);
            // 
            // загруженностьСкладовToolStripMenuItem
            // 
            this.загруженностьСкладовToolStripMenuItem.Name = "загруженностьСкладовToolStripMenuItem";
            this.загруженностьСкладовToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.загруженностьСкладовToolStripMenuItem.Text = "Загруженность кладовых";
            this.загруженностьСкладовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьКладовыхToolStripMenuItem_Click);
            // 
            // заказыЗавсегдатаевToolStripMenuItem
            // 
            this.заказыЗавсегдатаевToolStripMenuItem.Name = "заказыЗавсегдатаевToolStripMenuItem";
            this.заказыЗавсегдатаевToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.заказыЗавсегдатаевToolStripMenuItem.Text = "Заказы завсегдатаев";
            this.заказыЗавсегдатаевToolStripMenuItem.Click += new System.EventHandler(this.заказыЗавсегдатаевToolStripMenuItem_Click);
            // 
            // запускРаботToolStripMenuItem
            // 
            this.запускРаботToolStripMenuItem.Name = "запускРаботToolStripMenuItem";
            this.запускРаботToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.запускРаботToolStripMenuItem.Text = "Запуск работ";
            this.запускРаботToolStripMenuItem.Click += new System.EventHandler(this.запускРаботToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.habitueIdDataGridViewTextBoxColumn,
            this.habitueFIODataGridViewTextBoxColumn,
            this.cocktailIdDataGridViewTextBoxColumn,
            this.cocktailNameDataGridViewTextBoxColumn,
            this.countDataGridViewTextBoxColumn,
            this.sumDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.dateCreateDataGridViewTextBoxColumn,
            this.dateImplementDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.bookingViewModelBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(13, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(664, 313);
            this.dataGridView.TabIndex = 1;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // habitueIdDataGridViewTextBoxColumn
            // 
            this.habitueIdDataGridViewTextBoxColumn.DataPropertyName = "HabitueId";
            this.habitueIdDataGridViewTextBoxColumn.HeaderText = "HabitueId";
            this.habitueIdDataGridViewTextBoxColumn.Name = "habitueIdDataGridViewTextBoxColumn";
            this.habitueIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.habitueIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.habitueIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // habitueFIODataGridViewTextBoxColumn
            // 
            this.habitueFIODataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.habitueFIODataGridViewTextBoxColumn.DataPropertyName = "HabitueFIO";
            this.habitueFIODataGridViewTextBoxColumn.HeaderText = "HabitueFIO";
            this.habitueFIODataGridViewTextBoxColumn.Name = "habitueFIODataGridViewTextBoxColumn";
            this.habitueFIODataGridViewTextBoxColumn.ReadOnly = true;
            this.habitueFIODataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // cocktailIdDataGridViewTextBoxColumn
            // 
            this.cocktailIdDataGridViewTextBoxColumn.DataPropertyName = "CocktailId";
            this.cocktailIdDataGridViewTextBoxColumn.HeaderText = "CocktailId";
            this.cocktailIdDataGridViewTextBoxColumn.Name = "cocktailIdDataGridViewTextBoxColumn";
            this.cocktailIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.cocktailIdDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cocktailIdDataGridViewTextBoxColumn.Visible = false;
            // 
            // cocktailNameDataGridViewTextBoxColumn
            // 
            this.cocktailNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cocktailNameDataGridViewTextBoxColumn.DataPropertyName = "CocktailName";
            this.cocktailNameDataGridViewTextBoxColumn.HeaderText = "CocktailName";
            this.cocktailNameDataGridViewTextBoxColumn.Name = "cocktailNameDataGridViewTextBoxColumn";
            this.cocktailNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.cocktailNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            this.countDataGridViewTextBoxColumn.HeaderText = "Count";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.countDataGridViewTextBoxColumn.Visible = false;
            this.countDataGridViewTextBoxColumn.Width = 76;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Sum";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dateCreateDataGridViewTextBoxColumn
            // 
            this.dateCreateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateCreateDataGridViewTextBoxColumn.DataPropertyName = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.HeaderText = "DateCreate";
            this.dateCreateDataGridViewTextBoxColumn.Name = "dateCreateDataGridViewTextBoxColumn";
            this.dateCreateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dateImplementDataGridViewTextBoxColumn
            // 
            this.dateImplementDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateImplementDataGridViewTextBoxColumn.DataPropertyName = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.HeaderText = "DateImplement";
            this.dateImplementDataGridViewTextBoxColumn.Name = "dateImplementDataGridViewTextBoxColumn";
            this.dateImplementDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateImplementDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // bookingViewModelBindingSource
            // 
            this.bookingViewModelBindingSource.DataSource = typeof(BarServiceDAL.ViewModels.BookingViewModel);
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(700, 41);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(193, 32);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(700, 88);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(193, 32);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(700, 319);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(193, 28);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 359);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.buttonPayBooking);
            this.Controls.Add(this.buttonCreateBooking);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Бар";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem завсегдатаиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ингредиентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem коктейльToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateBooking;
        private System.Windows.Forms.Button buttonPayBooking;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.BindingSource bookingViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitueIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn habitueFIODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cocktailIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cocktailNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateImplementDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem кладовыеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьКладовуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсКоктейлейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыЗавсегдатаевToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem барменыToolStripMenuItem;
    }
}

