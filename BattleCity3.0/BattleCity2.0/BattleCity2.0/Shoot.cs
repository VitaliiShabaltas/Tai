using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
namespace BattleCity2._0
{
    class Shoot
    {
        public string? direction;
        public int shootleft;
        public int shootTop;

        private int speed = 20;
        private PictureBox shoot = new PictureBox();
        private System.Windows.Forms.Timer shootTimer = new System.Windows.Forms.Timer();

        public void MakeShoot(Form form)
        {

            shoot.BackColor = Color.Gray;
            shoot.Size = new Size(5, 5);
            shoot.Tag = "shoot";
            shoot.Left = shootleft;
            shoot.Top = shootTop;
            shoot.BringToFront();

            form.Controls.Add(shoot);
            shootTimer.Interval = speed;
            shootTimer.Tick += new EventHandler(ShootTimerEvent);
            shootTimer.Start();

        }
        private void ShootTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                shoot.Left -= speed;

            }
            if (direction == "right")
            {
                shoot.Left += speed;

            }
            if (direction == "up")
            {
                shoot.Top -= speed;

            }
            if (direction == "down")
            {
                shoot.Top += speed;

            }
            if (shoot.Left < 50 || shoot.Left > 1200 || shoot.Top < 50 || shoot.Top > 860)
            {
                
                shootTimer.Stop();
                shootTimer.Dispose();
                shoot.Dispose();
                shootTimer = null;
                shoot = null;
            }
        }
    }
}
