namespace MissionPlanner.Controls
{
    partial class DefaultSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultSettings));
            this.BUT_paramfileload = new MissionPlanner.Controls.MyButton();
            this.CMB_paramfiles = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BUT_paramfileload
            // 
            this.BUT_paramfileload.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_paramfileload.BGGradTop = System.Drawing.Color.Gray;
            this.BUT_paramfileload.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.BUT_paramfileload, "BUT_paramfileload");
            this.BUT_paramfileload.Name = "BUT_paramfileload";
            this.BUT_paramfileload.TextColor = System.Drawing.Color.White;
            this.BUT_paramfileload.UseVisualStyleBackColor = true;
            this.BUT_paramfileload.Click += new System.EventHandler(this.BUT_paramfileload_Click);
            // 
            // CMB_paramfiles
            // 
            this.CMB_paramfiles.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_paramfiles, "CMB_paramfiles");
            this.CMB_paramfiles.Name = "CMB_paramfiles";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CMB_paramfiles);
            this.groupBox1.Controls.Add(this.BUT_paramfileload);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // DefaultSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.groupBox1);
            this.Name = "DefaultSettings";
            resources.ApplyResources(this, "$this");
            this.Load += new System.EventHandler(this.ConfigDefaultSettings_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Controls.MyButton BUT_paramfileload;
        private System.Windows.Forms.ComboBox CMB_paramfiles;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
