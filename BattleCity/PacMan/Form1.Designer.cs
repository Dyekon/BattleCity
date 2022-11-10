namespace PacMan {
    partial class Form1 {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// this.panel1 = new DoubleBufferdPanel();
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PlayerImagelist = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.blockImageList = new System.Windows.Forms.ImageList(this.components);
            this.TankImageList = new System.Windows.Forms.ImageList(this.components);
            this.mapImage = new System.Windows.Forms.ImageList(this.components);
            this.BoomImage = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new DoubleBufferdPanel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PlayerImagelist
            // 
            this.PlayerImagelist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PlayerImagelist.ImageStream")));
            this.PlayerImagelist.TransparentColor = System.Drawing.Color.Transparent;
            this.PlayerImagelist.Images.SetKeyName(0, "PlayerTank1 1.jpg");
            this.PlayerImagelist.Images.SetKeyName(1, "PlayerTank1 2.jpg");
            this.PlayerImagelist.Images.SetKeyName(2, "PlayerTank2 1.jpg");
            this.PlayerImagelist.Images.SetKeyName(3, "PlayerTank2 2.jpg");
            this.PlayerImagelist.Images.SetKeyName(4, "PlayerTank3 1.jpg");
            this.PlayerImagelist.Images.SetKeyName(5, "PlayerTank3 2.jpg");
            this.PlayerImagelist.Images.SetKeyName(6, "PlayerTank4 1.jpg");
            this.PlayerImagelist.Images.SetKeyName(7, "PlayerTank4 2.jpg");
            this.PlayerImagelist.Images.SetKeyName(8, "Bullet.png");
            this.PlayerImagelist.Images.SetKeyName(9, "Bullet1.png");
            this.PlayerImagelist.Images.SetKeyName(10, "Bullet2.png");
            this.PlayerImagelist.Images.SetKeyName(11, "Bullet3.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(958, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // blockImageList
            // 
            this.blockImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("blockImageList.ImageStream")));
            this.blockImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.blockImageList.Images.SetKeyName(0, "Block.jpg");
            this.blockImageList.Images.SetKeyName(1, "Block1.jpg");
            this.blockImageList.Images.SetKeyName(2, "Flag.jpg");
            this.blockImageList.Images.SetKeyName(3, "EnemyIcon.jpg");
            // 
            // TankImageList
            // 
            this.TankImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TankImageList.ImageStream")));
            this.TankImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TankImageList.Images.SetKeyName(0, "EnemyTank1 1.jpg");
            this.TankImageList.Images.SetKeyName(1, "EnemyTank1 2.jpg");
            this.TankImageList.Images.SetKeyName(2, "EnemyTank2 1.jpg");
            this.TankImageList.Images.SetKeyName(3, "EnemyTank2 2.jpg");
            this.TankImageList.Images.SetKeyName(4, "EnemyTank3 1.jpg");
            this.TankImageList.Images.SetKeyName(5, "EnemyTank3 2.jpg");
            this.TankImageList.Images.SetKeyName(6, "EnemyTank4 1.jpg");
            this.TankImageList.Images.SetKeyName(7, "EnemyTank4 2.jpg");
            this.TankImageList.Images.SetKeyName(8, "EnemySpawn1.jpg");
            this.TankImageList.Images.SetKeyName(9, "EnemySpawn2.jpg");
            this.TankImageList.Images.SetKeyName(10, "EnemySpawn3.jpg");
            this.TankImageList.Images.SetKeyName(11, "EnemySpawn4.jpg");
            // 
            // mapImage
            // 
            this.mapImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("mapImage.ImageStream")));
            this.mapImage.TransparentColor = System.Drawing.Color.Transparent;
            this.mapImage.Images.SetKeyName(0, "background.png");
            this.mapImage.Images.SetKeyName(1, "background.png");
            this.mapImage.Images.SetKeyName(2, "Flag.jpg");
            this.mapImage.Images.SetKeyName(3, "Flag1.jpg");
            // 
            // BoomImage
            // 
            this.BoomImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("BoomImage.ImageStream")));
            this.BoomImage.TransparentColor = System.Drawing.Color.Transparent;
            this.BoomImage.Images.SetKeyName(0, "Boom1.jpg");
            this.BoomImage.Images.SetKeyName(1, "Boom2.jpg");
            this.BoomImage.Images.SetKeyName(2, "Boom3.jpg");
            this.BoomImage.Images.SetKeyName(3, "Boom4.jpg");
            this.BoomImage.Images.SetKeyName(4, "Boom5.jpg");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(958, 558);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::PacMan.Properties.Resources.background;
            this.panel1.Location = new System.Drawing.Point(279, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 625);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::PacMan.Properties.Resources.NextStageImage;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1265, 50);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::PacMan.Properties.Resources.StartImage;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1265, 50);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Interval = 25;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::PacMan.Properties.Resources.NextStageImage;
            this.pictureBox3.Location = new System.Drawing.Point(0, 637);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(1265, 50);
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::PacMan.Properties.Resources.Stage1Image;
            this.pictureBox4.Location = new System.Drawing.Point(0, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(1265, 19);
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::PacMan.Properties.Resources.Stage2Image;
            this.pictureBox5.Location = new System.Drawing.Point(0, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1265, 50);
            this.pictureBox5.TabIndex = 10;
            this.pictureBox5.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PacMan.Properties.Resources.Map;
            this.ClientSize = new System.Drawing.Size(1264, 684);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList PlayerImagelist;
        private System.Windows.Forms.ImageList blockImageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ImageList TankImageList;
        private System.Windows.Forms.ImageList mapImage;
        private System.Windows.Forms.ImageList BoomImage;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        public System.Windows.Forms.Panel panel1;
        //public System.Windows.Forms.Panel panel1;
    }
}

