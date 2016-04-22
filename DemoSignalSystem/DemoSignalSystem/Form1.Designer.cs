﻿namespace DemoSignalSystem
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
            this.bLeftButton2 = new System.Windows.Forms.Button();
            this.dLeftButton2 = new System.Windows.Forms.Button();
            this.dLightButton2 = new System.Windows.Forms.Button();
            this.aLightButton2 = new System.Windows.Forms.Button();
            this.bLightButton2 = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabLightStatus = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.startStopButton = new System.Windows.Forms.Button();
            this.patternListBox = new System.Windows.Forms.ListBox();
            this.timerTextBox = new System.Windows.Forms.TextBox();
            this.lightCycleLabel = new System.Windows.Forms.Label();
            this.lightCycleComboBox = new System.Windows.Forms.ComboBox();
            this.timeMultiLabel = new System.Windows.Forms.Label();
            this.timeMultiBox = new System.Windows.Forms.TextBox();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cLeftButton = new System.Windows.Forms.Button();
            this.dLeftButton = new System.Windows.Forms.Button();
            this.bLightButton = new System.Windows.Forms.Button();
            this.dLightButton = new System.Windows.Forms.Button();
            this.aLightButton = new System.Windows.Forms.Button();
            this.cLightButton = new System.Windows.Forms.Button();
            this.tabControl4 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.startStopButton2 = new System.Windows.Forms.Button();
            this.timerTextBox2 = new System.Windows.Forms.TextBox();
            this.patternListBox2 = new System.Windows.Forms.ListBox();
            this.timeMultiTextBox2 = new System.Windows.Forms.TextBox();
            this.lightCycleComboBox2 = new System.Windows.Forms.ComboBox();
            this.timeMultiLabel2 = new System.Windows.Forms.Label();
            this.lightCycleLabel2 = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.minutesTextBox = new System.Windows.Forms.TextBox();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.hoursTextBox = new System.Windows.Forms.TextBox();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.secondsLabel = new System.Windows.Forms.Label();
            this.secondsTextBox = new System.Windows.Forms.TextBox();
            this.minutesTextBox2 = new System.Windows.Forms.TextBox();
            this.minutesLabel2 = new System.Windows.Forms.Label();
            this.hoursTextBox2 = new System.Windows.Forms.TextBox();
            this.hoursLabel2 = new System.Windows.Forms.Label();
            this.secondsLabel2 = new System.Windows.Forms.Label();
            this.secondsTextBox2 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabLightPattern.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl4.SuspendLayout();
            this.tabPage5.SuspendLayout();
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
            this.tabLightPattern.Controls.Add(this.secondsTextBox);
            this.tabLightPattern.Controls.Add(this.secondsLabel);
            this.tabLightPattern.Controls.Add(this.hoursLabel);
            this.tabLightPattern.Controls.Add(this.hoursTextBox);
            this.tabLightPattern.Controls.Add(this.minutesLabel);
            this.tabLightPattern.Controls.Add(this.minutesTextBox);
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
            this.panel1.Controls.Add(this.bLeftButton2);
            this.panel1.Controls.Add(this.dLeftButton2);
            this.panel1.Controls.Add(this.dLightButton2);
            this.panel1.Controls.Add(this.aLightButton2);
            this.panel1.Controls.Add(this.bLightButton2);
            this.panel1.Location = new System.Drawing.Point(366, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1062, 578);
            this.panel1.TabIndex = 0;
            // 
            // bLeftButton2
            // 
            this.bLeftButton2.ForeColor = System.Drawing.Color.Black;
            this.bLeftButton2.Location = new System.Drawing.Point(665, 254);
            this.bLeftButton2.Name = "bLeftButton2";
            this.bLeftButton2.Size = new System.Drawing.Size(20, 22);
            this.bLeftButton2.TabIndex = 8;
            this.bLeftButton2.Text = "↓";
            this.bLeftButton2.UseVisualStyleBackColor = true;
            this.bLeftButton2.Click += new System.EventHandler(this.button6_Click);
            // 
            // dLeftButton2
            // 
            this.dLeftButton2.ForeColor = System.Drawing.Color.Black;
            this.dLeftButton2.Location = new System.Drawing.Point(460, 129);
            this.dLeftButton2.Name = "dLeftButton2";
            this.dLeftButton2.Size = new System.Drawing.Size(20, 20);
            this.dLeftButton2.TabIndex = 6;
            this.dLeftButton2.Text = "→";
            this.dLeftButton2.UseVisualStyleBackColor = true;
            // 
            // dLightButton2
            // 
            this.dLightButton2.ForeColor = System.Drawing.Color.Black;
            this.dLightButton2.Location = new System.Drawing.Point(443, 129);
            this.dLightButton2.Name = "dLightButton2";
            this.dLightButton2.Size = new System.Drawing.Size(20, 20);
            this.dLightButton2.TabIndex = 3;
            this.dLightButton2.Text = "D";
            this.dLightButton2.UseVisualStyleBackColor = true;
            // 
            // aLightButton2
            // 
            this.aLightButton2.ForeColor = System.Drawing.Color.Black;
            this.aLightButton2.Location = new System.Drawing.Point(376, 338);
            this.aLightButton2.Name = "aLightButton2";
            this.aLightButton2.Size = new System.Drawing.Size(20, 20);
            this.aLightButton2.TabIndex = 2;
            this.aLightButton2.Text = "A";
            this.aLightButton2.UseMnemonic = false;
            this.aLightButton2.UseVisualStyleBackColor = true;
            this.aLightButton2.Click += new System.EventHandler(this.button3_Click);
            // 
            // bLightButton2
            // 
            this.bLightButton2.ForeColor = System.Drawing.Color.Black;
            this.bLightButton2.Location = new System.Drawing.Point(665, 238);
            this.bLightButton2.Name = "bLightButton2";
            this.bLightButton2.Size = new System.Drawing.Size(20, 20);
            this.bLightButton2.TabIndex = 0;
            this.bLightButton2.Text = "B";
            this.bLightButton2.UseVisualStyleBackColor = true;
            this.bLightButton2.Click += new System.EventHandler(this.button1_Click);
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
            // startStopButton
            // 
            this.startStopButton.Location = new System.Drawing.Point(264, 46);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(82, 23);
            this.startStopButton.TabIndex = 2;
            this.startStopButton.Text = "Start";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.Click += new System.EventHandler(this.startStopButton_Click);
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
            // lightCycleLabel
            // 
            this.lightCycleLabel.AutoSize = true;
            this.lightCycleLabel.Location = new System.Drawing.Point(6, 6);
            this.lightCycleLabel.Name = "lightCycleLabel";
            this.lightCycleLabel.Size = new System.Drawing.Size(86, 13);
            this.lightCycleLabel.TabIndex = 3;
            this.lightCycleLabel.Text = "Light Cycle Type";
            // 
            // lightCycleComboBox
            // 
            this.lightCycleComboBox.FormattingEnabled = true;
            this.lightCycleComboBox.Location = new System.Drawing.Point(6, 22);
            this.lightCycleComboBox.Name = "lightCycleComboBox";
            this.lightCycleComboBox.Size = new System.Drawing.Size(252, 21);
            this.lightCycleComboBox.TabIndex = 2;
            this.lightCycleComboBox.SelectedIndexChanged += new System.EventHandler(this.lightCycleComboBox_SelectedIndexChanged);
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
            // timeMultiBox
            // 
            this.timeMultiBox.Location = new System.Drawing.Point(264, 22);
            this.timeMultiBox.Name = "timeMultiBox";
            this.timeMultiBox.Size = new System.Drawing.Size(82, 20);
            this.timeMultiBox.TabIndex = 0;
            this.timeMultiBox.TextChanged += new System.EventHandler(this.timeMultiBox_TextChanged);
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
            this.tabPage2.Controls.Add(this.secondsTextBox2);
            this.tabPage2.Controls.Add(this.secondsLabel2);
            this.tabPage2.Controls.Add(this.hoursLabel2);
            this.tabPage2.Controls.Add(this.hoursTextBox2);
            this.tabPage2.Controls.Add(this.minutesLabel2);
            this.tabPage2.Controls.Add(this.minutesTextBox2);
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
            this.panel2.Controls.Add(this.cLeftButton);
            this.panel2.Controls.Add(this.dLeftButton);
            this.panel2.Controls.Add(this.bLightButton);
            this.panel2.Controls.Add(this.dLightButton);
            this.panel2.Controls.Add(this.aLightButton);
            this.panel2.Controls.Add(this.cLightButton);
            this.panel2.Location = new System.Drawing.Point(363, 22);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1071, 582);
            this.panel2.TabIndex = 2;
            // 
            // cLeftButton
            // 
            this.cLeftButton.ForeColor = System.Drawing.Color.Black;
            this.cLeftButton.Location = new System.Drawing.Point(713, 322);
            this.cLeftButton.Name = "cLeftButton";
            this.cLeftButton.Size = new System.Drawing.Size(20, 20);
            this.cLeftButton.TabIndex = 8;
            this.cLeftButton.Text = "←";
            this.cLeftButton.UseVisualStyleBackColor = true;
            // 
            // dLeftButton
            // 
            this.dLeftButton.ForeColor = System.Drawing.Color.Black;
            this.dLeftButton.Location = new System.Drawing.Point(435, 272);
            this.dLeftButton.Name = "dLeftButton";
            this.dLeftButton.Size = new System.Drawing.Size(20, 20);
            this.dLeftButton.TabIndex = 7;
            this.dLeftButton.Text = "→";
            this.dLeftButton.UseVisualStyleBackColor = true;
            this.dLeftButton.Click += new System.EventHandler(this.button12_Click);
            // 
            // bLightButton
            // 
            this.bLightButton.Location = new System.Drawing.Point(680, 287);
            this.bLightButton.Name = "bLightButton";
            this.bLightButton.Size = new System.Drawing.Size(20, 20);
            this.bLightButton.TabIndex = 4;
            this.bLightButton.Text = "B";
            this.bLightButton.UseVisualStyleBackColor = true;
            this.bLightButton.Click += new System.EventHandler(this.button11_Click);
            // 
            // dLightButton
            // 
            this.dLightButton.Location = new System.Drawing.Point(419, 272);
            this.dLightButton.Name = "dLightButton";
            this.dLightButton.Size = new System.Drawing.Size(20, 20);
            this.dLightButton.TabIndex = 3;
            this.dLightButton.Text = "D";
            this.dLightButton.UseVisualStyleBackColor = true;
            this.dLightButton.Click += new System.EventHandler(this.button10_Click);
            // 
            // aLightButton
            // 
            this.aLightButton.Location = new System.Drawing.Point(289, 312);
            this.aLightButton.Name = "aLightButton";
            this.aLightButton.Size = new System.Drawing.Size(20, 20);
            this.aLightButton.TabIndex = 2;
            this.aLightButton.Text = "A";
            this.aLightButton.UseVisualStyleBackColor = true;
            // 
            // cLightButton
            // 
            this.cLightButton.Location = new System.Drawing.Point(729, 322);
            this.cLightButton.Name = "cLightButton";
            this.cLightButton.Size = new System.Drawing.Size(20, 20);
            this.cLightButton.TabIndex = 1;
            this.cLightButton.Text = "C";
            this.cLightButton.UseVisualStyleBackColor = true;
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
            // startStopButton2
            // 
            this.startStopButton2.Cursor = System.Windows.Forms.Cursors.Default;
            this.startStopButton2.Location = new System.Drawing.Point(264, 46);
            this.startStopButton2.Name = "startStopButton2";
            this.startStopButton2.Size = new System.Drawing.Size(82, 23);
            this.startStopButton2.TabIndex = 7;
            this.startStopButton2.Text = "Start";
            this.startStopButton2.UseVisualStyleBackColor = true;
            this.startStopButton2.Click += new System.EventHandler(this.startStopButton2_Click);
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
            // patternListBox2
            // 
            this.patternListBox2.FormattingEnabled = true;
            this.patternListBox2.Location = new System.Drawing.Point(6, 72);
            this.patternListBox2.Name = "patternListBox2";
            this.patternListBox2.Size = new System.Drawing.Size(340, 498);
            this.patternListBox2.TabIndex = 5;
            // 
            // timeMultiTextBox2
            // 
            this.timeMultiTextBox2.Location = new System.Drawing.Point(264, 20);
            this.timeMultiTextBox2.Name = "timeMultiTextBox2";
            this.timeMultiTextBox2.Size = new System.Drawing.Size(82, 20);
            this.timeMultiTextBox2.TabIndex = 4;
            this.timeMultiTextBox2.TextChanged += new System.EventHandler(this.timeMultiTextBox2_TextChanged);
            // 
            // lightCycleComboBox2
            // 
            this.lightCycleComboBox2.FormattingEnabled = true;
            this.lightCycleComboBox2.Location = new System.Drawing.Point(6, 19);
            this.lightCycleComboBox2.Name = "lightCycleComboBox2";
            this.lightCycleComboBox2.Size = new System.Drawing.Size(252, 21);
            this.lightCycleComboBox2.TabIndex = 3;
            this.lightCycleComboBox2.SelectedIndexChanged += new System.EventHandler(this.lightCycleComboBox2_SelectedIndexChanged);
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
            // lightCycleLabel2
            // 
            this.lightCycleLabel2.AutoSize = true;
            this.lightCycleLabel2.Location = new System.Drawing.Point(6, 3);
            this.lightCycleLabel2.Name = "lightCycleLabel2";
            this.lightCycleLabel2.Size = new System.Drawing.Size(86, 13);
            this.lightCycleLabel2.TabIndex = 3;
            this.lightCycleLabel2.Text = "Light Cycle Type";
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(352, 578);
            this.tabPage8.TabIndex = 2;
            this.tabPage8.Text = "Simulation";
            this.tabPage8.UseVisualStyleBackColor = true;
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
            // minutesTextBox
            // 
            this.minutesTextBox.Location = new System.Drawing.Point(628, 3);
            this.minutesTextBox.Name = "minutesTextBox";
            this.minutesTextBox.ReadOnly = true;
            this.minutesTextBox.Size = new System.Drawing.Size(100, 20);
            this.minutesTextBox.TabIndex = 1;
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Location = new System.Drawing.Point(578, 6);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(44, 13);
            this.minutesLabel.TabIndex = 2;
            this.minutesLabel.Text = "Minutes";
            // 
            // hoursTextBox
            // 
            this.hoursTextBox.Location = new System.Drawing.Point(472, 3);
            this.hoursTextBox.Name = "hoursTextBox";
            this.hoursTextBox.ReadOnly = true;
            this.hoursTextBox.Size = new System.Drawing.Size(100, 20);
            this.hoursTextBox.TabIndex = 3;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Location = new System.Drawing.Point(431, 6);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(35, 13);
            this.hoursLabel.TabIndex = 4;
            this.hoursLabel.Text = "Hours";
            // 
            // secondsLabel
            // 
            this.secondsLabel.AutoSize = true;
            this.secondsLabel.Location = new System.Drawing.Point(739, 6);
            this.secondsLabel.Name = "secondsLabel";
            this.secondsLabel.Size = new System.Drawing.Size(49, 13);
            this.secondsLabel.TabIndex = 5;
            this.secondsLabel.Text = "Seconds";
            // 
            // secondsTextBox
            // 
            this.secondsTextBox.Location = new System.Drawing.Point(794, 3);
            this.secondsTextBox.Name = "secondsTextBox";
            this.secondsTextBox.ReadOnly = true;
            this.secondsTextBox.Size = new System.Drawing.Size(100, 20);
            this.secondsTextBox.TabIndex = 6;
            // 
            // minutesTextBox2
            // 
            this.minutesTextBox2.Location = new System.Drawing.Point(625, 3);
            this.minutesTextBox2.Name = "minutesTextBox2";
            this.minutesTextBox2.ReadOnly = true;
            this.minutesTextBox2.Size = new System.Drawing.Size(100, 20);
            this.minutesTextBox2.TabIndex = 3;
            // 
            // minutesLabel2
            // 
            this.minutesLabel2.AutoSize = true;
            this.minutesLabel2.Location = new System.Drawing.Point(575, 6);
            this.minutesLabel2.Name = "minutesLabel2";
            this.minutesLabel2.Size = new System.Drawing.Size(44, 13);
            this.minutesLabel2.TabIndex = 4;
            this.minutesLabel2.Text = "Minutes";
            // 
            // hoursTextBox2
            // 
            this.hoursTextBox2.Location = new System.Drawing.Point(469, 3);
            this.hoursTextBox2.Name = "hoursTextBox2";
            this.hoursTextBox2.ReadOnly = true;
            this.hoursTextBox2.Size = new System.Drawing.Size(100, 20);
            this.hoursTextBox2.TabIndex = 5;
            // 
            // hoursLabel2
            // 
            this.hoursLabel2.AutoSize = true;
            this.hoursLabel2.Location = new System.Drawing.Point(428, 6);
            this.hoursLabel2.Name = "hoursLabel2";
            this.hoursLabel2.Size = new System.Drawing.Size(35, 13);
            this.hoursLabel2.TabIndex = 6;
            this.hoursLabel2.Text = "Hours";
            // 
            // secondsLabel2
            // 
            this.secondsLabel2.AutoSize = true;
            this.secondsLabel2.Location = new System.Drawing.Point(731, 6);
            this.secondsLabel2.Name = "secondsLabel2";
            this.secondsLabel2.Size = new System.Drawing.Size(49, 13);
            this.secondsLabel2.TabIndex = 7;
            this.secondsLabel2.Text = "Seconds";
            // 
            // secondsTextBox2
            // 
            this.secondsTextBox2.Location = new System.Drawing.Point(786, 3);
            this.secondsTextBox2.Name = "secondsTextBox2";
            this.secondsTextBox2.ReadOnly = true;
            this.secondsTextBox2.Size = new System.Drawing.Size(100, 20);
            this.secondsTextBox2.TabIndex = 8;
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
            this.tabLightPattern.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
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
        private System.Windows.Forms.Button dLightButton2;
        private System.Windows.Forms.Button aLightButton2;
        private System.Windows.Forms.Button bLightButton2;
        private System.Windows.Forms.Button bLeftButton2;
        private System.Windows.Forms.Button dLeftButton2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button cLightButton;
        private System.Windows.Forms.TabControl tabControl4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.Button bLightButton;
        private System.Windows.Forms.Button dLightButton;
        private System.Windows.Forms.Button aLightButton;
        private System.Windows.Forms.Button cLeftButton;
        private System.Windows.Forms.Button dLeftButton;
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
        private System.Windows.Forms.TextBox secondsTextBox;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label hoursLabel;
        private System.Windows.Forms.TextBox hoursTextBox;
        private System.Windows.Forms.Label minutesLabel;
        private System.Windows.Forms.TextBox minutesTextBox;
        private System.Windows.Forms.TextBox secondsTextBox2;
        private System.Windows.Forms.Label secondsLabel2;
        private System.Windows.Forms.Label hoursLabel2;
        private System.Windows.Forms.TextBox hoursTextBox2;
        private System.Windows.Forms.Label minutesLabel2;
        private System.Windows.Forms.TextBox minutesTextBox2;
    }
}

