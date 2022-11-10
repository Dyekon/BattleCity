using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan {
    class EnemyTank {
        private const int GhostAmount = 1;

        public int Ghosts = GhostAmount;
        Graphics g;
        private Form1 form;
        private Board board;
        public Bitmap TankBitmap;
        private ImageList TankImages = new ImageList();
        private Timer spawnTimer = new Timer();
        private int spawnTimerCount;
        public int spawnBitmapSize;
        private bool upDown;
        public bool isSpawn;
        private Timer triggerTimer = new Timer();
        private Timer killTimer = new Timer();
        private Random rand;
        public int enemySpeed;
        public int X;
        public int Y;
        public int checkX;
        public int checkY;
        public int Direction;
        public int imageOn;
        private int BlockMoveStack;
        private float changeDirectionTimer;
        private bool CheckOk;
        private bool bulletShootOk;
        private float bulletCount;
        private ArrayList blinkyMoveRouteX = new ArrayList();
        private ArrayList blinkyMoveRouteY = new ArrayList();
        private Random ran = new Random();

        public EnemyTank(int x, int y, ImageList imglist, Board board, Form1 form) {
            this.form = form;
            this.board = board;
            for (int i = 0; i < imglist.Images.Count; i++)
                TankImages.Images.Add(imglist.Images[i]);

            spawnTimerCount = 0;
            isSpawn = false;
            upDown = false;
            spawnBitmapSize = 35;

            rand = new Random();
            BlockMoveStack = 0;
            changeDirectionTimer = 0;

            Direction = 2;
            enemySpeed = 3;
            bulletShootOk = false;
            bulletCount = 0;
            imageOn = 0;

            X = x;
            Y = y;
            checkX = x / 24;
            checkY = y / 24;

            TankBitmap = new Bitmap(TankImages.Images[8], new Size(35, 35));
            g = form.panel1.CreateGraphics();
            g.DrawImage(TankBitmap, new Point(X , Y));
            g.Dispose();

            CheckOk = false;

            /*if (Direction == 2 || Direction == 4) {
                X += DirectionX;
                checkX = X / 24;
            }
            if (Direction == 1 || Direction == 3) {
                Y += DirectionY;
                checkY = Y / 24;
            }*/

            spawnTimer.Interval = 110;
            spawnTimer.Enabled = false;
            spawnTimer.Tick += new EventHandler(spawnTimer_Tick);

                /*triggerTimer.Interval = 25;
                triggerTimer.Enabled = true;
                triggerTimer.Tick += new EventHandler(triggerTimer_Tick);*/

            }

        public void ChangeDirection() {
            int prevDir = Direction;
            Direction = rand.Next(1, 5);
            if (prevDir == Direction)
                Direction = rand.Next(1, 5);
            BlockMoveStack = 0;
            changeDirectionTimer = 0;
        }

        public void ShootBullet() {
            form.bulletDirection.Add(Direction);
            form.bulletPositionX.Add(X);
            form.bulletPositionY.Add(Y);
            bulletShootOk = false;
        }

        public void MoveEnemyTank() {
            if (isSpawn) {
                if (check_direction(Direction)) {
                    switch (Direction) {
                        case 1: Y += -enemySpeed; break;
                        case 2: X += enemySpeed; break;
                        case 3: Y += enemySpeed; break;
                        case 4: X += -enemySpeed; break;
                    }
                }

                if (bulletShootOk) {
                    ShootBullet();
                    bulletShootOk = false;
                }
                checkX = X / 24;
                checkY = Y / 24;
                changeDirectionTimer++;
                if (BlockMoveStack >= 15 || changeDirectionTimer >= rand.Next(50, 80))
                    ChangeDirection();

                //총알 발사 쿨타임
                if (!bulletShootOk) {
                    bulletCount += 0.1f;
                    if (bulletCount >= 3) {
                        bulletShootOk = true;
                        bulletCount = 0;
                    }
                }
                UpdateEnemyTankImage();
            } else {
                spawnTimerCount++;
                if (spawnTimerCount >= 70) {
                    isSpawn = true;
                }
                if (upDown)
                    spawnBitmapSize += 3;
                else
                    spawnBitmapSize -= 3;
                if (spawnBitmapSize < 5)
                    upDown = true;
                else if (spawnBitmapSize > 35)
                    upDown = false;
                TankBitmap = new Bitmap(TankImages.Images[8], new Size(spawnBitmapSize, spawnBitmapSize));
            }
        }

        private bool check_direction(int direction) {
            int enemyPos;
            CheckOk = false;
            if (direction == 2 || direction == 4) {
                for (int i = Y - 17; i < Y + 17; i++) {
                    enemyPos = i / 24;
                    if (direction == 2)
                        CheckOk = direction_ok(checkX + 1, enemyPos);
                    else
                        CheckOk = direction_ok(checkX - 1, enemyPos);
                    if (!CheckOk) {
                        BlockMoveStack++;
                        return false;
                    }
                }
            } else if (direction == 1 || direction == 3) {
                for (int i = X - 17; i < X + 17; i++) {
                    enemyPos = i / 24;
                    if (direction == 1)
                        CheckOk = direction_ok(enemyPos, checkY - 1);
                    else
                        CheckOk = direction_ok(enemyPos, checkY + 1);
                    if (!CheckOk) {
                        BlockMoveStack++;
                        return false;
                    }
                }
            }
            return true;
        }

        private bool direction_ok(int x, int y) {
            if (board.Map[y, x] == 1) { return true; } else { return false; }
        }

        private void UpdateEnemyTankImage() {
                if (Direction != 0) {
                TankBitmap = new Bitmap(TankImages.Images[(Direction - 1) * 2 + imageOn], new Size(35, 35));
                imageOn++;
                    if (imageOn > 1) { imageOn = 0; }
                }
        }

        private void spawnTimer_Tick(object sender, EventArgs e) {

        }

        public void StopGame() {
            killTimer.Enabled = false;
            triggerTimer.Enabled = false;
        }

    }
}
