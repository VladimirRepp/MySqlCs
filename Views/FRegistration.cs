using LanguageTraining.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LanguageTraining.Models;

namespace LanguageTraining.Views
{
    public partial class FRegistration : Form
    {
        DbUserController _userController;

        public FRegistration()
        {
            InitializeComponent();
            _userController = new DbUserController();   
        }

        private void button_reg_Click(object sender, EventArgs e)
        {
            if(textBox_email.Text == "" || textBox_fullname.Text == "" ||
                textBox_login.Text == "" || textBox_password.Text == "" || 
                textBox_phone.Text == "")
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new User();
                d.DateOfBirth = dateTimePicker_birth.Value.ToShortDateString();
                d.Role = "Student";
                d.Email = textBox_email.Text;
                d.Fullname = textBox_fullname.Text;
                d.Login = textBox_login.Text;
                d.Password = textBox_password.Text;
                d.Phone = textBox_phone.Text;

                if (_userController.Request_Inserting(d))
                {
                    d.Id = _userController.Request_GetLastId();
                    _userController.SavedUser = d;

                    var form = new FStudent();
                    form.Show();
                    this.Hide();
                }
                else
                {
                    MessageHelper.ShowError("Ошибка регистрации!");
                }
            }
            catch(Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void linkLabel_entry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new FEntry();
            form.Show();
            this.Hide();
        }
    }
}
