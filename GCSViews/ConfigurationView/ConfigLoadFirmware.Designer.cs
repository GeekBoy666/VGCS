namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class ConfigLoadFirmware
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
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelStatu = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.ForeColor = System.Drawing.Color.White;
            this.progressBarLoad.Location = new System.Drawing.Point(48, 110);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(581, 22);
            this.progressBarLoad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(44, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择需要加载的固件";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // LabelStatu
            // 
            this.LabelStatu.AutoSize = true;
            this.LabelStatu.ForeColor = System.Drawing.Color.Black;
            this.LabelStatu.Location = new System.Drawing.Point(46, 78);
            this.LabelStatu.Name = "LabelStatu";
            this.LabelStatu.Size = new System.Drawing.Size(35, 12);
            this.LabelStatu.TabIndex = 2;
            this.LabelStatu.Text = "statu";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("华文行楷", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(484, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 39);
            this.button1.TabIndex = 3;
            this.button1.Text = "加载固件";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ConfigLoadFirmware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LabelStatu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarLoad);
            this.Name = "ConfigLoadFirmware";
            this.Size = new System.Drawing.Size(700, 177);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelStatu;
        private System.Windows.Forms.Button button1;
    }
}
