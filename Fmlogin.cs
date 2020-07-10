using EasyNote.Controlers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyNote
{
    public partial class fmlogin : Form
    {
        
        fmRegister f2 = new fmRegister();
        fmForgot f3 = new fmForgot();
        public fmlogin()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtforgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            f3.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;
            f2.ShowDialog();
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void butSign_Click(object sender, EventArgs e)
        {
            if ((this.txtUsername.Text.Trim().Length <= 0 && (this.txtPass.Text.Trim().Length <= 0 || this.txtPass.Text == "Password"))
                || (this.txtUsername.Text == "Username" && (this.txtPass.Text.Trim().Length <= 0 || this.txtPass.Text == "Password")))
            {
                this.errLogin.SetError(this.txtUsername, "Please,input username!!!");
                this.errLogin.SetError(this.txtPass, "Please,input password!!!");
            }
            //this.errLogin.Clear();
            else
            {
                if (NoteControl.SignIn(txtUsername.Text, txtPass.Text) == true)
                {
                    
                    Program.GeneralName = txtUsername.Text;
                    Program.GeneralID = NoteControl.GetIdLogin(txtUsername.Text);
                    Program.Tags = true;
                    this.Dispose();
                    fmNote fm = new fmNote();
                    fm.ShowDialog();
                    
                }
                else MessageBox.Show("Login failed");
            }
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text== "Username")
                txtUsername.Clear();
            picSign.Image = Properties.Resources.login__5_1;
            panel1.BackColor = Color.FromArgb(78, 184, 206);
            txtUsername.ForeColor = Color.FromArgb(78, 184, 206);

            picPass.Image = Properties.Resources.password__1_1;
            panel2.BackColor= Color.White;
            txtPass.ForeColor = Color.White;
        }

        private void txtPass_Click(object sender, EventArgs e)
        {
            if(txtPass.Text== "Password")
                txtPass.Clear();
            picPass.Image = Properties.Resources.lock1;
            panel2.BackColor = Color.FromArgb(78, 184, 206);
            txtPass.ForeColor = Color.FromArgb(78, 184, 206);

            picSign.Image = Properties.Resources.login__41_;
            panel1.BackColor = Color.White;
            txtUsername.ForeColor = Color.White;
        }
        private void fmlogin_Load(object sender, EventArgs e)
        {

        }

        private void fmlogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MessageBox.Show("Bạn vừa nhấn enter");
            }
        }

        private void butSign_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void fmlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
