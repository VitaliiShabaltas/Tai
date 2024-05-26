using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity2._0
{
    public partial class Form1 : Form
    {
        bool goLeft, goRight, goUp, goDown, gameOver;
        string facing = "up";
        int speed = 10;
        int enemyspeed = 50;
        int playerHealth = 1;
        int score;
        Random randNum = new Random();
        private System.Windows.Forms.Timer shootTimer = new System.Windows.Forms.Timer();
        List<PictureBox> Enemylist = new List<PictureBox>();
        List<PictureBox> Walllist = new List<PictureBox>();

        public Form1()
        {
            InitializeComponent();
            label1.BringToFront();
            label2.BringToFront();
            label1.Visible = false;
            label2.Visible = false;
            InitializeGame();
        }

        private void MainTimerEvent(object sender, EventArgs e)
        {
            if (Enemylist.Count == 0)
            {
                gameOver = true;
                label2.Visible = true;
                GameTimer.Stop();
                return;
            }
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                gameOver = true;
                label1.Visible = true;
                
                Player.Image = Properties.Resources.dead;
                GameTimer.Stop();
                return;
            }
            txtScore.Text = "Kills: " + score;

            if (!(goUp && goRight) && !(goUp && goLeft) && !(goDown && goRight) && !(goDown && goLeft))
            {
                if (goLeft && Player.Left > 0)
                {
                    Player.Left -= speed;
                    if (CheckWallCollision())
                    {
                        Player.Left += speed;
                    }
                }
                if (goRight && Player.Left + Player.Width < this.ClientSize.Width)
                {
                    Player.Left += speed;
                    if (CheckWallCollision())
                    {
                        Player.Left -= speed;
                    }
                }
                if (goUp && Player.Top >100)
                {
                    Player.Top -= speed;
                    if (CheckWallCollision())
                    {
                        Player.Top += speed;
                    }
                }
                if (goDown && Player.Top + Player.Height < this.ClientSize.Height)
                {
                    Player.Top += speed;
                    if (CheckWallCollision())
                    {
                        Player.Top -= speed;
                    }
                }

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag?.ToString() == "enemy")
                    {
                        if (Player.Bounds.IntersectsWith(x.Bounds))
                        {
                            playerHealth -= 100;
                        }
                        PictureBox enemy = (PictureBox)x;
                        int randomDirection = randNum.Next(-50, 60);

                        int oldLeft = enemy.Left;
                        int oldTop = enemy.Top;

                        bool collision = false;

                        switch (randomDirection)
                        {
                            case -50:
                                if (enemy.Left - enemyspeed >= 100 && !CheckEnemyWallCollision(enemy.Left - enemyspeed, enemy.Top, enemy.Width, enemy.Height))
                                {
                                    enemy.Left -= enemyspeed;
                                    enemy.Image = Properties.Resources.eleft;
                                }
                                break;
                            case -25:
                                if (enemy.Left + enemyspeed + enemy.Width <= this.ClientSize.Width && !CheckEnemyWallCollision(enemy.Left + enemyspeed, enemy.Top, enemy.Width, enemy.Height))
                                {
                                    enemy.Left += enemyspeed;
                                    enemy.Image = Properties.Resources.eright;
                                }
                                break;
                            case 25:
                                if (enemy.Top - enemyspeed >= 60 && !CheckEnemyWallCollision(enemy.Left, enemy.Top - enemyspeed, enemy.Width, enemy.Height))
                                {
                                    enemy.Top -= enemyspeed;
                                    enemy.Image = Properties.Resources.eup;
                                }
                                break;
                            case 50:
                                if (enemy.Top + enemyspeed + enemy.Height <= this.ClientSize.Height && !CheckEnemyWallCollision(enemy.Left, enemy.Top + enemyspeed, enemy.Width, enemy.Height))
                                {
                                    enemy.Top += enemyspeed;
                                    enemy.Image = Properties.Resources.edown;
                                }
                                break;
                        }

                        
                        foreach (PictureBox otherEnemy in Enemylist)
                        {
                            if (otherEnemy != enemy && enemy.Bounds.IntersectsWith(otherEnemy.Bounds))
                            {
                                collision = true;
                                break;
                            }
                        }

                        if (collision)
                        {
                            
                            enemy.Left = oldLeft;
                            enemy.Top = oldTop;
                        }
                    }
                }

                foreach (Control j in this.Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "shoot" && j is PictureBox)
                    {
                        PictureBox shoot = (PictureBox)j;

                        foreach (Control x in this.Controls)
                        {
                            if (x is PictureBox && x.Tag == "enemy" && x.Bounds.IntersectsWith(shoot.Bounds))
                            {
                                score++;
                                this.Controls.Remove(shoot);
                                shoot.Dispose();
                                this.Controls.Remove(x);
                                x.Dispose();
                                Enemylist.Remove((PictureBox)x);
                                break;
                            }

                            if (x is PictureBox && x.Tag == "wall1" && x.Bounds.IntersectsWith(shoot.Bounds))
                            {
                                this.Controls.Remove(shoot);
                                shoot.Dispose();
                                this.Controls.Remove(x);
                                x.Dispose();
                                Walllist.Remove((PictureBox)x);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private bool CheckEnemyWallCollision(int left, int top, int width, int height)
        {
            Rectangle enemyRect = new Rectangle(left, top, width, height);

            foreach (PictureBox wall in Walllist)
            {
                Rectangle wallRect = new Rectangle(wall.Left, wall.Top, wall.Width, wall.Height);

                if (enemyRect.IntersectsWith(wallRect))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckWallCollision()
        {
            foreach (PictureBox wall in Walllist)
            {
                if (Player.Bounds.IntersectsWith(wall.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver == true)
            {
                return;
            }
            if (e.KeyCode == Keys.Left)
            {
                if (goUp || goDown || goRight) return;
                goLeft = true;
                facing = "left";
                Player.Image = Properties.Resources.pleft;
            }
            if (e.KeyCode == Keys.Right)
            {
                if (goUp || goDown || goLeft) return;
                goRight = true;
                facing = "right";
                Player.Image = Properties.Resources.pright;
            }
            if (e.KeyCode == Keys.Up)
            {
                if (goLeft || goRight || goDown) return;
                goUp = true;
                facing = "up";
                Player.Image = Properties.Resources.pup;
            }
            if (e.KeyCode == Keys.Down)
            {
                if (goLeft || goRight || goUp) return;
                goDown = true;
                facing = "down";
                Player.Image = Properties.Resources.pdown;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.E && gameOver == false)
            {
                ShootPlayer(facing);
            }             
        }

        private void ShootPlayer(string direction)
        {
            Shoot shootSpere = new Shoot();
            shootSpere.direction = direction;
            shootSpere.shootleft = Player.Left + (Player.Width / 2);
            shootSpere.shootTop = Player.Top + (Player.Height / 2);
            shootSpere.MakeShoot(this);
        }

        private void Enemy(int left, int top)
        {
            PictureBox enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = Properties.Resources.edown;

            enemy.Left = left;
            enemy.Top = top;
            enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            Enemylist.Add(enemy);
            this.Controls.Add(enemy);
            Player.BringToFront();
        }

        private void Wall(int left, int top)
        {
            PictureBox wall1 = new PictureBox();
            wall1.Tag = "wall1";
            wall1.Image = Properties.Resources.wall1;
            wall1.Left = left;
            wall1.Top = top;
            wall1.SizeMode = PictureBoxSizeMode.AutoSize;
            Walllist.Add(wall1);
            this.Controls.Add(wall1);
            Player.BringToFront();
        }

        private void InitializeGame()
        {
            Enemy(500, 360); 
            Enemy(40, 700); 
            Enemy(600, 306);

            Wall(100, 100);
            Wall(150, 150);
            Wall(200, 200);
            Wall(250, 250);
            Wall(300, 300);
            Wall(350, 350);
            Wall(400, 400);
            Wall(450, 450);
            Wall(500, 500);
            Wall(550, 550);
            Wall(600, 600);
            Wall(650, 650);
            Wall(700, 700);
                      
            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;
            playerHealth = 100;
            score = 0;
            GameTimer.Start();
        }
    }
}