namespace DemoSignalSystem
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLightPattern = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.F = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabLightStatus = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timeMultiBox = new System.Windows.Forms.TextBox();
            this.timeMultiLabel = new System.Windows.Forms.Label();
            this.lightCycleComboBox = new System.Windows.Forms.ComboBox();
            this.lightCycleLabel = new System.Windows.Forms.Label();
            this.patternListBox = new System.Windows.Forms.ListBox();
            this.lightCycleLabel2 = new System.Windows.Forms.Label();
            this.timeMultiLabel2 = new System.Windows.Forms.Label();
            this.lightCycleComboBox2 = new System.Windows.Forms.ComboBox();
            this.timeMultiTextBox2 = new System.Windows.Forms.TextBox();
            this.patternListBox2 = new System.Windows.Forms.ListBox();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.startStopButton = new System.Windows.Forms.Button();
            this.timerTextBox2 = new System.Windows.Forms.TextBox();
            this.startStopButton2 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabLightPattern.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabLightPattern);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1442, 630);
            this.tabControl1.TabIndex = 0;
            // 
            // tabLightPattern
            // 
            this.tabLightPattern.Controls.Add(this.panel1);
            this.tabLightPattern.Controls.Add(this.tabControl2);
            this.tabLightPattern.Location = new System.Drawing.Point(4, 22);
            this.tabLightPattern.Name = "tabLightPattern";
            this.tabLightPattern.Padding = new System.Windows.Forms.Padding(3);
            this.tabLightPattern.Size = new System.Drawing.Size(1434, 604);
            this.tabLightPattern.TabIndex = 0;
            this.tabLightPattern.Text = "Traffic Light Map";
            this.tabLightPattern.UseVisualStyleBackColor = true;
            this.tabLightPattern.Click += new System.EventHandler(this.tabLightPattern_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.button6);
            this.panel1.Controls.Add(this.button8);
            this.panel1.Controls.Add(this.button7);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.F);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(366, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 578);
            this.panel1.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(665, 254);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(20, 22);
            this.button6.TabIndex = 8;
            this.button6.Text = "↓";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(376, 297);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(20, 35);
            this.button8.TabIndex = 7;
            this.button8.Text = " ↑";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.Location = new System.Drawing.Point(460, 129);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(20, 20);
            this.button7.TabIndex = 6;
            this.button7.Text = "→";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(535, 414);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(20, 20);
            this.button2.TabIndex = 4;
            this.button2.Text = "←";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(443, 129);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(20, 20);
            this.button4.TabIndex = 3;
            this.button4.Text = "H";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(376, 338);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(20, 20);
            this.button3.TabIndex = 2;
            this.button3.Text = "E";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // F
            // 
            this.F.ForeColor = System.Drawing.Color.Black;
            this.F.Location = new System.Drawing.Point(561, 414);
            this.F.Name = "F";
            this.F.Size = new System.Drawing.Size(20, 20);
            this.F.TabIndex = 1;
            this.F.Text = "F";
            this.F.UseVisualStyleBackColor = true;
            this.F.Click += new System.EventHandler(this.F_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(665, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "G";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabLightStatus);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabSimulation);
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(360, 604);
            this.tabControl2.TabIndex = 0;
            // 
            // tabLightStatus
            // 
            this.tabLightStatus.Location = new System.Drawing.Point(4, 22);
            this.tabLightStatus.Name = "tabLightStatus";
            this.tabLightStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabLightStatus.Size = new System.Drawing.Size(352, 578);
            this.tabLightStatus.TabIndex = 0;
            this.tabLightStatus.Text = "Light Status";
            this.tabLightStatus.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.startStopButton);
            this.tabPage4.Controls.Add(this.patternListBox);
            this.tabPage4.Controls.Add(this.timerTextBox);
            this.tabPage4.Controls.Add(this.lightCycleLabel);
            this.tabPage4.Controls.Add(this.lightCycleComboBox);
            this.tabPage4.Controls.Add(this.timeMultiLabel);
            this.tabPage4.Controls.Add(this.timeMultiBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(352, 578);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Pattern";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabSimulation
            // 
            this.tabSimulation.Location = new System.Drawing.Point(4, 22);
            this.tabSimulation.Name = "tabSimulation";
            this.tabSimulation.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulation.Size = new System.Drawing.Size(352, 578);
            this.tabSimulation.TabIndex = 2;
            this.tabSimulation.Text = "Simulation";
            this.tabSimulation.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.tabControl4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1434, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Traffic Map Overview";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.button13);
            this.panel2.Controls.Add(this.button12);
            this.panel2.Controls.Add(this.button11);
            this.panel2.Controls.Add(this.button10);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Location = new System.Drawing.Point(363, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 597);
            this.panel2.TabIndex = 2;
            // 
            // button13
            // 
            this.button13.ForeColor = System.Drawing.Color.Black;
            this.button13.Location = new System.Drawing.Point(713, 322);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(20, 20);
            this.button13.TabIndex = 8;
            this.button13.Text = "←";
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.ForeColor = System.Drawing.Color.Black;
            this.button12.Location = new System.Drawing.Point(435, 272);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(20, 20);
            this.button12.TabIndex = 7;
            this.button12.Text = "→";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(646, 286);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(20, 20);
            this.button11.TabIndex = 4;
            this.button11.Text = "B";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(409, 272);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(20, 20);
            this.button10.TabIndex = 3;
            this.button10.Text = "B";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(288, 307);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(20, 20);
            this.button9.TabIndex = 2;
            this.button9.Text = "B";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(729, 322);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(20, 20);
            this.button5.TabIndex = 1;
            this.button5.Text = "B";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // tabControl4
            // 
            this.tabControl4.Controls.Add(this.tabPage1);
            this.tabControl4.Controls.Add(this.tabPage5);
            this.tabControl4.Controls.Add(this.tabPage8);
            this.tabControl4.Location = new System.Drawing.Point(0, 0);
            this.tabControl4.Name = "tabControl4";
            this.tabControl4.SelectedIndex = 0;
            this.tabControl4.Size = new System.Drawing.Size(360, 604);
            this.tabControl4.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(352, 578);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Light Status";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.startStopButton2);
            this.tabPage5.Controls.Add(this.timerTextBox2);
            this.tabPage5.Controls.Add(this.patternListBox2);
            this.tabPage5.Controls.Add(this.timeMultiTextBox2);
            this.tabPage5.Controls.Add(this.lightCycleComboBox2);
            this.tabPage5.Controls.Add(this.timeMultiLabel2);
            this.tabPage5.Controls.Add(this.lightCycleLabel2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(352, 578);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Pattern";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.textBox5);
            this.tabPage8.Controls.Add(this.label3);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(352, 578);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Simulation";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(104, 3);
            this.textBox5.MaxLength = 8;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(78, 20);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Time Acceleration";
            // 
            // timeMultiBox
            // 
            this.timeMultiBox.Location = new System.Drawing.Point(264, 22);
            this.timeMultiBox.Name = "timeMultiBox";
            this.timeMultiBox.Size = new System.Drawing.Size(82, 20);
            this.timeMultiBox.TabIndex = 0;
            // 
            // timeMultiLabel
            // 
            this.timeMultiLabel.AutoSize = true;
            this.timeMultiLabel.Location = new System.Drawing.Point(261, 6);
            this.timeMultiLabel.Name = "timeMultiLabel";
            this.timeMultiLabel.Size = new System.Drawing.Size(85, 13);
            this.timeMultiLabel.TabIndex = 1;
            this.timeMultiLabel.Text = "Playback Speed";
            // 
            // lightCycleComboBox
            // 
            this.lightCycleComboBox.FormattingEnabled = true;
            this.lightCycleComboBox.Location = new System.Drawing.Point(6, 22);
            this.lightCycleComboBox.Name = "lightCycleComboBox";
            this.lightCycleComboBox.Size = new System.Drawing.Size(252, 21);
            this.lightCycleComboBox.TabIndex = 2;
            // 
            // lightCycleLabel
            // 
            this.lightCycleLabel.AutoSize = true;
            this.lightCycleLabel.Location = new System.Drawing.Point(6, 6);
            this.lightCycleLabel.Name = "lightCycleLabel";
            this.lightCycleLabel.Size = new System.Drawing.Size(86, 13);
            this.lightCycleLabel.TabIndex = 3;
            this.lightCycleLabel.Text = "Light Cycle Type";
            // 
            // patternListBox
            // 
            this.patternListBox.FormattingEnabled = true;
            this.patternListBox.Location = new System.Drawing.Point(6, 75);
            this.patternListBox.Name = "patternListBox";
            this.patternListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.patternListBox.Size = new System.Drawing.Size(340, 498);
            this.patternListBox.TabIndex = 5;
            // 
            // lightCycleLabel2
            // 
            this.lightCycleLabel2.AutoSize = true;
            this.lightCycleLabel2.Location = new System.Drawing.Point(6, 3);
            this.lightCycleLabel2.Name = "lightCycleLabel2";
            this.lightCycleLabel2.Size = new System.Drawing.Size(86, 13);
            this.lightCycleLabel2.TabIndex = 3;
            this.lightCycleLabel2.Text = "Light Cycle Type";
            // 
            // timeMultiLabel2
            // 
            this.timeMultiLabel2.AutoSize = true;
            this.timeMultiLabel2.Location = new System.Drawing.Point(261, 3);
            this.timeMultiLabel2.Name = "timeMultiLabel2";
            this.timeMultiLabel2.Size = new System.Drawing.Size(85, 13);
            this.timeMultiLabel2.TabIndex = 3;
            this.timeMultiLabel2.Text = "Playback Speed";
            // 
            // lightCycleComboBox2
            // 
            this.lightCycleComboBox2.FormattingEnabled = true;
            this.lightCycleComboBox2.Location = new System.Drawing.Point(6, 19);
            this.lightCycleComboBox2.Name = "lightCycleComboBox2";
            this.lightCycleComboBox2.Size = new System.Drawing.Size(252, 21);
            this.lightCycleComboBox2.TabIndex = 3;
            // 
            // timeMultiTextBox2
            // 
            this.timeMultiTextBox2.Location = new System.Drawing.Point(264, 20);
            this.timeMultiTextBox2.Name = "timeMultiTextBox2";
            this.timeMultiTextBox2.Size = new System.Drawing.Size(82, 20);
            this.timeMultiTextBox2.TabIndex = 4;
            // 
            // patternListBox2
            // 
            this.patternListBox2.FormattingEnabled = true;
            this.patternListBox2.Location = new System.Drawing.Point(6, 72);
            this.patternListBox2.Name = "patternListBox2";
            this.patternListBox2.Size = new System.Drawing.Size(340, 498);
            this.patternListBox2.TabIndex = 5;
            // 
            // timerTextBox
            // 
            this.timerTextBox.Location = new System.Drawing.Point(6, 49);
            this.timerTextBox.Name = "timerTextBox";
            this.timerTextBox.ReadOnly = true;
            this.timerTextBox.Size = new System.Drawing.Size(252, 20);
            this.timerTextBox.TabIndex = 1;
            this.timerTextBox.Text = "0";
            this.timerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(264, 46);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(82, 23);
            this.startStopButton.TabIndex = 2;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            // 
            // timerTextBox2
            // 
            this.timerTextBox2.Location = new System.Drawing.Point(6, 46);
            this.timerTextBox2.Name = "timerTextBox2";
            this.timerTextBox2.ReadOnly = true;
            this.timerTextBox2.Size = new System.Drawing.Size(252, 20);
            this.timerTextBox2.TabIndex = 6;
            this.timerTextBox2.Text = "0";
            this.timerTextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // startStopButton2
            // 
            this.startStopButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.startStopButton2.Location = new System.Drawing.Point(264, 46);
            this.startStopButton2.Name = "startStopButton2";
            this.startStopButton2.Size = new System.Drawing.Size(82, 23);
            this.startStopButton2.TabIndex = 7;
            this.startStopButton2.Text = "Start";
            this.startStopButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 630);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Ruritania";
            this.tabControl1.ResumeLayout(false);
            this.tabLightPattern.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLightPattern;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabLightStatus;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabSimulation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button F;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ListBox patternListBox;
        private System.Windows.Forms.Label lightCycleLabel;
        private System.Windows.Forms.ComboBox lightCycleComboBox;
        private System.Windows.Forms.Label timeMultiLabel;
        private System.Windows.Forms.TextBox timeMultiBox;
        private System.Windows.Forms.ListBox patternListBox2;
        private System.Windows.Forms.TextBox timeMultiTextBox2;
        private System.Windows.Forms.ComboBox lightCycleComboBox2;
        private System.Windows.Forms.Label timeMultiLabel2;
        private System.Windows.Forms.Label lightCycleLabel2;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.TextBox timerTextBox;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Button startStopButton2;
        private System.Windows.Forms.TextBox timerTextBox2;
    }
}

