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
    public partial class Form1 : Form {
        Graphics g;
        public PictureBox blockImage = new PictureBox();
        private Board board = new Board();
        private Player player;
        private Bitmap FlagImage;
        private Bitmap EnemyLifeImage;
        private Bitmap boomImage;
        private Bitmap boomImage1;
        private Bitmap boomImage2;
        private Bitmap boomImage3;
        private Bitmap boomImage4;
        private List<EnemyTank> enemyTankArray;
        private bool isKeyDown;
        private bool isKeyUp;
        private bool CheckOk = false;
        private Keys keyCode;
        private bool isUp;
        private bool isDown;
        private bool isLeft;
        private bool isRight;
        private bool isSpace;
        private int playerSpeed = 3;
        private int playerDirectionX;
        private int playerDirectionY;
        private int nextDirection;
        public int score;
        private bool gameSet;
        public int EnemySpawnCount;
        public int EnemySpawnLimit;
        public int EnemyLifeCount;
        public int GameEndCount;
        int playerBulletDir;
        private int playerBoomEffectNum;
        private Point playerBoomEffectPos;
        private int FlagBoomEffectNum;
        private Point FlagBoomEffectPos;
        Point playerBulletPos;
        List<int> BoomEffectNum;
        List<Point> BoomEffectPos;
        List<int> enemyBoomEffectNum;
        List<Point> enemyBoomEffectPos;
        public List<int> bulletDirection;
        public List<int> bulletPositionX;
        public List<int> bulletPositionY;

        public bool IsReady;
        public int SizeCnt;
        public int WaitTimer;
        public int StageNum;

        private Random rand;

        private String labelText;
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            timer1.Enabled = false;
            timer2.Enabled = true;
            timer2.Interval = 20;
            pictureBox1.BringToFront();
            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox5.BringToFront();
            pictureBox2.Size = new Size(1265, 0);
            pictureBox3.Size = new Size(1265, 0);
            pictureBox4.Size = new Size(1265, 0);
            pictureBox5.Size = new Size(1265, 0);
            WaitTimer = 0;
            player = new Player(board.StartX, board.StartY, PlayerImagelist, board, this);
            boomImage = new Bitmap(BoomImage.Images[0], new Size(22, 22));
            boomImage.MakeTransparent(Color.Black);
            boomImage1 = new Bitmap(BoomImage.Images[1], new Size(28, 28));
            boomImage1.MakeTransparent(Color.Black);
            boomImage2 = new Bitmap(BoomImage.Images[2], new Size(33, 33));
            boomImage2.MakeTransparent(Color.Black);
            boomImage3 = new Bitmap(BoomImage.Images[3], new Size(90, 90));
            boomImage3.MakeTransparent(Color.Black);
            boomImage4 = new Bitmap(BoomImage.Images[4], new Size(100, 100));
            boomImage4.MakeTransparent(Color.Black);
            enemyTankArray = new List<EnemyTank>();

            isKeyDown = false;
            blockImage.Image = blockImageList.Images[0];
            bulletDirection = new List<int>();
            bulletPositionX = new List<int>();
            bulletPositionY = new List<int>();
            BoomEffectNum = new List<int>();
            BoomEffectPos = new List<Point>();
            enemyBoomEffectNum = new List<int>();
            enemyBoomEffectPos = new List<Point>();
            rand = new Random();
            score = 0;
            SizeCnt = 0;
            playerBoomEffectNum = 0;
            FlagBoomEffectNum = 0;
            gameSet = false;
            EnemySpawnCount = 0;
            EnemyLifeCount = 16;
            GameEndCount = 16;
            EnemySpawnLimit = 3;
            StageNum = 1;
            isUp = false;
            isSpace = false;
            IsReady = false;
            isKeyUp = false;

            FlagImage = new Bitmap(mapImage.Images[2], new Size(50, 50));
            EnemyLifeImage = new Bitmap(blockImageList.Images[3], new Size(24, 24));

            labelText = String.Format("Ctrl - 공격\n방향키 - 움직임");
            label2.Text = labelText;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {
            isKeyDown = true;
            if (keyCode != e.KeyCode)
                keyCode = e.KeyCode;
            if (e.KeyCode == Keys.Up) {
                isUp = true;
            }
            if (e.KeyCode == Keys.Down) {
                isDown = true;
            }
            if (e.KeyCode == Keys.Left) {
                isLeft = true;
            }
            if (e.KeyCode == Keys.Right) {
                isRight = true;
            }
            if (e.Modifiers == Keys.Control)
                isSpace = true;
            //  if (e.KeyCode == Keys.Space)
            //isSpace = true;

            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e) {
            isKeyUp = true;
            if (e.KeyCode == Keys.Up) {
                isUp = false;
            }
            if (e.KeyCode == Keys.Down) {
                isDown = false;
            }
            if (e.KeyCode == Keys.Left) {
                isLeft = false;
            }
            if (e.KeyCode == Keys.Right) {
                isRight = false;
            }
            if (e.Modifiers != Keys.Control)
                isSpace = false;
            // if (e.KeyCode == Keys.Space)
            //isSpace = false;
            //isKeyDown = false;
            //keyCode = Keys.;
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {
            g = e.Graphics;
            g.DrawImage(FlagImage, new Point(290, 577));

            //블록 그리기
           for (int i = 0; i < 30; i++)
             for (int j = 0; j < 28; j++)
                if (board.Map[j, i] == 2) {
                    g.DrawImage(blockImage.Image, ((i - 1) * 24), ((j - 1) * 24));
                } else if (board.Map[j, i] == 3) {
                    blockImage.Image = blockImageList.Images[1];
                    g.DrawImage(blockImage.Image, ((i - 1) * 24), ((j - 1) * 24));
                    blockImage.Image = blockImageList.Images[0];
                }


            //총알 그리기
            if (bulletDirection.Count != 0) {
                int cnt = bulletDirection.Count;
                for (int i = 0; i < cnt; i++) {
                    if (bulletDirection[i] == 1) {
                        g.DrawImage(player.PlayerBullet, new Point(bulletPositionX[i] - 28, bulletPositionY[i] - 28));
                    } else if (bulletDirection[i] == 2) {
                        g.DrawImage(player.PlayerBullet1, new Point(bulletPositionX[i] - 28, bulletPositionY[i] - 28));
                    } else if (bulletDirection[i] == 3) {
                        g.DrawImage(player.PlayerBullet2, new Point(bulletPositionX[i] - 28, bulletPositionY[i] - 28));
                    } else if (bulletDirection[i] == 4) {
                        g.DrawImage(player.PlayerBullet3, new Point(bulletPositionX[i] - 28, bulletPositionY[i] - 28));
                    }
                }
            }
            if (playerBulletDir != -1) {
                if (playerBulletDir == 1) {
                    g.DrawImage(player.PlayerBullet, new Point(playerBulletPos.X - 28, playerBulletPos.Y - 28));
                } else if (playerBulletDir == 2) {
                    g.DrawImage(player.PlayerBullet1, new Point(playerBulletPos.X - 28, playerBulletPos.Y - 28));
                } else if (playerBulletDir == 3) {
                    g.DrawImage(player.PlayerBullet2, new Point(playerBulletPos.X - 28, playerBulletPos.Y - 28));
                } else if (playerBulletDir == 4) {
                    g.DrawImage(player.PlayerBullet3, new Point(playerBulletPos.X - 28, playerBulletPos.Y - 28));
                }
            }
            //플레이어 그리기
            if (playerBoomEffectNum >= 1) {
                if (playerBoomEffectNum == 1 || playerBoomEffectNum == 2) {
                    g.DrawImage(boomImage, new Point(playerBoomEffectPos.X - 32, playerBoomEffectPos.Y - 32));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 3 || playerBoomEffectNum == 4) {
                    g.DrawImage(boomImage1, new Point(playerBoomEffectPos.X - 36, playerBoomEffectPos.Y - 36));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 5 || playerBoomEffectNum == 6) {
                    g.DrawImage(boomImage2, new Point(playerBoomEffectPos.X - 40, playerBoomEffectPos.Y - 40));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 7 || playerBoomEffectNum == 8) {
                    g.DrawImage(boomImage3, new Point(playerBoomEffectPos.X - 60, playerBoomEffectPos.Y - 60));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 9 || playerBoomEffectNum == 10) {
                    g.DrawImage(boomImage4, new Point(playerBoomEffectPos.X - 65, playerBoomEffectPos.Y - 65));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 11) {
                    g.DrawImage(boomImage3, new Point(playerBoomEffectPos.X - 60, playerBoomEffectPos.Y - 60));
                    playerBoomEffectNum++;
                } else if (playerBoomEffectNum == 12) {
                    gameSet = true;
                }
            } else
                g.DrawImage(player.PlayerBitmap, new Point(player.pX - 40, player.pY - 40));

            if (enemyTankArray.Count != 0)
                for (int i = 0; i < enemyTankArray.Count; i++) {
                    if (!enemyTankArray[i].isSpawn)
                        g.DrawImage(enemyTankArray[i].TankBitmap, new Point(enemyTankArray[i].X - 25 - enemyTankArray[i].spawnBitmapSize / 2, enemyTankArray[i].Y - 25 - enemyTankArray[i].spawnBitmapSize / 2));
                    else
                        g.DrawImage(enemyTankArray[i].TankBitmap, new Point(enemyTankArray[i].X - 40, enemyTankArray[i].Y - 40));
                }

            //적 폭발 이펙트
            if (enemyBoomEffectNum.Count != 0) {
                int cnt1 = enemyBoomEffectNum.Count;
                for (int i = 0; i < cnt1; i++) {
                    if (enemyBoomEffectNum[i] == 1 || enemyBoomEffectNum[i] == 2) {
                        g.DrawImage(boomImage, new Point(enemyBoomEffectPos[i].X - 32, enemyBoomEffectPos[i].Y - 32));
                        enemyBoomEffectNum[i]++;
                    } else if (enemyBoomEffectNum[i] == 3 || enemyBoomEffectNum[i] == 4) {
                        g.DrawImage(boomImage1, new Point(enemyBoomEffectPos[i].X - 36, enemyBoomEffectPos[i].Y - 36));
                        enemyBoomEffectNum[i]++;
                    } else if (enemyBoomEffectNum[i] == 5 || enemyBoomEffectNum[i] == 6) {
                        g.DrawImage(boomImage2, new Point(enemyBoomEffectPos[i].X - 40, enemyBoomEffectPos[i].Y - 40));
                        enemyBoomEffectNum[i]++;
                    } else if (enemyBoomEffectNum[i] == 7 || enemyBoomEffectNum[i] == 8) {
                        g.DrawImage(boomImage3, new Point(enemyBoomEffectPos[i].X - 60, enemyBoomEffectPos[i].Y - 60));
                        enemyBoomEffectNum[i]++;
                    } else if (enemyBoomEffectNum[i] == 9 || enemyBoomEffectNum[i] == 10) {
                        g.DrawImage(boomImage4, new Point(enemyBoomEffectPos[i].X - 65, enemyBoomEffectPos[i].Y - 65));
                        enemyBoomEffectNum[i]++;
                    } else if (enemyBoomEffectNum[i] == 11) {
                        g.DrawImage(boomImage3, new Point(enemyBoomEffectPos[i].X - 60, enemyBoomEffectPos[i].Y - 60));
                        score += 150;
                        enemyBoomEffectNum.RemoveAt(i);
                        enemyBoomEffectPos.RemoveAt(i);
                        i--;
                        cnt1 = enemyBoomEffectNum.Count;
                        GameEndCount--;
                    }
                }
            }

            //폭발 이펙트 출력
            if (BoomEffectNum.Count != 0) {
                int cnt1 = BoomEffectNum.Count;
                for (int i = 0; i < cnt1; i++) {
                    if (BoomEffectNum[i] == 1 || BoomEffectNum[i] == 2) {
                        g.DrawImage(boomImage, new Point(BoomEffectPos[i].X - 32, BoomEffectPos[i].Y - 32));
                        BoomEffectNum[i]++;
                    } else if (BoomEffectNum[i] == 3 || BoomEffectNum[i] == 4) {
                        g.DrawImage(boomImage1, new Point(BoomEffectPos[i].X - 36, BoomEffectPos[i].Y - 36));
                        BoomEffectNum[i]++;
                    } else if (BoomEffectNum[i] == 5) {
                        g.DrawImage(boomImage2, new Point(BoomEffectPos[i].X - 40, BoomEffectPos[i].Y - 40));
                        BoomEffectNum.RemoveAt(i);
                        BoomEffectPos.RemoveAt(i);
                        i--;
                        cnt1 = BoomEffectNum.Count;
                    }
                }
            }

            if (FlagBoomEffectNum >= 1) {
                if (FlagBoomEffectNum == 1 || FlagBoomEffectNum == 2) {
                    g.DrawImage(boomImage, new Point(FlagBoomEffectPos.X - 32, FlagBoomEffectPos.Y - 32));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 3 || FlagBoomEffectNum == 4) {
                    g.DrawImage(boomImage1, new Point(FlagBoomEffectPos.X - 36, FlagBoomEffectPos.Y - 36));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 5 || FlagBoomEffectNum == 6) {
                    g.DrawImage(boomImage2, new Point(FlagBoomEffectPos.X - 40, FlagBoomEffectPos.Y - 40));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 7 || FlagBoomEffectNum == 8) {
                    FlagImage = new Bitmap(mapImage.Images[3], new Size(50, 50));
                    g.DrawImage(boomImage3, new Point(FlagBoomEffectPos.X - 60, FlagBoomEffectPos.Y - 60));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 9 || FlagBoomEffectNum == 10) {
                    g.DrawImage(boomImage4, new Point(FlagBoomEffectPos.X - 65, FlagBoomEffectPos.Y - 65));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 11) {
                    g.DrawImage(boomImage3, new Point(FlagBoomEffectPos.X - 60, FlagBoomEffectPos.Y - 60));
                    FlagBoomEffectNum++;
                } else if (FlagBoomEffectNum == 12) {
                    gameSet = true;
                }
            }

            if (GameEndCount <= 0)
                gameSet = true;

            labelText = String.Format("Score : {0}", score);
            label1.Text = labelText;
            if (gameSet) {
                if (StageNum == 2) {
                    GameOver();
                    MessageBox.Show(String.Format("Score : {0}", score));
                }
                WaitTimer++;
                if (WaitTimer >= 60 && StageNum == 1) {
                    GameOver();
                    StageNum++;
                    WaitTimer = 0;
                    timer2.Enabled = true;
                }
            }
            if (!IsReady) {
                pictureBox1.Size = new Size(1265, 685);
                IsReady = true;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            g = e.Graphics;
            int cnt = 0;
            for (int i = 0; cnt < EnemyLifeCount; i++) {
                for (int j = 0; j < 2; j++) {
                    if (cnt < EnemyLifeCount) {
                        g.DrawImage(EnemyLifeImage, new Point(970 + (j * 25), 200 + (i * 24)));
                        cnt++;
                    }
                }
            }
        }
        private void timer2_Tick(object sender, EventArgs e) {
            if (isKeyUp && WaitTimer < 70) {
                WaitTimer++;
                SizeCnt += 30;
                if (SizeCnt >= 342) {
                    SizeCnt = 342;
                    if(StageNum == 1)
                        pictureBox4.Size = new Size(1265, 660);
                    else if(StageNum == 2)
                        pictureBox5.Size = new Size(1265, 660);
                }
                pictureBox2.Size = new Size(1265, SizeCnt);
                pictureBox3.Size = new Size(1265, SizeCnt);
                pictureBox3.Location = new Point(0, 682 - SizeCnt);
            }
            if(WaitTimer == 70 && StageNum >= 2) {
                for (int y = 0; y < 28; y++)
                    for (int x = 0; x < 30; x++) {
                        board.Map[y, x] = board.Map2[y, x];
                    }
                for (int y = 0; y < 28; y++)
                    for (int x = 0; x < 30; x++) {
                        board.copyMap[y, x] = board.Map[y, x];
                    }
                ResetGame();
            }
            if (isKeyUp && WaitTimer >= 70 && WaitTimer <= 90) {
                pictureBox1.Size = new Size(1265, 0);
                if (StageNum == 1)
                    pictureBox4.Size = new Size(1265, 0);
                else if (StageNum == 2)
                    pictureBox5.Size = new Size(1265, 0);
                SizeCnt -= 30;
                if (SizeCnt <= 0) {
                    SizeCnt = 0;
                    StartGame();
                    timer2.Enabled = false;
                }
                pictureBox2.Size = new Size(1265, SizeCnt);
                pictureBox3.Size = new Size(1265, SizeCnt);
                pictureBox3.Location = new Point(0, 682 - SizeCnt);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (isKeyDown && isUp || isKeyDown && isRight || isKeyDown && isDown || isKeyDown && isLeft) {
                if (isUp) {
                    nextDirection = 1;
                } else if (isRight) {
                    nextDirection = 2;
                } else if (isDown) {
                    nextDirection = 3;
                } else if (isLeft) {
                    nextDirection = 4;
                }
                player.currentDirection = nextDirection;
                if (check_direction(nextDirection)) {
                    switch (nextDirection) {
                        case 1: playerDirectionY = -playerSpeed; break;
                        case 2: playerDirectionX = playerSpeed; break;
                        case 3: playerDirectionY = playerSpeed; break;
                        case 4: playerDirectionX = -playerSpeed; break;
                    }
                } else {
                    playerDirectionY = 0;
                    playerDirectionX = 0;
                }
                player.UpdatePacmanImage();
            }

            if (player.currentDirection == 2 || player.currentDirection == 4) {
                player.pX += playerDirectionX;
                player.checkX = player.pX / 24;
            }
            if (player.currentDirection == 1 || player.currentDirection == 3) {
                player.pY += playerDirectionY;
                player.checkY = player.pY / 24;
            }


            //총말 발사
            if (isSpace && playerBulletDir == -1) {
                playerBulletDir = player.currentDirection;
                playerBulletPos = new Point(player.pX, player.pY);
            }

            if (playerBulletDir != -1) {
                if (check_PlayerBulletCollision()) {
                    if (playerBulletDir == 1) {
                        playerBulletPos.Y -= 10;
                    } else if (playerBulletDir == 2) {
                        playerBulletPos.X += 10;
                    } else if (playerBulletDir == 3) {
                        playerBulletPos.Y += 10;
                    } else if (playerBulletDir == 4) {
                        playerBulletPos.X -= 10;
                    }
                } else {
                    playerBulletDir = -1;
                }
            }

            //총알 움직임 계산
            if (bulletDirection.Count != 0) {
                int cnt = bulletDirection.Count;
                for (int i = 0; i < cnt; i++) {
                    if (check_BulletCollision(i)) {
                        if (bulletDirection[i] == 1) {
                            bulletPositionY[i] -= 10;
                        } else if (bulletDirection[i] == 2) {
                            bulletPositionX[i] += 10;
                        } else if (bulletDirection[i] == 3) {
                            bulletPositionY[i] += 10;
                        } else if (bulletDirection[i] == 4) {
                            bulletPositionX[i] -= 10;
                        }
                    } else {
                        bulletDirection.RemoveAt(i);
                        bulletPositionX.RemoveAt(i);
                        bulletPositionY.RemoveAt(i);
                        i--;
                        cnt = bulletDirection.Count;
                    }
                }
            }

            if (enemyTankArray.Count != 0)
                for (int i = 0; i < enemyTankArray.Count; i++) {
                    enemyTankArray[i].MoveEnemyTank();
                }

            if (EnemyLifeCount <= 3)
                EnemySpawnLimit = EnemyLifeCount;

            if (enemyTankArray.Count < EnemySpawnLimit && EnemySpawnCount >= 120) {
                switch (rand.Next(1, 4)) {
                    case 1: enemyTankArray.Add(new EnemyTank(48, 48, TankImageList, board, this)); break;
                    case 2: enemyTankArray.Add(new EnemyTank(336, 48, TankImageList, board, this)); break;
                    case 3: enemyTankArray.Add(new EnemyTank(624, 48, TankImageList, board, this)); break;
                }
                EnemySpawnCount = 0;
            }
            EnemySpawnCount++;
            //nextDirection = 0;
            playerDirectionX = 0;
            playerDirectionY = 0;
            panel1.Invalidate();
            Invalidate();
        }
        private bool check_PlayerBulletCollision() {//벽에 부딪혔을 경우
            /*BulletCheckOk = false;
            for (int i = -1; i < 1; i++) {
                if (playerBulletDir == 2 || playerBulletDir == 4) {
                    BulletCheckOk = direction_ok(playerBulletPos.X / 24, (playerBulletPos.Y + i) / 24);
                    if (!BulletCheckOk) {
                        if (board.Map[playerBulletPos.X / 24, (playerBulletPos.Y + i) / 24] == 02)
                            block_Destroy(playerBulletDir, (playerBulletPos.Y + i), playerBulletPos.X);
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(playerBulletPos.X, playerBulletPos.Y));
                        return false;
                    }
                } else if (playerBulletDir == 1 || playerBulletDir == 3) {
                    BulletCheckOk = direction_ok((playerBulletPos.X + i) / 24, playerBulletPos.Y / 24);
                    if (!BulletCheckOk) {
                        if (board.Map[(playerBulletPos.X + i) / 24, playerBulletPos.Y / 24] == 02)
                            block_Destroy(playerBulletDir, playerBulletPos.Y, (playerBulletPos.X + i));
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(playerBulletPos.X, playerBulletPos.Y));
                        return false;
                    }
                }
            }
            return BulletCheckOk;*/
            if (enemyTankArray.Count != 0) {
                for (int i = 0; i < enemyTankArray.Count; i++) {
                    if (enemyTankArray[i].X - 17 < playerBulletPos.X && enemyTankArray[i].X + 17 > playerBulletPos.X &&
                        enemyTankArray[i].Y - 17 < playerBulletPos.Y && enemyTankArray[i].Y + 17 > playerBulletPos.Y && enemyTankArray[i].isSpawn) {
                        EnemyLifeCount--;
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(playerBulletPos.X, playerBulletPos.Y));
                        enemyBoomEffectNum.Add(1);
                        enemyBoomEffectPos.Add(new Point(enemyTankArray[i].X, enemyTankArray[i].Y));
                        enemyTankArray.RemoveAt(i);
                        i--;
                        playerBulletDir = -1;
                    }
                }
            }
            if (direction_ok(playerBulletPos.X / 24, playerBulletPos.Y / 24))
                return true;
            else {
                if (board.Map[playerBulletPos.Y / 24, playerBulletPos.X / 24] == 02)
                    Playerblock_Destroy(playerBulletDir, playerBulletPos.Y, playerBulletPos.X);
                if (board.Map[playerBulletPos.Y / 24, playerBulletPos.X / 24] == 11 && FlagBoomEffectNum == 0) {
                    FlagBoomEffectNum = 1;
                    FlagBoomEffectPos = new Point(335, 622);
                }
                BoomEffectNum.Add(1);
                BoomEffectPos.Add(new Point(playerBulletPos.X, playerBulletPos.Y));
                return false;
            }
        }

        private void Playerblock_Destroy(int index, int x, int y) {//벽돌 부시기
            if (index == 1 || index == 3) {
                for (int i = y - 9; i < y + 9; i++) {
                    if (board.Map[x / 24, i / 24] == 02)
                        board.Map[x / 24, i / 24] = 01;
                }
            } else if (index == 2 || index == 4) {
                for (int i = x - 9; i < x + 9; i++) {
                    if (board.Map[i / 24, y / 24] == 02)
                        board.Map[i / 24, y / 24] = 01;
                }
            }
        }

        private bool check_BulletCollision(int index) {//벽에 부딪혔을 경우
            /*BulletCheckOk = false;
            for(int i = -1; i < 2; i++) {
                if (bulletDirection[index] == 2 || bulletDirection[index] == 4) {
                    BulletCheckOk = direction_ok(bulletPositionX[index] / 24, (bulletPositionY[index] + i) / 24);
                    if (!BulletCheckOk) {
                        if (board.Map[bulletPositionX[index] / 24, (bulletPositionY[index] + i) / 24] == 02)
                            block_Destroy(bulletDirection[index], (bulletPositionY[index] + i), bulletPositionX[index]);
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                        return false;
                    }
                } else if (bulletDirection[index] == 1 || bulletDirection[index] == 3) {
                    BulletCheckOk = direction_ok((bulletPositionX[index] + i) / 24, bulletPositionY[index] / 24);
                    if (!BulletCheckOk) {
                        if (board.Map[(bulletPositionX[index] + i) / 24, bulletPositionY[index] / 24] == 02)
                            block_Destroy(bulletDirection[index], bulletPositionY[index], (bulletPositionX[index] + i));
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                        return false;
                    }
                }      
            }
            return BulletCheckOk;*/
            if (player.pX - 17 < bulletPositionX[index] && player.pX + 17 > bulletPositionX[index] &&
                player.pY - 17 < bulletPositionY[index] && player.pY + 17 > bulletPositionY[index]) {
                BoomEffectNum.Add(1);
                BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                playerBoomEffectNum = 1;
                playerBoomEffectPos = new Point(player.pX, player.pY);
                return false;
            }
            if (playerBulletDir != -1) {
                if (bulletDirection[index] == 2 || bulletDirection[index] == 4) {
                    if (playerBulletPos.X - 15 < bulletPositionX[index] && playerBulletPos.X + 15 > bulletPositionX[index] &&
                        playerBulletPos.Y - 10 < bulletPositionY[index] && playerBulletPos.Y + 10 > bulletPositionY[index]) {
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                        playerBulletDir = -1;
                        return false;
                    }
                }
                if (bulletDirection[index] == 1 || bulletDirection[index] == 3) {
                    if (playerBulletPos.X - 10 < bulletPositionX[index] && playerBulletPos.X + 10 > bulletPositionX[index] &&
                        playerBulletPos.Y - 15 < bulletPositionY[index] && playerBulletPos.Y + 15 > bulletPositionY[index]) {
                        BoomEffectNum.Add(1);
                        BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                        playerBulletDir = -1;
                        return false;
                    }
                }
            }
            if (direction_ok(bulletPositionX[index] / 24, bulletPositionY[index] / 24))
                return true;
            else {
                if (board.Map[bulletPositionY[index] / 24, bulletPositionX[index] / 24] == 02)
                    block_Destroy(bulletDirection[index], bulletPositionY[index], bulletPositionX[index]);
                if (board.Map[bulletPositionY[index] / 24, bulletPositionX[index] / 24] == 11 && FlagBoomEffectNum == 0) {
                    FlagBoomEffectNum = 1;
                    FlagBoomEffectPos = new Point(315, 602);
                }
                BoomEffectNum.Add(1);
                BoomEffectPos.Add(new Point(bulletPositionX[index], bulletPositionY[index]));
                return false;
            }
        }

        private void block_Destroy(int dir, int x, int y) {//벽돌 부시기
            if (dir == 1 || dir == 3) {
                for (int i = y - 9; i < y + 9; i++) {
                    if (board.Map[x / 24, i / 24] == 02)
                        board.Map[x / 24, i / 24] = 01;
                }
            } else if (dir == 2 || dir == 4) {
                for (int i = x - 9; i < x + 9; i++) {
                    if (board.Map[i / 24, y / 24] == 02)
                        board.Map[i / 24, y / 24] = 01;
                }
            }
        }

        private bool check_direction(int direction) {
            int playerPos;
            CheckOk = false;
            if (direction == 2 || direction == 4) {
                for (int i = player.pY - 17; i < player.pY + 17; i++) {
                    playerPos = i / 24;
                    if (direction == 2)
                        CheckOk = direction_ok(player.checkX + 1, playerPos);
                    else
                        CheckOk = direction_ok(player.checkX - 1, playerPos);
                    if (!CheckOk)
                        return false;
                }
            } else if (direction == 1 || direction == 3) {
                for (int i = player.pX - 17; i < player.pX + 17; i++) {
                    playerPos = i / 24;
                    if (direction == 1)
                        CheckOk = direction_ok(playerPos, player.checkY - 1);
                    else
                        CheckOk = direction_ok(playerPos, player.checkY + 1);
                    if (!CheckOk)
                        return false;
                }
            }
            return true;
        }

        private bool direction_ok(int x, int y) {
            if (board.Map[y, x] == 1) { return true; } else { return false; }
        }

        public void GameOver() {
            timer1.Enabled = false;
            player.StopGame();
        }

        public void StartGame() {
            player.StartGame();
            timer1.Enabled = true;
            timer1.Interval = 25;
            WaitTimer = 0;
            enemyTankArray.Add(new EnemyTank(48, 48, TankImageList, board, this));
        }

        private void ResetGame() {
            player.ResetGame();
            timer1.Enabled = false;
            //score = 0;
            gameSet = false;
            FlagImage = new Bitmap(mapImage.Images[2], new Size(50, 50));
            playerBoomEffectNum = 0;
            FlagBoomEffectNum = 0;
            EnemySpawnCount = 0;
            EnemyLifeCount = 16;
            GameEndCount = 16;
            EnemySpawnLimit = 3;
            playerBulletDir = -1;
            bulletDirection.Clear();
            bulletPositionX.Clear();
            bulletPositionY.Clear();
            BoomEffectNum.Clear();
            BoomEffectPos.Clear();
            enemyBoomEffectNum.Clear();
            enemyBoomEffectPos.Clear();
            enemyTankArray.Clear();
            board.CopyMap();
            panel1.Invalidate();
        }
    }
}
