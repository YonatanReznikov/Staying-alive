using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;


namespace Staying_alive
{
    [Serializable]
    public partial class Game : Form
    {
        [NonSerialized]
        bool gameStarted = false, song = true;
        static int highscore;
        int score = 0;
        System.Media.SoundPlayer music = new System.Media.SoundPlayer(Properties.Resources.Alive);
        Bar prog = new Bar();
        Helper easy;
        MainCharacter hero = new MainCharacter();
        Kong monkey = new Kong(22, 115);
        Grass[] grassArray = new Grass[]
       {
            new Grass(12, 520,354,30),
            new Grass(103, 452,124,20),
            new Grass(240, 384,128, 20),
            new Grass(10, 316,193, 20),
            new Grass(253, 248,100, 20),
            new Grass(13, 175,210, 20),
            new Grass(255, 100,111, 20)
        };

        Coins[] coinsArray = new Coins[]
      {
            new Coins(253, 488),
            new Coins(195, 488),
            new Coins(147, 488),
            new Coins(103, 488),
            new Coins(13, 465),
            new Coins(13, 424),
            new Coins(312, 424),
            new Coins(111, 420),
            new Coins(195, 420),
            new Coins(253, 350),
            new Coins(291, 350),
            new Coins(332, 350),
            new Coins(36, 280),
            new Coins(78, 280),
            new Coins(120, 280),
            new Coins(206, 246),
            new Coins(270, 215),
            new Coins(320, 215),
            new Coins(320, 160),
            new Coins(270, 160),
            new Coins(147, 145),
            new Coins(90, 145),
            new Coins(273, 65),
            new Coins(331, 65)
       };

        Mashroom[] mashArray = new Mashroom[]
        {
            new Mashroom(180, 498),
            new Mashroom(100, 498),
            new Mashroom(29, 498),
            new Mashroom(173, 430),
            new Mashroom(260, 362),
            new Mashroom(332, 362),
            new Mashroom(60,  295),
            new Mashroom(100, 295),
            new Mashroom(140, 295),
            new Mashroom(321, 227),
            new Mashroom(103, 152),
            new Mashroom(155, 152),
            new Mashroom(312, 79)
         };
        List<Banana> bananaList = new List<Banana>();
        System.Timers.Timer bananaTimer;

        public Game()
        {
            InitializeComponent();
            music.Play();
            Controls.Add(prog.progressBar);
            prog.progressBar.BringToFront();
            Controls.Add(hero.item);
            hero.item.BringToFront();
            foreach (Coins coin in coinsArray)
            {
                Controls.Add(coin.Item);
                coin.Item.BringToFront();
            }
            foreach (Grass grass in grassArray)
            {
                Controls.Add(grass.Item);
                grass.Item.BringToFront();
            }
            foreach (Mashroom mash in mashArray)
            {
                Controls.Add(mash.item);
                mash.item.BringToFront();
            }
            Controls.Add(monkey.item);
            monkey.item.BringToFront();

            bananaTimer = new System.Timers.Timer(10000);
            bananaTimer.Elapsed += BananaTimerElapsed;
            bananaTimer.AutoReset = true;
            bananaTimer.Enabled = true;

            Gametimer.Start();
        }

        private void GametimerEvent(object sender, EventArgs e)
        {
            if (gameStarted)
            {
                txtScore.Text = "Score: " + score;
                txthigh.Text = "Highest Score: " + highscore;
                highscore = highest(highscore, score);
                mashArray[0].MoveLeft(mashArray[0], grassArray[0]);
                mashArray[1].MoveLeft(mashArray[1], grassArray[0]);
                mashArray[2].MoveLeft(mashArray[2], grassArray[0]);
                mashArray[3].MoveLeft(mashArray[3], grassArray[1]);
                mashArray[4].MoveLeft(mashArray[4], grassArray[2]);
                mashArray[5].MoveLeft(mashArray[5], grassArray[2]);
                mashArray[6].MoveLeft(mashArray[6], grassArray[3]);
                mashArray[7].MoveLeft(mashArray[7], grassArray[3]);
                mashArray[8].MoveLeft(mashArray[8], grassArray[3]);
                mashArray[9].MoveLeft(mashArray[9], grassArray[4]);
                mashArray[10].MoveLeft(mashArray[10], grassArray[5]);
                mashArray[11].MoveLeft(mashArray[11], grassArray[5]);
                mashArray[12].MoveLeft(mashArray[12], grassArray[6]);

                List<Banana> bananasToModify = new List<Banana>(bananaList);

                foreach (Banana banana in bananasToModify)
                    banana.MoveTowardsCurrentGrass(hero.currentGrass, hero, prog);
                if (hero.health == 0)
                {
                    Gametimer.Stop();
                    txtScore.Text = "Score: " + score + Environment.NewLine + "You failed to stay alive \nYou Lost!";
                    if (score == highscore)
                        txthigh.Text = "Score: " + highscore + Environment.NewLine + "You Set a new record";
                    else
                        txthigh.Text = "Score: " + highscore + Environment.NewLine + "Try harder";
                    str.Enabled = true;
                    selector.Enabled = true;
                    ext.Enabled = true;
                    Helperbtn.Enabled = true;
                    snap.Enabled = true;
                    pause.Enabled = true;
                    saveButton.Enabled = true;
                    loadButton.Enabled = true;
                }

                if (hero.moveLeft)
                    hero.MoveLeft();
                if (hero.moveRight)
                    hero.MoveRight();
                if (hero.jumping)
                    hero.jump();


                foreach (Grass grass in grassArray)
                {
                    if (hero.item.Bounds.IntersectsWith(grass.Item.Bounds))
                    {
                        if (hero.item.Bottom > grass.Item.Bottom + 10)
                            hero.jumping = false;
                        else
                        {
                            hero.currentGrass = grass;
                            hero.jumping = false;
                            hero.item.Top = grass.Item.Top - hero.item.Height - 4;
                            hero.force = 8;
                            break;
                        }
                    }
                }
                if (hero.inAir && !hero.jumping)
                    hero.item.Top += hero.force;

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && hero.item.Bounds.IntersectsWith(x.Bounds))
                    {
                        if ((string)x.Tag == "coins" && x.Visible == true)
                        {
                            x.Visible = false;
                            score += 5;
                            System.Threading.Timer timer = null;
                            timer = new System.Threading.Timer((state) =>
                            {
                                x.Invoke((MethodInvoker)delegate
                                {
                                    x.Visible = true;
                                });
                                timer.Dispose();
                            }, null, 5000, Timeout.Infinite);

                        }
                        else if ((string)x.Tag == "banana")
                        {
                            x.Dispose();
                            if (hero.health > 50)
                            {
                                hero.health -= 50;
                                prog.progressBar.Value = hero.health;
                            }
                            else
                            {
                                hero.health = 0;
                                prog.progressBar.Value = hero.health;
                            }
                        }
                        else if ((string)x.Tag == "enemy")
                        {
                            if ((string)x.Name == "Kongi")
                            {
                                hero.health = 0;
                                break;
                            }
                            if (x.Left < hero.item.Left || x.Right > hero.item.Right)
                            {
                                if (x.Visible == false)
                                    continue;

                                hero.health -= 25;

                                if (hero.health == 0)
                                {
                                    Gametimer.Stop();
                                    txtScore.Text = "Score: " + score + Environment.NewLine + "You failed to stay alive \nYou Lost!";
                                    if (score == highscore)
                                        txthigh.Text = "Score: " + highscore + Environment.NewLine + "You Set a new record";
                                    else
                                        txthigh.Text = "Score: " + highscore + Environment.NewLine + "Try harder";
                                    str.Enabled = true;
                                    selector.Enabled = true;
                                    ext.Enabled = true;
                                    snap.Enabled = true;
                                    pause.Enabled = true;
                                    saveButton.Enabled = true;
                                    loadButton.Enabled = true;
                                    Helperbtn.Enabled = true;

                                }
                                if (hero.health > 0)
                                    prog.progressBar.Value = Convert.ToInt32(hero.health);
                                else
                                    prog.progressBar.Value = 0;

                                x.Visible = false;
                                System.Threading.Timer timer = null;
                                timer = new System.Threading.Timer((state) =>
                                {
                                    x.Invoke((MethodInvoker)delegate
                                    {
                                        x.Visible = true;
                                    });
                                    timer.Dispose();
                                }, null, 10000, Timeout.Infinite);
                            }
                            else
                            {
                                if (hero.item.Bounds.Bottom > x.Bounds.Top && x.Visible == true)
                                    score += 10;

                                x.Visible = false;
                                System.Threading.Timer timer = null;
                                timer = new System.Threading.Timer((state) =>
                                {
                                    if (x.InvokeRequired)
                                    {
                                        x.Invoke((MethodInvoker)delegate
                                        {
                                            x.Visible = true;
                                        });
                                    }
                                    else
                                    {
                                        x.Visible = true;
                                    }
                                    timer.Dispose();
                                }, null, 5000, Timeout.Infinite);
                            }
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            selector.Text = ("Change player:\nPrincess Peach");
            if (hero.who)
            {
                hero.who = false;
                selector.Text = "Change player:\nMario";
            }
            else
            {
                hero.who = true;
                selector.Text = "Change player:\nPrincess Peach";
            }
        }
        private void BananaTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (gameStarted)
            {
                Banana banana = new Banana(monkey.item.Left, monkey.item.Top, hero, gameStarted);
                bananaList.Add(banana);

                this.BeginInvoke((MethodInvoker)delegate
                {
                    Controls.Add(banana.Item);
                    banana.Item.BringToFront();
                });
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                hero.moveLeft = true;

            if (e.KeyCode == Keys.Right)
                hero.moveRight = true;

            if (e.KeyCode == Keys.Up && hero.jumping == false)
            {
                hero.jumping = true;
                hero.jumpSpeed = -10;
            }
        }


        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
                hero.moveLeft = false;

            if (e.KeyCode == Keys.Right)
                hero.moveRight = false;
        }
        private void RestartGame()
        {
            gameStarted = true;
            hero.health = 100;
            prog.progressBar.Value = Convert.ToInt32(hero.health);
            mashArray[0].item.Left = 180;
            mashArray[0].item.Top = 498;
            mashArray[1].item.Left = 100;
            mashArray[1].item.Top = 498;
            mashArray[2].item.Left = 29;
            mashArray[2].item.Top = 498;
            mashArray[3].item.Left = 173;
            mashArray[3].item.Top = 430;
            mashArray[4].item.Left = 260;
            mashArray[4].item.Top = 362;
            mashArray[5].item.Left = 333;
            mashArray[5].item.Top = 362;
            mashArray[6].item.Left = 60;
            mashArray[6].item.Top = 295;
            mashArray[7].item.Left = 100;
            mashArray[7].item.Top = 295;
            mashArray[8].item.Left = 140;
            mashArray[8].item.Top = 295;
            mashArray[9].item.Left = 321;
            mashArray[9].item.Top = 227;
            mashArray[10].item.Left = 103;
            mashArray[10].item.Top = 152;
            mashArray[11].item.Left = 155;
            mashArray[11].item.Top = 152;
            mashArray[12].item.Left = 312;
            mashArray[12].item.Top = 79;
            hero.item.Left = 312;
            hero.item.Top = 473;
            selector.Enabled = false;
            pause.Enabled = false;
            ext.Enabled = false;
            str.Enabled = false;
            snap.Enabled = false;
            saveButton.Enabled = false;
            loadButton.Enabled = false;
            hero.jumping = false;
            Helperbtn.Enabled = false;
            hero.moveLeft = false;
            hero.moveRight = false;
            score = 0;
            txtScore.Text = "Score:" + score;
            foreach (Control X in this.Controls)
            {
                if (X is PictureBox && X.Visible == false)
                    X.Visible = true;
            }
            Gametimer.Start();
        }


        private void str_Click(object sender, EventArgs e)
        {
            gameStarted = true;
            RestartGame();
            Gametimer.Start();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public int highest(int highscore, int score)
        {
            if (score > highscore)
                highscore = score;
            return highscore;
        }

        private void snap_Click(object sender, EventArgs e)
        {
            Panel panel = morio;
            Bitmap screenshot = new Bitmap(panel.Width, panel.Height);
            using (Graphics graphics = Graphics.FromImage(screenshot))
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is Label label)
                    {
                        Point labelLocation = label.Location;
                        label.DrawToBitmap(screenshot, new Rectangle(labelLocation, label.Size));
                    }
                }
            }
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Image|*.png";
            saveFile.Title = "Save Screenshot";
            saveFile.ShowDialog();

            if (saveFile.FileName != "")
                screenshot.Save(saveFile.FileName, ImageFormat.Png);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (song == true)
            {
                music.Stop();
                song = false;
            }
            else
            {
                music.Play();
                song = true;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Data File|*.dat";
            saveFile.Title = "Save Game Data";
            saveFile.ShowDialog();

            if (!string.IsNullOrWhiteSpace(saveFile.FileName))
            {
                string filePath = saveFile.FileName;
                SaveGameData(filePath);
            }
        }
        private void SaveGameData(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, score);
                    binaryFormatter.Serialize(fileStream, highscore);
                    binaryFormatter.Serialize(fileStream, hero.health);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save data." + ex.Message);
            }
        }
        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Data|*.dat";
            openFile.Title = "Load Game Data";
            openFile.ShowDialog();

            if (!string.IsNullOrWhiteSpace(openFile.FileName))
            {
                string filePath = openFile.FileName;
                LoadGameData(filePath);
            }
        }

        private void LoadGameData(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    score = (int)binaryFormatter.Deserialize(fileStream);
                    highscore = (int)binaryFormatter.Deserialize(fileStream);
                    hero.health = (int)binaryFormatter.Deserialize(fileStream);
                    prog.progressBar.Value = hero.health;
                    txtScore.Text = "Score: " + score;
                    txthigh.Text = "Highest Score: " + highscore;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load data" + ex.Message);
            }
        }
        private void Helperbtn_CheckedChanged_1(object sender, EventArgs e)
        { 
            if (Helperbtn.Checked)
            {
                easy = new Helper(new Point(10, 10), 25, 25);
                morio.MouseDown += Panel1_MouseDown;
                morio.MouseMove += Panel1_MouseMove;
                morio.Paint += Panel1_Paint;
            }
            else
            {
                morio.MouseDown -= Panel1_MouseDown;
                morio.MouseMove -= Panel1_MouseMove;
                morio.Paint -= Panel1_Paint;
                easy = null;
                morio.Invalidate();
            }
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (easy == null)
                easy = new Helper(new Point(10, 10), 25, 25);
            if (gameStarted == true)
            {
                easy.Location = e.Location;
                morio.Invalidate();
            }
        }
        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && easy != null && gameStarted == true)
            {
                easy.Location = e.Location;
                morio.Invalidate();
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "enemy" && easy.IntersectsWith(x))
                {
                    if ((string)x.Name == "Kongi")
                        break;

                    x.Visible = false;
                    System.Threading.Timer timer = null;
                    timer = new System.Threading.Timer((state) =>
                    {
                        x.Invoke((MethodInvoker)delegate
                        {
                            x.Visible = true;
                        });
                        timer.Dispose();
                    }, null, 10000, Timeout.Infinite);
                }
            }
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (easy != null)
                easy.Draw(e.Graphics);
        }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
        private void Game_Load(object sender, EventArgs e) {}
        private void txtScore_Click(object sender, EventArgs e) { }
    }
}