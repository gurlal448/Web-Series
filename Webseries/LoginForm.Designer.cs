namespace MyMovieStore
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1start = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1stop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1start
            // 
            this.button1start.BackgroundImage = global::MyMovieStore.Properties.Resources.start;
            this.button1start.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1start.FlatAppearance.BorderSize = 0;
            this.button1start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1start.Location = new System.Drawing.Point(422, 350);
            this.button1start.Name = "button1start";
            this.button1start.Size = new System.Drawing.Size(138, 52);
            this.button1start.TabIndex = 2;
            this.button1start.UseVisualStyleBackColor = true;
            this.button1start.Click += new System.EventHandler(this.button1start_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::MyMovieStore.Properties.Resources.series_rental;
            this.pictureBox2.Location = new System.Drawing.Point(388, 140);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(363, 160);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MyMovieStore.Properties.Resources.movie;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 542);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1stop
            // 
            this.button1stop.BackgroundImage = global::MyMovieStore.Properties.Resources.stop;
            this.button1stop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1stop.FlatAppearance.BorderSize = 0;
            this.button1stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1stop.Location = new System.Drawing.Point(603, 350);
            this.button1stop.Name = "button1stop";
            this.button1stop.Size = new System.Drawing.Size(138, 52);
            this.button1stop.TabIndex = 3;
            this.button1stop.UseVisualStyleBackColor = true;
            this.button1stop.Click += new System.EventHandler(this.button1stop_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 542);
            this.Controls.Add(this.button1stop);
            this.Controls.Add(this.button1start);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Series Rental System";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button button1start;
        private System.Windows.Forms.Button button1stop;
    }
}