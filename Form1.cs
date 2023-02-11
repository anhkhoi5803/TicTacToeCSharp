﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacT
{
    public partial class Form1 : Form
    {
        int turn = 0;
        string player = "X";
        Button[] buttons = new Button[9];
        int[] grids = new int[9];
        int pointX = 0;
        int pointO = 0;
        public Form1()
        {
            InitializeComponent();

            buttons[0] = btn0;
            buttons[1] = btn1;
            buttons[2] = btn2;
            buttons[3] = btn3;
            buttons[4] = btn4;
            buttons[5] = btn5;
            buttons[6] = btn6;
            buttons[7] = btn7;
            buttons[8] = btn8;


            for (int i = 0; i < 9; i++)
            {
                buttons[i].Click += ButtonClick;
                buttons[i].Tag = i;
            }
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            btnResetScore.Enabled = false;
            Button bt = (Button)sender;

            bt.Enabled = false;

            turn++;

            int gridPlayed = (int)bt.Tag;

            bt.Text = player;
            grids[gridPlayed] = player.Equals("X") ? 1 : 2;




            if (CheckWinCon())
            {

                MessageBox.Show("player "+player + " won the game");
                if (player.Equals("X"))
                {
                    pointX += 10;
                    label2.Text = pointX.ToString();
                }
                else
                {
                    pointO += 10;
                    label4.Text = pointO.ToString();
                }

                ResetGame();
                return;
            }

            if (turn == 9)
            {
                MessageBox.Show("The game is a tie");
                ResetGame();

                return;
            }


            player = player.Equals("X") ? "O" : "X";
        }


        private bool CheckWinCon()
        {
            if (CheckRow() || CheckCol() || CheckDiag())
                return true;

            return false;
        }

        private bool CheckRow()
        {
            for (int i = 0; i < 9; i += 3)
            {
                if (grids[i] == 0) continue;

                if (grids[i] == grids[i + 1] && grids[i] == grids[i + 2]) return true;
            }
            return false;
        }

        private bool CheckCol()
        {
            for (int i = 0; i < 3; i++)
            {
                if (grids[i] == 0) continue;

                if (grids[i] == grids[i + 3] && grids[i] == grids[i + 6]) return true;
            }
            return false;
        }

        private bool CheckDiag()
        {
            if (grids[4] == 0) return false;
            if (grids[0] == grids[4] && grids[4] == grids[8]) return true;
            if (grids[2] == grids[4] && grids[4] == grids[6]) return true;

            return false;
        }

        void ResetGame()
        {
            turn = 0;
            player = "X";
            for (int i = 0; i < 9; i++)
            {
                buttons[i].Enabled = true;
                buttons[i].Text = "";

                grids[i] = 0;
            }
            btnResetScore.Enabled = true;
        }

        // Create ai opponent
        int evaluate()
        {
            if(CheckRow()==true) { }

            return 0;
        }
        bool isMovesLeft(int[] grid)
        {
            for(int i = 0; i< grid.Length; i++)
            {
                if (grid[i] == 0) return true;
            }
            return false;
        }

        int miniMax(int[] grid,int depth, bool isMax) 
        {
            bool isWon = CheckWinCon();
            int best = int.MinValue;

            if (isWon) return 10;
            

            return 1;
        }

        private void btnResetScore_Click(object sender, EventArgs e)
        {
            label2.Text= string.Empty;
            label4.Text = string.Empty;
            MessageBox.Show("Score is reseted");

        }
    }
}
