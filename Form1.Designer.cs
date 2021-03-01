
namespace O_Natashao
{
    partial class Form1
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
            this.checkerBoardText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.p1NameBox = new System.Windows.Forms.TextBox();
            this.p2NameBox = new System.Windows.Forms.TextBox();
            this.p2CounterImage = new System.Windows.Forms.PictureBox();
            this.p1CounterImage = new System.Windows.Forms.PictureBox();
            this.playersInfoBox = new System.Windows.Forms.PictureBox();
            this.p1XLabel = new System.Windows.Forms.Label();
            this.p1CountersRemaingLabel = new System.Windows.Forms.Label();
            this.p2XLabel = new System.Windows.Forms.Label();
            this.p2CountersRemaingLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.p2CounterImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1CounterImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersInfoBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkerBoardText
            // 
            this.checkerBoardText.Location = new System.Drawing.Point(289, 136);
            this.checkerBoardText.Multiline = true;
            this.checkerBoardText.Name = "checkerBoardText";
            this.checkerBoardText.Size = new System.Drawing.Size(124, 125);
            this.checkerBoardText.TabIndex = 0;
            this.checkerBoardText.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 285);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "infinate board";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // p1NameBox
            // 
            this.p1NameBox.Location = new System.Drawing.Point(126, 601);
            this.p1NameBox.Name = "p1NameBox";
            this.p1NameBox.Size = new System.Drawing.Size(141, 20);
            this.p1NameBox.TabIndex = 3;
            // 
            // p2NameBox
            // 
            this.p2NameBox.Location = new System.Drawing.Point(446, 601);
            this.p2NameBox.Name = "p2NameBox";
            this.p2NameBox.Size = new System.Drawing.Size(142, 20);
            this.p2NameBox.TabIndex = 4;
            // 
            // p2CounterImage
            // 
            this.p2CounterImage.BackColor = System.Drawing.Color.Transparent;
            this.p2CounterImage.BackgroundImage = global::O_Natashao.Properties.Resources._0;
            this.p2CounterImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2CounterImage.Location = new System.Drawing.Point(408, 590);
            this.p2CounterImage.Name = "p2CounterImage";
            this.p2CounterImage.Size = new System.Drawing.Size(32, 31);
            this.p2CounterImage.TabIndex = 6;
            this.p2CounterImage.TabStop = false;
            // 
            // p1CounterImage
            // 
            this.p1CounterImage.BackColor = System.Drawing.Color.Transparent;
            this.p1CounterImage.BackgroundImage = global::O_Natashao.Properties.Resources._1;
            this.p1CounterImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1CounterImage.Location = new System.Drawing.Point(89, 590);
            this.p1CounterImage.Name = "p1CounterImage";
            this.p1CounterImage.Size = new System.Drawing.Size(31, 31);
            this.p1CounterImage.TabIndex = 5;
            this.p1CounterImage.TabStop = false;
            // 
            // playersInfoBox
            // 
            this.playersInfoBox.BackColor = System.Drawing.Color.RosyBrown;
            this.playersInfoBox.Location = new System.Drawing.Point(18, 561);
            this.playersInfoBox.Name = "playersInfoBox";
            this.playersInfoBox.Size = new System.Drawing.Size(632, 74);
            this.playersInfoBox.TabIndex = 2;
            this.playersInfoBox.TabStop = false;
            // 
            // p1XLabel
            // 
            this.p1XLabel.BackColor = System.Drawing.Color.RosyBrown;
            this.p1XLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1XLabel.Location = new System.Drawing.Point(67, 590);
            this.p1XLabel.Name = "p1XLabel";
            this.p1XLabel.Size = new System.Drawing.Size(24, 31);
            this.p1XLabel.TabIndex = 7;
            this.p1XLabel.Text = "x";
            // 
            // p1CountersRemaingLabel
            // 
            this.p1CountersRemaingLabel.BackColor = System.Drawing.Color.RosyBrown;
            this.p1CountersRemaingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1CountersRemaingLabel.Location = new System.Drawing.Point(28, 593);
            this.p1CountersRemaingLabel.Name = "p1CountersRemaingLabel";
            this.p1CountersRemaingLabel.Size = new System.Drawing.Size(41, 31);
            this.p1CountersRemaingLabel.TabIndex = 8;
            this.p1CountersRemaingLabel.Text = "2";
            // 
            // p2XLabel
            // 
            this.p2XLabel.BackColor = System.Drawing.Color.RosyBrown;
            this.p2XLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2XLabel.Location = new System.Drawing.Point(378, 589);
            this.p2XLabel.Name = "p2XLabel";
            this.p2XLabel.Size = new System.Drawing.Size(24, 31);
            this.p2XLabel.TabIndex = 9;
            this.p2XLabel.Text = "x";
            // 
            // p2CountersRemaingLabel
            // 
            this.p2CountersRemaingLabel.BackColor = System.Drawing.Color.RosyBrown;
            this.p2CountersRemaingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2CountersRemaingLabel.Location = new System.Drawing.Point(331, 593);
            this.p2CountersRemaingLabel.Name = "p2CountersRemaingLabel";
            this.p2CountersRemaingLabel.Size = new System.Drawing.Size(41, 31);
            this.p2CountersRemaingLabel.TabIndex = 10;
            this.p2CountersRemaingLabel.Text = "2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(662, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(662, 647);
            this.Controls.Add(this.p2CountersRemaingLabel);
            this.Controls.Add(this.p2XLabel);
            this.Controls.Add(this.p1CountersRemaingLabel);
            this.Controls.Add(this.p1XLabel);
            this.Controls.Add(this.p2CounterImage);
            this.Controls.Add(this.p1CounterImage);
            this.Controls.Add(this.p2NameBox);
            this.Controls.Add(this.p1NameBox);
            this.Controls.Add(this.playersInfoBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkerBoardText);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.p2CounterImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1CounterImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.playersInfoBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox checkerBoardText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox playersInfoBox;
        private System.Windows.Forms.TextBox p1NameBox;
        private System.Windows.Forms.TextBox p2NameBox;
        private System.Windows.Forms.PictureBox p1CounterImage;
        private System.Windows.Forms.PictureBox p2CounterImage;
        private System.Windows.Forms.Label p1XLabel;
        private System.Windows.Forms.Label p1CountersRemaingLabel;
        private System.Windows.Forms.Label p2XLabel;
        private System.Windows.Forms.Label p2CountersRemaingLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

