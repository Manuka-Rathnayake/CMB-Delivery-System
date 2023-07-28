namespace CMB_Delivery_Management
{
    partial class DriverCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DriverCard));
            this.DriverImage = new System.Windows.Forms.PictureBox();
            this.DriverID = new System.Windows.Forms.Label();
            this.DriverName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DriverImage)).BeginInit();
            this.SuspendLayout();
            // 
            // DriverImage
            // 
            this.DriverImage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("DriverImage.BackgroundImage")));
            this.DriverImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.DriverImage.Location = new System.Drawing.Point(13, 21);
            this.DriverImage.Margin = new System.Windows.Forms.Padding(2);
            this.DriverImage.Name = "DriverImage";
            this.DriverImage.Size = new System.Drawing.Size(47, 45);
            this.DriverImage.TabIndex = 41;
            this.DriverImage.TabStop = false;
            // 
            // DriverID
            // 
            this.DriverID.AutoSize = true;
            this.DriverID.BackColor = System.Drawing.Color.RoyalBlue;
            this.DriverID.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriverID.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DriverID.Location = new System.Drawing.Point(280, 30);
            this.DriverID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DriverID.Name = "DriverID";
            this.DriverID.Padding = new System.Windows.Forms.Padding(5);
            this.DriverID.Size = new System.Drawing.Size(84, 27);
            this.DriverID.TabIndex = 40;
            this.DriverID.Text = "#1224567";
            // 
            // DriverName
            // 
            this.DriverName.AutoSize = true;
            this.DriverName.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DriverName.Location = new System.Drawing.Point(78, 31);
            this.DriverName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DriverName.Name = "DriverName";
            this.DriverName.Size = new System.Drawing.Size(118, 26);
            this.DriverName.TabIndex = 39;
            this.DriverName.Text = " John Doe";
            // 
            // DriverCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.DriverImage);
            this.Controls.Add(this.DriverID);
            this.Controls.Add(this.DriverName);
            this.Name = "DriverCard";
            this.Size = new System.Drawing.Size(377, 86);
            ((System.ComponentModel.ISupportInitialize)(this.DriverImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox DriverImage;
        public System.Windows.Forms.Label DriverID;
        public System.Windows.Forms.Label DriverName;
    }
}
