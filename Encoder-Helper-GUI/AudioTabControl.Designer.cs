﻿namespace Encoder_Helper_GUI
{
    partial class AudioTabControl
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
            this.TextBox_LanguageCode = new System.Windows.Forms.TextBox();
            this.Label_LanguageCode = new System.Windows.Forms.Label();
            this.TextBox_AudioTrackName = new System.Windows.Forms.TextBox();
            this.Label_AudioTrackName = new System.Windows.Forms.Label();
            this.NumericUpDown_Quality = new System.Windows.Forms.NumericUpDown();
            this.Label_AudioQuality = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Quality)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBox_LanguageCode
            // 
            this.TextBox_LanguageCode.Location = new System.Drawing.Point(202, 59);
            this.TextBox_LanguageCode.Name = "TextBox_LanguageCode";
            this.TextBox_LanguageCode.Size = new System.Drawing.Size(180, 20);
            this.TextBox_LanguageCode.TabIndex = 16;
            // 
            // Label_LanguageCode
            // 
            this.Label_LanguageCode.AutoSize = true;
            this.Label_LanguageCode.Location = new System.Drawing.Point(199, 42);
            this.Label_LanguageCode.Name = "Label_LanguageCode";
            this.Label_LanguageCode.Size = new System.Drawing.Size(144, 13);
            this.Label_LanguageCode.TabIndex = 15;
            this.Label_LanguageCode.Text = "Audio Track Language Code";
            // 
            // TextBox_AudioTrackName
            // 
            this.TextBox_AudioTrackName.Location = new System.Drawing.Point(3, 59);
            this.TextBox_AudioTrackName.Name = "TextBox_AudioTrackName";
            this.TextBox_AudioTrackName.Size = new System.Drawing.Size(169, 20);
            this.TextBox_AudioTrackName.TabIndex = 14;
            // 
            // Label_AudioTrackName
            // 
            this.Label_AudioTrackName.AutoSize = true;
            this.Label_AudioTrackName.Location = new System.Drawing.Point(3, 42);
            this.Label_AudioTrackName.Name = "Label_AudioTrackName";
            this.Label_AudioTrackName.Size = new System.Drawing.Size(96, 13);
            this.Label_AudioTrackName.TabIndex = 13;
            this.Label_AudioTrackName.Text = "Audio Track Name";
            // 
            // NumericUpDown_Quality
            // 
            this.NumericUpDown_Quality.DecimalPlaces = 2;
            this.NumericUpDown_Quality.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.NumericUpDown_Quality.Location = new System.Drawing.Point(3, 19);
            this.NumericUpDown_Quality.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDown_Quality.Name = "NumericUpDown_Quality";
            this.NumericUpDown_Quality.Size = new System.Drawing.Size(120, 20);
            this.NumericUpDown_Quality.TabIndex = 12;
            // 
            // Label_AudioQuality
            // 
            this.Label_AudioQuality.AutoSize = true;
            this.Label_AudioQuality.Location = new System.Drawing.Point(3, 3);
            this.Label_AudioQuality.Name = "Label_AudioQuality";
            this.Label_AudioQuality.Size = new System.Drawing.Size(39, 13);
            this.Label_AudioQuality.TabIndex = 11;
            this.Label_AudioQuality.Text = "Quality";
            // 
            // AudioTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TextBox_LanguageCode);
            this.Controls.Add(this.Label_LanguageCode);
            this.Controls.Add(this.TextBox_AudioTrackName);
            this.Controls.Add(this.Label_AudioTrackName);
            this.Controls.Add(this.NumericUpDown_Quality);
            this.Controls.Add(this.Label_AudioQuality);
            this.Name = "AudioTabControl";
            this.Size = new System.Drawing.Size(392, 98);
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_Quality)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBox_LanguageCode;
        private System.Windows.Forms.Label Label_LanguageCode;
        private System.Windows.Forms.TextBox TextBox_AudioTrackName;
        private System.Windows.Forms.Label Label_AudioTrackName;
        private System.Windows.Forms.NumericUpDown NumericUpDown_Quality;
        private System.Windows.Forms.Label Label_AudioQuality;
    }
}
