namespace Aruco
{
    partial class AforgeForm
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
            this.buttonStartCamera = new System.Windows.Forms.Button();
            this.comboBoxCameraList = new System.Windows.Forms.ComboBox();
            this.buttonStopCamera = new System.Windows.Forms.Button();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.buttonPrintboardAruco = new System.Windows.Forms.Button();
            this.useThisFrameButton = new System.Windows.Forms.Button();
            this.messageLabel = new System.Windows.Forms.Label();
            this.textBoxV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxZ = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartCamera
            // 
            this.buttonStartCamera.Enabled = false;
            this.buttonStartCamera.Location = new System.Drawing.Point(139, 27);
            this.buttonStartCamera.Name = "buttonStartCamera";
            this.buttonStartCamera.Size = new System.Drawing.Size(75, 23);
            this.buttonStartCamera.TabIndex = 1;
            this.buttonStartCamera.Text = "Start";
            this.buttonStartCamera.UseVisualStyleBackColor = true;
            this.buttonStartCamera.Click += new System.EventHandler(this.buttonStartCamera_Click);
            // 
            // comboBoxCameraList
            // 
            this.comboBoxCameraList.FormattingEnabled = true;
            this.comboBoxCameraList.Location = new System.Drawing.Point(12, 29);
            this.comboBoxCameraList.Name = "comboBoxCameraList";
            this.comboBoxCameraList.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCameraList.TabIndex = 2;
            this.comboBoxCameraList.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameraList_SelectedIndexChanged);
            // 
            // buttonStopCamera
            // 
            this.buttonStopCamera.Enabled = false;
            this.buttonStopCamera.Location = new System.Drawing.Point(220, 27);
            this.buttonStopCamera.Name = "buttonStopCamera";
            this.buttonStopCamera.Size = new System.Drawing.Size(75, 23);
            this.buttonStopCamera.TabIndex = 3;
            this.buttonStopCamera.Text = "Stop";
            this.buttonStopCamera.UseVisualStyleBackColor = true;
            this.buttonStopCamera.Click += new System.EventHandler(this.buttonStopCamera_Click);
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Location = new System.Drawing.Point(12, 69);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(368, 346);
            this.pictureBoxVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxVideo.TabIndex = 0;
            this.pictureBoxVideo.TabStop = false;
            // 
            // buttonPrintboardAruco
            // 
            this.buttonPrintboardAruco.Location = new System.Drawing.Point(305, 27);
            this.buttonPrintboardAruco.Name = "buttonPrintboardAruco";
            this.buttonPrintboardAruco.Size = new System.Drawing.Size(94, 23);
            this.buttonPrintboardAruco.TabIndex = 4;
            this.buttonPrintboardAruco.Text = "PrintBoardAruco";
            this.buttonPrintboardAruco.UseVisualStyleBackColor = true;
            this.buttonPrintboardAruco.Click += new System.EventHandler(this.buttonPrintboardAruco_Click);
            // 
            // useThisFrameButton
            // 
            this.useThisFrameButton.Location = new System.Drawing.Point(405, 27);
            this.useThisFrameButton.Name = "useThisFrameButton";
            this.useThisFrameButton.Size = new System.Drawing.Size(75, 23);
            this.useThisFrameButton.TabIndex = 5;
            this.useThisFrameButton.Text = "Calibrar";
            this.useThisFrameButton.UseVisualStyleBackColor = true;
            this.useThisFrameButton.Click += new System.EventHandler(this.useThisFrameButton_Click);
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Location = new System.Drawing.Point(13, 53);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(35, 13);
            this.messageLabel.TabIndex = 6;
            this.messageLabel.Text = "label1";
            // 
            // textBoxV
            // 
            this.textBoxV.Enabled = false;
            this.textBoxV.Location = new System.Drawing.Point(447, 227);
            this.textBoxV.Name = "textBoxV";
            this.textBoxV.Size = new System.Drawing.Size(100, 20);
            this.textBoxV.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(427, 230);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "V";
            // 
            // textBoxU
            // 
            this.textBoxU.Enabled = false;
            this.textBoxU.Location = new System.Drawing.Point(447, 201);
            this.textBoxU.Name = "textBoxU";
            this.textBoxU.Size = new System.Drawing.Size(100, 20);
            this.textBoxU.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(427, 204);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "U";
            // 
            // textBoxW
            // 
            this.textBoxW.Enabled = false;
            this.textBoxW.Location = new System.Drawing.Point(447, 253);
            this.textBoxW.Name = "textBoxW";
            this.textBoxW.Size = new System.Drawing.Size(100, 20);
            this.textBoxW.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(427, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "W";
            // 
            // textBoxZ
            // 
            this.textBoxZ.Enabled = false;
            this.textBoxZ.Location = new System.Drawing.Point(447, 149);
            this.textBoxZ.Name = "textBoxZ";
            this.textBoxZ.Size = new System.Drawing.Size(100, 20);
            this.textBoxZ.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Z";
            // 
            // textBoxY
            // 
            this.textBoxY.Enabled = false;
            this.textBoxY.Location = new System.Drawing.Point(447, 123);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(427, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Y";
            // 
            // textBoxX
            // 
            this.textBoxX.Enabled = false;
            this.textBoxX.Location = new System.Drawing.Point(447, 97);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(427, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "X";
            // 
            // AforgeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxW);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.useThisFrameButton);
            this.Controls.Add(this.buttonPrintboardAruco);
            this.Controls.Add(this.buttonStopCamera);
            this.Controls.Add(this.comboBoxCameraList);
            this.Controls.Add(this.buttonStartCamera);
            this.Controls.Add(this.pictureBoxVideo);
            this.Name = "AforgeForm";
            this.Text = "AforgeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStartCamera;
        private System.Windows.Forms.ComboBox comboBoxCameraList;
        private System.Windows.Forms.Button buttonStopCamera;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.Button buttonPrintboardAruco;
        private System.Windows.Forms.Button useThisFrameButton;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.TextBox textBoxV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxZ;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label label1;
    }
}