using LanguageTraining.Context;
using LanguageTraining.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageTraining
{
    public partial class FEntry : Form
    {
        private DbUserController _userController;

        public FEntry()
        {
            InitializeComponent();
            _userController = new DbUserController();
        }

        private void button_entry_Click(object sender, EventArgs e)
        {
            if(textBox_login.Text == "" || textBox_password.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                string log = textBox_login.Text;
                string pass = textBox_password.Text;

                if(_userController.Request_TrySelectByLoginAndPassword(log, pass))
                {
                    if(_userController.SavedUser.Role == "Admin")
                    {
                        var form = new FAdmin();
                        form.Show();
                        this.Hide();
                    }
                    else if(_userController.SavedUser.Role == "Editor")
                    {
                        var form = new FEditor();
                        form.Show();
                        this.Hide();
                    }
                    else if (_userController.SavedUser.Role == "Student")
                    {
                        var form = new FStudent();
                        form.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageHelper.ShowWarning("Логин или пароль не совпал!");
                }
            }
            catch(Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void linkLabel_reg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new FRegistration();
            form.Show();
            this.Hide();
        }
    }
}
