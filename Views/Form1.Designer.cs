
namespace TODO_Test
{
    partial class Form1
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
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_TodoSimple = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_HeaderSimple = new System.Windows.Forms.TextBox();
            this.textBox_DescriptionSimple = new System.Windows.Forms.TextBox();
            this.button_AddSimple = new System.Windows.Forms.Button();
            this.button_EditSimple = new System.Windows.Forms.Button();
            this.button_DeleteSimple = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_DeleteMark = new System.Windows.Forms.Button();
            this.button_EditMark = new System.Windows.Forms.Button();
            this.button_AddMark = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_DescriptionMark = new System.Windows.Forms.TextBox();
            this.textBox_HeaderMark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridView_Mark = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton_DoneMark = new System.Windows.Forms.RadioButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TodoSimple)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mark)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1411, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1411, 690);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1403, 664);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Простые задачи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1403, 664);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Задачи с меткой";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_TodoSimple);
            this.groupBox1.Location = new System.Drawing.Point(8, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(866, 652);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_DescriptionSimple);
            this.groupBox2.Controls.Add(this.textBox_HeaderSimple);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(880, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 192);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Поле ввода";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button_DeleteSimple);
            this.groupBox3.Controls.Add(this.button_EditSimple);
            this.groupBox3.Controls.Add(this.button_AddSimple);
            this.groupBox3.Location = new System.Drawing.Point(880, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(515, 79);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Действия";
            // 
            // dataGridView_TodoSimple
            // 
            this.dataGridView_TodoSimple.AllowUserToAddRows = false;
            this.dataGridView_TodoSimple.AllowUserToDeleteRows = false;
            this.dataGridView_TodoSimple.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_TodoSimple.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView_TodoSimple.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_TodoSimple.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_TodoSimple.Name = "dataGridView_TodoSimple";
            this.dataGridView_TodoSimple.Size = new System.Drawing.Size(860, 633);
            this.dataGridView_TodoSimple.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заголовок:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Описание:";
            // 
            // textBox_HeaderSimple
            // 
            this.textBox_HeaderSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_HeaderSimple.Location = new System.Drawing.Point(132, 26);
            this.textBox_HeaderSimple.Name = "textBox_HeaderSimple";
            this.textBox_HeaderSimple.Size = new System.Drawing.Size(377, 29);
            this.textBox_HeaderSimple.TabIndex = 2;
            // 
            // textBox_DescriptionSimple
            // 
            this.textBox_DescriptionSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_DescriptionSimple.Location = new System.Drawing.Point(132, 60);
            this.textBox_DescriptionSimple.Multiline = true;
            this.textBox_DescriptionSimple.Name = "textBox_DescriptionSimple";
            this.textBox_DescriptionSimple.Size = new System.Drawing.Size(377, 126);
            this.textBox_DescriptionSimple.TabIndex = 3;
            // 
            // button_AddSimple
            // 
            this.button_AddSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddSimple.Location = new System.Drawing.Point(59, 23);
            this.button_AddSimple.Name = "button_AddSimple";
            this.button_AddSimple.Size = new System.Drawing.Size(135, 38);
            this.button_AddSimple.TabIndex = 4;
            this.button_AddSimple.Text = "Добавить";
            this.button_AddSimple.UseVisualStyleBackColor = true;
            this.button_AddSimple.Click += new System.EventHandler(this.button_AddSimple_Click);
            // 
            // button_EditSimple
            // 
            this.button_EditSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_EditSimple.Location = new System.Drawing.Point(200, 23);
            this.button_EditSimple.Name = "button_EditSimple";
            this.button_EditSimple.Size = new System.Drawing.Size(135, 38);
            this.button_EditSimple.TabIndex = 5;
            this.button_EditSimple.Text = "Измненить";
            this.button_EditSimple.UseVisualStyleBackColor = true;
            this.button_EditSimple.Click += new System.EventHandler(this.button_EditSimple_Click);
            // 
            // button_DeleteSimple
            // 
            this.button_DeleteSimple.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DeleteSimple.Location = new System.Drawing.Point(341, 23);
            this.button_DeleteSimple.Name = "button_DeleteSimple";
            this.button_DeleteSimple.Size = new System.Drawing.Size(135, 38);
            this.button_DeleteSimple.TabIndex = 6;
            this.button_DeleteSimple.Text = "Удалить";
            this.button_DeleteSimple.UseVisualStyleBackColor = true;
            this.button_DeleteSimple.Click += new System.EventHandler(this.button_DeleteSimple_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_DeleteMark);
            this.groupBox4.Controls.Add(this.button_EditMark);
            this.groupBox4.Controls.Add(this.button_AddMark);
            this.groupBox4.Location = new System.Drawing.Point(880, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(515, 79);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Действия";
            // 
            // button_DeleteMark
            // 
            this.button_DeleteMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_DeleteMark.Location = new System.Drawing.Point(341, 23);
            this.button_DeleteMark.Name = "button_DeleteMark";
            this.button_DeleteMark.Size = new System.Drawing.Size(135, 38);
            this.button_DeleteMark.TabIndex = 6;
            this.button_DeleteMark.Text = "Удалить";
            this.button_DeleteMark.UseVisualStyleBackColor = true;
            this.button_DeleteMark.Click += new System.EventHandler(this.button_DeleteMark_Click);
            // 
            // button_EditMark
            // 
            this.button_EditMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_EditMark.Location = new System.Drawing.Point(200, 23);
            this.button_EditMark.Name = "button_EditMark";
            this.button_EditMark.Size = new System.Drawing.Size(135, 38);
            this.button_EditMark.TabIndex = 5;
            this.button_EditMark.Text = "Измненить";
            this.button_EditMark.UseVisualStyleBackColor = true;
            this.button_EditMark.Click += new System.EventHandler(this.button_EditMark_Click);
            // 
            // button_AddMark
            // 
            this.button_AddMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_AddMark.Location = new System.Drawing.Point(59, 23);
            this.button_AddMark.Name = "button_AddMark";
            this.button_AddMark.Size = new System.Drawing.Size(135, 38);
            this.button_AddMark.TabIndex = 4;
            this.button_AddMark.Text = "Добавить";
            this.button_AddMark.UseVisualStyleBackColor = true;
            this.button_AddMark.Click += new System.EventHandler(this.button_AddMark_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton_DoneMark);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.textBox_DescriptionMark);
            this.groupBox5.Controls.Add(this.textBox_HeaderMark);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(880, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(515, 245);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Поле ввода";
            // 
            // textBox_DescriptionMark
            // 
            this.textBox_DescriptionMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_DescriptionMark.Location = new System.Drawing.Point(132, 60);
            this.textBox_DescriptionMark.Multiline = true;
            this.textBox_DescriptionMark.Name = "textBox_DescriptionMark";
            this.textBox_DescriptionMark.Size = new System.Drawing.Size(377, 126);
            this.textBox_DescriptionMark.TabIndex = 3;
            // 
            // textBox_HeaderMark
            // 
            this.textBox_HeaderMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_HeaderMark.Location = new System.Drawing.Point(132, 26);
            this.textBox_HeaderMark.Name = "textBox_HeaderMark";
            this.textBox_HeaderMark.Size = new System.Drawing.Size(377, 29);
            this.textBox_HeaderMark.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(16, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Описание:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(16, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Заголовок:";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridView_Mark);
            this.groupBox6.Location = new System.Drawing.Point(8, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(866, 652);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Данные";
            // 
            // dataGridView_Mark
            // 
            this.dataGridView_Mark.AllowUserToAddRows = false;
            this.dataGridView_Mark.AllowUserToDeleteRows = false;
            this.dataGridView_Mark.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Mark.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView_Mark.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Mark.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_Mark.Name = "dataGridView_Mark";
            this.dataGridView_Mark.Size = new System.Drawing.Size(860, 633);
            this.dataGridView_Mark.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Отметка:";
            // 
            // radioButton_DoneMark
            // 
            this.radioButton_DoneMark.AutoSize = true;
            this.radioButton_DoneMark.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButton_DoneMark.Location = new System.Drawing.Point(132, 196);
            this.radioButton_DoneMark.Name = "radioButton_DoneMark";
            this.radioButton_DoneMark.Size = new System.Drawing.Size(127, 28);
            this.radioButton_DoneMark.TabIndex = 5;
            this.radioButton_DoneMark.TabStop = true;
            this.radioButton_DoneMark.Text = "выполнена";
            this.radioButton_DoneMark.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Заголовок";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Описание";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Заголовок";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Описание";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Отметка выполнения";
            this.Column5.Name = "Column5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1411, 714);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное окно";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TodoSimple)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Mark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button_DeleteSimple;
        private System.Windows.Forms.Button button_EditSimple;
        private System.Windows.Forms.Button button_AddSimple;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox_DescriptionSimple;
        private System.Windows.Forms.TextBox textBox_HeaderSimple;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_TodoSimple;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_DeleteMark;
        private System.Windows.Forms.Button button_EditMark;
        private System.Windows.Forms.Button button_AddMark;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton radioButton_DoneMark;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_DescriptionMark;
        private System.Windows.Forms.TextBox textBox_HeaderMark;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridView_Mark;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
    }
}

