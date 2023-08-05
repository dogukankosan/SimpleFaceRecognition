namespace Simple_Face_Recognition_App
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnTrain = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.pctNowUser = new System.Windows.Forms.PictureBox();
            this.pctOldUser = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNowUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOldUser)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Dock = System.Windows.Forms.DockStyle.Left;
            this.picCapture.Location = new System.Drawing.Point(0, 0);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(653, 450);
            this.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(666, 12);
            this.txtPersonName.MaxLength = 20;
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(122, 20);
            this.txtPersonName.TabIndex = 0;
            this.txtPersonName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPersonName_KeyPress);
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTrain.Location = new System.Drawing.Point(666, 341);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(122, 23);
            this.btnTrain.TabIndex = 2;
            this.btnTrain.Text = "Kişiyi Tanı";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // picDetected
            // 
            this.picDetected.Location = new System.Drawing.Point(663, 75);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(123, 123);
            this.picDetected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDetected.TabIndex = 7;
            this.picDetected.TabStop = false;
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPerson.Location = new System.Drawing.Point(665, 38);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(123, 23);
            this.btnAddPerson.TabIndex = 1;
            this.btnAddPerson.Text = "Kişiyi Ekle";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // pctNowUser
            // 
            this.pctNowUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctNowUser.Location = new System.Drawing.Point(666, 370);
            this.pctNowUser.Name = "pctNowUser";
            this.pctNowUser.Size = new System.Drawing.Size(63, 68);
            this.pctNowUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctNowUser.TabIndex = 10;
            this.pctNowUser.TabStop = false;
            // 
            // pctOldUser
            // 
            this.pctOldUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pctOldUser.Location = new System.Drawing.Point(727, 370);
            this.pctOldUser.Name = "pctOldUser";
            this.pctOldUser.Size = new System.Drawing.Size(61, 68);
            this.pctOldUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctOldUser.TabIndex = 10;
            this.pctOldUser.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(794, 450);
            this.Controls.Add(this.pctOldUser);
            this.Controls.Add(this.pctNowUser);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.picCapture);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görüntü İşleme";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctNowUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctOldUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.PictureBox pctNowUser;
        private System.Windows.Forms.PictureBox pctOldUser;
    }
}

