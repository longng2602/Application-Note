using EasyNote.Controlers;
using EasyNote.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyNote.Views
{
    public partial class fmEditAccount : Form
    {
        public fmEditAccount()
        {
            InitializeComponent();
        }

        private void fmEditAccount_Load(object sender, EventArgs e)
        {
            LoginUser login  = NoteControl.getLogin(Program.GeneralID);
            txtFirst.Text = login.FullName;
            txtPass.Text = login.Password;
            txtUser.Text = login.Username;
            txtPhone.Text = login.PhoneNum;
            txtConfirm.Text = "";
            dtpDOB.Value = login.DOB.Value;
            cbSex.Text = login.Gender;
            txtUser.ReadOnly = true;
            this.picava.Image = Image.FromFile(String.Format("{0}.jpg", Program.GeneralName));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            LoginUser login = NoteControl.getLogin(Program.GeneralID);
            login.PhoneNum = txtPhone.Text;
            login.Password = txtPass.Text;
            login.FullName = txtFirst.Text;
            login.DOB = dtpDOB.Value;
            login.Gender = cbSex.Text;
            this.picava.Image.Save(String.Format("{0}.jpg", Program.GeneralName));
            if (NoteControl.UpdateAccount(login) == false)
            {
                MessageBox.Show("Sorry, you need to fill full your information");
            }
            else this.Dispose();
        }
    }
}
