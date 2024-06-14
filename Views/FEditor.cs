using LanguageTraining.Context;
using LanguageTraining.Controllers;
using LanguageTraining.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageTraining.Views
{
    public partial class FEditor : Form
    {
        private DbTheoryController _theoryController;
        private DbTestController _testController;
        private DbPracticeController _practiceController;
        private DbUserController _userController;
        private DbResultController _resultController;

        public FEditor()
        {
            InitializeComponent();

            _testController = new DbTestController();
            _theoryController = new DbTheoryController();
            _practiceController = new DbPracticeController();
            _userController = new DbUserController(); 
            _resultController = new DbResultController();

            dataGridView_practice.TopLeftHeaderCell.Value = "Код";
            dataGridView_result.TopLeftHeaderCell.Value = "Код";
            dataGridView_test.TopLeftHeaderCell.Value = "Код";
            dataGridView_theory.TopLeftHeaderCell.Value = "Код";
        }

        private void FEditor_Load(object sender, EventArgs e)
        {
            LoadAndViewPractice(); 
            LoadAndViewTest();
            LoadAndViewTheory();
            LoadAndViewResult();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FEntry();
            form.Show();
            this.Hide();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region === Теория ===
        private void LoadAndViewTheory(bool isLoad = true)
        {
            try
            {
                if (isLoad)
                    _theoryController.Request_Loading();

                int i = 0;
                dataGridView_theory.Rows.Clear();

                foreach (var d in _theoryController.Data)
                {
                    dataGridView_theory.Rows.Add(d.ToArrayStr);
                    dataGridView_theory.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_theory_add_Click(object sender, EventArgs e)
        {
            if(textBox_theory_text.Text == "" || textBox_theory_title.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Theory();
                d.Text = textBox_theory_text.Text;
                d.Title = textBox_theory_title.Text;

                if(_theoryController.Request_Inserting(d))
                    LoadAndViewTheory();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_theory_edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_theory.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            if (textBox_theory_text.Text == "" || textBox_theory_title.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Theory();
                d.Id = Convert.ToInt32(dataGridView_theory.CurrentRow.HeaderCell.Value);
                d.Text = textBox_theory_text.Text;
                d.Title = textBox_theory_title.Text;

                if (_theoryController.Request_Updating(d))
                    LoadAndViewTheory(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_theory_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_theory.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            try
            {
                if (_theoryController.Request_DeleteById(Convert.ToInt32(dataGridView_theory.CurrentRow.HeaderCell.Value)))
                    LoadAndViewTheory(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }
        #endregion

        #region === Тест ===
        private void LoadAndViewTest(bool isLoad = true)
        {
            try
            {
                if (isLoad)
                    _testController.Request_Loading();

                int i = 0;
                dataGridView_test.Rows.Clear();

                foreach (var d in _testController.Data)
                {
                    dataGridView_test.Rows.Add(d.ToArrayStr);
                    dataGridView_test.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_test_add_Click(object sender, EventArgs e)
        {
            if(textBox_test_answer1.Text == "" || textBox_test_answer2.Text == "" ||
                textBox_test_answer3.Text == "" || textBox_test_answer4.Text == "" ||
                textBox_test_textQuaton.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Test();
                d.QuestionText = textBox_test_textQuaton.Text;
                d.AnswerText_1 = textBox_test_answer1.Text;
                d.AnswerText_2 = textBox_test_answer2.Text;
                d.AnswerText_3 = textBox_test_answer3.Text;
                d.AnswerText_4 = textBox_test_answer4.Text;
                d.RightAnswerNumber = Convert.ToInt32(numericUpDown_test_rightAnswerNumber.Value);

                if (_testController.Request_Inserting(d))
                    LoadAndViewTest();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_test_edit_Click(object sender, EventArgs e)
        {
            if(dataGridView_test.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            if (textBox_test_answer1.Text == "" || textBox_test_answer2.Text == "" ||
               textBox_test_answer3.Text == "" || textBox_test_answer4.Text == "" ||
               textBox_test_textQuaton.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Test();
                d.Id = Convert.ToInt32(dataGridView_test.CurrentRow.HeaderCell.Value);
                d.QuestionText = textBox_test_textQuaton.Text;
                d.AnswerText_1 = textBox_test_answer1.Text;
                d.AnswerText_2 = textBox_test_answer2.Text;
                d.AnswerText_3 = textBox_test_answer3.Text;
                d.AnswerText_4 = textBox_test_answer4.Text;
                d.RightAnswerNumber = Convert.ToInt32(numericUpDown_test_rightAnswerNumber.Value);

                if (_testController.Request_Updating(d))
                    LoadAndViewTest(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_test_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_test.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }
            try
            {
                if (_testController.Request_DeleteById(Convert.ToInt32(dataGridView_test.CurrentRow.HeaderCell.Value)))
                    LoadAndViewTest(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }
        #endregion

        #region === Практика ===
        private void LoadAndViewPractice(bool isLoad = true)
        {
            try
            {
                if (isLoad)
                    _practiceController.Request_Loading();

                int i = 0;
                dataGridView_practice.Rows.Clear();

                foreach (var d in _practiceController.Data)
                {
                    dataGridView_practice.Rows.Add(d.ToArrayStr);
                    dataGridView_practice.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_practice_add_Click(object sender, EventArgs e)
        {
            if(textBox_practice_rightWord.Text == "" || textBox_practice_text.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Practice();
                d.Text = textBox_practice_text.Text;
                d.RightWord = textBox_practice_rightWord.Text;

                if(_practiceController.Request_Inserting(d))
                    LoadAndViewPractice();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_practice_edit_Click(object sender, EventArgs e)
        {
            if(dataGridView_result.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            if (textBox_practice_rightWord.Text == "" || textBox_practice_text.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new Practice();
                d.Id = Convert.ToInt32(dataGridView_result.CurrentRow.HeaderCell.Value);
                d.Text = textBox_practice_text.Text;
                d.RightWord = textBox_practice_rightWord.Text;

                if (_practiceController.Request_Updating(d))
                    LoadAndViewPractice(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_practice_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView_result.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            try
            {
                if (_practiceController.Request_DeleteById(Convert.ToInt32(dataGridView_result.CurrentRow.HeaderCell.Value)))
                    LoadAndViewPractice(false);
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }
        #endregion

        #region === Результат ===
        private void LoadAndViewResult(bool isLoad = true)
        {
            try
            {
                if (isLoad)
                    _resultController.Request_Loading();

                int i = 0;
                dataGridView_result.Rows.Clear();

                foreach (var d in _resultController.Data)
                {
                    dataGridView_result.Rows.Add(d.ToArrayStr);
                    dataGridView_result.Rows[i].HeaderCell.Value = d.Id.ToString();

                    string user = "не найдено";
                    if (_userController.Request_TrySelectById(d.IdUser, out User found))
                    {
                        user = found.Fullname;
                    }
                    dataGridView_result.Rows[i++].Cells[0].Value = user;
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }
        #endregion
    }
}
