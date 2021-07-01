﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace YoketoruVS21
{
    public partial class Form1 : Form
    {
        const bool isDebug = true;
        enum State
        {
            None = -1,  // 無効
            Title,      // タイトル
            Game,       // ゲーム
            Gameover,   // ゲームオーバー
            Clear       // クリア
        }
        State currentState = State.None;
        State nextState = State.Title;

        [DllImport("user32.dll")]

        public static extern short GetAsyncKeyState(int vKey);
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(isDebug)
            {
                nextState = State.Gameover;
            }
            else if(GetAsyncKeyState((int)Keys.C)<0)
            {
                nextState = State.Clear;
            }
         if (nextState!=State.None)
            {
                initProc();
            }
        }
        void initProc()
        {
            currentState = nextState;
            nextState = State.None;

            switch (currentState)
            {
                case State.Title:
                    titleLabel.Visible = true;
                    startButton.Visible = true;
                    copyrightLabel.Visible = true;
                    hiLabel.Visible = true;
                    gameOverLabel.Visible = true;
                    titleButton.Visible = true;
                    clearLabel.Visible = true;
                    break;

                case State.Game:
                    titleLabel.Visible = true;
                    startButton.Visible = true;
                    copyrightLabel.Visible = true;
                    hiLabel.Visible = true;
 
                    break;
                case State.Gameover:
                    //MessageBox.Show("gameOverLabel");
                    break;
                case State.Clear:
                    //MessageBox.Show("Clear");
                    clearLabel.Visible = true;
                    titleButton.Visible = true;
                    break;

            }

        }

        private void titleButton_Click(object sender, EventArgs e)
        {
            nextState = State.Title;
        }
    }
}
