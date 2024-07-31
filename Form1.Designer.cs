
namespace Staying_alive
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.Gametimer = new System.Windows.Forms.Timer(this.components);
            this.morio = new System.Windows.Forms.Panel();
            this.txtScore = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.txthigh = new System.Windows.Forms.Label();
            this.Helperbtn = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.pause = new System.Windows.Forms.Button();
            this.snap = new System.Windows.Forms.Button();
            this.ext = new System.Windows.Forms.Button();
            this.str = new System.Windows.Forms.Button();
            this.selector = new System.Windows.Forms.Button();
            this.morio.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gametimer
            // 
            this.Gametimer.Enabled = true;
            this.Gametimer.Interval = 20;
            this.Gametimer.Tick += new System.EventHandler(this.GametimerEvent);
            // 
            // morio
            // 
            this.morio.BackColor = System.Drawing.Color.Beige;
            this.morio.Controls.Add(this.txtScore);
            this.morio.Location = new System.Drawing.Point(16, -2);
            this.morio.Margin = new System.Windows.Forms.Padding(4);
            this.morio.Name = "morio";
            this.morio.Size = new System.Drawing.Size(475, 681);
            this.morio.TabIndex = 0;
            this.morio.Tag = "Coin";
            this.morio.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScore.Location = new System.Drawing.Point(4, 0);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(334, 114);
            this.txtScore.TabIndex = 18;
            this.txtScore.Text = "Score:0";
            this.txtScore.Click += new System.EventHandler(this.txtScore_Click);
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Kristen ITC", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(16, 682);
            this.info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(471, 87);
            this.info.TabIndex = 38;
            this.info.Text = "Arrow keys to move, up arrow key to jump. \r\nThe goal is to earn as many points as" +
    " possible, mushroom jumps worth double coins.";
            this.info.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txthigh
            // 
            this.txthigh.Font = new System.Drawing.Font("Kristen ITC", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthigh.ForeColor = System.Drawing.Color.Navy;
            this.txthigh.Location = new System.Drawing.Point(497, -2);
            this.txthigh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.txthigh.Name = "txthigh";
            this.txthigh.Size = new System.Drawing.Size(129, 153);
            this.txthigh.TabIndex = 19;
            this.txthigh.Tag = "Highest ";
            this.txthigh.Text = "Highest \r\nScore:0";
            // 
            // Helperbtn
            // 
            this.Helperbtn.AccessibleDescription = "";
            this.Helperbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Helperbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Helperbtn.Location = new System.Drawing.Point(511, 207);
            this.Helperbtn.Name = "Helperbtn";
            this.Helperbtn.Size = new System.Drawing.Size(115, 32);
            this.Helperbtn.TabIndex = 46;
            this.Helperbtn.Text = "Easy Mode";
            this.toolTip1.SetToolTip(this.Helperbtn, resources.GetString("Helperbtn.ToolTip"));
            this.Helperbtn.UseVisualStyleBackColor = true;
            this.Helperbtn.CheckedChanged += new System.EventHandler(this.Helperbtn_CheckedChanged_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 754);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(629, 26);
            this.statusStrip1.TabIndex = 47;
            this.statusStrip1.Text = "©";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(519, 20);
            this.toolStripStatusLabel1.Text = "©All rights reserved. Copyrights owned by Yonatan Reznikov and Mor Moshe.";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(151, 20);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // loadButton
            // 
            this.loadButton.BackgroundImage = global::Staying_alive.Properties.Resources.grey_buttoms;
            this.loadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loadButton.Location = new System.Drawing.Point(502, 489);
            this.loadButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(115, 39);
            this.loadButton.TabIndex = 45;
            this.loadButton.Text = "Load Game";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackgroundImage = global::Staying_alive.Properties.Resources.grey_buttoms;
            this.saveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.saveButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveButton.Location = new System.Drawing.Point(502, 429);
            this.saveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 39);
            this.saveButton.TabIndex = 44;
            this.saveButton.Text = "Save Game";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // pause
            // 
            this.pause.BackgroundImage = global::Staying_alive.Properties.Resources.grey_buttoms;
            this.pause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pause.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pause.Location = new System.Drawing.Point(502, 550);
            this.pause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pause.Name = "pause";
            this.pause.Size = new System.Drawing.Size(115, 53);
            this.pause.TabIndex = 43;
            this.pause.Text = "Play/Stop Music";
            this.pause.UseVisualStyleBackColor = true;
            this.pause.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // snap
            // 
            this.snap.BackgroundImage = global::Staying_alive.Properties.Resources.grey_buttoms;
            this.snap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.snap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.snap.Location = new System.Drawing.Point(502, 365);
            this.snap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.snap.Name = "snap";
            this.snap.Size = new System.Drawing.Size(115, 39);
            this.snap.TabIndex = 42;
            this.snap.Text = "Snap Score";
            this.snap.UseVisualStyleBackColor = true;
            this.snap.Click += new System.EventHandler(this.snap_Click);
            // 
            // ext
            // 
            this.ext.BackgroundImage = global::Staying_alive.Properties.Resources.red_buttom;
            this.ext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ext.Location = new System.Drawing.Point(502, 631);
            this.ext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ext.Name = "ext";
            this.ext.Size = new System.Drawing.Size(115, 39);
            this.ext.TabIndex = 41;
            this.ext.Text = "Exit";
            this.ext.UseVisualStyleBackColor = true;
            this.ext.Click += new System.EventHandler(this.button1_Click);
            // 
            // str
            // 
            this.str.BackgroundImage = global::Staying_alive.Properties.Resources.green_buttoms;
            this.str.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.str.Cursor = System.Windows.Forms.Cursors.Hand;
            this.str.Location = new System.Drawing.Point(502, 153);
            this.str.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.str.Name = "str";
            this.str.Size = new System.Drawing.Size(115, 39);
            this.str.TabIndex = 40;
            this.str.Text = "Start";
            this.str.UseVisualStyleBackColor = true;
            this.str.Click += new System.EventHandler(this.str_Click);
            // 
            // selector
            // 
            this.selector.BackgroundImage = global::Staying_alive.Properties.Resources.grey_buttoms;
            this.selector.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.selector.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selector.Location = new System.Drawing.Point(502, 261);
            this.selector.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.selector.Name = "selector";
            this.selector.Size = new System.Drawing.Size(115, 73);
            this.selector.TabIndex = 39;
            this.selector.Text = "Change player:\r\nPrincess Peach";
            this.selector.UseVisualStyleBackColor = true;
            this.selector.Click += new System.EventHandler(this.button2_Click);
            // 
            // Game
            // 
            this.AccessibleDescription = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(629, 780);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Helperbtn);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.txthigh);
            this.Controls.Add(this.pause);
            this.Controls.Add(this.snap);
            this.Controls.Add(this.ext);
            this.Controls.Add(this.str);
            this.Controls.Add(this.morio);
            this.Controls.Add(this.selector);
            this.Controls.Add(this.info);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "game";
            this.Text = "Staying Alive!";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.KeyIsUp);
            this.morio.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Gametimer;
        private System.Windows.Forms.Panel morio;
        private System.Windows.Forms.Label txtScore;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button selector;
        private System.Windows.Forms.Button str;
        private System.Windows.Forms.Button ext;
        private System.Windows.Forms.Button snap;
        private System.Windows.Forms.Button pause;
        private System.Windows.Forms.Label txthigh;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.CheckBox Helperbtn;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}

