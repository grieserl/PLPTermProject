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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLightPattern = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabLightStatus = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabSimulation = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabLightPattern.SuspendLayout();
            this.tabControl2.SuspendLayout();
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
            this.tabLightPattern.Controls.Add(this.tabControl2);
            this.tabLightPattern.Location = new System.Drawing.Point(4, 22);
            this.tabLightPattern.Name = "tabLightPattern";
            this.tabLightPattern.Padding = new System.Windows.Forms.Padding(3);
            this.tabLightPattern.Size = new System.Drawing.Size(1434, 604);
            this.tabLightPattern.TabIndex = 0;
            this.tabLightPattern.Text = "Traffic Light Map";
            this.tabLightPattern.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1434, 604);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 630);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabLightPattern.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
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
    }
}

