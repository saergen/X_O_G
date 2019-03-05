using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace X_O_G
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Regal_Caracal","XOG_About");
        }

        private void leaveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
                b.Text = "X";
            else
                b.Text = "O";
            turn = !turn;
            b.Enabled = false;
            turn_count++;

            checkForWinner();
        }

        private void checkForWinner()
        {
            foreach (Control c in Controls)
            {
                bool winner = false;

                if ((A1.Text == A2.Text) && (A2.Text == A3.Text)&&(!A1.Enabled))
                    winner = true;
                else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
                    winner = true;
                else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
                    winner = true;
                else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
                    winner = true;
                else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
                    winner = true;
                else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
                    winner = true;
                else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
                    winner = true;
                else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
                    winner = true;               


                if (winner)
                {
                    disableButtons();
                    String the_winner = "";
                    if (turn)
                        the_winner = "O";
                    else
                        the_winner = "X";
                    MessageBox.Show(the_winner + "'s Victory!", "Game Result:");
                }

                else
                {
                    if(turn_count==9)
                        MessageBox.Show("Nobody's Victory!");
                }

            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;

                }
            }
            catch { }



        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
