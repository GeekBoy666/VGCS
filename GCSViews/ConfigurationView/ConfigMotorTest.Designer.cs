namespace MissionPlanner.GCSViews.ConfigurationView
{
    partial class ConfigMotorTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigMotorTest));
            this.numthrpercent = new System.Windows.Forms.NumericUpDown();
            this.numduration = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numthrpercent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numduration)).BeginInit();
            this.SuspendLayout();
            // 
            // numthrpercent
            // 
            resources.ApplyResources(this.numthrpercent, "numthrpercent");
            this.numthrpercent.Name = "numthrpercent";
            this.numthrpercent.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numduration
            // 
            resources.ApplyResources(this.numduration, "numduration");
            this.numduration.Name = "numduration";
            this.numduration.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // ConfigMotorTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numduration);
            this.Controls.Add(this.numthrpercent);
            this.Name = "ConfigMotorTest";
            resources.ApplyResources(this, "$this");
            ((System.ComponentModel.ISupportInitialize)(this.numthrpercent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numduration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numthrpercent;
        private System.Windows.Forms.NumericUpDown numduration;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}
