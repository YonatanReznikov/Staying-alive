using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Staying_alive
{
    [Serializable]
    public abstract class Classes
    {
        public int health;
        protected bool isMoving;
        protected int speed;
        public PictureBox item;
        public string direction;


        public Classes()
        {
            isMoving = false;
            speed = 0;
        }

        public abstract void MoveLeft();
        public abstract void MoveRight();

    }
    [Serializable]
    public class MainCharacter : Classes
    {
        public Grass currentGrass, prevGrass;
        public bool jumping = false, moveLeft, moveRight, who = true;
        public int jumpSpeed, force = 2;
        public bool inAir;
        public new int speed=5;

        public MainCharacter()
        {
            item = new PictureBox();
            item.Size = new Size(40, 50);
            item.SizeMode = PictureBoxSizeMode.StretchImage;
            item.Image = Properties.Resources.Mario_left;
            item.BackColor = Color.Beige;
            item.Left = 312;
            item.Top = 473;
            health = 100;

        }

        public override void MoveLeft()
        {
            moveLeft = true;
            direction = "Left";
            ChangeImage(who, direction);
            if (moveLeft == true && item.Left > 0)
                item.Left -= speed;
        }

        public override void MoveRight()
        {
            moveRight = true;
            direction = "Right";
            ChangeImage(who, direction);
            if (moveRight == true && item.Left + item.Width < 365)
                item.Left += speed;
        }
        public void jump()
        {
            item.Top += jumpSpeed;
            jumpSpeed += force / 7;
            inAir = true;
        }
        public void ChangeImage(bool who, string direction)
        {
            if (who)
            {
                item.Size = new Size(40, 50);
                if (direction == "Left")
                    item.Image = Properties.Resources.Mario_left;
                else if (direction == "Right")
                    item.Image = Properties.Resources.Mario_right;
            }
            else
            {
                item.Size =new Size(25, 43);
                if (direction == "Left")
                    item.Image = Properties.Resources.Princess_Peach_left;
                else if (direction == "Right")
                    item.Image = Properties.Resources.Princess_Peach_right;
            }
        }
    }

    [Serializable]
    public abstract class Enemy : Classes
    {
        public new int speed;
        public Enemy()
        {
            item = new PictureBox();
            item.SizeMode = PictureBoxSizeMode.StretchImage;
            item.BackColor = Color.Beige;
            item.Tag = "enemy";
        }

        public abstract override void MoveLeft();

        public abstract override void MoveRight();

    }
    [Serializable]

    public class Mashroom : Enemy
    {
        public Mashroom(int x, int y)
        {
            item.Image = Properties.Resources.Mashroom;
            item.Size = new Size(22, 21);
            item.Visible = true;
            item.Left = x;
            item.Top = y;
            speed = 2;
            item.Left -= speed;

        }
        public override void MoveLeft() { }

        public override void MoveRight() { }
        public void MoveLeft(Mashroom a, Grass b)
        {
            a.item.Left -= speed;
            if (a.item.Left < b.Item.Left || a.item.Left + a.item.Width > b.Item.Left + b.Item.Width)
                speed = -speed;
        }
    }
    [Serializable]

    public class Kong : Enemy
    {
        public Kong(int x, int y)
        {
            item.Image = Properties.Resources.Kong_right;
            item.Name = "Kongi";
            item.Size = new Size(55, 60);
            item.Visible = true;
            item.Left = x;
            item.Top = y;
            speed = 1;
            item.Left -= speed;
        }
        public void MoveLeft(Kong a, Grass b)
        {
            a.item.Left -= speed;
            if (a.item.Left < b.Item.Left)
            {
                speed = -speed;
                a.item.Image = Properties.Resources.Kong_right;
            }

            if (a.item.Left + a.item.Width > b.Item.Left + b.Item.Width)
            {
                speed = -speed;
                a.item.Image = Properties.Resources.kong_left;
            }
        }
        public override void MoveLeft() { }
        public override void MoveRight() { }
    }
    [Serializable]
    public class Grass
    {
        public static PictureBox grass;
        public PictureBox Item { get; }

        public Grass(int x, int y, int sizex, int sizey)
        {
            Item = new PictureBox();
            Item.Image = Properties.Resources.Grass;
            Item.Size = new Size(sizex, sizey);
            Item.SizeMode = PictureBoxSizeMode.StretchImage;
            Item.BackColor = Color.Transparent;
            Item.Tag = "grass";
            Item.Left = x;
            Item.Top = y;
        }
    }
    [Serializable]
    public class Coins
    {
        public PictureBox Item { get; }
        public Coins(int x, int y)
        {
            Item = new PictureBox();
            Item.Image = Properties.Resources.Coin1;
            Item.Size = new Size(22, 20);
            Item.SizeMode = PictureBoxSizeMode.StretchImage;
            Item.BackColor = Color.Transparent;
            Item.Tag = "coins";
            Item.Left = x;
            Item.Top = y;
        }
    }
    [Serializable]
    public class Banana
    {
        private PictureBox item;
        private int speed;
        private MainCharacter player;
        private bool gameStarted;

        public Banana(int x, int y, MainCharacter player, bool gameStarted)
        {
            item = new PictureBox();
            item.Image = Properties.Resources.WhatsApp_Image_2023_05_16_at_14_36_34;
            item.Size = new Size(22, 20);
            item.SizeMode = PictureBoxSizeMode.StretchImage;
            item.BackColor = Color.Transparent;
            item.Tag = "banana";
            item.Left = x;
            item.Top = y;
            speed = 3;
            this.player = player;
            this.gameStarted = gameStarted;
        }
        public PictureBox Item
        {
            get { return item; }
        }

        public void MoveTowardsCurrentGrass(Grass currentGrass, MainCharacter player, Bar prog)
        {
            if (gameStarted)
            {
                int X = currentGrass.Item.Left - this.item.Left;
                int Y = currentGrass.Item.Top - this.item.Top;
                double distance = Math.Sqrt(X * X + Y * Y);

                int moveX = (int)(X / distance * speed);
                int moveY = (int)(Y / distance * speed);

                this.item.Left += moveX;
                this.item.Top += moveY;

                if (this.item.Bounds.IntersectsWith(currentGrass.Item.Bounds))
                    this.item.Dispose();
            }
        }
    }

    [Serializable]
    public class Bar
    {
        public ProgressBar progressBar;

        public  Bar()
        {
            progressBar = new ProgressBar();
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Value = 100;
            progressBar.Size = new Size(110, 15);
            progressBar.Location = new Point(245, 10);
        }
    }
    public class Helper
    {
        public Point Location { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }

        public Helper(Point location, float width, float height)
        {
            Location = location;
            Width = width;
            Height = height;
        }
        public bool IntersectsWith(Control x)
        {
            RectangleF thisRect = new RectangleF(Location.X - Width / 2, Location.Y - Height / 2, Width, Height);
            RectangleF otherRect = new RectangleF(x.Location.X - x.Width / 2, x.Location.Y - x.Height / 2, x.Width, x.Height);

            return thisRect.IntersectsWith(otherRect);
        }

        public void Draw(Graphics g)
        {
            float x = Location.X - Width / 2;
            float y = Location.Y - Height / 2;

            SolidBrush brush = new SolidBrush(Color.Yellow);
            Pen pen = new Pen(Color.Orange, 2);
            g.FillRectangle(brush, x, y, Width, Height);
            g.DrawRectangle(pen, x, y, Width, Height);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
    }
}