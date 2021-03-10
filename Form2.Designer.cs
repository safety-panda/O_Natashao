
namespace O_Natashao
{
    partial class Form2
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
            this.okayButton = new System.Windows.Forms.Button();
            this.oneillioPicturebox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.oneilloLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.aboutTextbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.oneillioPicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // okayButton
            // 
            this.okayButton.Location = new System.Drawing.Point(206, 343);
            this.okayButton.Name = "okayButton";
            this.okayButton.Size = new System.Drawing.Size(99, 34);
            this.okayButton.TabIndex = 0;
            this.okayButton.Text = "Okay";
            this.okayButton.UseVisualStyleBackColor = true;
            this.okayButton.Click += new System.EventHandler(this.okayButton_Click);
            // 
            // oneillioPicturebox
            // 
            this.oneillioPicturebox.BackgroundImage = global::O_Natashao.Properties.Resources.aboutImage;
            this.oneillioPicturebox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.oneillioPicturebox.Location = new System.Drawing.Point(31, 39);
            this.oneillioPicturebox.Name = "oneillioPicturebox";
            this.oneillioPicturebox.Size = new System.Drawing.Size(230, 260);
            this.oneillioPicturebox.TabIndex = 2;
            this.oneillioPicturebox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(488, 304);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // oneilloLabel
            // 
            this.oneilloLabel.AutoSize = true;
            this.oneilloLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneilloLabel.Location = new System.Drawing.Point(318, 39);
            this.oneilloLabel.Name = "oneilloLabel";
            this.oneilloLabel.Size = new System.Drawing.Size(122, 37);
            this.oneilloLabel.TabIndex = 3;
            this.oneilloLabel.Text = "ONeillo";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.Location = new System.Drawing.Point(340, 76);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(75, 37);
            this.versionLabel.TabIndex = 4;
            this.versionLabel.Text = "v1.0";
            // 
            // aboutTextbox
            // 
            this.aboutTextbox.Location = new System.Drawing.Point(277, 116);
            this.aboutTextbox.Multiline = true;
            this.aboutTextbox.Name = "aboutTextbox";
            this.aboutTextbox.Size = new System.Drawing.Size(211, 183);
            this.aboutTextbox.TabIndex = 5;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 389);
            this.Controls.Add(this.aboutTextbox);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.oneilloLabel);
            this.Controls.Add(this.oneillioPicturebox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.okayButton);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.oneillioPicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okayButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox oneillioPicturebox;
        private System.Windows.Forms.Label oneilloLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.TextBox aboutTextbox;
    }
}