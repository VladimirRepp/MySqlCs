using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TODO_Test.Context;
using TODO_Test.Models;

namespace TODO_Test
{
    public partial class Form1 : Form
    {
        private DbTodoSimpleContetx _dbTodoSimpleContetx;
        private DbTodoMarkContext _dbTodoMarkContext;

        public Form1()
        {
            InitializeComponent();

            _dbTodoSimpleContetx = new DbTodoSimpleContetx();
            _dbTodoMarkContext = new DbTodoMarkContext();

            dataGridView_TodoSimple.TopLeftHeaderCell.Value = "Код";
            dataGridView_Mark.TopLeftHeaderCell.Value = "Код";
        }

        private void ShowException(Exception ex)
        {
            MessageBox.Show($"Сообщение: {ex.Message}", "Вызвано исключение!");
        }

        private void LoadAndViewTodoSimple(bool isLoad = false)
        {
            try
            {
                if (isLoad)
                    _dbTodoSimpleContetx.Query_SelectAll();

                int i = 0;
                dataGridView_TodoSimple.Rows.Clear();
                foreach (MTodoSimple d in _dbTodoSimpleContetx.Data)
                {
                    dataGridView_TodoSimple.Rows.Add(d.ToArrayStr);
                    dataGridView_TodoSimple.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void LoadAndViewTodoMark(bool isLoad = false)
        {
            try
            {
                if (isLoad)
                    _dbTodoMarkContext.Query_SelectAll();

                int i = 0;
                dataGridView_Mark.Rows.Clear();
                foreach (MTodoMark d in _dbTodoMarkContext.Data)
                {
                    dataGridView_Mark.Rows.Add(d.ToArrayStr);
                    dataGridView_Mark.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAndViewTodoSimple(true);
            LoadAndViewTodoMark(true);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Продолжить выход?", "Внимание!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                Application.Exit();
        }

        private void button_AddSimple_Click(object sender, EventArgs e)
        {
            if(textBox_HeaderSimple.Text == "" || textBox_DescriptionSimple.Text == "")
            {
                MessageBox.Show("Не все поля введены!", "Внимание!");
                return;
            }

            try
            {
                MTodoSimple mTodoSimple = new MTodoSimple(
                    id: 0,
                    header: textBox_HeaderSimple.Text,
                    description: textBox_DescriptionSimple.Text
                    );

                if (_dbTodoSimpleContetx.Query_Insert(mTodoSimple))
                    LoadAndViewTodoSimple(true);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void button_EditSimple_Click(object sender, EventArgs e)
        {
            if (textBox_HeaderSimple.Text == "" || textBox_DescriptionSimple.Text == "")
            {
                MessageBox.Show("Не все поля введены!", "Внимание!");
                return;
            }

            if(dataGridView_TodoSimple.CurrentRow.Index == -1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }

            try
            {
                MTodoSimple mTodoSimple = new MTodoSimple(
                    id: Convert.ToInt32(dataGridView_TodoSimple.CurrentRow.HeaderCell.Value),
                    header: textBox_HeaderSimple.Text,
                    description: textBox_DescriptionSimple.Text
                    );

                if (_dbTodoSimpleContetx.Query_Update(mTodoSimple))
                    LoadAndViewTodoSimple(false);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void button_DeleteSimple_Click(object sender, EventArgs e)
        {
            if (dataGridView_TodoSimple.CurrentRow.Index == -1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView_TodoSimple.CurrentRow.HeaderCell.Value);
                if (_dbTodoSimpleContetx.Query_Delete(id))
                    LoadAndViewTodoSimple(false);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void button_AddMark_Click(object sender, EventArgs e)
        {
            if (textBox_HeaderMark.Text == "" || textBox_DescriptionMark.Text == "")
            {
                MessageBox.Show("Не все поля введены!", "Внимание!");
                return;
            }

            try
            {
                MTodoMark mTodoMark = new MTodoMark(
                    id: 0,
                    header: textBox_HeaderMark.Text,
                    description: textBox_DescriptionMark.Text,
                    mark: radioButton_DoneMark.Checked
                    );

                if (_dbTodoMarkContext.Query_Insert(mTodoMark))
                    LoadAndViewTodoMark(true);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void button_EditMark_Click(object sender, EventArgs e)
        {
            if (textBox_HeaderMark.Text == "" || textBox_DescriptionMark.Text == "")
            {
                MessageBox.Show("Не все поля введены!", "Внимание!");
                return;
            }

            if(dataGridView_Mark.CurrentRow.Index == -1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }

            try
            {
                MTodoMark mTodoMark = new MTodoMark(
                    id: Convert.ToInt32(dataGridView_Mark.CurrentRow.HeaderCell.Value),
                    header: textBox_HeaderMark.Text,
                    description: textBox_DescriptionMark.Text,
                    mark: radioButton_DoneMark.Checked
                    );

                if (_dbTodoMarkContext.Query_Update(mTodoMark))
                    LoadAndViewTodoMark(false);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }

        private void button_DeleteMark_Click(object sender, EventArgs e)
        {
            if (dataGridView_Mark.CurrentRow.Index == -1)
            {
                MessageBox.Show("Выберите строку!", "Внимание!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridView_Mark.CurrentRow.HeaderCell.Value);
                if (_dbTodoMarkContext.Query_Delete(id))
                    LoadAndViewTodoMark(false);
            }
            catch (Exception ex)
            {
                ShowException(ex);
            }
        }
    }
}
