namespace Lab5
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
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.blurPictureBox = new System.Windows.Forms.PictureBox();
            this.cannyPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contourPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.contourLabel = new System.Windows.Forms.Label();
            this.BinaryImageBox = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.BinaryMintrackBar1 = new System.Windows.Forms.TrackBar();
            this.BinaryMaxtrackBar2 = new System.Windows.Forms.TrackBar();
            this.CannyMintrackBar5 = new System.Windows.Forms.TrackBar();
            this.CannyMaxtrackBar6 = new System.Windows.Forms.TrackBar();
            this.actionLabel1 = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.sLabel = new System.Windows.Forms.Label();
            this.LastLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryMintrackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryMaxtrackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyMintrackBar5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyMaxtrackBar6)).BeginInit();
            this.SuspendLayout();
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Location = new System.Drawing.Point(0, 309);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(239, 199);
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // blurPictureBox
            // 
            this.blurPictureBox.Location = new System.Drawing.Point(285, 12);
            this.blurPictureBox.Name = "blurPictureBox";
            this.blurPictureBox.Size = new System.Drawing.Size(239, 199);
            this.blurPictureBox.TabIndex = 1;
            this.blurPictureBox.TabStop = false;
            // 
            // cannyPictureBox
            // 
            this.cannyPictureBox.Location = new System.Drawing.Point(554, 12);
            this.cannyPictureBox.Name = "cannyPictureBox";
            this.cannyPictureBox.Size = new System.Drawing.Size(239, 199);
            this.cannyPictureBox.TabIndex = 2;
            this.cannyPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Source Image";
            // 
            // contourPictureBox
            // 
            this.contourPictureBox.Location = new System.Drawing.Point(831, 12);
            this.contourPictureBox.Name = "contourPictureBox";
            this.contourPictureBox.Size = new System.Drawing.Size(239, 199);
            this.contourPictureBox.TabIndex = 4;
            this.contourPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(905, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Decorated Image";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Blur Image";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(625, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Canny Image";
            // 
            // contourLabel
            // 
            this.contourLabel.AutoSize = true;
            this.contourLabel.Location = new System.Drawing.Point(828, 248);
            this.contourLabel.Name = "contourLabel";
            this.contourLabel.Size = new System.Drawing.Size(135, 17);
            this.contourLabel.TabIndex = 8;
            this.contourLabel.Text = "Number of Countors";
            // 
            // BinaryImageBox
            // 
            this.BinaryImageBox.Location = new System.Drawing.Point(12, 12);
            this.BinaryImageBox.Name = "BinaryImageBox";
            this.BinaryImageBox.Size = new System.Drawing.Size(239, 199);
            this.BinaryImageBox.TabIndex = 10;
            this.BinaryImageBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 214);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Binary Image";
            // 
            // BinaryMintrackBar1
            // 
            this.BinaryMintrackBar1.Location = new System.Drawing.Point(12, 230);
            this.BinaryMintrackBar1.Maximum = 255;
            this.BinaryMintrackBar1.Name = "BinaryMintrackBar1";
            this.BinaryMintrackBar1.Size = new System.Drawing.Size(239, 56);
            this.BinaryMintrackBar1.TabIndex = 12;
            this.BinaryMintrackBar1.Scroll += new System.EventHandler(this.BinaryMintrackBar1_Scroll);
            // 
            // BinaryMaxtrackBar2
            // 
            this.BinaryMaxtrackBar2.Location = new System.Drawing.Point(12, 260);
            this.BinaryMaxtrackBar2.Maximum = 255;
            this.BinaryMaxtrackBar2.Name = "BinaryMaxtrackBar2";
            this.BinaryMaxtrackBar2.Size = new System.Drawing.Size(239, 56);
            this.BinaryMaxtrackBar2.TabIndex = 13;
            this.BinaryMaxtrackBar2.Scroll += new System.EventHandler(this.BinaryMaxtrackBar2_Scroll);
            // 
            // CannyMintrackBar5
            // 
            this.CannyMintrackBar5.Location = new System.Drawing.Point(554, 230);
            this.CannyMintrackBar5.Maximum = 255;
            this.CannyMintrackBar5.Name = "CannyMintrackBar5";
            this.CannyMintrackBar5.Size = new System.Drawing.Size(239, 56);
            this.CannyMintrackBar5.TabIndex = 16;
            this.CannyMintrackBar5.Scroll += new System.EventHandler(this.CannyMintrackBar5_Scroll);
            // 
            // CannyMaxtrackBar6
            // 
            this.CannyMaxtrackBar6.Location = new System.Drawing.Point(554, 260);
            this.CannyMaxtrackBar6.Maximum = 255;
            this.CannyMaxtrackBar6.Name = "CannyMaxtrackBar6";
            this.CannyMaxtrackBar6.Size = new System.Drawing.Size(239, 56);
            this.CannyMaxtrackBar6.TabIndex = 17;
            this.CannyMaxtrackBar6.Scroll += new System.EventHandler(this.CannyMaxtrackBar6_Scroll);
            // 
            // actionLabel1
            // 
            this.actionLabel1.AutoSize = true;
            this.actionLabel1.Location = new System.Drawing.Point(388, 329);
            this.actionLabel1.Name = "actionLabel1";
            this.actionLabel1.Size = new System.Drawing.Size(86, 17);
            this.actionLabel1.TabIndex = 18;
            this.actionLabel1.Text = "Action Label";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(595, 319);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(17, 17);
            this.xLabel.TabIndex = 19;
            this.xLabel.Text = "X";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(595, 350);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(17, 17);
            this.yLabel.TabIndex = 20;
            this.yLabel.Text = "Y";
            // 
            // sLabel
            // 
            this.sLabel.AutoSize = true;
            this.sLabel.Location = new System.Drawing.Point(595, 392);
            this.sLabel.Name = "sLabel";
            this.sLabel.Size = new System.Drawing.Size(49, 17);
            this.sLabel.TabIndex = 21;
            this.sLabel.Text = "Shape";
            // 
            // LastLabel
            // 
            this.LastLabel.AutoSize = true;
            this.LastLabel.Location = new System.Drawing.Point(595, 424);
            this.LastLabel.Name = "LastLabel";
            this.LastLabel.Size = new System.Drawing.Size(35, 17);
            this.LastLabel.TabIndex = 22;
            this.LastLabel.Text = "One";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 508);
            this.Controls.Add(this.LastLabel);
            this.Controls.Add(this.sLabel);
            this.Controls.Add(this.yLabel);
            this.Controls.Add(this.xLabel);
            this.Controls.Add(this.actionLabel1);
            this.Controls.Add(this.sourcePictureBox);
            this.Controls.Add(this.CannyMaxtrackBar6);
            this.Controls.Add(this.CannyMintrackBar5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BinaryMaxtrackBar2);
            this.Controls.Add(this.BinaryMintrackBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BinaryImageBox);
            this.Controls.Add(this.contourLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contourPictureBox);
            this.Controls.Add(this.cannyPictureBox);
            this.Controls.Add(this.blurPictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blurPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contourPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryMintrackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BinaryMaxtrackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyMintrackBar5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CannyMaxtrackBar6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.PictureBox blurPictureBox;
        private System.Windows.Forms.PictureBox cannyPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox contourPictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label contourLabel;
        private System.Windows.Forms.PictureBox BinaryImageBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar BinaryMintrackBar1;
        private System.Windows.Forms.TrackBar BinaryMaxtrackBar2;
        private System.Windows.Forms.TrackBar CannyMintrackBar5;
        private System.Windows.Forms.TrackBar CannyMaxtrackBar6;
        private System.Windows.Forms.Label actionLabel1;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label sLabel;
        private System.Windows.Forms.Label LastLabel;
    }
}

