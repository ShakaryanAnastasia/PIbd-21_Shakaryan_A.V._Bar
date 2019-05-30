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
            this.buttonCreateBooking = new System.Windows.Forms.Button();
            this.buttonPayBooking = new System.Windows.Forms.Button();
            this.buttonRef = new System.Windows.Forms.Button();
            this.письмаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьКладовуюToolStripMenuItem,
            this.отчетыToolStripMenuItem,
            this.запускРаботToolStripMenuItem,
            this.письмаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1131, 28);
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
            this.завсегдатаиToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.завсегдатаиToolStripMenuItem.Text = "Завсегдатаи";
            this.завсегдатаиToolStripMenuItem.Click += new System.EventHandler(this.завсегдатаиToolStripMenuItem_Click);
            // 
            // ингредиентыToolStripMenuItem
            // 
            this.ингредиентыToolStripMenuItem.Name = "ингредиентыToolStripMenuItem";
            this.ингредиентыToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.ингредиентыToolStripMenuItem.Text = "Ингредиенты";
            this.ингредиентыToolStripMenuItem.Click += new System.EventHandler(this.ингредиентыToolStripMenuItem_Click);
            // 
            // коктейльToolStripMenuItem
            // 
            this.коктейльToolStripMenuItem.Name = "коктейльToolStripMenuItem";
            this.коктейльToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.коктейльToolStripMenuItem.Text = "Коктейль";
            this.коктейльToolStripMenuItem.Click += new System.EventHandler(this.коктейлиToolStripMenuItem_Click);
            // 
            // кладовыеToolStripMenuItem
            // 
            this.кладовыеToolStripMenuItem.Name = "кладовыеToolStripMenuItem";
            this.кладовыеToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.кладовыеToolStripMenuItem.Text = "Кладовые";
            this.кладовыеToolStripMenuItem.Click += new System.EventHandler(this.кладовыеToolStripMenuItem_Click);
            // 
            // барменыToolStripMenuItem
            // 
            this.барменыToolStripMenuItem.Name = "барменыToolStripMenuItem";
            this.барменыToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
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
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 41);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 24;
            this.dataGridView.Size = new System.Drawing.Size(890, 313);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateBooking
            // 
            this.buttonCreateBooking.Location = new System.Drawing.Point(926, 42);
            this.buttonCreateBooking.Name = "buttonCreateBooking";
            this.buttonCreateBooking.Size = new System.Drawing.Size(193, 32);
            this.buttonCreateBooking.TabIndex = 2;
            this.buttonCreateBooking.Text = "Создать заказ";
            this.buttonCreateBooking.UseVisualStyleBackColor = true;
            this.buttonCreateBooking.Click += new System.EventHandler(this.buttonCreateBooking_Click);
            // 
            // buttonPayBooking
            // 
            this.buttonPayBooking.Location = new System.Drawing.Point(926, 89);
            this.buttonPayBooking.Name = "buttonPayBooking";
            this.buttonPayBooking.Size = new System.Drawing.Size(193, 32);
            this.buttonPayBooking.TabIndex = 5;
            this.buttonPayBooking.Text = "Заказ оплачен";
            this.buttonPayBooking.UseVisualStyleBackColor = true;
            this.buttonPayBooking.Click += new System.EventHandler(this.buttonPayBooking_Click);
            // 
            // buttonRef
            // 
            this.buttonRef.Location = new System.Drawing.Point(926, 320);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(193, 28);
            this.buttonRef.TabIndex = 6;
            this.buttonRef.Text = "Обновить список";
            this.buttonRef.UseVisualStyleBackColor = true;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // письмаToolStripMenuItem
            // 
            this.письмаToolStripMenuItem.Name = "письмаToolStripMenuItem";
            this.письмаToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.письмаToolStripMenuItem.Text = "Письма";
            this.письмаToolStripMenuItem.Click += new System.EventHandler(this.письмаToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 359);
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
        private System.Windows.Forms.ToolStripMenuItem кладовыеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьКладовуюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсКоктейлейToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыЗавсегдатаевToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem запускРаботToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem барменыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem письмаToolStripMenuItem;
    }
}

