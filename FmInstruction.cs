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
    public partial class FmInstruction : Form
    {
        public FmInstruction()
        {
            InitializeComponent();
        }

        private void FmInstruction_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                this.pic1.Visible = true;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false;
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = true;
                this.pic3.Visible = false;
                this.pic4.Visible = false;
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = true;
                this.pic4.Visible = false; 
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = true;  
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false;  
                this.pic6.Visible = true;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }
        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false; 
                this.pic6.Visible = false;
                this.pic7.Visible = true;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }
        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton8.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false;  
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = true;
                this.pic9.Visible = false;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false;  
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = true;
                this.pic10.Visible = false;
                this.picVersion.Visible = false;
            }
        }
        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                this.pic1.Visible = false;
                this.pic2.Visible = false;
                this.pic3.Visible = false;
                this.pic4.Visible = false; 
                this.pic6.Visible = false;
                this.pic7.Visible = false;
                this.pic8.Visible = false;
                this.pic9.Visible = false;
                this.pic10.Visible = true;
                this.picVersion.Visible = false;
            }
        }
        private void laX_Click(object sender, EventArgs e)
        {
            FmInstruction.ActiveForm.Close();
        }

        private void picnext_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                radioButton2.Checked = true;
            else if (radioButton2.Checked == true)
                radioButton3.Checked = true;
            else if (radioButton3.Checked == true)
                radioButton4.Checked = true;
            else if (radioButton4.Checked == true)
                radioButton6.Checked = true;
            else if (radioButton6.Checked == true)
                radioButton7.Checked = true;
            else if (radioButton7.Checked == true)
                radioButton8.Checked = true;
            else if (radioButton8.Checked == true)
                radioButton9.Checked = true;
            else if (radioButton9.Checked == true)
                radioButton10.Checked = true;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                radioButton1.Checked = true;
            else if (radioButton3.Checked == true)
                radioButton2.Checked = true;
            else if (radioButton4.Checked == true)
                radioButton3.Checked = true;
            else if (radioButton6.Checked == true)
                radioButton4.Checked = true;
            else if (radioButton7.Checked == true)
                radioButton6.Checked = true;
            else if (radioButton8.Checked == true)
                radioButton7.Checked = true;
            else if (radioButton9.Checked == true)
                radioButton8.Checked = true;
            else if (radioButton10.Checked == true)
                radioButton9.Checked = true;
        }

        private void picVersion_Click(object sender, EventArgs e)
        {
            
        }

        private void pic10_Click(object sender, EventArgs e)
        {

        }

        private void pic7_Click(object sender, EventArgs e)
        {

        }

        private void pic6_Click(object sender, EventArgs e)
        {

        }

        private void pic9_Click(object sender, EventArgs e)
        {

        }
    }
}
