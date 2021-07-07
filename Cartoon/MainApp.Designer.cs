
namespace Cartoon
{
    partial class App
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
            this.pbxOrigImg = new System.Windows.Forms.PictureBox();
            this.ColorPanel = new System.Windows.Forms.Panel();
            this.dltColorPalettebtn = new System.Windows.Forms.Button();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbxColor6 = new System.Windows.Forms.PictureBox();
            this.pbxColor9 = new System.Windows.Forms.PictureBox();
            this.pbxColor11 = new System.Windows.Forms.PictureBox();
            this.pbxColor8 = new System.Windows.Forms.PictureBox();
            this.pbxColor5 = new System.Windows.Forms.PictureBox();
            this.pbxColor3 = new System.Windows.Forms.PictureBox();
            this.pbxColor2 = new System.Windows.Forms.PictureBox();
            this.pbxColor12 = new System.Windows.Forms.PictureBox();
            this.pbxColor10 = new System.Windows.Forms.PictureBox();
            this.pbxColor7 = new System.Windows.Forms.PictureBox();
            this.pbxColor4 = new System.Windows.Forms.PictureBox();
            this.pbxColor1 = new System.Windows.Forms.PictureBox();
            this.lblToggleSelect = new System.Windows.Forms.Label();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxToggleSelection = new System.Windows.Forms.CheckBox();
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.toolSSHSVColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSSColorTag = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbxRsltImg = new System.Windows.Forms.PictureBox();
            this.btnApplyKmeans = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.cbxDifferentiate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxOrigImg)).BeginInit();
            this.ColorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor1)).BeginInit();
            this.MainMenu.SuspendLayout();
            this.MainStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRsltImg)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxOrigImg
            // 
            this.pbxOrigImg.Location = new System.Drawing.Point(130, 33);
            this.pbxOrigImg.MaximumSize = new System.Drawing.Size(775, 700);
            this.pbxOrigImg.Name = "pbxOrigImg";
            this.pbxOrigImg.Size = new System.Drawing.Size(775, 600);
            this.pbxOrigImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxOrigImg.TabIndex = 10;
            this.pbxOrigImg.TabStop = false;
            this.pbxOrigImg.ClientSizeChanged += new System.EventHandler(this.pbxDisplayImage_ClientSizeChanged);
            this.pbxOrigImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxDisplayImage_MouseDown);
            // 
            // ColorPanel
            // 
            this.ColorPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ColorPanel.Controls.Add(this.cbxDifferentiate);
            this.ColorPanel.Controls.Add(this.dltColorPalettebtn);
            this.ColorPanel.Controls.Add(this.lblColor);
            this.ColorPanel.Controls.Add(this.pbxColor6);
            this.ColorPanel.Controls.Add(this.pbxColor9);
            this.ColorPanel.Controls.Add(this.cbxToggleSelection);
            this.ColorPanel.Controls.Add(this.pbxColor11);
            this.ColorPanel.Controls.Add(this.lblToggleSelect);
            this.ColorPanel.Controls.Add(this.pbxColor8);
            this.ColorPanel.Controls.Add(this.pbxColor5);
            this.ColorPanel.Controls.Add(this.pbxColor3);
            this.ColorPanel.Controls.Add(this.pbxColor2);
            this.ColorPanel.Controls.Add(this.pbxColor12);
            this.ColorPanel.Controls.Add(this.pbxColor10);
            this.ColorPanel.Controls.Add(this.pbxColor7);
            this.ColorPanel.Controls.Add(this.pbxColor4);
            this.ColorPanel.Controls.Add(this.pbxColor1);
            this.ColorPanel.Location = new System.Drawing.Point(8, 33);
            this.ColorPanel.Name = "ColorPanel";
            this.ColorPanel.Size = new System.Drawing.Size(116, 297);
            this.ColorPanel.TabIndex = 11;
            // 
            // dltColorPalettebtn
            // 
            this.dltColorPalettebtn.Location = new System.Drawing.Point(9, 258);
            this.dltColorPalettebtn.Name = "dltColorPalettebtn";
            this.dltColorPalettebtn.Size = new System.Drawing.Size(75, 23);
            this.dltColorPalettebtn.TabIndex = 13;
            this.dltColorPalettebtn.Text = "Clear All";
            this.dltColorPalettebtn.UseVisualStyleBackColor = true;
            this.dltColorPalettebtn.Click += new System.EventHandler(this.deleteColorPaletteBtn_Click);
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(6, 4);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(89, 17);
            this.lblColor.TabIndex = 12;
            this.lblColor.Text = "Color Palette";
            // 
            // pbxColor6
            // 
            this.pbxColor6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor6.Location = new System.Drawing.Point(81, 70);
            this.pbxColor6.Name = "pbxColor6";
            this.pbxColor6.Size = new System.Drawing.Size(21, 22);
            this.pbxColor6.TabIndex = 11;
            this.pbxColor6.TabStop = false;
            this.pbxColor6.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor9
            // 
            this.pbxColor9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor9.Location = new System.Drawing.Point(81, 107);
            this.pbxColor9.Name = "pbxColor9";
            this.pbxColor9.Size = new System.Drawing.Size(21, 22);
            this.pbxColor9.TabIndex = 10;
            this.pbxColor9.TabStop = false;
            this.pbxColor9.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor11
            // 
            this.pbxColor11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor11.Location = new System.Drawing.Point(42, 144);
            this.pbxColor11.Name = "pbxColor11";
            this.pbxColor11.Size = new System.Drawing.Size(21, 22);
            this.pbxColor11.TabIndex = 9;
            this.pbxColor11.TabStop = false;
            this.pbxColor11.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor8
            // 
            this.pbxColor8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor8.Location = new System.Drawing.Point(42, 107);
            this.pbxColor8.Name = "pbxColor8";
            this.pbxColor8.Size = new System.Drawing.Size(21, 22);
            this.pbxColor8.TabIndex = 8;
            this.pbxColor8.TabStop = false;
            this.pbxColor8.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor5
            // 
            this.pbxColor5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor5.Location = new System.Drawing.Point(42, 70);
            this.pbxColor5.Name = "pbxColor5";
            this.pbxColor5.Size = new System.Drawing.Size(21, 22);
            this.pbxColor5.TabIndex = 7;
            this.pbxColor5.TabStop = false;
            this.pbxColor5.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor3
            // 
            this.pbxColor3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor3.Location = new System.Drawing.Point(81, 33);
            this.pbxColor3.Name = "pbxColor3";
            this.pbxColor3.Size = new System.Drawing.Size(21, 22);
            this.pbxColor3.TabIndex = 6;
            this.pbxColor3.TabStop = false;
            this.pbxColor3.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor2
            // 
            this.pbxColor2.BackColor = System.Drawing.Color.Silver;
            this.pbxColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor2.Location = new System.Drawing.Point(42, 33);
            this.pbxColor2.Name = "pbxColor2";
            this.pbxColor2.Size = new System.Drawing.Size(21, 22);
            this.pbxColor2.TabIndex = 5;
            this.pbxColor2.TabStop = false;
            this.pbxColor2.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor12
            // 
            this.pbxColor12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor12.Location = new System.Drawing.Point(81, 144);
            this.pbxColor12.Name = "pbxColor12";
            this.pbxColor12.Size = new System.Drawing.Size(21, 22);
            this.pbxColor12.TabIndex = 4;
            this.pbxColor12.TabStop = false;
            this.pbxColor12.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor10
            // 
            this.pbxColor10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor10.Location = new System.Drawing.Point(6, 144);
            this.pbxColor10.Name = "pbxColor10";
            this.pbxColor10.Size = new System.Drawing.Size(21, 22);
            this.pbxColor10.TabIndex = 3;
            this.pbxColor10.TabStop = false;
            this.pbxColor10.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor7
            // 
            this.pbxColor7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor7.Location = new System.Drawing.Point(6, 107);
            this.pbxColor7.Name = "pbxColor7";
            this.pbxColor7.Size = new System.Drawing.Size(21, 22);
            this.pbxColor7.TabIndex = 2;
            this.pbxColor7.TabStop = false;
            this.pbxColor7.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor4
            // 
            this.pbxColor4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.pbxColor4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor4.Location = new System.Drawing.Point(6, 70);
            this.pbxColor4.Name = "pbxColor4";
            this.pbxColor4.Size = new System.Drawing.Size(21, 22);
            this.pbxColor4.TabIndex = 1;
            this.pbxColor4.TabStop = false;
            this.pbxColor4.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // pbxColor1
            // 
            this.pbxColor1.BackColor = System.Drawing.Color.Silver;
            this.pbxColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxColor1.Location = new System.Drawing.Point(6, 33);
            this.pbxColor1.Name = "pbxColor1";
            this.pbxColor1.Size = new System.Drawing.Size(21, 22);
            this.pbxColor1.TabIndex = 0;
            this.pbxColor1.TabStop = false;
            this.pbxColor1.Click += new System.EventHandler(this.pbxColor_Click);
            // 
            // lblToggleSelect
            // 
            this.lblToggleSelect.AutoSize = true;
            this.lblToggleSelect.Location = new System.Drawing.Point(1, 169);
            this.lblToggleSelect.Name = "lblToggleSelect";
            this.lblToggleSelect.Size = new System.Drawing.Size(114, 17);
            this.lblToggleSelect.TabIndex = 12;
            this.lblToggleSelect.Text = "Toggle Selection";
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1692, 28);
            this.MainMenu.TabIndex = 13;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveImageToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.openToolStripMenuItem.Text = "Open image";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveImageToolStripMenuItem
            // 
            this.saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            this.saveImageToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.saveImageToolStripMenuItem.Text = "Save image";
            this.saveImageToolStripMenuItem.Click += new System.EventHandler(this.saveImageToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // cbxToggleSelection
            // 
            this.cbxToggleSelection.AutoSize = true;
            this.cbxToggleSelection.Location = new System.Drawing.Point(6, 188);
            this.cbxToggleSelection.Name = "cbxToggleSelection";
            this.cbxToggleSelection.Size = new System.Drawing.Size(69, 21);
            this.cbxToggleSelection.TabIndex = 14;
            this.cbxToggleSelection.Text = "Select";
            this.cbxToggleSelection.UseVisualStyleBackColor = true;
            // 
            // MainStatus
            // 
            this.MainStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSSHSVColor,
            this.toolSSColorTag});
            this.MainStatus.Location = new System.Drawing.Point(0, 642);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(1692, 26);
            this.MainStatus.TabIndex = 15;
            this.MainStatus.Text = "statusStrip1";
            // 
            // toolSSHSVColor
            // 
            this.toolSSHSVColor.Name = "toolSSHSVColor";
            this.toolSSHSVColor.Size = new System.Drawing.Size(21, 20);
            this.toolSSHSVColor.Text = "   ";
            // 
            // toolSSColorTag
            // 
            this.toolSSColorTag.Name = "toolSSColorTag";
            this.toolSSColorTag.Size = new System.Drawing.Size(44, 20);
            this.toolSSColorTag.Text = " HSV:";
            // 
            // pbxRsltImg
            // 
            this.pbxRsltImg.Location = new System.Drawing.Point(911, 33);
            this.pbxRsltImg.MaximumSize = new System.Drawing.Size(775, 700);
            this.pbxRsltImg.Name = "pbxRsltImg";
            this.pbxRsltImg.Size = new System.Drawing.Size(775, 600);
            this.pbxRsltImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbxRsltImg.TabIndex = 17;
            this.pbxRsltImg.TabStop = false;
            this.pbxRsltImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbxDisplayImage_MouseDown);
            // 
            // btnApplyKmeans
            // 
            this.btnApplyKmeans.Location = new System.Drawing.Point(8, 361);
            this.btnApplyKmeans.Name = "btnApplyKmeans";
            this.btnApplyKmeans.Size = new System.Drawing.Size(75, 25);
            this.btnApplyKmeans.TabIndex = 18;
            this.btnApplyKmeans.Text = "KMeans";
            this.btnApplyKmeans.UseVisualStyleBackColor = true;
            this.btnApplyKmeans.Click += new System.EventHandler(this.btnApplyKmeans_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(8, 333);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 25);
            this.btnApply.TabIndex = 19;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // cbxDifferentiate
            // 
            this.cbxDifferentiate.AutoSize = true;
            this.cbxDifferentiate.Location = new System.Drawing.Point(6, 215);
            this.cbxDifferentiate.Name = "cbxDifferentiate";
            this.cbxDifferentiate.Size = new System.Drawing.Size(107, 21);
            this.cbxDifferentiate.TabIndex = 15;
            this.cbxDifferentiate.Text = "Differentiate";
            this.cbxDifferentiate.UseVisualStyleBackColor = true;
            // 
            // App
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 668);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnApplyKmeans);
            this.Controls.Add(this.pbxRsltImg);
            this.Controls.Add(this.MainStatus);
            this.Controls.Add(this.ColorPanel);
            this.Controls.Add(this.pbxOrigImg);
            this.Controls.Add(this.MainMenu);
            this.Location = new System.Drawing.Point(2000, 800);
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximumSize = new System.Drawing.Size(1999, 1000);
            this.MinimumSize = new System.Drawing.Size(1710, 715);
            this.Name = "App";
            this.Text = "Cartoon App";
            ((System.ComponentModel.ISupportInitialize)(this.pbxOrigImg)).EndInit();
            this.ColorPanel.ResumeLayout(false);
            this.ColorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxColor1)).EndInit();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRsltImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pbxOrigImg;
        private System.Windows.Forms.Panel ColorPanel;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbxColor6;
        private System.Windows.Forms.PictureBox pbxColor9;
        private System.Windows.Forms.PictureBox pbxColor11;
        private System.Windows.Forms.PictureBox pbxColor8;
        private System.Windows.Forms.PictureBox pbxColor5;
        private System.Windows.Forms.PictureBox pbxColor3;
        private System.Windows.Forms.PictureBox pbxColor2;
        private System.Windows.Forms.PictureBox pbxColor12;
        private System.Windows.Forms.PictureBox pbxColor10;
        private System.Windows.Forms.PictureBox pbxColor7;
        private System.Windows.Forms.PictureBox pbxColor4;
        private System.Windows.Forms.PictureBox pbxColor1;
        private System.Windows.Forms.Label lblToggleSelect;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.CheckBox cbxToggleSelection;
        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolSSHSVColor;
        private System.Windows.Forms.ToolStripStatusLabel toolSSColorTag;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Button dltColorPalettebtn;
        private System.Windows.Forms.PictureBox pbxRsltImg;
        private System.Windows.Forms.Button btnApplyKmeans;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.CheckBox cbxDifferentiate;
    }
}

