using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Tic_Tac_Toe
{  
    
    //SoundPlayer sO = new SoundPlayer();
    
    public partial class Form1 : Form
    { 
        int XorO = 0;
        bool S = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SoundPlayer s = new SoundPlayer(@Tic_Tac_Toe.Properties.Resources.Open);
            s.Play();
            S = true;
            XorO = 0;
            win = false;
            label1.Text = "Play Now";
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.BackColor = Color.White;
                }
            }
            // add action to all buttons inside panel2
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Click += new System.EventHandler(btn_click);
                }
            }
        }        
        // create button 
        public void btn_click(object sender, EventArgs e)
        {
            if (win!=true)
            {
                SoundPlayer sR = new SoundPlayer(@Tic_Tac_Toe.Properties.Resources.רוני_פוני);
                sR.Play();
            }
            Button btn = (Button)sender;
            if (win==false&&btn.Text == "")
            {
                if (XorO % 2 == 0)
                {
                    btn.Text = "X";
                    btn.ForeColor = Color.Blue;
                    label1.Text = "O turn now";
                    getTheWinner();
                }
                else
                {
                    btn.Text = "O";
                    btn.ForeColor = Color.Red;
                    label1.Text = "X turn now";
                    getTheWinner();
                }
                XorO++;
            }
        }
        bool win = false;
        // get the winner 
        public void getTheWinner()
        {
            if (!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text))
            {
                winEffect(button1, button2, button3);
                win = true;
            }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text))
            {
                winEffect(button4, button5, button6);
                win = true;
            }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text))
            {
                winEffect(button7, button8, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text))
            {
                winEffect(button1, button4, button7);
                win = true;
            }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text))
            {
                winEffect(button2, button5, button8);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text))
            {
                winEffect(button3, button6, button9);
                win = true;
            }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text))
            {
                winEffect(button1, button5, button9);
                win = true;
            }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text))
            {
                winEffect(button3, button5, button7);
                win = true;
            }

            // if no one win
            // if all buttons are not empty 
            // we can but 1 char in a button "X or O"
            // we have 9 buttons 
            // mean 9 char in length
            if (AllBtnLength() == 9 && win == false)
            {
                SoundPlayer sH = new SoundPlayer(Tic_Tac_Toe.Properties.Resources.תיקו);
                sH.Play();
                label1.Text = "No Winner";
            }

        }
        // get all button text length    
        public int AllBtnLength()
        {
            int allTextButtonsLength = 0;
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    allTextButtonsLength += c.Text.Length;
                }
            }
            return allTextButtonsLength;
        }              
        public void winEffect(Button b1, Button b2, Button b3)
        {
            if (b1.Text=="O")
            {
                SoundPlayer sX = new SoundPlayer(Tic_Tac_Toe.Properties.Resources.X);
                sX.Play();
            }
            else
            {
                SoundPlayer sO = new SoundPlayer(Tic_Tac_Toe.Properties.Resources.O);
                sO.Play();
            }

            b1.BackColor = Color.FromArgb(130, 21, 34);
            b2.BackColor = Color.FromArgb(130, 21, 34);
            b3.BackColor = Color.FromArgb(130, 21, 34);

            b1.ForeColor = Color.White;
            b2.ForeColor = Color.White;
            b3.ForeColor = Color.White;

            label1.Text = b1.Text + " Win";
        }     
        //restart
        private void ButtonPartie_Click(object sender, EventArgs e)
        {
            XorO = 0;
            S = false;
            win = false;
            label1.Text = "Play Now";
            foreach (Control c in panel2.Controls)
            {
                if (c is Button)
                {
                    c.Text = "";
                    c.BackColor = Color.White;                     
                }
            }
            SoundPlayer s = new SoundPlayer(@Tic_Tac_Toe.Properties.Resources.Open);
            s.Play();
        }  
    }
}