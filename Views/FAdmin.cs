using LanguageTraining.Context;
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
    public partial class FAdmin : Form
    {
        private DbUserController _userController;

        public FAdmin()
        {
            InitializeComponent();
            _userController = new DbUserController();
            dataGridView.TopLeftHeaderCell.Value = "Код";
        }

        private void LoadAndView(bool isLoad = true)
        {
            try
            {
                if (isLoad)
                    _userController.Request_Loading();

                int i = 0;
                dataGridView.Rows.Clear();
                foreach(var d in _userController.Data)
                {
                    dataGridView.Rows.Add(d.ToArrayStr);
                    dataGridView.Rows[i++].HeaderCell.Value = d.Id.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void FAdmin_Load(object sender, EventArgs e)
        {
            LoadAndView();
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

        private void button_add_Click(object sender, EventArgs e)
        {
            if (textBox_email.Text == "" || textBox_fullname.Text == "" ||
                textBox_login.Text == "" || textBox_password.Text == "" ||
                textBox_phone.Text == "" || comboBox_role.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new User();
                d.DateOfBirth = dateTimePicker_birth.Value.ToShortDateString();
                d.Email = textBox_email.Text;
                d.Fullname = textBox_fullname.Text;
                d.Login = textBox_login.Text;
                d.Password = textBox_password.Text;
                d.Phone = textBox_phone.Text;

                switch(comboBox_role.SelectedIndex)
                {
                    case 0:
                        d.Role = "Admin";
                        break;

                    case 1:
                        d.Role = "Editor";
                        break;

                    case 2:
                        d.Role = "Student";
                        break;
                }

                if (_userController.Request_Inserting(d))
                {
                    LoadAndView();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            if(dataGridView.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            if (textBox_email.Text == "" || textBox_fullname.Text == "" ||
              textBox_login.Text == "" || textBox_password.Text == "" ||
              textBox_phone.Text == "" || comboBox_role.SelectedIndex == -1)
            {
                MessageHelper.ShowWarning("Не все поля введены!");
                return;
            }

            try
            {
                var d = new User();
                d.Id = Convert.ToInt32(dataGridView.CurrentRow.HeaderCell.Value);
                d.DateOfBirth = dateTimePicker_birth.Value.ToShortDateString();
                d.Email = textBox_email.Text;
                d.Fullname = textBox_fullname.Text;
                d.Login = textBox_login.Text;
                d.Password = textBox_email.Text;
                d.Phone = textBox_email.Text;

                switch (comboBox_role.SelectedIndex)
                {
                    case 0:
                        d.Role = "Admin";
                        break;

                    case 1:
                        d.Role = "Editor";
                        break;

                    case 2:
                        d.Role = "Student";
                        break;
                }

                if (_userController.Request_Updating(d))
                {
                    LoadAndView(false);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow.Index == -1)
            {
                MessageHelper.ShowWarning("Выберите строку!");
                return;
            }

            try
            {
                if (_userController.Request_DeleteById(Convert.ToInt32(dataGridView.CurrentRow.HeaderCell.Value)))
                {
                    LoadAndView(false);
                }
            }
            catch (Exception ex)
            {
                MessageHelper.ShowException(ex.Message);
            }
        }
    }
}
