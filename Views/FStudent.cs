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
    public partial class FStudent : Form
    {
        private DbTheoryController _theoryController;
        private DbTestController _testController;
        private DbPracticeController _practiceController;
        private DbUserController _userController;
        private DbResultController _resultController;

        private int _currentTheory = 0;
        private int _currentTest = 0;
        private int _currentPractice = 0;

        private bool _isTestChecked;
        private bool _isPracticeChecked;

        private bool _isCanRunTest;
        private bool _isCanRunPractice;

        public FStudent()
        {
            InitializeComponent();

            _theoryController = new DbTheoryController();
            _testController = new DbTestController();
            _practiceController = new DbPracticeController();
            _userController = new DbUserController();
            _resultController = new DbResultController();

            _isTestChecked = false;
            _isPracticeChecked = false;

            _isCanRunTest = false;  
            _isCanRunPractice = false;
        }

        private void FStudent_Load(object sender, EventArgs e)
        {
            try
            {
                _theoryController.Request_Loading();
                _testController.Request_Loading();
                _practiceController.Request_Loading();
                _resultController.Request_Loading();

                textBox_email.Text = _userController.SavedUser.Email;
                textBox_fullname.Text = _userController.SavedUser.Fullname;
                textBox_login.Text = _userController.SavedUser.Login;
                textBox_password.Text = _userController.SavedUser.Password;
                textBox_phone.Text = _userController.SavedUser.Phone;
                textBox_dateOfBirth.Text = _userController.SavedUser.DateOfBirth;

                ViewPractice();
                ViewTest();
                ViewTheory();
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
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

        private void button_edit_user_Click(object sender, EventArgs e)
        {
            if (textBox_email.Text == "" || textBox_fullname.Text == "" ||
                textBox_login.Text == "" || textBox_password.Text == "" ||
                textBox_phone.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new User();
                d.DateOfBirth = textBox_dateOfBirth.Text;
                d.Role = "Student";
                d.Email = textBox_email.Text;
                d.Fullname = textBox_fullname.Text;
                d.Login = textBox_login.Text;
                d.Password = textBox_password.Text;
                d.Phone = textBox_phone.Text;

                if (_userController.Request_Updating(d))
                {
                    MessageHelper.Show("Запрос обновления данных выполнен!", "Выполнено!");
                }
                else
                {
                    MessageHelper.ShowError("Ошибка обновления данных!");
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void CheckResultAvailability(out Result res)
        {
            if (!_resultController.Requst_TrySelectByIdUser(_userController.SavedUser.Id, out res))
            {
                res = new Result();
                res.IdUser = _userController.SavedUser.Id;
                res.TestScore = 0;
                res.PracticeScore = 0;

                if (!_resultController.Request_Inserting(res))
                {
                    MessageHelper.ShowError("Ошибка добавления результата");
                }
            }
        }

        private void ResetResultForTest()
        {
            if (MessageBox.Show("Для прохождения теста необходимо сбросить предыдущие результаты!\nПродолжить прохождение теста?",
                    "Внимание!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                _isCanRunTest = false;
                return;
            }

            CheckResultAvailability(out Result res);
            res.TestScore = 0;

            if (_resultController.Requst_UpdatinByIdUser(res))
            {
                MessageHelper.Show("Предыдущие результаты сброшены, можете пройти тест!", "Успешно!");
                _isCanRunTest = true;
            }
            else
            {
                MessageHelper.ShowError("Ошибка сброса результата теста!");
                _isCanRunTest = false;
            }
        }

        private void ResetResultForPractice()
        {
            if (MessageBox.Show("Для прохождения практики необходимо сбросить предыдущие результаты!\nПродолжить прохождение практики?",
                                  "Внимание!", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                _isCanRunPractice = false;
                return;
            }

            CheckResultAvailability(out Result res);
            res.PracticeScore = 0;

            if (_resultController.Requst_UpdatinByIdUser(res))
            {
                MessageHelper.Show("Предыдущие результаты сброшены, можете пройти практику!", "Успешно!");
                _isCanRunPractice = true;
            }
            else
            {
                MessageHelper.ShowError("Ошибка сброса результата практики!");
                _isCanRunPractice = false;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == 2)
            {
                ResetResultForTest();
                _isCanRunPractice = false;
            }
            else if(tabControl1.SelectedIndex == 3)
            {
                ResetResultForPractice();
                _isCanRunTest = false;
            }
            else
            {
                _isCanRunTest = false;
                _isCanRunPractice = false;
            }
        }

        #region === Теория ===
        private void ViewTheory()
        {
            label_theory_title.Text = _theoryController[_currentTheory].Title;
            textBox_theory_text.Text = _theoryController[_currentTheory].Text;
        }

        private void button_theory_prev_Click(object sender, EventArgs e)
        {
            if (_currentTheory == 0)
            {
                MessageHelper.ShowWarning("Нет предыдущей записи!");
                return;
            }

            _currentTheory--;
            ViewTheory();
        }

        private void button_theory_next_Click(object sender, EventArgs e)
        {
            if (_currentTheory == _theoryController.Count - 1)
            {
                MessageHelper.ShowWarning("Нет следующей записи!");
                return;
            }

            _currentTheory++;
            ViewTheory();
        }
        #endregion

        #region === Тест ===
        private void ViewTest()
        {
            label_test_textQuation.Text = _testController[_currentTest].QuestionText;
            radioButton_test_answer1.Text = _testController[_currentTest].AnswerText_1;
            radioButton_test_answer2.Text = _testController[_currentTest].AnswerText_2;
            radioButton_test_answer3.Text = _testController[_currentTest].AnswerText_3;
            radioButton_test_answer4.Text = _testController[_currentTest].AnswerText_4;
        }

        private void button_chechTest_Click(object sender, EventArgs e)
        {
            if (!_isCanRunTest)
            {
                ResetResultForTest();
                return;
            }

            CheckResultAvailability(out Result res);

                int selectedAnswer = -1; 
            if(radioButton_test_answer1.Checked)
                selectedAnswer = 1;
            else if (radioButton_test_answer2.Checked)
                selectedAnswer = 2;
            else if (radioButton_test_answer3.Checked)
                selectedAnswer = 3;
            else if (radioButton_test_answer4.Checked)
                selectedAnswer = 4;

            if (selectedAnswer == _testController[_currentTest].RightAnswerNumber)
            {
                res.TestScore++;
                if (_resultController.Requst_UpdatinByIdUser(res))
                {
                    MessageHelper.Show("Вы ответили верно!", "Ответ засчитан!");
                }
                else
                {
                    MessageHelper.ShowError("Ошибка сохранения результата (вы ответили верно!)...");
                }
            }
            else
            {
                MessageHelper.ShowError("Вы ответили не верно!");
            }
        }

        private void button_test_prev_Click(object sender, EventArgs e)
        {
            if (!_isCanRunTest)
            {
                ResetResultForTest();
                return;
            }

            if (_currentTest == 0)
            {
                MessageHelper.ShowWarning("Нет предыдущей записи!");
                return;
            }

            _currentTest--;
            ViewTest();
        }

        private void button_test_next_Click(object sender, EventArgs e)
        {
            if (!_isCanRunTest)
            {
                ResetResultForTest();
                return;
            }

            if (_currentTest == _testController.Count - 1)
            {
                MessageHelper.ShowWarning("Нет следующей записи!");
                return;
            }

            _currentTest++;
            ViewTest();
        }
        #endregion

        #region === Практика ===
        private void ViewPractice()
        {
            label_practice_header.Text = $"Практика №{_currentPractice + 1}";
            textBox_practice_text.Text = _practiceController[_currentPractice].Text;
        }

        private void button_checkPractice_Click(object sender, EventArgs e)
        {
            if (!_isCanRunPractice)
            {
                ResetResultForPractice();
                return;
            }

            CheckResultAvailability(out Result res);
            string selectedAnswer = textBox_practice_answer.Text;

            if(selectedAnswer == _practiceController[_currentPractice].RightWord)
            {
                res.PracticeScore++;
                if (_resultController.Requst_UpdatinByIdUser(res))
                {
                    MessageHelper.Show("Вы ответили верно!", "Ответ засчитан!");
                }
                else
                {
                    MessageHelper.ShowError("Ошибка сохранения результата (вы ответили верно!)...");
                }
            }
            else
            {
                MessageHelper.ShowError("Вы ответили не верно!");
            }
        }

        private void button_practice_prev_Click(object sender, EventArgs e)
        {
            if (!_isCanRunPractice)
            {
                ResetResultForPractice();
                return;
            }

            if (_currentPractice == 0)
            {
                MessageHelper.ShowWarning("Нет предыдущей записи!");
                return;
            }

            _currentPractice--;
            ViewPractice();
        }

        private void button_practice_next_Click(object sender, EventArgs e)
        {
            if (!_isCanRunPractice)
            {
                ResetResultForPractice();
                return;
            }

            if (_currentPractice == _practiceController.Count - 1)
            {
                MessageHelper.ShowWarning("Нет следующей записи!");
                return;
            }

            _currentPractice++;
            ViewPractice();
        }
        #endregion

        #region === Результаты ===
        private void button_viewResult_Click(object sender, EventArgs e)
        {
            if (_resultController.Requst_TrySelectByIdUser(_userController.SavedUser.Id, out Result res))
            {
                textBox_resultTest.Text = $"{res.TestScore}/{_testController.Count}";
                textBox_resultPractice.Text = $"{res.PracticeScore}/{_practiceController.Count}";
            }
            else
            {
                MessageHelper.ShowWarning("Ваши результаты не найдены!\nВозможно, вы еще не выполняли задания!");
            }
        }
        #endregion
    }
}
