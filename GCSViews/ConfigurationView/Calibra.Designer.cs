namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class Calibra
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.configAccelerometerCalibration1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigAccelerometerCalibration();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.configHWCompass1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigHWCompass();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.configFailSafe1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigFailSafe();
            this.backstageView = new MissionPlanner.Controls.BackstageView.BackstageView();
            this.currentStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.configRadioInput1 = new MissionPlanner.GCSViews.ConfigurationView.ConfigRadioInput();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("华文楷体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1145, 645);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.configAccelerometerCalibration1);
            this.tabPage1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1109, 637);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "加速度计校准";
            // 
            // configAccelerometerCalibration1
            // 
            this.configAccelerometerCalibration1.Font = new System.Drawing.Font("华文楷体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.configAccelerometerCalibration1.Location = new System.Drawing.Point(0, 0);
            this.configAccelerometerCalibration1.Name = "configAccelerometerCalibration1";
            this.configAccelerometerCalibration1.Size = new System.Drawing.Size(819, 492);
            this.configAccelerometerCalibration1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.configHWCompass1);
            this.tabPage2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1109, 637);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "磁罗盘校准";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // configHWCompass1
            // 
            this.configHWCompass1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configHWCompass1.Font = new System.Drawing.Font("宋体", 9F);
            this.configHWCompass1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.configHWCompass1.Location = new System.Drawing.Point(3, 3);
            this.configHWCompass1.Name = "configHWCompass1";
            this.configHWCompass1.Size = new System.Drawing.Size(1103, 631);
            this.configHWCompass1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.configRadioInput1);
            this.tabPage3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1109, 637);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "遥控器校准";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.configFailSafe1);
            this.tabPage4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1109, 637);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "电机测试";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // configFailSafe1
            // 
            this.configFailSafe1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.configFailSafe1.Font = new System.Drawing.Font("宋体", 9F);
            this.configFailSafe1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.configFailSafe1.Location = new System.Drawing.Point(0, 0);
            this.configFailSafe1.Name = "configFailSafe1";
            this.configFailSafe1.Size = new System.Drawing.Size(1109, 637);
            this.configFailSafe1.TabIndex = 0;
            // 
            // backstageView
            // 
            this.backstageView.HighlightColor1 = System.Drawing.SystemColors.Highlight;
            this.backstageView.HighlightColor2 = System.Drawing.SystemColors.MenuHighlight;
            this.backstageView.Location = new System.Drawing.Point(0, 0);
            this.backstageView.Margin = new System.Windows.Forms.Padding(4);
            this.backstageView.Name = "backstageView";
            this.backstageView.Size = new System.Drawing.Size(657, 422);
            this.backstageView.TabIndex = 0;
            this.backstageView.WidthMenu = 203;
            // 
            // currentStateBindingSource
            // 
            this.currentStateBindingSource.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // configRadioInput1
            // 
            this.configRadioInput1.Font = new System.Drawing.Font("华文楷体", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.configRadioInput1.Location = new System.Drawing.Point(21, 14);
            this.configRadioInput1.Name = "configRadioInput1";
            this.configRadioInput1.Size = new System.Drawing.Size(828, 539);
            this.configRadioInput1.TabIndex = 0;
            // 
            // Calibra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "Calibra";
            this.Size = new System.Drawing.Size(1145, 645);
            this.Load += new System.EventHandler(this.Calibra_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private ConfigHWCompass configHWCompass1;
        private System.Windows.Forms.TabPage tabPage4;
        private ConfigFailSafe configFailSafe1;
        private ConfigAccelerometerCalibration configAccelerometerCalibration1;
        private System.Windows.Forms.BindingSource currentStateBindingSource;
        internal Controls.BackstageView.BackstageView backstageView;
        internal System.Windows.Forms.TabControl tabControl1;
        private ConfigRadioInput configRadioInput1;
    }
}
