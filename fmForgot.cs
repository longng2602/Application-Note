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
    public partial class fmForgot : Form
    {
        public fmForgot()
        {
            InitializeComponent();
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            if (NoteControl.GetPassword(txtUsername.Text, txtPhone.Text) == null)
            {
                DialogResult result = MessageBox.Show("Sorry, Account is not exist", "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else 
            { 
                DialogResult result= MessageBox.Show("Your password is " + NoteControl.GetPassword(txtUsername.Text, txtPhone.Text), "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    this.Dispose();
                }
            }
        }
    }
}
