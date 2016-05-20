using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            question1.Location = new Point(this.Width + 300, 300);
            brick4.Location = new Point(this.Width + 500, 350);
            marioSlide.Hide();
            fireBall.Hide();
        }
        Random randNum = new Random();
        bool gifnotloaded;
        bool jump, doubleJump, sliding;
        int force;
        int G = 25;
        bool onBrick;
        bool start;
        bool fire;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape) { this.Close(); }

            if (e.KeyCode == Keys.Enter)
            {
                start = true;
                lose = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                sliding = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                fire = true;
            }
            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    force = G;
                    player.Image = Properties.Resources.mexicanJump;
                }
            }
            else if (doubleJump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    doubleJump = true;
                    force = G;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                sliding = false;
                gifnotloaded = true;
                player.Show();
                marioSlide.Hide();
            }
            if (e.KeyCode == Keys.Space)
            {
                gifnotloaded = true;
            }
            if (e.KeyCode == Keys.Enter)
            {
                gifnotloaded = true;
            }
        }
        int xValue;
        int chanceValue;
        int score;
        int[] locations = { 430, 370, 305, 245, 185, 100 };
        int speed = 10;

      
        bool lose;
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (fire == true)
            {
                fireBall.Show();
                fireBall.Left += speed * 2;
                if (fireBall.Left > this.Width)
                {
                    fireBall.Left = player.Left;
                    fireBall.Hide();
                    fire = false;
                }

            }
            else
            {
                fireBall.Top = player.Top;
            }
            if (lose == true)
            {
                speed = 0;
            }
            else
            {
                speed = 10;
            }
            xValue = randNum.Next(this.Width, 1500);
            chanceValue = randNum.Next(1, 3);
            if (start == true)
            {
                brick.Left -= speed;
                brick2.Left -= speed;
                brick3.Left -= speed;
                question.Left -= speed;
                brick4.Left -= speed;
                question1.Left -= speed;
                cactus1.Left -= speed;
                cactus2.Left -= speed;


                cloud.Left -= speed;
                cloud1.Left -= speed;
                cloud2.Left -= speed;
                ground.Left -= speed;

                if (ground.Left <= -2025)
                {
                    ground.Left = -5;
                }

                if (score < 2)
                {
                    if (brick2.Right <= 0)
                    {
                        score += 1; ;
                        brick2.Location = new Point(xValue, locations[2]);
                    }
                    if (brick.Right <= 0)
                    {
                        brick.Location = new Point(xValue, locations[1]);
                    }
                    if (brick3.Right <= 0)
                    {
                        brick3.Location = new Point(xValue, locations[3]);
                    }
                    if (question.Right <= 0)
                    {
                        question.Location = new Point(xValue, locations[4]);
                    }
                    if (question1.Right <= 0)
                    {
                        question1.Location = new Point(xValue, locations[5]);
                    }
                    if (brick4.Right <= 0)
                    {
                        brick4.Location = new Point(xValue, locations[0]);
                    }
                    if (brick4.Right < this.Width && cactus1.Right <= 0 && cactus2.Right <= 0)
                    {
                        if (chanceValue == 1)
                        {
                            cactus1.Location = new Point(xValue, 416);
                        }
                        if (chanceValue == 2)
                        {
                            cactus2.Location = new Point(xValue, 428);
                        }
                    }
                }
                if (score >= 2 && score < 4)
                {
                    if (brick2.Right <= 0)
                    {
                        score += 1; ;
                        brick2.Location = new Point(xValue + 47, locations[0]);
                    }
                    if (brick.Right <= 0)
                    {
                        brick.Location = new Point(xValue + 28, locations[1]);
                    }
                    if (brick3.Right <= 0)
                    {
                        brick3.Location = new Point(xValue + 17, locations[2]);
                    }
                    if (question.Right <= 0)
                    {
                        question.Location = new Point(xValue, locations[5]);
                    }
                    if (question1.Right <= 0)
                    {
                        question1.Location = new Point(xValue, locations[4]);
                    }
                    if (brick4.Right <= 0)
                    {
                        brick4.Location = new Point(xValue + 89, locations[3]);
                    }
                    if (brick2.Right < this.Width && cactus1.Right <= 0 && cactus2.Right <= 0)
                    {
                        if (chanceValue == 1)
                        {
                            cactus1.Location = new Point(xValue, 416);
                        }
                        if (chanceValue == 2)
                        {
                            cactus2.Location = new Point(xValue, 428);
                        }
                    }
                }
                if (score >= 4 && score <= 6)
                {
                    if (brick2.Right <= 0)
                    {
                        score += 1; ;
                        brick2.Location = new Point(xValue + 17, locations[2]);
                    }
                    if (brick.Right <= 0)
                    {
                        brick.Location = new Point(xValue + 80, locations[3]);
                    }
                    if (brick3.Right <= 0)
                    {
                        brick3.Location = new Point(xValue + 50, locations[0]);
                    }
                    if (question.Right <= 0)
                    {
                        question.Location = new Point(xValue, locations[4]);
                    }
                    if (question1.Right <= 0)
                    {
                        question1.Location = new Point(xValue, locations[5]);
                    }
                    if (brick4.Right <= 0)
                    {
                        brick4.Location = new Point(xValue + 20, locations[1]);
                    }
                    if (brick3.Right < this.Width && cactus1.Right <= 0 && cactus2.Right <= 0)
                    {
                        if (chanceValue == 1)
                        {
                            cactus1.Location = new Point(xValue, 416);
                        }
                        if (chanceValue == 2)
                        {
                            cactus2.Location = new Point(xValue, 428);
                        }
                    }
                    if (score == 6)
                    {
                        score = 0;
                    }
                }
                if (jump == true)
                {
                    player.Top -= force;
                    force -= 2;
                }
                else
                {
                    if (gifnotloaded == true)
                    {
                        player.Image = Properties.Resources.mexicanRight;
                        gifnotloaded = false;
                    }
                }
                //object borders
                if (player.Top < brick.Top && player.Top + player.Height >= brick.Top && player.Left + player.Width / 3 * 2 >= brick.Left && player.Left + player.Width / 3 * 2 < brick.Left + brick.Width)
                {
                    player.Top = brick.Top - player.Height;
                    force = 0;
                    doubleJump = false;
                    jump = false;
                    onBrick = true;
                }
                else { onBrick = false; }
                //hitting bottom
                if (player.Left + player.Width / 3 * 2 >= brick.Left && player.Left + player.Width / 3 * 2 < brick.Left + brick.Width && player.Top - brick.Bottom <= 8 && player.Top - brick.Top > -8)
                {
                    force = -6;
                }

                if (player.Top < brick2.Top && player.Top + player.Height >= brick2.Top && player.Left + player.Width / 3 * 2 >= brick2.Left && player.Left + player.Width / 3 * 2 < brick2.Left + brick2.Width)
                {
                    player.Top = brick2.Top - player.Height;
                    force = 0;
                    jump = false;
                    doubleJump = false;
                    onBrick = true;
                }
                if (player.Bottom >= brick3.Top + 10 && player.Top + 10 < brick3.Bottom && player.Right > brick3.Left && player.Left < brick3.Right)
                {
                    player.Top = brick3.Top - player.Height + 10;
                    force = 0;
                    doubleJump = false;
                    jump = false;
                    onBrick = true;
                }
                if (player.Top - 10 <= brick3.Bottom && player.Bottom > brick3.Top + 10 && player.Right >= brick3.Left && player.Left <= brick3.Right)
                {
                    force = -6;
                }
                if (player.Bottom >= brick3.Top + 10 && player.Top + 40 < brick3.Bottom && player.Right >= brick3.Left && player.Left < brick3.Right - 86 && sliding == false)
                {
                    lose = true;
                }

                if (player.Bottom >= brick4.Top + 10 && player.Top + 10 < brick4.Bottom && player.Right > brick4.Left && player.Left < brick4.Right)
                {
                    lose = true;
                }
                if (player.Top - 10 <= brick4.Bottom && player.Bottom > brick4.Top + 10 && player.Right >= brick4.Left && player.Left <= brick4.Right)
                {
                    force = -6;
                }
                //touching spikes
                if (player.Right >= brick2.Left && player.Left < brick2.Left + 5 && player.Top < brick2.Bottom && player.Bottom > brick2.Top)
                {
                    lose = true;
                }
                if (player.Right >= brick.Left && player.Left < brick.Left + 5 && player.Top < brick.Bottom && player.Bottom > brick.Top)
                {
                    lose = true;
                }
                if (player.Left + player.Width / 3 * 2 >= brick2.Left && player.Left + player.Width / 3 * 2 < brick2.Left + brick2.Width && player.Top - brick2.Bottom <= 8 && player.Top - brick2.Top > -8)
                {
                    force = -6;
                }

                //question borders
                if (player.Bottom < question.Bottom && player.Bottom >= question.Top && player.Right >= question.Left && player.Left < question.Right)
                {
                    player.Top = question.Top - player.Height;
                    force = 0;
                    jump = false;
                    onBrick = true;
                }
                if (player.Top <= question.Bottom && player.Bottom > question.Top && player.Right >= question.Left && player.Left < question.Right)
                {
                    force = -6;
                }
                if (player.Top >= ground.Top - player.Height)
                {
                    player.Top = ground.Top - player.Height;
                    force = 0;
                    if (sliding == true)
                    {
                        marioSlide.Show();
                        player.Hide();
                        jump = true;
                        doubleJump = true;
                    }
                    else
                    {
                        jump = false;
                        doubleJump = false;
                    }
                }
                //falling off brick no jump
                else if (onBrick == false && jump == false)
                {
                    jump = true;
                    player.Top += 12;
                    player.Image = Properties.Resources.mexicanJump;
                    gifnotloaded = true;
                }
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources.fireBall, 52, 402, 70, 38);
        }

    }
}
