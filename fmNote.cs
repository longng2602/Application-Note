using EasyNote.Controlers;
using EasyNote.Models;
using EasyNote.Views;
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
    public partial class fmNote : Form
    {

        
        FmInstruction instruction = new FmInstruction();
        fmEditAccount fmEditAccount = new fmEditAccount();
        public static DBNoteEntities _context = new DBNoteEntities();

        public fmNote(int ID)
        {
            InitializeComponent();
            this.CNotes.DataPropertyName = nameof(Note.Tittle);
            this.CID.DataPropertyName = nameof(Note.NodeID);
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListNote(ID);
            this.dataGridViewNote.DataSource = source.DataSource;
            this.picUser.Image = Properties.Resources.exit__3_1;
        }
        public fmNote()
        {
            InitializeComponent();
            this.CNotes.DataPropertyName = nameof(Note.Tittle);
            this.CID.DataPropertyName = nameof(Note.NodeID);
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListNote(Program.GeneralID);
            this.dataGridViewNote.DataSource = source.DataSource;
            if (Program.GeneralID != 0)
                this.picUser.Image = Properties.Resources.exit__3_1;
        }
        public void fmNote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBNoteDataSet1.Trash' table. You can move, or remove it, as needed.
            this.trashTableAdapter.Fill(this.dBNoteDataSet1.Trash);
            // TODO: This line of code loads data into the 'dBNoteDataSet.Note' table. You can move, or remove it, as needed.
            this.noteTableAdapter.Fill(this.dBNoteDataSet.Note);

            this.richnote.Focus();
            if (Program.Tags == true)
            {
                this.CNotes.DataPropertyName = nameof(Note.Tittle);
                this.CID.DataPropertyName = nameof(Note.NodeID);
                //
                this.richnote.Clear();
                if (this.darkTheme.Checked == true)
                {
                    picDelete.Image = Properties.Resources.delete__4_;
                    button1.BackColor = Color.DarkSlateGray;
                    pictureBox2.BackColor = Color.DarkSlateGray;
                    button1.ForeColor = Color.PaleTurquoise;

                    button2.BackColor = Color.FromArgb(34, 36, 49);
                    pictureBox4.BackColor = Color.FromArgb(34, 36, 49);
                    button2.ForeColor = Color.White;
                }
                else
                {
                    picDelete.Image = Properties.Resources.delete_Cam;
                    button1.BackColor = Color.DarkGoldenrod;
                    pictureBox2.BackColor = Color.DarkGoldenrod;
                    button1.ForeColor = Color.AliceBlue;

                    button2.BackColor = Color.FromArgb(227, 227, 227);
                    pictureBox4.BackColor = Color.FromArgb(227, 227, 227);
                    button2.ForeColor = Color.Black;
                }

                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListNote(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;
                for (int i = 1; i <= 7; i++)
                {
                    if (i != 3)
                        dataGridViewNote.Columns[i].Visible = false;
                }
                dataGridViewNote.Columns[3].Width = 345;
                dataGridViewNote.Columns[3].ReadOnly = true;

                this.laCountNote.Text = dataGridViewNote.Rows.Count.ToString()+ " Notes" ;
                this.picDelete.Image = Properties.Resources.delete__4_;
                if (dataGridViewNote.CurrentCell==null)
                {
                    
                }
                else
                {
                    String s = Convert.ToString(this.dataGridViewNote.SelectedRows[0].Cells[1].Value);
                    this.richnote.Text = NoteControl.getNote(Program.GeneralID, s).Body;
                    ConfigureNote configure = NoteControl.GetConfigureNote(s);
                    string sfont = configure.FontNote;
                    int ssize = Convert.ToInt32(configure.SizeNote);
                    int colortext = Convert.ToInt32(configure.Colortxt);
                    this.richnote.Font = new Font(sfont, ssize);
                    this.richnote.ForeColor = Color.FromArgb(colortext);
                    if (configure.Boldtxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Bold);
                    if (configure.Italictxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Italic);
                    if (configure.Underlinwtxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Underline);
                    if (configure.Striketxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Strikeout);
                }
            }
            else
            {
                this.CNotes.DataPropertyName = nameof(Trash.Title);
                this.CID.DataPropertyName = nameof(Trash.NodeID);
                //
                this.richnote.Clear();
                if (this.darkTheme.Checked == true)
                {
                    picDelete.Image = Properties.Resources.history__2_;
                    button2.BackColor = Color.DarkSlateGray;
                    pictureBox4.BackColor = Color.DarkSlateGray;
                    button2.ForeColor = Color.PaleTurquoise;

                    button1.BackColor = Color.FromArgb(34, 36, 49);
                    pictureBox2.BackColor = Color.FromArgb(34, 36, 49);
                    button1.ForeColor = Color.White;
                }
                else
                {
                    picDelete.Image = Properties.Resources.history_Cam;
                    button2.BackColor = Color.DarkGoldenrod;
                    pictureBox4.BackColor = Color.DarkGoldenrod;
                    button2.ForeColor = Color.AliceBlue;

                    button1.BackColor = Color.FromArgb(227, 227, 227);
                    pictureBox2.BackColor = Color.FromArgb(227, 227, 227);
                    button1.ForeColor = Color.Black;
                }

                picDelete.Image = Properties.Resources.history__2_;

                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListTrash(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;
                for (int i = 1; i <= 9; i++)
                {
                    if (i != 4)
                        dataGridViewNote.Columns[i].Visible = false;
                }
                dataGridViewNote.Columns[4].Width = 345;
                dataGridViewNote.Columns[4].ReadOnly = true;

                String s = Convert.ToString(this.dataGridViewNote.SelectedRows[0].Cells[7].Value);
                this.richnote.Text = NoteControl.getTrash(Program.GeneralID, s).Body;
                ConfigureTrash configure = NoteControl.GetConfigureTrash(s);
                string sfont = configure.FontTrash;
                int ssize = Convert.ToInt32(configure.SizeTrash);
                int colortext = Convert.ToInt32(configure.Colortxt);
                this.richnote.Font = new Font(sfont, ssize);
                this.richnote.ForeColor = Color.FromArgb(colortext);
                this.laCountNote.Text = dataGridViewNote.Rows.Count.ToString() + " Notes";
                if (configure.Boldtxt == 1)
                    this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Bold);
                if (configure.Italictxt == 1)
                    this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Italic);
                if (configure.Underlinetxt == 1)
                    this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Underline);
                if (configure.Striketxt == 1)
                    this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Strikeout);
            }
            if (Program.GeneralID != 0)
                this.picAva.Image = Image.FromFile(String.Format("{0}.jpg", Program.GeneralName));
        }
        //đăng nhập
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (Program.GeneralID != 0)
            {

                Program.GeneralID = 0;
                Program.GeneralName = "general";
                Program.Tags = true;
                this.Dispose();
                fmNote fm = new fmNote();
                fm.ShowDialog();
            }
            else 
            {
                fmlogin newlogin = new fmlogin();
                this.Hide();
                newlogin.ShowDialog();
                
            }
            
        }
        //save note
        private void picSave_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            ConfigureNote configureNote = new ConfigureNote();
            if (this.dataGridViewNote.CurrentCell is null)
            {
                //lưu nội dung note
                String temp = Convert.ToString(NoteControl.getListNote(Program.GeneralID).Count + 1);
                note.NodeID = Program.GeneralName + temp;
                note.UserID = Program.GeneralID;
                String s = this.richnote.Text;
                if (richnote.Text.Length >= 6)
                    note.Tittle = s.Substring(0, 6);
                else note.Tittle = this.richnote.Text;
                note.Body = this.richnote.Text;
                note.SDate = DateTime.Now;

                //lưu cấu hình note
                configureNote.NodeID = Program.GeneralName + temp;
                configureNote.FontNote = richnote.Font.Name;
                configureNote.SizeNote = Convert.ToInt32(richnote.Font.Size);
                configureNote.Boldtxt = Convert.ToInt32(richnote.Font.Bold);
                configureNote.Italictxt = Convert.ToInt32(richnote.Font.Italic);
                configureNote.Underlinwtxt = Convert.ToInt32(richnote.Font.Underline);
                configureNote.Striketxt = Convert.ToInt32(richnote.Font.Strikeout);
                configureNote.Colortxt = richnote.ForeColor.ToArgb();

                if (NoteControl.SaveNote(note, configureNote) == false)
                {
                    MessageBox.Show("fault!!!");
                }
            }
            else
            {
                String s = Convert.ToString(this.dataGridViewNote.SelectedRows[0].Cells[1].Value);
                note = NoteControl.getNote(Program.GeneralID, s);
                //cập nhật lại nội dung
                note.Body = richnote.Text;
                if (richnote.Text.Length >= 6)
                    note.Tittle = this.richnote.Text.Substring(0, 6);
                else note.Tittle = this.richnote.Text;
                note.SDate = DateTime.Now;
                //cập nhật cấu hình note
                configureNote = NoteControl.GetConfigureNote(s);
                configureNote.FontNote = this.richnote.Font.Name;
                configureNote.SizeNote = Convert.ToInt32(this.richnote.Font.Size);
                configureNote.Boldtxt = Convert.ToInt32(this.richnote.Font.Bold);
                configureNote.Italictxt = Convert.ToInt32(this.richnote.Font.Italic);
                configureNote.Underlinwtxt = Convert.ToInt32(this.richnote.Font.Underline);
                configureNote.Striketxt = Convert.ToInt32(this.richnote.Font.Strikeout);
                configureNote.Colortxt = this.richnote.ForeColor.ToArgb();
                
                if (NoteControl.UpdateNote(note, configureNote) == false)
                    MessageBox.Show("fault!!!");
            }
            //load laị datagridview
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListNote(Program.GeneralID);
            this.dataGridViewNote.DataSource = source.DataSource;
            if(Program.GeneralID!=0)
                this.picUser.Image = Properties.Resources.exit__3_1;
        }

        
        //tạo note mới
        private void picNewnote_Click(object sender, EventArgs e)
        {
            this.richnote.Clear();
            this.dataGridViewNote.CurrentCell = null;
            this.richnote.Font = new Font("Arial", 16, FontStyle.Regular);
            this.richnote.ForeColor = Color.White;
            this.richnote.Focus();
        }

        public int CountCharacter(String text)
        {
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != 32 || text[i] != '\n' || text[i] != '\t')
                    count++;
            }
            return count;
        }
        public int CountWord(String text)
        { 
            int count = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ' && text[i - 1] != ' ')
                    count++;
            }
            return count;
        }
        //xem info của note
        private void picInfo_Click(object sender, EventArgs e)
        {
            if (this.pnInformation.Visible == true)
            {
                this.pnInformation.Visible = false;
            }
            else
            {
                this.pnInformation.Visible = true;
                this.lbInfo.Visible = true;
                this.txtModified.Visible = true;
                this.lbdate.Visible = true;
                this.txtWord.Visible = true;
                this.txtCha.Visible = true;
            }
            String countCha = Convert.ToString(this.CountCharacter(this.richnote.Text));
            this.txtCha.Text = countCha + " characters";
            String countWord = Convert.ToString(this.CountWord(this.richnote.Text));
            this.txtWord.Text = countWord + " words";
            if (this.dataGridViewNote.CurrentCell == null)
                lbdate.Text = "NULL";
            else
            {
                if (Program.Tags == true)
                {
                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[1].Value.ToString();
                    this.lbdate.Text = NoteControl.getNote(Program.GeneralID, newid).SDate.ToString();
                }
                else
                {
                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[7].Value.ToString();
                    this.lbdate.Text = NoteControl.getTrash(Program.GeneralID, newid).SDate.ToString();

                }
            }

        }
        //đóng phần xem info note
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.pnInformation.Visible = false;
            this.lbInfo.Visible = false;
            this.lbdate.Visible = false;
            this.txtCha.Visible = false;
            this.txtModified.Visible = false;
            this.txtWord.Visible = false;
        }
        //chọn trạng thái note hoặc trash
        private void picAdd_Click(object sender, EventArgs e)
        {
            if (this.panel4.Visible == true)
                this.panel4.Visible = false;
            else 
            { 
                this.panel4.Visible = true;
                if (Program.GeneralID != 0)
                { 
                    paAccount.Visible = true;
                    this.txtfullname.Text = NoteControl.getLogin(Program.GeneralID).FullName;
                    this.txtusername.Text = NoteControl.getLogin(Program.GeneralID).Username;
                }
                
            }
        }
        //trạng thái notes
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.richnote.Clear();
            this.panel4.Visible = false;
            Program.Tags = true;
            if (this.darkTheme.Checked == true)
            {
                picDelete.Image = Properties.Resources.delete__4_;
                button1.BackColor = Color.DarkSlateGray;
                pictureBox2.BackColor = Color.DarkSlateGray;
                button1.ForeColor = Color.PaleTurquoise;

                button2.BackColor = Color.FromArgb(34, 36, 49);
                pictureBox4.BackColor = Color.FromArgb(34, 36, 49);
                button2.ForeColor = Color.White; 
            }
            else
            {
                picDelete.Image = Properties.Resources.delete_Cam;
                button1.BackColor = Color.DarkGoldenrod;
                pictureBox2.BackColor = Color.DarkGoldenrod;
                button1.ForeColor = Color.AliceBlue;

                button2.BackColor = Color.FromArgb(227, 227, 227);
                pictureBox4.BackColor = Color.FromArgb(227, 227, 227);
                button2.ForeColor = Color.Black;
            }
            this.CNotes.DataPropertyName = nameof(Note.Tittle);
            this.CID.DataPropertyName = nameof(Note.NodeID);
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListNote(Program.GeneralID);
            this.dataGridViewNote.DataSource = source.DataSource;
            for (int i = 1; i <= 7; i++)
            {
                if(i!=3)
                    dataGridViewNote.Columns[i].Visible = false;
            }
            dataGridViewNote.Columns[3].Width = 345;
            dataGridViewNote.Columns[3].ReadOnly = true;
            this.laCountNote.Text = dataGridViewNote.Rows.Count.ToString() + " Notes";
        }
        //trạng thái trash
        private void button2_Click(object sender, EventArgs e)
        {
            
            this.richnote.Clear();
            panel4.Visible = false;
            Program.Tags = false;
            if (this.darkTheme.Checked == true)
            {
                picDelete.Image = Properties.Resources.history__2_;
                button2.BackColor = Color.DarkSlateGray;
                pictureBox4.BackColor = Color.DarkSlateGray;
                button2.ForeColor = Color.PaleTurquoise;

                button1.BackColor = Color.FromArgb(34, 36, 49);
                pictureBox2.BackColor = Color.FromArgb(34, 36, 49);
                button1.ForeColor = Color.White;
            }
            else
            {
                picDelete.Image = Properties.Resources.history_Cam;
                button2.BackColor = Color.DarkGoldenrod;
                pictureBox4.BackColor = Color.DarkGoldenrod;
                button2.ForeColor = Color.AliceBlue;

                button1.BackColor = Color.FromArgb(227, 227, 227);
                pictureBox2.BackColor = Color.FromArgb(227, 227, 227);
                button1.ForeColor = Color.Black;
            }
            this.CNotes.DataPropertyName = nameof(Trash.Title);
            this.CID.DataPropertyName = nameof(Trash.NodeID);
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListTrash(Program.GeneralID);
            this.dataGridViewNote.DataSource = source.DataSource;
            for (int i = 1; i <= 9; i++)
            {
                if (i != 4)
                    dataGridViewNote.Columns[i].Visible = false;
            }
            dataGridViewNote.Columns[4].Width = 345;
            dataGridViewNote.Columns[4].ReadOnly = true;
            //this.laCountNote.Text = dataGridViewNote.Rows.Count.ToString() + " Notes";
        }
        //chọn từng note hoặc trash
        private void dataGridViewNote_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dataGridViewNote.CurrentCell.Value != null)
            {
                if (Program.Tags == true)
                {

                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[1].Value.ToString();
                    ConfigureNote configure = NoteControl.GetConfigureNote(newid);
                    string sfont = configure.FontNote;
                    int ssize = Convert.ToInt32(configure.SizeNote);
                    this.richnote.Font = new Font(sfont, ssize);
                    this.richnote.ForeColor = Color.FromArgb(Convert.ToInt32(configure.Colortxt));
                    if (configure.Boldtxt==1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Bold);
                    if(configure.Italictxt==1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Italic);
                    if(configure.Underlinwtxt==1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Underline);
                    if(configure.Striketxt==1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Strikeout);
                    this.richnote.Text = NoteControl.getNote(Program.GeneralID, newid).Body;
                }
                else
                {
                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[7].Value.ToString();
                    ConfigureTrash configure = NoteControl.GetConfigureTrash(newid);
                    string sfont = configure.FontTrash;
                    int ssize = Convert.ToInt32(configure.SizeTrash);
                    this.richnote.Font = new Font(sfont, ssize);
                    this.richnote.ForeColor = Color.FromArgb(Convert.ToInt32(configure.Colortxt));
                    if (configure.Boldtxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Bold);
                    if (configure.Italictxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Italic);
                    if (configure.Underlinetxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Underline);
                    if (configure.Striketxt == 1)
                        this.richnote.Font = new Font(this.richnote.Font, this.richnote.Font.Style ^ FontStyle.Strikeout);
                    this.richnote.Text = NoteControl.getTrash(Program.GeneralID, newid).Body;
                }
            }
            if (pnInformation.Visible == true)
                pnInformation.Visible = false;
        }
        //Xóa note
        private void picDelete_Click(object sender, EventArgs e)
        {
            if (Program.Tags == true)
            {
                String newid = this.dataGridViewNote.SelectedRows[0].Cells[1].Value.ToString();
                Note note = NoteControl.getNote(Program.GeneralID, newid);
                ConfigureNote configure = NoteControl.GetConfigureNote(newid);
                if (NoteControl.DeleteNote(note, configure) == false)
                {
                    MessageBox.Show("fault");
                }
                else
                {
                    if (NoteControl.SaveDeleteNote(note, configure) == false)
                    {
                        MessageBox.Show("lưu lỗi");
                    }
                }
                this.richnote.Clear();
                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListNote(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;   
            }
            else
            {
                String newid = this.dataGridViewNote.SelectedRows[0].Cells[7].Value.ToString();
                Trash trash = NoteControl.getTrash(Program.GeneralID, newid);
                ConfigureTrash configure = NoteControl.GetConfigureTrash(newid);
                if(NoteControl.DeleteTrash(trash,configure)==false)
                    MessageBox.Show("fault");
                else
                {
                    if (NoteControl.SaveDeleteTrash(trash,configure)==false)
                    {
                        MessageBox.Show("lưu lỗi");
                    }
                }
                this.richnote.Clear();
                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListTrash(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;
            }
            if (Program.GeneralID != 0)
                this.picUser.Image = Properties.Resources.exit__3_1;

        }

        //Tìm kiếm
        private void txtFind_TextChanged(object sender, EventArgs e)
        {
            
            this.dataGridViewNote.CurrentCell = null;
            if (Program.Tags == true)
            {
                BindingSource source = new BindingSource();
                this.CNotes.DataPropertyName = nameof(Note.Tittle);
                this.CID.DataPropertyName = nameof(Note.NodeID);
                List<Note> searchNote = NoteControl.getListNote(Program.GeneralID).Where(x => x.Tittle.Contains(txtFind.Text.Trim())).ToList();
                if (searchNote.Count > 0)
                {
                    source.DataSource = searchNote;
                    this.dataGridViewNote.DataSource = source.DataSource;
                    for (int i = 1; i <= 7; i++)
                    {
                        if (i != 3)
                            dataGridViewNote.Columns[i].Visible = false;
                    }
                    dataGridViewNote.Columns[3].Width = 345;
                    dataGridViewNote.Columns[3].ReadOnly = true;
                }
                else
                {
                    source.DataSource = null;
                    this.dataGridViewNote.DataSource = source.DataSource;
                }
                if (txtFind.Text.Trim().Length <= 0)
                {
                    source.DataSource = NoteControl.getListNote(Program.GeneralID);
                    this.dataGridViewNote.DataSource = source.DataSource;
                    for (int i = 1; i <= 7; i++)
                    {
                        if (i != 3)
                            dataGridViewNote.Columns[i].Visible = false;
                    }
                    dataGridViewNote.Columns[3].Width = 345;
                    dataGridViewNote.Columns[3].ReadOnly = true;
                }
            }
            else
            {
                BindingSource source = new BindingSource();
                this.CNotes.DataPropertyName = nameof(Note.Tittle);
                this.CID.DataPropertyName = nameof(Note.NodeID);
                List<Trash> trashes = NoteControl.getListTrash(Program.GeneralID).Where(x => x.Title.Contains(txtFind.Text.Trim())).ToList();
                if (trashes.Count > 0)
                {
                    source.DataSource = trashes;
                    this.dataGridViewNote.DataSource = source.DataSource;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (i != 4)
                            dataGridViewNote.Columns[i].Visible = false;
                    }
                    dataGridViewNote.Columns[4].Width = 345;
                    dataGridViewNote.Columns[4].ReadOnly = true;
                }
                else
                {
                    source.DataSource = null;
                    this.dataGridViewNote.DataSource = source.DataSource;
                }
                if (txtFind.Text.Trim().Length <= 0)
                {
                    source.DataSource = NoteControl.getListTrash(Program.GeneralID);
                    this.dataGridViewNote.DataSource = source.DataSource;
                    for (int i = 1; i <= 9; i++)
                    {
                        if (i != 4)
                            dataGridViewNote.Columns[i].Visible = false;
                    }
                    dataGridViewNote.Columns[4].Width = 345;
                    dataGridViewNote.Columns[4].ReadOnly = true;
                }
            }
        }

        //Chọn font nhanh
        private void cbfont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbfont.SelectedIndex == 0)
            {
                richnote.Font = new Font("Arial", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 1)
            {
                richnote.Font = new Font("Calibri", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 2)
            {
                richnote.Font = new Font("Microsoft Sans Serif", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 3)
            {
                richnote.Font = new Font("Microsoft YaHei UI", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 4)
            {
                richnote.Font = new Font("MS Gothic", richnote.Font.Size, richnote.SelectionFont.Style);

            }
            else if (cbfont.SelectedIndex == 5)
            {
                richnote.Font = new Font("MV Boli", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 6)
            {
                richnote.Font = new Font("Segoe Script", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 7)
            {
                richnote.Font = new Font("Sitka Small", richnote.Font.Size, richnote.SelectionFont.Style);
            }
            else if (cbfont.SelectedIndex == 8)
            {
                richnote.Font = new Font("Tahoma", richnote.Font.Size, richnote.SelectionFont.Style);
            }
        }

        //chọn size chữ nhanh
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSize.SelectedIndex == 0)
            {
                richnote.Font = new Font(richnote.Font.Name, 13, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 1)
            {
                richnote.Font = new Font(richnote.Font.Name, 14, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 2)
            {
                richnote.Font = new Font(richnote.Font.Name, 15, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 3)
            {
                richnote.Font = new Font(richnote.Font.Name, 16, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 4)
            {
                richnote.Font = new Font(richnote.Font.Name, 17, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 5)
            {
                richnote.Font = new Font(richnote.Font.Name, 18, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 6)
            {
                richnote.Font = new Font(richnote.Font.Name, 19, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 7)
            {
                richnote.Font = new Font(richnote.Font.Name, 20, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 8)
            {
                richnote.Font = new Font(richnote.Font.Name, 21, richnote.SelectionFont.Style);
            }
            else if (cbSize.SelectedIndex == 9)
            {
                richnote.Font = new Font(richnote.Font.Name, 22, richnote.SelectionFont.Style);
            }
        }
        
        //double click to open toolbar
        private void richnote_DoubleClick_1(object sender, EventArgs e)
        {
            Point cp = this.PointToClient(Cursor.Position);
            this.paTool.Location = new Point(cp.X - 310, cp.Y - 62);
            if (this.paTool.Visible == true)
                this.paTool.Visible = false;
            else
            {
                this.paTool.Visible = true;
                this.cbfont.Text = this.richnote.SelectionFont.Name;
                this.cbSize.Text = this.richnote.SelectionFont.Size.ToString();
            }

        }
        
        //chọn font
        private void picAddtool_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            
            if(f.ShowDialog()==DialogResult.OK)
            {
                this.richnote.Font = f.Font;
                this.cbfont.Text = f.Font.Name;
                this.cbSize.Text = f.Font.Size.ToString();
            }
        }

        //tìm kiếm note
        private void txtFind_Click(object sender, EventArgs e)
        {
            txtFind.Clear();
            this.dataGridViewNote.CurrentCell = null;
            this.richnote.Clear();
        }

        //chọn màu
        private void picColor_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                this.richnote.ForeColor = dialog.Color;
        }

        //private void picAddPic_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog ofd = new OpenFileDialog();
        //    ofd.Title = "Please select image";
        //    ofd.Filter = "JPG|*.jpg|JPEG|*.jpeg|GIF|*.gif|PNG|*.png";
        //    DialogResult dr = ofd.ShowDialog();
        //    if (dr == DialogResult.OK)
        //    {
        //        string files = ofd.FileName;
        //        PictureBox box = new PictureBox();
        //        box.Image = Image.FromFile(files);
        //        box.SizeMode = PictureBoxSizeMode.StretchImage;
        //        box.Location = new Point(10, 10);
        //        this.richnote.Controls.Add(box);
        //    }

        //}
        
        //mở rộng note
        private void picEx_Click(object sender, EventArgs e)
        {
            this.panel9.Visible = true;
            this.richnoteEx.Text = this.richnote.Text;
            this.richnoteEx.Font = this.richnote.Font;
            this.richnoteEx.ForeColor = this.richnote.ForeColor;
            this.richnoteEx.Focus();
        }
        private void picEx2_Click(object sender, EventArgs e)
        {
            this.panel9.Visible = false;

        }
        //xem info note trong trạng thái mở rộng
        private void picExInfor_Click(object sender, EventArgs e)
        {
            this.pnInformation.BringToFront();
            if (this.pnInformation.Visible == true)
            {
                this.pnInformation.Visible = false;
                this.lbInfo.Visible = false;
                this.lbdate.Visible = false;
                this.txtCha.Visible = false;
                this.txtModified.Visible = false;
                this.txtWord.Visible = false;
            }
            else
            {
                this.pnInformation.Visible = true;
                this.lbdate.Text = DateTime.Now.ToString();
                this.pnInformation.Visible = true;
                this.lbInfo.Visible = true;
                this.lbdate.Visible = true;
                this.txtCha.Visible = true;
                this.txtModified.Visible = true;
                this.txtWord.Visible = true;
            }
            String countCha = Convert.ToString(this.CountCharacter(this.richnoteEx.Text));
            this.txtCha.Text = countCha + " characters";
            String countWord = Convert.ToString(this.CountWord(this.richnoteEx.Text));
            this.txtWord.Text = countWord + " words";
            if (this.dataGridViewNote.CurrentCell == null)
                lbdate.Text = "NULL";
            else
            {
                if (Program.Tags == true)
                {
                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[1].Value.ToString();
                    this.lbdate.Text = NoteControl.getNote(Program.GeneralID, newid).SDate.ToString();
                }
                else
                {
                    String newid = this.dataGridViewNote.SelectedRows[0].Cells[7].Value.ToString();
                    this.lbdate.Text = NoteControl.getTrash(Program.GeneralID, newid).SDate.ToString();

                }
            }
        }
        //save note trong lúc mở rộng note
        private void picExSave_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            ConfigureNote configureNote = new ConfigureNote();
            if (this.dataGridViewNote.CurrentCell is null)
            {
                //lưu nội dung note
                String temp = Convert.ToString(NoteControl.getListNote(Program.GeneralID).Count + 1);
                note.NodeID = Program.GeneralName + temp;
                note.UserID = Program.GeneralID;
                String s = this.richnoteEx.Text;
                if (richnoteEx.Text.Length >= 6)
                    note.Tittle = s.Substring(0, 6);
                else note.Tittle = this.richnoteEx.Text;
                note.Body = this.richnoteEx.Text;
                note.SDate = DateTime.Now;

                //lưu cấu hình note
                configureNote.NodeID = Program.GeneralName + temp;
                configureNote.FontNote = richnote.Font.Name;
                configureNote.SizeNote = Convert.ToInt32(richnoteEx.Font.Size);
                configureNote.Boldtxt = Convert.ToInt32(richnoteEx.Font.Bold);
                configureNote.Italictxt = Convert.ToInt32(richnoteEx.Font.Italic);
                configureNote.Underlinwtxt = Convert.ToInt32(richnoteEx.Font.Underline);
                configureNote.Striketxt = Convert.ToInt32(richnoteEx.Font.Strikeout);
                configureNote.Colortxt = richnoteEx.ForeColor.ToArgb();

                if (NoteControl.SaveNote(note, configureNote) == false)
                {
                    MessageBox.Show("fault!!!");
                }
            }
            else
            {
                String s = Convert.ToString(this.dataGridViewNote.SelectedRows[0].Cells[1].Value);
                note = NoteControl.getNote(Program.GeneralID, s);
                //cập nhật lại nội dung
                note.Body = richnoteEx.Text;
                if (richnoteEx.Text.Length >= 6)
                    note.Tittle = this.richnoteEx.Text.Substring(0, 6);
                else note.Tittle = this.richnoteEx.Text;
                note.SDate = DateTime.Now;
                //cập nhật cấu hình note
                configureNote = NoteControl.GetConfigureNote(s);
                configureNote.FontNote = this.richnoteEx.Font.Name;
                configureNote.SizeNote = Convert.ToInt32(this.richnoteEx.Font.Size);
                configureNote.Boldtxt = Convert.ToInt32(this.richnoteEx.Font.Bold);
                configureNote.Italictxt = Convert.ToInt32(this.richnoteEx.Font.Italic);
                configureNote.Underlinwtxt = Convert.ToInt32(this.richnoteEx.Font.Underline);
                configureNote.Striketxt = Convert.ToInt32(this.richnoteEx.Font.Strikeout);
                configureNote.Colortxt = this.richnoteEx.ForeColor.ToArgb();

                if (NoteControl.UpdateNote(note, configureNote) == false)
                    MessageBox.Show("fault!!!");
            }
            //load laị datagridview
            BindingSource source = new BindingSource();
            source.DataSource = NoteControl.getListNote(Program.GeneralID);
            this.dataGridViewNote.DataSource = source.DataSource;
            if (Program.GeneralID != 0)
                this.picExUser.Image = Properties.Resources.exit__3_1;
        }

        //picExDelete
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (Program.Tags == true)
            {
                String newid = this.dataGridViewNote.SelectedRows[0].Cells[1].Value.ToString();
                Note note = NoteControl.getNote(Program.GeneralID, newid);
                ConfigureNote configure = NoteControl.GetConfigureNote(newid);
                if (NoteControl.DeleteNote(note, configure) == false)
                {
                    MessageBox.Show("fault");
                }
                else
                {
                    if (NoteControl.SaveDeleteNote(note, configure) == false)
                    {
                        MessageBox.Show("lưu lỗi");
                    }
                }
                this.richnoteEx.Clear();
                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListNote(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;
            }
            else
            {
                String newid = this.dataGridViewNote.SelectedRows[0].Cells[7].Value.ToString();
                Trash trash = NoteControl.getTrash(Program.GeneralID, newid);
                ConfigureTrash configure = NoteControl.GetConfigureTrash(newid);
                if (NoteControl.DeleteTrash(trash, configure) == false)
                    MessageBox.Show("fault");
                else
                {
                    if (NoteControl.SaveDeleteTrash(trash, configure) == false)
                    {
                        MessageBox.Show("lưu lỗi");
                    }
                }
                this.richnoteEx.Clear();
                BindingSource source = new BindingSource();
                source.DataSource = NoteControl.getListTrash(Program.GeneralID);
                this.dataGridViewNote.DataSource = source.DataSource;
            }
            if (Program.GeneralID != 0)
                this.picExUser.Image = Properties.Resources.exit__3_1;
            panel9.Visible = false;
            this.richnote.Clear();
        }
        //pic exlogin
        private void picExUser_Click(object sender, EventArgs e)
        {
            if (Program.GeneralID != 0)
            {
                this.Visible = false;
            }
            else
            {
                fmlogin newlogin = new fmlogin();
                //this.Visible = false;
                newlogin.Show();
            }
        }
        //---------thanh toolstrip------------
                //nút file
            //New note
        private void newNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richnote.Clear();
            this.dataGridViewNote.CurrentCell = null;
            this.richnote.Font = new Font("Arial", 16, FontStyle.Regular);
            this.richnote.ForeColor = Color.White;
            this.richnote.Focus();
        }
        //Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

                //---nút edit
        //search
        private void searchCtrlFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtFind.Clear();
            txtFind.Focus();
        }
            //select all
        private void selectAllCtrlAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richnote.Focus();
            this.richnote.SelectionStart = 0;
            this.richnote.SelectionLength = this.richnote.Text.Length;
        }
            //copy
        private void copyCtrlCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richnote.Copy();
        }
            //cut
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richnote.Cut();
        }
            //paste
        private void pasteCtrlVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.richnote.Paste();
        }

                 //---nút View
        //Sort Date Create
        private void dateCreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Tags == true)
            {
                List<Note> notes = NoteControl.getListNote(Program.GeneralID);
                for (int i = 0; i < notes.Count; i++)
                {
                    for (int j = i + 1; j < notes.Count; j++)
                    {
                        int result = DateTime.Compare(notes[i].SDate.Value, notes[j].SDate.Value);
                        if (result > 0)
                        {
                            Note temp = notes[i];
                            notes[i] = notes[j];
                            notes[j] = temp;
                        }
                    }
                }
                BindingSource source = new BindingSource();
                source.DataSource = notes;
                this.dataGridViewNote.DataSource = source.DataSource;
            }
            else
            {
                List<Trash> trashes = NoteControl.getListTrash(Program.GeneralID);
                for (int i = 0; i < trashes.Count; i++)
                {
                    for (int j = i + 1; j < trashes.Count; j++)
                    {
                        int result = DateTime.Compare(trashes[i].SDate.Value, trashes[j].SDate.Value);
                        if (result > 0)
                        {
                            Trash temp = trashes[i];
                            trashes[i] = trashes[j];
                            trashes[j] = temp;
                        }
                    }
                }
                BindingSource source = new BindingSource();
                source.DataSource = trashes;
                this.dataGridViewNote.DataSource = source.DataSource;
            }
        }
        //Sort Alphabetical
        private void alphabeticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Tags == true)
            {
                List<Note> notes = NoteControl.getListNote(Program.GeneralID);
                for (int i = 0; i < notes.Count; i++)
                {
                    for (int j = i + 1; j < notes.Count; j++)
                    {
                        string s1 = notes[i].Tittle.ToUpper();
                        string s2 = notes[j].Tittle.ToUpper();
                        if (s1[0] > s2[0])
                        {
                            Note temp = notes[i];
                            notes[i] = notes[j];
                            notes[j] = temp;
                        }
                    }
                }
                BindingSource source = new BindingSource();
                source.DataSource = notes;
                this.dataGridViewNote.DataSource = source.DataSource;
            }
            else
            {
                List<Trash> trashes = NoteControl.getListTrash(Program.GeneralID);
                for (int i = 0; i < trashes.Count; i++)
                {
                    for (int j = i + 1; j < trashes.Count; j++)
                    {
                        string s1 = trashes[i].Title.ToUpper();
                        string s2 = trashes[j].Title.ToUpper();
                        if (s1[0] > s2[0])
                        {
                            Trash temp = trashes[i];
                            trashes[i] = trashes[j];
                            trashes[j] = temp;
                        }
                    }
                }
                BindingSource source = new BindingSource();
                source.DataSource = trashes;
                this.dataGridViewNote.DataSource = source.DataSource;
            }
        }
        //Reverse
        private void reverseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.Tags == true)
            {
                BindingSource source = new BindingSource();
                source.DataSource = this.dataGridViewNote.DataSource;
                List<Note> notes = (List<Note>)source.DataSource;
                notes.Reverse();
                source.DataSource = notes;
                this.dataGridViewNote.DataSource = null;
                this.dataGridViewNote.DataSource = source.DataSource;
                for (int i = 1; i <= 7; i++)
                {
                    if (i != 3)
                        dataGridViewNote.Columns[i].Visible = false;
                }
                dataGridViewNote.Columns[3].Width = 345;
                dataGridViewNote.Columns[3].ReadOnly = true;
            }
            else
            {
                BindingSource source = new BindingSource();
                source.DataSource = this.dataGridViewNote.DataSource;
                List<Trash> trashes = (List<Trash>)source.DataSource;
                trashes.Reverse();
                source.DataSource = trashes;
                this.dataGridViewNote.DataSource = null;
                this.dataGridViewNote.DataSource = source.DataSource;
                for (int i = 1; i <= 9; i++)
                {
                    if (i != 4)
                        dataGridViewNote.Columns[i].Visible = false;
                }
                dataGridViewNote.Columns[4].Width = 345;
                dataGridViewNote.Columns[4].ReadOnly = true;
            }
        }
        //Zoom in
        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (this.richnote.Font.Size <= 36)
            {
                int sizefont = Convert.ToInt32(this.richnote.Font.Size);
                sizefont++;
                richnote.Font = new Font(richnote.Font.Name, sizefont, richnote.SelectionFont.Style);
            }
        }
        //Zoom out
        private void zoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.richnote.Font.Size >= 13)
            {
                int sizefont = Convert.ToInt32(this.richnote.Font.Size);
                sizefont--;
                richnote.Font = new Font(richnote.Font.Name, sizefont, richnote.SelectionFont.Style);
            }
        }
        //Actual size
        private void actualSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richnote.Font = new Font(richnote.Font.Name, 16, richnote.SelectionFont.Style);
        }
        //Focus mode
        private void focusModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.panel9.Visible == true)
                this.panel9.Visible = false;
            else this.panel9.Visible = true;
        }

                //--nút Help
        //Help & support
        private void helpSupportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            instruction.Show();
        }
        //About Easynote
        private void aboutEasynoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FmInstruction fmInstruction = new FmInstruction();
            fmInstruction.Show();
            fmInstruction.picVersion.Visible = true;
        }


        //-----phần bỏ-------
        private void richnote_DoubleClick(object sender, EventArgs e)
        {

        }
        private void pnInformation_Paint(object sender, PaintEventArgs e)
        {

        }
        private void lbdate_Click(object sender, EventArgs e)
        {

        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void cbSize_SelectedValueChanged(object sender, EventArgs e)
        {

        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
        private void richnote_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtWord_TextChanged(object sender, EventArgs e)
        {

        }
        private void dataGridViewNote_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void richnote_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void fmNote_Activated(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        //nút quản lí tài khoản
        private void button3_Click(object sender, EventArgs e)
        {
            fmEditAccount.Show();
        }

        private void fmNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lightTheme_Click(object sender, EventArgs e)
        {
            this.darkTheme.Checked = false;
            this.lightTheme.Checked = true;

            this.tableLayoutPanel1.BackColor = Color.FromArgb(227, 227, 227);
            this.panel1.BackColor = Color.FromArgb(200, 200, 200);
            this.panel2.BackColor = Color.FromArgb(227, 227, 227);
            this.richnote.BackColor = Color.FromArgb(227, 227, 227);
            this.panel7.BackColor = Color.FromArgb(227, 227, 227);
            this.panel3.BackColor = Color.FromArgb(200, 200, 200);
            this.dataGridViewNote.BackgroundColor = Color.FromArgb(227, 227, 227);
            this.picNewnote.Image = Properties.Resources.add11;
            this.pictureBox3.Image = Properties.Resources.search;
            this.picEx.Image = Properties.Resources.expand__11_1;
            this.picAdd.Image = Properties.Resources.moreCam;
            this.picSave.Image = Properties.Resources.essayCam;
            if(Program.Tags==true)
                this.picDelete.Image = Properties.Resources.delete_Cam;
            else this.picDelete.Image = Properties.Resources.history_Cam;
            this.picInfo.Image = Properties.Resources.infoCam;
            this.picUser.Image = Properties.Resources.loginCam;

            //panel add
            this.panel4.BackColor = Color.FromArgb(160, 160, 160);
            this.button1.BackColor= Color.FromArgb(227, 227, 227);
            this.button1.ForeColor = Color.Black;
            this.button2.BackColor= Color.FromArgb(227, 227, 227);
            this.button2.ForeColor = Color.Black;
            this.txtfullname.ForeColor = Color.Black;
            this.txtusername.ForeColor = Color.Black;
            this.button3.ForeColor = Color.Black;
            this.panel6.BackColor = Color.Black;
            this.pictureBox2.Image = Properties.Resources.essayCam;
            this.pictureBox2.BackColor=Color.FromArgb(227, 227, 227);
            this.pictureBox4.Image = Properties.Resources.delete_Cam;
            this.pictureBox4.BackColor = Color.FromArgb(227, 227, 227);

            //panel infor
            pnInformation.BackColor = Color.FromArgb(160, 160, 160);
            this.lbInfo.ForeColor = Color.White;
            this.txtModified.ForeColor = Color.Black;
            this.lbdate.ForeColor = Color.White;
            this.txtWord.BackColor= Color.FromArgb(160, 160, 160);
            this.txtWord.ForeColor = Color.Black;
            this.txtCha.BackColor = Color.FromArgb(160, 160, 160);
            this.txtCha.ForeColor = Color.Black;
            this.paKe.BackColor = Color.Black;
            this.pictureBox1.Image = Properties.Resources.next_Cam;

            this.dataGridViewNote.RowsDefaultCellStyle.BackColor = Color.Orange;
            this.dataGridViewNote.RowsDefaultCellStyle.SelectionBackColor = Color.Goldenrod;
            this.laCountNote.ForeColor = Color.Black;
            this.txtFind.ForeColor = Color.Black;
            this.txtFind.BackColor = Color.FromArgb(200, 200, 200);

            //phần expand
            this.panel9.BackColor = Color.FromArgb(227, 227, 227);
            this.panel10.BackColor= Color.FromArgb(227, 227, 227);
            this.panel11.BackColor = Color.FromArgb(227, 227, 227);
            this.picEx2.Image = Properties.Resources.expand__11_1;
            if(Program.Tags==true)
                this.picExDelete.Image = Properties.Resources.delete_Cam;
            else this.picExDelete.Image = Properties.Resources.history_Cam;
            this.picExSave.Image = Properties.Resources.essayCam;
            this.picExInfor.Image = Properties.Resources.infoCam;
            this.picExUser.Image = Properties.Resources.loginCam;
            this.richnoteEx.BackColor= Color.FromArgb(227, 227, 227);
        }

        private void darkTheme_Click(object sender, EventArgs e)
        {
            this.lightTheme.Checked = false;
            this.darkTheme.Checked = true;

            this.tableLayoutPanel1.BackColor = Color.FromArgb(34, 36, 49);
            this.panel1.BackColor = Color.FromArgb(27, 29, 39);
            this.panel2.BackColor = Color.FromArgb(34, 36, 49);
            this.richnote.BackColor = Color.FromArgb(34, 36, 49);
            this.panel7.BackColor = Color.FromArgb(34, 36, 49);
            this.panel3.BackColor = Color.FromArgb(27, 29, 39);
            this.dataGridViewNote.BackgroundColor = Color.FromArgb(34, 36, 49);
            this.picNewnote.Image = Properties.Resources.add1;
            this.pictureBox3.Image = Properties.Resources.search1;
            this.picEx.Image = Properties.Resources.expand__1_11;
            this.picAdd.Image = Properties.Resources.more2;
            this.picSave.Image = Properties.Resources.essay11;
            if (Program.Tags == true)
                this.picDelete.Image = Properties.Resources.delete__4_;
            else this.picDelete.Image = Properties.Resources.history__2_;
            this.picInfo.Image = Properties.Resources.info2;
            this.picUser.Image = Properties.Resources.login__5_;

            //panel add
            this.panel4.BackColor = Color.FromArgb(34, 36, 49);
            this.button1.BackColor = Color.FromArgb(34, 36, 49);
            this.button1.ForeColor = Color.White;
            this.button2.BackColor = Color.FromArgb(34, 36, 49);
            this.button2.ForeColor = Color.White;
            this.txtfullname.ForeColor = Color.White;
            this.txtusername.ForeColor = Color.FromArgb(171, 171, 171);
            this.button3.ForeColor = Color.White;
            this.panel6.BackColor = Color.White;
            this.pictureBox2.Image = Properties.Resources.essay11;
            this.pictureBox2.BackColor = Color.FromArgb(34, 36, 49);
            this.pictureBox4.Image = Properties.Resources.delete__4_;
            this.pictureBox4.BackColor = Color.FromArgb(34, 36, 49);

            //panel infor
            pnInformation.BackColor = Color.FromArgb(34, 36, 49);
            this.lbInfo.ForeColor = Color.FromArgb(105,105,105);
            this.txtModified.ForeColor = Color.White;
            this.lbdate.ForeColor = Color.FromArgb(105, 105, 105);
            this.txtWord.BackColor = Color.FromArgb(34, 36, 49);
            this.txtWord.ForeColor = Color.White;
            this.txtCha.BackColor = Color.FromArgb(34, 36, 49);
            this.txtCha.ForeColor = Color.White;
            this.paKe.BackColor = Color.White;
            this.pictureBox1.Image = Properties.Resources.next__2_;

            this.dataGridViewNote.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            this.dataGridViewNote.RowsDefaultCellStyle.SelectionBackColor = Color.SlateGray;
            this.laCountNote.ForeColor = Color.White;
            this.txtFind.ForeColor = Color.White;
            this.txtFind.BackColor = Color.FromArgb(34, 36, 49);

            //phần expand
            this.panel9.BackColor = Color.FromArgb(34, 36, 49);
            this.panel10.BackColor = Color.FromArgb(34, 36, 49);
            this.panel11.BackColor = Color.FromArgb(34, 36, 49);
            this.picEx2.Image = Properties.Resources.expand__11_1;
            if (Program.Tags == true)
                this.picExDelete.Image = Properties.Resources.delete__4_;
            else this.picExDelete.Image = Properties.Resources.history__2_;
            this.picExSave.Image = Properties.Resources.essay11;
            this.picExInfor.Image = Properties.Resources.info2;
            this.picExUser.Image = Properties.Resources.login__5_;
            this.richnoteEx.BackColor = Color.FromArgb(34, 36, 49);

            ////////////this.darkTheme.Checked = true;
        }
    }
}
