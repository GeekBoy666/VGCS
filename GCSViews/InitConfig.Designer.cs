namespace MissionPlanner.GCSViews
{
    partial class InitConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitConfig));
            this.TabInitConfig = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.TabInitConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabInitConfig
            // 
            this.TabInitConfig.Controls.Add(this.tabPage1);
            this.TabInitConfig.Controls.Add(this.tabPage2);
            this.TabInitConfig.Controls.Add(this.tabPage3);
            this.TabInitConfig.Controls.Add(this.tabPage4);
            this.TabInitConfig.Controls.Add(this.tabPage5);
            this.TabInitConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabInitConfig.Location = new System.Drawing.Point(0, 0);
            this.TabInitConfig.Name = "TabInitConfig";
            this.TabInitConfig.SelectedIndex = 0;
            this.TabInitConfig.Size = new System.Drawing.Size(884, 544);
            this.TabInitConfig.TabIndex = 2;
            this.TabInitConfig.SelectedIndexChanged += new System.EventHandler(this.TabInitConfig_SelectedIndexChanged_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 518);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "模式设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 518);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "磁罗盘校准";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(876, 518);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "加速度校准";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(876, 518);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "遥控器校准";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(876, 518);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "机架选择";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // InitConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 544);
            this.Controls.Add(this.TabInitConfig);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "InitConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.TabInitConfig.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabInitConfig;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
    }
}