using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan
{
    class Player
    {
        public Graphics g;
        public Bitmap PlayerBitmap;
        public Bitmap PlayerBullet;
        public Bitmap PlayerBullet1;
        public Bitmap PlayerBullet2;
        public Bitmap PlayerBullet3;
        public Form1 form;
        public Board board;
        //public PictureBox PacmanImage = new PictureBox();
        private ImageList PlayerImages = new ImageList();
        public Timer timer = new Timer();
        public int pX;
        public int pY;
		public int checkX;
		public int checkY;
        public int currentDirection = 1;
        private int imageOn = 0;
        
        public Player(){
            
        }
        public Player(int x, int y, ImageList imglist, Board board, Form1 form){
            this.form = form;
            this.board = board;
            pX = x * 24;
            pY = y * 24;
			checkX = x;
			checkY = y;
            for(int i = 0; i < imglist.Images.Count; i++)
                PlayerImages.Images.Add(imglist.Images[i]);

            PlayerBitmap = new Bitmap(PlayerImages.Images[1], new Size(35, 35));
            PlayerBullet = new Bitmap(PlayerImages.Images[8], new Size(10, 10));
            PlayerBullet1 = new Bitmap(PlayerImages.Images[9], new Size(10, 10));
            PlayerBullet2 = new Bitmap(PlayerImages.Images[10], new Size(10, 10));
            PlayerBullet3 = new Bitmap(PlayerImages.Images[11], new Size(10, 10));
            g = form.panel1.CreateGraphics();
            g.DrawImage(PlayerBitmap, new Point(pX, pY));
            g.Dispose();

            timer.Interval = 200;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            PlayerBitmap.Dispose();
            UpdatePacmanImage();
        }
        public void UpdatePacmanImage()
        {
            if (currentDirection != 0) {
                PlayerBitmap = new Bitmap(PlayerImages.Images[((currentDirection - 1) * 2) + imageOn], new Size(35, 35));
                imageOn++;
                if (imageOn > 1) { imageOn = 0; }
            }
        }

        public void StartGame()
        {
            timer.Enabled = true;
        }

        public void StopGame()
        {
            timer.Enabled = false;
        }

        public void ResetGame()
        {
            imageOn = 0;

            currentDirection = 1;
            pX = board.StartX * 24;
            pY = board.StartY * 24;
            checkX = board.StartX;
            checkY = board.StartY;

            PlayerBitmap = new Bitmap(PlayerImages.Images[1], new Size(35, 35));
            g = form.panel1.CreateGraphics();
            g.DrawImage(PlayerBitmap, new Point(pX, pY));
            g.Dispose();

            timer.Interval = 200;
            timer.Enabled = false;
            timer.Tick += new EventHandler(timer_Tick);
        }
    }
}
