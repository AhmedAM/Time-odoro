using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace StickyNotes
{

    public partial class Form1 : Form
    {
        //Mouse Drag Move start
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //Mouse Drag Move Stop


        
        int TaskCounter  =2;
        //int ButtonIndex = 3;
        int TextBoxlocation = 52;
        //int ButtonLocation = 70;
        




        public Form1()
        {
            InitializeComponent();
            //timer1.Start();
            //this.TopMost = true;
        }



        private void bt_add_Click(object sender, EventArgs e)
        {
            TextBox txt = new TextBox();
            txt.Name = "TextBox" + TaskCounter;
            
            
            txt.Size = new System.Drawing.Size(159,40);
            txt.Multiline = true;
            txt.Location = new Point(1, TextBoxlocation);
            txt.Leave += new EventHandler(txt_Leave);
            txt.DoubleClick += new EventHandler(txt_DoubleClick);
            txt.TabIndex = TaskCounter;
            txt.BackColor = System.Drawing.Color.LightSkyBlue;
            //txt.BorderStyle = BorderStyle.None;
            txt.ForeColor = Color.White;
            txt.Font = new Font ("Georgia",10);
            

            Button bt = new Button();
            bt.Name = "Button" + TaskCounter;
            bt.TabIndex = TaskCounter;
            bt.Size = new System.Drawing.Size(35, 38);
            bt.Location = new Point(161, TextBoxlocation);
            bt.BackColor = System.Drawing.Color.LightSkyBlue;
            bt.FlatStyle = FlatStyle.Flat;
            bt.ForeColor = System.Drawing.Color.White;
            bt.Font = new Font("Wingdings", 15);
            bt.Click += new EventHandler(bt_Click);
            bt.Text = "þ";  // check box 

            this.Controls.Add(txt);
            this.Controls.Add(bt);
            
            
            TaskCounter++;
            TextBoxlocation += 38;
           

            //this.Controls.Remove(textBox1);
        }

        void bt_Click(object sender, EventArgs e)
        {
            int n = ((System.Windows.Forms.Control)(sender)).TabIndex;
            var Txt = new Control[1]; 
            Txt = this.Controls.Find("TextBox" + n, true);
            Txt[0].Font = new Font(Txt[0].Font, FontStyle.Strikeout);
            Txt[0].Text += Environment.NewLine+"Nailed It!";
            


            //this.Controls.Remove(Txt[0]);
        }

        void txt_DoubleClick(object sender, EventArgs e)
        {

            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.ReadOnly) 
                txt.ReadOnly=false;
                
            }
           
            
//            throw new NotImplementedException();
        }


        void txt_Leave(object sender, EventArgs e)
        {//use this function to update when it is left    Use tab index as ID 
           // MessageBox.Show("banana");
            //((System.Windows.Forms.Control)(sender)).Enabled = false ;


            foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (!(txt.Text == "") || !(txt.Text == " "))
                    txt.ReadOnly = true;

            }
            
            
            //throw new NotImplementedException();
        }

        private void bt_edit_Click(object sender, EventArgs e)
        {
              foreach (TextBox txt in this.Controls.OfType<TextBox>())
            {
                if (txt.ReadOnly == true&& !(txt.Text.Contains("Nailed"))) 
                txt.ReadOnly= false;
                  
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            bt_add.Focus();
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_save_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;
        }

        



        
    }
}
