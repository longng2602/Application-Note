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

namespace EasyNote
{
    public partial class fmRegister : Form
    {
        LoginUser loginUser = new LoginUser();
        public fmRegister()
        {
            InitializeComponent();
        }

        private void fmRegister_Load(object sender, EventArgs e)
        {

        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            bool te1 = true;
            bool te2 = true;
            bool te3 = true;
            int count = 1;
            List<LoginUser> loginUsers = NoteControl.getListLogin();
            if (NoteControl.getListLogin().Count == 1)
                count = 1;
            else count = NoteControl.getListLogin().Count;
            for(int i = 0; i < loginUsers.Count; i++)
            {
                if (count == loginUsers[i].UserID)
                    count++;
            }
            loginUser.UserID = count;
            loginUser.FullName = this.txtFirst.Text + " " + this.txtLast.Text;
            loginUser.DOB = this.dtpDOB.Value;
            loginUser.Gender = this.cbSex.Text.Trim();
            loginUser.PhoneNum = this.txtPhone.Text.Trim();
            

            for(int i = 0; i < loginUsers.Count; i++)
            {
                if (txtUser.Text == loginUsers[i].Username)
                {
                    DialogResult dialog= MessageBox.Show("Username has existed","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    if (dialog == DialogResult.OK)
                    {
                        txtUser.Focus();
                        te1 = false;
                    }
                }
                else { loginUser.Username = txtUser.Text; te1 = true; }
            }

            if (txtPass.Text == textBox5.Text && txtPass.Text != "")
            {
                loginUser.Password = this.txtPass.Text.Trim();
                te2 = true;
            }
            else
            {
                DialogResult dialog = MessageBox.Show("You can confirm password again!!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dialog == DialogResult.OK)
                {   textBox5.Focus();
                    te2 = false; 
                }
            }

            if (pictureBox1.Image == Properties.Resources.login__5_3)
            {
                te3 = false;
            }
            if (te3 == true && te1==true && te2==true)
            {
                if (NoteControl.RegisterUser(loginUser) == true)
                {
                    this.pictureBox1.Image.Save(String.Format("{0}.jpg", loginUser.Username));
                    MessageBox.Show("Finish, you can login to use Easynote!!!");
                    this.Dispose();
                }
                else MessageBox.Show("Sorry, you need to fill full your information");
            }
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Please select image";
            ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string files = ofd.FileName;
                //PictureBox box = new PictureBox();
                this.pictureBox1.Image = Image.FromFile(files);
            }
        }

        private void txtUser_TextChanged_1(object sender, EventArgs e)
        {
            txtUser.Text = this.txtUser.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = this.textBox5.Text;
        }
    }
}
