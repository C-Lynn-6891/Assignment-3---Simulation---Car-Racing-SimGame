using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices.Marshalling;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace Assignment_3_Car_Sim_Game
{
    public partial class Form1 : Form
    {


        int roadSpeed;
        int trafficSpeed;
        int playerSpeed;
        int score;
        int carImage;

        Random rand = new Random();
        Random carPosition = new Random();

        bool goleft, goright;


        public Form1()
        {
            InitializeComponent();
            ResetGame();
        }

        private Panel panel1;
        private Button btnStart;
        private Label txtScore;

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            award = new PictureBox();
            explosion = new PictureBox();
            AI2 = new PictureBox();
            AI1 = new PictureBox();
            player = new PictureBox();
            roadTrack2 = new PictureBox();
            roadTrack1 = new PictureBox();
            btnStart = new Button();
            txtScore = new Label();
            label2 = new Label();
            gameTimer = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)award).BeginInit();
            ((System.ComponentModel.ISupportInitialize)explosion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AI2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AI1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)player).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roadTrack2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roadTrack1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(award);
            panel1.Controls.Add(explosion);
            panel1.Controls.Add(AI2);
            panel1.Controls.Add(AI1);
            panel1.Controls.Add(player);
            panel1.Controls.Add(roadTrack2);
            panel1.Controls.Add(roadTrack1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(473, 561);
            panel1.TabIndex = 0;
            // 
            // award
            // 
            award.ErrorImage = null;
            award.Image = (Image)resources.GetObject("award.Image");
            award.InitialImage = null;
            award.Location = new Point(106, 264);
            award.Name = "award";
            award.Size = new Size(273, 95);
            award.SizeMode = PictureBoxSizeMode.StretchImage;
            award.TabIndex = 2;
            award.TabStop = false;
            // 
            // explosion
            // 
            explosion.ErrorImage = null;
            explosion.Image = (Image)resources.GetObject("explosion.Image");
            explosion.InitialImage = null;
            explosion.Location = new Point(74, 365);
            explosion.Name = "explosion";
            explosion.Size = new Size(64, 64);
            explosion.SizeMode = PictureBoxSizeMode.AutoSize;
            explosion.TabIndex = 2;
            explosion.TabStop = false;
            // 
            // AI2
            // 
            AI2.ErrorImage = null;
            AI2.Image = (Image)resources.GetObject("AI2.Image");
            AI2.InitialImage = null;
            AI2.Location = new Point(423, 37);
            AI2.Name = "AI2";
            AI2.Size = new Size(50, 100);
            AI2.SizeMode = PictureBoxSizeMode.AutoSize;
            AI2.TabIndex = 2;
            AI2.TabStop = false;
            AI2.Tag = "carRight";
            // 
            // AI1
            // 
            AI1.ErrorImage = null;
            AI1.Image = (Image)resources.GetObject("AI1.Image");
            AI1.InitialImage = null;
            AI1.Location = new Point(57, 37);
            AI1.Name = "AI1";
            AI1.Size = new Size(50, 101);
            AI1.SizeMode = PictureBoxSizeMode.AutoSize;
            AI1.TabIndex = 2;
            AI1.TabStop = false;
            AI1.Tag = "carLeft";
            // 
            // player
            // 
            player.ErrorImage = null;
            player.Image = (Image)resources.GetObject("player.Image");
            player.InitialImage = null;
            player.Location = new Point(217, 458);
            player.Name = "player";
            player.Size = new Size(50, 99);
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.TabIndex = 2;
            player.TabStop = false;
            // 
            // roadTrack2
            // 
            roadTrack2.BackgroundImageLayout = ImageLayout.None;
            roadTrack2.ErrorImage = null;
            roadTrack2.Image = Properties.Resources.roadTrack;
            roadTrack2.InitialImage = null;
            roadTrack2.Location = new Point(0, 0);
            roadTrack2.Name = "roadTrack2";
            roadTrack2.Size = new Size(473, 561);
            roadTrack2.SizeMode = PictureBoxSizeMode.CenterImage;
            roadTrack2.TabIndex = 1;
            roadTrack2.TabStop = false;
            // 
            // roadTrack1
            // 
            roadTrack1.BackgroundImageLayout = ImageLayout.None;
            roadTrack1.ErrorImage = null;
            roadTrack1.Image = Properties.Resources.roadTrack;
            roadTrack1.InitialImage = null;
            roadTrack1.Location = new Point(0, -561);
            roadTrack1.Name = "roadTrack1";
            roadTrack1.Size = new Size(473, 561);
            roadTrack1.SizeMode = PictureBoxSizeMode.CenterImage;
            roadTrack1.TabIndex = 0;
            roadTrack1.TabStop = false;
            // 
            // btnStart
            // 
            btnStart.Font = new Font("Segoe UI Black", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnStart.Location = new Point(193, 611);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(106, 44);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += restartGame;
            // 
            // txtScore
            // 
            txtScore.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtScore.Location = new Point(12, 578);
            txtScore.Name = "txtScore";
            txtScore.Size = new Size(473, 25);
            txtScore.TabIndex = 2;
            txtScore.Text = "Score: 0";
            txtScore.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Firebrick;
            label2.Location = new Point(12, 664);
            label2.Name = "label2";
            label2.Size = new Size(473, 110);
            label2.TabIndex = 3;
            label2.Text = "Have a need for speed? The more you score the faster you go. \r\nNavigate through the streets using your Left and\r\n Right arrows\r\n";
            label2.TextAlign = ContentAlignment.TopCenter;
            label2.Click += label2_Click;
            // 
            // gameTimer
            // 
            gameTimer.Interval = 20;
            gameTimer.Tick += gameTimerEvent;
            // 
            // Form1
            // 
            ClientSize = new Size(497, 773);
            Controls.Add(label2);
            Controls.Add(txtScore);
            Controls.Add(btnStart);
            Controls.Add(panel1);
            Name = "Form1";
            KeyDown += keyisdown;
            KeyUp += keyisup;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)award).EndInit();
            ((System.ComponentModel.ISupportInitialize)explosion).EndInit();
            ((System.ComponentModel.ISupportInitialize)AI2).EndInit();
            ((System.ComponentModel.ISupportInitialize)AI1).EndInit();
            ((System.ComponentModel.ISupportInitialize)player).EndInit();
            ((System.ComponentModel.ISupportInitialize)roadTrack2).EndInit();
            ((System.ComponentModel.ISupportInitialize)roadTrack1).EndInit();
            ResumeLayout(false);

        }

        private Label label2;

        private void label2_Click(object sender, EventArgs e)
        {
             
          
        }

        private PictureBox roadTrack1;
        private PictureBox player;
        private PictureBox roadTrack2;
        private PictureBox award;
        private PictureBox explosion;
        private PictureBox AI2;
        private PictureBox AI1;
        private System.Windows.Forms.Timer gameTimer;
        private System.ComponentModel.IContainer components;
        private static CultureInfo? resourceCulture;
        private object key;

        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
        }


        private void gameTimerEvent(object sender, EventArgs e)
        {

            txtScore.Text = "Score:" + score;
            score++;


            if (goleft == true && player.Left > 6)
            {
                player.Left -= playerSpeed;
            }
            if (goright == true && player.Left < 415)
            {
                player.Left += playerSpeed;
            }

            roadTrack1.Top += roadSpeed;
            roadTrack2.Top += roadSpeed;

            if (roadTrack2.Top > 561)
            {
                roadTrack2.Top = -561;
            }
            if (roadTrack1.Top > 561)
            {
                roadTrack1.Top = -561;
            }

            AI1.Top += trafficSpeed;
            AI2.Top += trafficSpeed;

            if (AI1.Top > 570)
            {
                changeAIcars(AI1);
            }

            if (AI2.Top > 570)
            {
                changeAIcars(AI2);
            }

            if (player.Bounds.IntersectsWith(AI1.Bounds) || player.Bounds.IntersectsWith(AI2.Bounds))
            {
                gameOver();
            }



            if (score > 50 && score < 550)
            {

                award.Image = Image.FromStream(new MemoryStream(Properties.Resources.bronse));
            }
            if (score > 550 && score < 1050)
            {
                award.Image = Image.FromStream(new MemoryStream(Properties.Resources.silver));
                roadSpeed = 20;
                trafficSpeed = 22;
            }
            if (score > 1050)
            {
                award.Image = Image.FromStream(new MemoryStream(Properties.Resources.gold));
                roadSpeed = 30;
                trafficSpeed = 32;
            }



        }

        private void changeAIcars(PictureBox tempCar)
        {

            carImage = rand.Next(1, 9);

            switch (carImage)
            {

                case 1:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.ambulance));
                    break;
                case 2:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.carGrey));
                    break;
                case 3:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.carOrange));
                    break;
                case 4:
                    tempCar.Image = Image.FromStream(new MemoryStream  (Properties.Resources.CarRed));
                    break;
                case 5:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.TruckBlue));
                    break;
                case 6:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.carGreen));
                    break;
                case 7:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.carYellow));
                    break;
                case 8:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.carPink));
                    break;
                case 9:
                    tempCar.Image = Image.FromStream(new MemoryStream(Properties.Resources.TruckWhite));
                    break;

            }

            tempCar.Top = carPosition.Next(100, 400) * -1;


            if ((string)tempCar.Tag == "carLeft")
            {
                tempCar.Left = carPosition.Next(3, 185);
            }
            if ((string)tempCar.Tag == "carRight")
            {
                tempCar.Left = carPosition.Next(234, 423);
            }


        }

        private void gameOver()
        {

            playSound();
            gameTimer.Stop();
            explosion.Visible = true;
            player.Controls.Add(explosion);
            explosion.Location = new Point(-8, 5);
            explosion.BackColor = Color.Transparent;

            award.Visible = true;
            award.BringToFront();

            btnStart.Enabled = true;

        }

        private void ResetGame()
        {

            btnStart.Enabled = false;
            explosion.Visible = false;
            award.Visible = false;
            goleft = false;
            goright = false;
            score = 0;
            award.Image = Image.FromStream(new MemoryStream(Properties.Resources.bronse));
            roadSpeed = 12;
            trafficSpeed = 15;

            AI1.Top = carPosition.Next(200, 500) * -1;
            AI1.Left = carPosition.Next(3, 185);

            AI2.Top = carPosition.Next(200, 500) * -1;
            AI2.Left = carPosition.Next(237, 423);

            gameTimer.Start();
        }

        private void playSound()
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.hit);
            playCrash.Play();

        }

        private void restartGame(object sender, EventArgs e)
        {
            ResetGame();
        }
    }

}
