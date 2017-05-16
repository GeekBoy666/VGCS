using System;
namespace MissionPlanner
{
    partial class MainV2
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
            Console.WriteLine("mainv2_Dispose");
            if (PluginThreadrunner != null)
                PluginThreadrunner.Dispose();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainV2));
            this.CTX_mainmenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.autoHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readonlyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource_hub = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPageStatustext = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControlactions = new System.Windows.Forms.TabControl();
            this.tabActions = new System.Windows.Forms.TabPage();
            this.myButton6 = new MissionPlanner.Controls.MyButton();
            this.myButton5 = new MissionPlanner.Controls.MyButton();
            this.myButton7 = new MissionPlanner.Controls.MyButton();
            this.myButton4 = new MissionPlanner.Controls.MyButton();
            this.modifyandSetLoiterRad = new MissionPlanner.Controls.ModifyandSet();
            this.BUT_ARM = new MissionPlanner.Controls.MyButton();
            this.BUT_quickmanual = new MissionPlanner.Controls.MyButton();
            this.BUT_quickrtl = new MissionPlanner.Controls.MyButton();
            this.BUT_quickauto = new MissionPlanner.Controls.MyButton();
            this.CMB_setwp = new System.Windows.Forms.ComboBox();
            this.BUT_setwp = new MissionPlanner.Controls.MyButton();
            this.CMB_modes = new System.Windows.Forms.ComboBox();
            this.BUT_setmode = new MissionPlanner.Controls.MyButton();
            this.CMB_action = new System.Windows.Forms.ComboBox();
            this.BUT_Homealt = new MissionPlanner.Controls.MyButton();
            this.BUTactiondo = new MissionPlanner.Controls.MyButton();
            this.modifyandSetSpeed = new MissionPlanner.Controls.ModifyandSet();
            this.modifyandSetAlt = new MissionPlanner.Controls.ModifyandSet();
            this.tabPagePreFlight = new System.Windows.Forms.TabPage();
            this.checkListControl1 = new MissionPlanner.Controls.PreFlight.CheckListControl();
            this.tabTLogs = new System.Windows.Forms.TabPage();
            this.tableLayoutPaneltlogs = new System.Windows.Forms.TableLayoutPanel();
            this.BUT_loadtelem = new MissionPlanner.Controls.MyButton();
            this.tracklog = new System.Windows.Forms.TrackBar();
            this.lbl_logpercent = new MissionPlanner.Controls.MyLabel();
            this.LBL_logfn = new MissionPlanner.Controls.MyLabel();
            this.BUT_log2kml = new MissionPlanner.Controls.MyButton();
            this.BUT_playlog = new MissionPlanner.Controls.MyButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.BUT_speed10 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed5 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed2 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_2 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_4 = new MissionPlanner.Controls.MyButton();
            this.BUT_speed1_10 = new MissionPlanner.Controls.MyButton();
            this.lbl_playbackspeed = new MissionPlanner.Controls.MyLabel();
            this.DataFlashLog = new System.Windows.Forms.TabPage();
            this.myButton10 = new MissionPlanner.Controls.MyButton();
            this.myButton9 = new MissionPlanner.Controls.MyButton();
            this.myButton8 = new MissionPlanner.Controls.MyButton();
            this.myButton3 = new MissionPlanner.Controls.MyButton();
            this.myButton2 = new MissionPlanner.Controls.MyButton();
            this.myButton1 = new MissionPlanner.Controls.MyButton();
            this.CB_Dbug = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MenuConnect = new System.Windows.Forms.ToolStripButton();
            this.toolStripConnectionControl = new MissionPlanner.Controls.ToolStripConnectionControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hud1 = new MissionPlanner.Controls.HUD();
            this.bindingSourceQTab = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Messagetabletimer1 = new System.Windows.Forms.Timer(this.components);
            this.currentStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ZedTimer = new System.Windows.Forms.Timer(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.bindingSourcepreflight = new System.Windows.Forms.BindingSource(this.components);
            this.CTX_mainmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_hub)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControlactions.SuspendLayout();
            this.tabActions.SuspendLayout();
            this.tabPagePreFlight.SuspendLayout();
            this.tabTLogs.SuspendLayout();
            this.tableLayoutPaneltlogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).BeginInit();
            this.panel4.SuspendLayout();
            this.DataFlashLog.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQTab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcepreflight)).BeginInit();
            this.SuspendLayout();
            // 
            // CTX_mainmenu
            // 
            this.CTX_mainmenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CTX_mainmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoHideToolStripMenuItem,
            this.fullScreenToolStripMenuItem,
            this.readonlyToolStripMenuItem,
            this.connectionOptionsToolStripMenuItem});
            this.CTX_mainmenu.Name = "CTX_mainmenu";
            resources.ApplyResources(this.CTX_mainmenu, "CTX_mainmenu");
            // 
            // autoHideToolStripMenuItem
            // 
            this.autoHideToolStripMenuItem.CheckOnClick = true;
            this.autoHideToolStripMenuItem.Name = "autoHideToolStripMenuItem";
            resources.ApplyResources(this.autoHideToolStripMenuItem, "autoHideToolStripMenuItem");
            this.autoHideToolStripMenuItem.Click += new System.EventHandler(this.autoHideToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.CheckOnClick = true;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            resources.ApplyResources(this.fullScreenToolStripMenuItem, "fullScreenToolStripMenuItem");
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // readonlyToolStripMenuItem
            // 
            this.readonlyToolStripMenuItem.CheckOnClick = true;
            this.readonlyToolStripMenuItem.Name = "readonlyToolStripMenuItem";
            resources.ApplyResources(this.readonlyToolStripMenuItem, "readonlyToolStripMenuItem");
            this.readonlyToolStripMenuItem.Click += new System.EventHandler(this.readonlyToolStripMenuItem_Click);
            // 
            // connectionOptionsToolStripMenuItem
            // 
            this.connectionOptionsToolStripMenuItem.Name = "connectionOptionsToolStripMenuItem";
            resources.ApplyResources(this.connectionOptionsToolStripMenuItem, "connectionOptionsToolStripMenuItem");
            this.connectionOptionsToolStripMenuItem.Click += new System.EventHandler(this.connectionOptionsToolStripMenuItem_Click);
            // 
            // bindingSource_hub
            // 
            this.bindingSource_hub.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.panel2);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPageStatustext);
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label20, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label19, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label15, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label21, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label22, 2, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.ForeColor = System.Drawing.Color.LimeGreen;
            this.label15.Name = "label15";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "groundspeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "N/A", "N2"));
            this.label14.Name = "label14";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.ForeColor = System.Drawing.Color.LimeGreen;
            this.label16.Name = "label16";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "verticalspeed", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "N/A", "N2"));
            this.label12.Name = "label12";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.ForeColor = System.Drawing.Color.LimeGreen;
            this.label17.Name = "label17";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "alt", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.label1.Name = "label1";
            this.label1.BindingContextChanged += new System.EventHandler(this.label1_BindingContextChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "pitch", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "N/A", "N2"));
            this.label8.Name = "label8";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "roll", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.label6.Name = "label6";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_hub, "yaw", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "N/A", "N2"));
            this.label10.Name = "label10";
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.textBox1);
            resources.ApplyResources(this.tabPage11, "tabPage11");
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // tabPageStatustext
            // 
            resources.ApplyResources(this.tabPageStatustext, "tabPageStatustext");
            this.tabPageStatustext.Name = "tabPageStatustext";
            this.tabPageStatustext.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            resources.ApplyResources(this.splitContainer3, "splitContainer3");
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControlactions);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.CB_Dbug);
            this.splitContainer3.Panel2.Controls.Add(this.toolStrip1);
            // 
            // tabControlactions
            // 
            this.tabControlactions.Controls.Add(this.tabActions);
            this.tabControlactions.Controls.Add(this.tabPagePreFlight);
            this.tabControlactions.Controls.Add(this.tabTLogs);
            this.tabControlactions.Controls.Add(this.DataFlashLog);
            resources.ApplyResources(this.tabControlactions, "tabControlactions");
            this.tabControlactions.Name = "tabControlactions";
            this.tabControlactions.SelectedIndex = 0;
            // 
            // tabActions
            // 
            this.tabActions.Controls.Add(this.myButton6);
            this.tabActions.Controls.Add(this.myButton5);
            this.tabActions.Controls.Add(this.myButton7);
            this.tabActions.Controls.Add(this.myButton4);
            this.tabActions.Controls.Add(this.modifyandSetLoiterRad);
            this.tabActions.Controls.Add(this.BUT_ARM);
            this.tabActions.Controls.Add(this.BUT_quickmanual);
            this.tabActions.Controls.Add(this.BUT_quickrtl);
            this.tabActions.Controls.Add(this.BUT_quickauto);
            this.tabActions.Controls.Add(this.CMB_setwp);
            this.tabActions.Controls.Add(this.BUT_setwp);
            this.tabActions.Controls.Add(this.CMB_modes);
            this.tabActions.Controls.Add(this.BUT_setmode);
            this.tabActions.Controls.Add(this.CMB_action);
            this.tabActions.Controls.Add(this.BUT_Homealt);
            this.tabActions.Controls.Add(this.BUTactiondo);
            this.tabActions.Controls.Add(this.modifyandSetSpeed);
            this.tabActions.Controls.Add(this.modifyandSetAlt);
            resources.ApplyResources(this.tabActions, "tabActions");
            this.tabActions.Name = "tabActions";
            this.tabActions.UseVisualStyleBackColor = true;
            this.tabActions.Click += new System.EventHandler(this.tabActions_Click);
            // 
            // myButton6
            // 
            this.myButton6.BGGradBot = System.Drawing.Color.Gainsboro;
            this.myButton6.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton6.ColorMouseDown = System.Drawing.Color.Gray;
            this.myButton6.ColorMouseOver = System.Drawing.Color.Empty;
            this.myButton6.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.myButton6, "myButton6");
            this.myButton6.Name = "myButton6";
            this.myButton6.TextColor = System.Drawing.Color.WhiteSmoke;
            this.myButton6.UseVisualStyleBackColor = true;
            this.myButton6.Click += new System.EventHandler(this.myButton6_Click);
            // 
            // myButton5
            // 
            this.myButton5.BGGradBot = System.Drawing.Color.Gainsboro;
            this.myButton5.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton5.ColorMouseDown = System.Drawing.Color.Gray;
            this.myButton5.ColorMouseOver = System.Drawing.Color.Empty;
            this.myButton5.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.myButton5, "myButton5");
            this.myButton5.Name = "myButton5";
            this.myButton5.TextColor = System.Drawing.Color.WhiteSmoke;
            this.myButton5.UseVisualStyleBackColor = true;
            this.myButton5.Click += new System.EventHandler(this.myButton5_Click);
            // 
            // myButton7
            // 
            this.myButton7.BGGradBot = System.Drawing.Color.Gainsboro;
            this.myButton7.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton7.ColorMouseDown = System.Drawing.Color.Gray;
            this.myButton7.ColorMouseOver = System.Drawing.Color.Empty;
            this.myButton7.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.myButton7, "myButton7");
            this.myButton7.Name = "myButton7";
            this.myButton7.TextColor = System.Drawing.Color.WhiteSmoke;
            this.myButton7.UseVisualStyleBackColor = true;
            // 
            // myButton4
            // 
            this.myButton4.BGGradBot = System.Drawing.Color.Gainsboro;
            this.myButton4.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton4.ColorMouseDown = System.Drawing.Color.Gray;
            this.myButton4.ColorMouseOver = System.Drawing.Color.Empty;
            this.myButton4.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.myButton4, "myButton4");
            this.myButton4.Name = "myButton4";
            this.myButton4.TextColor = System.Drawing.Color.WhiteSmoke;
            this.myButton4.UseVisualStyleBackColor = true;
            this.myButton4.Click += new System.EventHandler(this.myButton4_Click);
            // 
            // modifyandSetLoiterRad
            // 
            this.modifyandSetLoiterRad.ButtonText = "更改飞行高度";
            resources.ApplyResources(this.modifyandSetLoiterRad, "modifyandSetLoiterRad");
            this.modifyandSetLoiterRad.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.modifyandSetLoiterRad.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.modifyandSetLoiterRad.Name = "modifyandSetLoiterRad";
            this.modifyandSetLoiterRad.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.modifyandSetLoiterRad.Click += new System.EventHandler(this.modifyandSetLoiterRad_Click);
            // 
            // BUT_ARM
            // 
            this.BUT_ARM.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_ARM.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_ARM.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_ARM.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_ARM.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_ARM, "BUT_ARM");
            this.BUT_ARM.Name = "BUT_ARM";
            this.BUT_ARM.Outline = System.Drawing.Color.Gray;
            this.BUT_ARM.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_ARM.UseVisualStyleBackColor = true;
            this.BUT_ARM.Click += new System.EventHandler(this.BUT_ARM_Click);
            // 
            // BUT_quickmanual
            // 
            this.BUT_quickmanual.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_quickmanual.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_quickmanual.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_quickmanual.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_quickmanual.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_quickmanual, "BUT_quickmanual");
            this.BUT_quickmanual.Name = "BUT_quickmanual";
            this.BUT_quickmanual.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_quickmanual.UseVisualStyleBackColor = true;
            this.BUT_quickmanual.Click += new System.EventHandler(this.BUT_quickmanual_Click);
            // 
            // BUT_quickrtl
            // 
            this.BUT_quickrtl.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_quickrtl.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_quickrtl.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_quickrtl.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_quickrtl.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_quickrtl, "BUT_quickrtl");
            this.BUT_quickrtl.Name = "BUT_quickrtl";
            this.BUT_quickrtl.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_quickrtl.UseVisualStyleBackColor = true;
            // 
            // BUT_quickauto
            // 
            this.BUT_quickauto.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_quickauto.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_quickauto.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_quickauto.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_quickauto.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_quickauto, "BUT_quickauto");
            this.BUT_quickauto.Name = "BUT_quickauto";
            this.BUT_quickauto.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_quickauto.UseVisualStyleBackColor = true;
            this.BUT_quickauto.Click += new System.EventHandler(this.BUT_quickauto_Click);
            // 
            // CMB_setwp
            // 
            this.CMB_setwp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_setwp.FormattingEnabled = true;
            this.CMB_setwp.Items.AddRange(new object[] {
            resources.GetString("CMB_setwp.Items")});
            resources.ApplyResources(this.CMB_setwp, "CMB_setwp");
            this.CMB_setwp.Name = "CMB_setwp";
            // 
            // BUT_setwp
            // 
            this.BUT_setwp.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_setwp.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_setwp.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_setwp.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_setwp.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_setwp, "BUT_setwp");
            this.BUT_setwp.Name = "BUT_setwp";
            this.BUT_setwp.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_setwp.UseVisualStyleBackColor = true;
            this.BUT_setwp.Click += new System.EventHandler(this.BUT_setwp_Click);
            // 
            // CMB_modes
            // 
            this.CMB_modes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_modes.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_modes, "CMB_modes");
            this.CMB_modes.Name = "CMB_modes";
            // 
            // BUT_setmode
            // 
            this.BUT_setmode.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_setmode.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_setmode.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_setmode.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_setmode.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_setmode, "BUT_setmode");
            this.BUT_setmode.Name = "BUT_setmode";
            this.BUT_setmode.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_setmode.UseVisualStyleBackColor = true;
            this.BUT_setmode.Click += new System.EventHandler(this.BUT_setmode_Click);
            // 
            // CMB_action
            // 
            this.CMB_action.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CMB_action.DropDownWidth = 150;
            this.CMB_action.FormattingEnabled = true;
            resources.ApplyResources(this.CMB_action, "CMB_action");
            this.CMB_action.Name = "CMB_action";
            // 
            // BUT_Homealt
            // 
            this.BUT_Homealt.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUT_Homealt.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_Homealt.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_Homealt.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_Homealt.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_Homealt, "BUT_Homealt");
            this.BUT_Homealt.Name = "BUT_Homealt";
            this.BUT_Homealt.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_Homealt.UseVisualStyleBackColor = true;
            this.BUT_Homealt.Click += new System.EventHandler(this.BUT_Homealt_Click);
            // 
            // BUTactiondo
            // 
            this.BUTactiondo.BGGradBot = System.Drawing.Color.Gainsboro;
            this.BUTactiondo.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUTactiondo.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUTactiondo.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUTactiondo.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUTactiondo, "BUTactiondo");
            this.BUTactiondo.Name = "BUTactiondo";
            this.BUTactiondo.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUTactiondo.UseVisualStyleBackColor = true;
            this.BUTactiondo.Click += new System.EventHandler(this.BUTactiondo_Click);
            // 
            // modifyandSetSpeed
            // 
            this.modifyandSetSpeed.ButtonText = "设置悬停半径";
            resources.ApplyResources(this.modifyandSetSpeed, "modifyandSetSpeed");
            this.modifyandSetSpeed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.modifyandSetSpeed.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.modifyandSetSpeed.Name = "modifyandSetSpeed";
            this.modifyandSetSpeed.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.modifyandSetSpeed.Click += new System.EventHandler(this.modifyandSetSpeed_Click);
            // 
            // modifyandSetAlt
            // 
            this.modifyandSetAlt.ButtonText = "更改飞行速度";
            resources.ApplyResources(this.modifyandSetAlt, "modifyandSetAlt");
            this.modifyandSetAlt.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.modifyandSetAlt.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.modifyandSetAlt.Name = "modifyandSetAlt";
            this.modifyandSetAlt.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.modifyandSetAlt.Click += new System.EventHandler(this.modifyandSetAlt_Click);
            // 
            // tabPagePreFlight
            // 
            this.tabPagePreFlight.Controls.Add(this.checkListControl1);
            resources.ApplyResources(this.tabPagePreFlight, "tabPagePreFlight");
            this.tabPagePreFlight.Name = "tabPagePreFlight";
            this.tabPagePreFlight.UseVisualStyleBackColor = true;
            // 
            // checkListControl1
            // 
            resources.ApplyResources(this.checkListControl1, "checkListControl1");
            this.checkListControl1.Name = "checkListControl1";
            // 
            // tabTLogs
            // 
            this.tabTLogs.Controls.Add(this.tableLayoutPaneltlogs);
            resources.ApplyResources(this.tabTLogs, "tabTLogs");
            this.tabTLogs.Name = "tabTLogs";
            this.tabTLogs.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPaneltlogs
            // 
            resources.ApplyResources(this.tableLayoutPaneltlogs, "tableLayoutPaneltlogs");
            this.tableLayoutPaneltlogs.Controls.Add(this.BUT_loadtelem, 0, 0);
            this.tableLayoutPaneltlogs.Controls.Add(this.tracklog, 1, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.lbl_logpercent, 2, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.LBL_logfn, 1, 0);
            this.tableLayoutPaneltlogs.Controls.Add(this.BUT_log2kml, 0, 2);
            this.tableLayoutPaneltlogs.Controls.Add(this.BUT_playlog, 0, 1);
            this.tableLayoutPaneltlogs.Controls.Add(this.panel4, 1, 2);
            this.tableLayoutPaneltlogs.Controls.Add(this.lbl_playbackspeed, 2, 2);
            this.tableLayoutPaneltlogs.Name = "tableLayoutPaneltlogs";
            // 
            // BUT_loadtelem
            // 
            this.BUT_loadtelem.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_loadtelem.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_loadtelem.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_loadtelem.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_loadtelem.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_loadtelem, "BUT_loadtelem");
            this.BUT_loadtelem.Name = "BUT_loadtelem";
            this.BUT_loadtelem.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_loadtelem.UseVisualStyleBackColor = true;
            this.BUT_loadtelem.Click += new System.EventHandler(this.BUT_loadtelem_Click);
            // 
            // tracklog
            // 
            resources.ApplyResources(this.tracklog, "tracklog");
            this.tracklog.Maximum = 100;
            this.tracklog.Name = "tracklog";
            this.tracklog.TickFrequency = 5;
            this.tracklog.Scroll += new System.EventHandler(this.tracklog_Scroll);
            // 
            // lbl_logpercent
            // 
            resources.ApplyResources(this.lbl_logpercent, "lbl_logpercent");
            this.lbl_logpercent.Name = "lbl_logpercent";
            this.lbl_logpercent.resize = false;
            // 
            // LBL_logfn
            // 
            this.tableLayoutPaneltlogs.SetColumnSpan(this.LBL_logfn, 2);
            resources.ApplyResources(this.LBL_logfn, "LBL_logfn");
            this.LBL_logfn.Name = "LBL_logfn";
            this.LBL_logfn.resize = false;
            // 
            // BUT_log2kml
            // 
            this.BUT_log2kml.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_log2kml.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_log2kml.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_log2kml.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_log2kml.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_log2kml, "BUT_log2kml");
            this.BUT_log2kml.Name = "BUT_log2kml";
            this.BUT_log2kml.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_log2kml.UseVisualStyleBackColor = true;
            this.BUT_log2kml.Click += new System.EventHandler(this.BUT_log2kml_Click);
            // 
            // BUT_playlog
            // 
            this.BUT_playlog.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_playlog.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_playlog.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_playlog.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_playlog.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_playlog, "BUT_playlog");
            this.BUT_playlog.Name = "BUT_playlog";
            this.BUT_playlog.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_playlog.UseVisualStyleBackColor = true;
            this.BUT_playlog.Click += new System.EventHandler(this.BUT_playlog_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.BUT_speed10);
            this.panel4.Controls.Add(this.BUT_speed5);
            this.panel4.Controls.Add(this.BUT_speed2);
            this.panel4.Controls.Add(this.BUT_speed1);
            this.panel4.Controls.Add(this.BUT_speed1_2);
            this.panel4.Controls.Add(this.BUT_speed1_4);
            this.panel4.Controls.Add(this.BUT_speed1_10);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // BUT_speed10
            // 
            this.BUT_speed10.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed10.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed10.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed10.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed10.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed10, "BUT_speed10");
            this.BUT_speed10.Name = "BUT_speed10";
            this.BUT_speed10.Tag = "10";
            this.BUT_speed10.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed10.UseVisualStyleBackColor = true;
            this.BUT_speed10.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed5
            // 
            this.BUT_speed5.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed5.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed5.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed5.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed5.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed5, "BUT_speed5");
            this.BUT_speed5.Name = "BUT_speed5";
            this.BUT_speed5.Tag = "5";
            this.BUT_speed5.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed5.UseVisualStyleBackColor = true;
            this.BUT_speed5.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed2
            // 
            this.BUT_speed2.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed2.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed2.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed2.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed2.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed2, "BUT_speed2");
            this.BUT_speed2.Name = "BUT_speed2";
            this.BUT_speed2.Tag = "2";
            this.BUT_speed2.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed2.UseVisualStyleBackColor = true;
            this.BUT_speed2.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed1
            // 
            this.BUT_speed1.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed1.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed1.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed1.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed1.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed1, "BUT_speed1");
            this.BUT_speed1.Name = "BUT_speed1";
            this.BUT_speed1.Tag = "1";
            this.BUT_speed1.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed1.UseVisualStyleBackColor = true;
            this.BUT_speed1.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed1_2
            // 
            this.BUT_speed1_2.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed1_2.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed1_2.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed1_2.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed1_2.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed1_2, "BUT_speed1_2");
            this.BUT_speed1_2.Name = "BUT_speed1_2";
            this.BUT_speed1_2.Tag = "0.5";
            this.BUT_speed1_2.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed1_2.UseVisualStyleBackColor = true;
            this.BUT_speed1_2.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed1_4
            // 
            this.BUT_speed1_4.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed1_4.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed1_4.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed1_4.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed1_4.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed1_4, "BUT_speed1_4");
            this.BUT_speed1_4.Name = "BUT_speed1_4";
            this.BUT_speed1_4.Tag = "0.25";
            this.BUT_speed1_4.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed1_4.UseVisualStyleBackColor = true;
            this.BUT_speed1_4.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // BUT_speed1_10
            // 
            this.BUT_speed1_10.BGGradBot = System.Drawing.Color.LightGray;
            this.BUT_speed1_10.BGGradTop = System.Drawing.Color.DarkGray;
            this.BUT_speed1_10.ColorMouseDown = System.Drawing.Color.Gray;
            this.BUT_speed1_10.ColorMouseOver = System.Drawing.Color.Empty;
            this.BUT_speed1_10.ColorNotEnabled = System.Drawing.Color.Empty;
            resources.ApplyResources(this.BUT_speed1_10, "BUT_speed1_10");
            this.BUT_speed1_10.Name = "BUT_speed1_10";
            this.BUT_speed1_10.Tag = "0.1";
            this.BUT_speed1_10.TextColor = System.Drawing.Color.WhiteSmoke;
            this.BUT_speed1_10.UseVisualStyleBackColor = true;
            this.BUT_speed1_10.Click += new System.EventHandler(this.BUT_speed1_10_Click);
            // 
            // lbl_playbackspeed
            // 
            resources.ApplyResources(this.lbl_playbackspeed, "lbl_playbackspeed");
            this.lbl_playbackspeed.Name = "lbl_playbackspeed";
            this.lbl_playbackspeed.resize = false;
            // 
            // DataFlashLog
            // 
            this.DataFlashLog.Controls.Add(this.myButton10);
            this.DataFlashLog.Controls.Add(this.myButton9);
            this.DataFlashLog.Controls.Add(this.myButton8);
            this.DataFlashLog.Controls.Add(this.myButton3);
            this.DataFlashLog.Controls.Add(this.myButton2);
            this.DataFlashLog.Controls.Add(this.myButton1);
            resources.ApplyResources(this.DataFlashLog, "DataFlashLog");
            this.DataFlashLog.Name = "DataFlashLog";
            this.DataFlashLog.UseVisualStyleBackColor = true;
            // 
            // myButton10
            // 
            this.myButton10.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton10.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton10.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton10, "myButton10");
            this.myButton10.Name = "myButton10";
            this.myButton10.TextColor = System.Drawing.Color.White;
            this.myButton10.UseVisualStyleBackColor = true;
            this.myButton10.Click += new System.EventHandler(this.myButton10_Click);
            // 
            // myButton9
            // 
            this.myButton9.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton9.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton9.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton9, "myButton9");
            this.myButton9.Name = "myButton9";
            this.myButton9.TextColor = System.Drawing.Color.White;
            this.myButton9.UseVisualStyleBackColor = true;
            this.myButton9.Click += new System.EventHandler(this.myButton9_Click);
            // 
            // myButton8
            // 
            this.myButton8.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton8.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton8.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton8, "myButton8");
            this.myButton8.Name = "myButton8";
            this.myButton8.TextColor = System.Drawing.Color.White;
            this.myButton8.UseVisualStyleBackColor = true;
            this.myButton8.Click += new System.EventHandler(this.myButton8_Click);
            // 
            // myButton3
            // 
            this.myButton3.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton3.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton3.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton3, "myButton3");
            this.myButton3.Name = "myButton3";
            this.myButton3.TextColor = System.Drawing.Color.White;
            this.myButton3.UseVisualStyleBackColor = true;
            this.myButton3.Click += new System.EventHandler(this.myButton3_Click);
            // 
            // myButton2
            // 
            this.myButton2.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton2.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton2.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton2, "myButton2");
            this.myButton2.Name = "myButton2";
            this.myButton2.TextColor = System.Drawing.Color.White;
            this.myButton2.UseVisualStyleBackColor = true;
            this.myButton2.Click += new System.EventHandler(this.myButton2_Click);
            // 
            // myButton1
            // 
            this.myButton1.BGGradBot = System.Drawing.Color.LightGray;
            this.myButton1.BGGradTop = System.Drawing.Color.DarkGray;
            this.myButton1.ColorMouseDown = System.Drawing.Color.Gray;
            resources.ApplyResources(this.myButton1, "myButton1");
            this.myButton1.Name = "myButton1";
            this.myButton1.TextColor = System.Drawing.Color.White;
            this.myButton1.UseVisualStyleBackColor = true;
            this.myButton1.Click += new System.EventHandler(this.myButton1_Click);
            // 
            // CB_Dbug
            // 
            resources.ApplyResources(this.CB_Dbug, "CB_Dbug");
            this.CB_Dbug.Name = "CB_Dbug";
            this.CB_Dbug.UseVisualStyleBackColor = true;
            this.CB_Dbug.CheckedChanged += new System.EventHandler(this.CB_Dbug_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(120)))), ((int)(((byte)(127)))));
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuConnect,
            this.toolStripConnectionControl});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseDown);
            this.toolStrip1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseMove);
            this.toolStrip1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.toolStrip1_MouseUp);
            // 
            // MenuConnect
            // 
            this.MenuConnect.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.MenuConnect, "MenuConnect");
            this.MenuConnect.BackColor = System.Drawing.Color.DimGray;
            this.MenuConnect.ForeColor = System.Drawing.Color.Black;
            this.MenuConnect.Image = global::MissionPlanner.Properties.Resources.disconnect001;
            this.MenuConnect.Margin = new System.Windows.Forms.Padding(0);
            this.MenuConnect.Name = "MenuConnect";
            this.MenuConnect.Click += new System.EventHandler(this.MenuConnect_Click);
            // 
            // toolStripConnectionControl
            // 
            this.toolStripConnectionControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            resources.ApplyResources(this.toolStripConnectionControl, "toolStripConnectionControl");
            this.toolStripConnectionControl.ForeColor = System.Drawing.Color.Black;
            this.toolStripConnectionControl.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripConnectionControl.Name = "toolStripConnectionControl";
            this.toolStripConnectionControl.MouseLeave += new System.EventHandler(this.MainMenu_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.hud1);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // hud1
            // 
            this.hud1.airspeed = 0F;
            this.hud1.alt = 0F;
            this.hud1.BackColor = System.Drawing.Color.Black;
            this.hud1.batterylevel = 0F;
            this.hud1.batteryremaining = 0F;
            this.hud1.bgimage = null;
            this.hud1.connected = false;
            this.hud1.current = 0F;
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("airspeed", this.bindingSource_hub, "airspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("alt", this.bindingSource_hub, "alt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("batterylevel", this.bindingSource_hub, "battery_voltage", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("batteryremaining", this.bindingSource_hub, "battery_remaining", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("connected", this.bindingSource_hub, "connected", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("current", this.bindingSource_hub, "current", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("datetime", this.bindingSource_hub, "datetime", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("disttowp", this.bindingSource_hub, "wp_dist", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("ekfstatus", this.bindingSource_hub, "ekfstatus", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("failsafe", this.bindingSource_hub, "failsafe", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix", this.bindingSource_hub, "gpsstatus", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpsfix2", this.bindingSource_hub, "gpsstatus2", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop", this.bindingSource_hub, "gpshdop", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("gpshdop2", this.bindingSource_hub, "gpshdop2", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundalt", this.bindingSource_hub, "HomeAlt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundcourse", this.bindingSource_hub, "groundcourse", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("groundspeed", this.bindingSource_hub, "groundspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("heading", this.bindingSource_hub, "yaw", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("linkqualitygcs", this.bindingSource_hub, "linkqualitygcs", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("message", this.bindingSource_hub, "messageHigh", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("messagetime", this.bindingSource_hub, "messageHighTime", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("mode", this.bindingSource_hub, "mode", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("navpitch", this.bindingSource_hub, "nav_pitch", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("navroll", this.bindingSource_hub, "nav_roll", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("pitch", this.bindingSource_hub, "pitch", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("roll", this.bindingSource_hub, "roll", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("status", this.bindingSource_hub, "armed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetalt", this.bindingSource_hub, "targetalt", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetheading", this.bindingSource_hub, "nav_bearing", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("targetspeed", this.bindingSource_hub, "targetairspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("turnrate", this.bindingSource_hub, "turnrate", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("verticalspeed", this.bindingSource_hub, "verticalspeed", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibex", this.bindingSource_hub, "vibex", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibey", this.bindingSource_hub, "vibey", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("vibez", this.bindingSource_hub, "vibez", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("wpno", this.bindingSource_hub, "wpno", true));
            this.hud1.DataBindings.Add(new System.Windows.Forms.Binding("xtrack_error", this.bindingSource_hub, "xtrack_error", true));
            this.hud1.datetime = new System.DateTime(((long)(0)));
            this.hud1.disttowp = 0F;
            resources.ApplyResources(this.hud1, "hud1");
            this.hud1.ekfstatus = 0F;
            this.hud1.failsafe = false;
            this.hud1.gpsfix = 0F;
            this.hud1.gpsfix2 = 0F;
            this.hud1.gpshdop = 0F;
            this.hud1.gpshdop2 = 0F;
            this.hud1.groundalt = 0F;
            this.hud1.groundcourse = 0F;
            this.hud1.groundspeed = 0F;
            this.hud1.heading = 0F;
            this.hud1.hudcolor = System.Drawing.Color.LightGray;
            this.hud1.linkqualitygcs = 0F;
            this.hud1.lowairspeed = false;
            this.hud1.lowgroundspeed = false;
            this.hud1.lowvoltagealert = false;
            this.hud1.message = null;
            this.hud1.messagetime = new System.DateTime(((long)(0)));
            this.hud1.mode = "Manual";
            this.hud1.Name = "hud1";
            this.hud1.navpitch = 0F;
            this.hud1.navroll = 0F;
            this.hud1.pitch = 0F;
            this.hud1.roll = 0F;
            this.hud1.Russian = false;
            this.hud1.status = false;
            this.hud1.streamjpg = ((System.IO.MemoryStream)(resources.GetObject("hud1.streamjpg")));
            this.hud1.targetalt = 0F;
            this.hud1.targetheading = 0F;
            this.hud1.targetspeed = 0F;
            this.hud1.turnrate = 0F;
            this.hud1.verticalspeed = 0F;
            this.hud1.vibex = 0F;
            this.hud1.vibey = 0F;
            this.hud1.vibez = 0F;
            this.hud1.VSync = false;
            this.hud1.wpno = 0;
            this.hud1.xtrack_error = 0F;
            // 
            // bindingSourceQTab
            // 
            this.bindingSourceQTab.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // Messagetabletimer1
            // 
            this.Messagetabletimer1.Interval = 200;
            this.Messagetabletimer1.Tick += new System.EventHandler(this.Messagetalbetimer1_Tick);
            // 
            // currentStateBindingSource
            // 
            this.currentStateBindingSource.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // ZedTimer
            // 
            this.ZedTimer.Tick += new System.EventHandler(this.ZedTimer_Tick);
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(MissionPlanner.GCSViews.FlightPlanner);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.zedGraphControl1);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // zedGraphControl1
            // 
            resources.ApplyResources(this.zedGraphControl1, "zedGraphControl1");
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.DoubleClick += new System.EventHandler(this.zedGraphControl1_DoubleClick);
            // 
            // bindingSourcepreflight
            // 
            this.bindingSourcepreflight.DataSource = typeof(MissionPlanner.CurrentState);
            // 
            // MainV2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "MainV2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainV2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainV2_KeyDown);
            this.Resize += new System.EventHandler(this.MainV2_Resize);
            this.CTX_mainmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_hub)).EndInit();
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControlactions.ResumeLayout(false);
            this.tabActions.ResumeLayout(false);
            this.tabPagePreFlight.ResumeLayout(false);
            this.tabTLogs.ResumeLayout(false);
            this.tableLayoutPaneltlogs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tracklog)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.DataFlashLog.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceQTab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcepreflight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip CTX_mainmenu;
        private System.Windows.Forms.ToolStripMenuItem autoHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readonlyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionOptionsToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource_hub;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Controls.HUD hud1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripButton MenuConnect;
        private Controls.ToolStripConnectionControl toolStripConnectionControl;
        private System.Windows.Forms.BindingSource bindingSourceQTab;
        private System.Windows.Forms.SplitContainer splitContainer3;
        public System.Windows.Forms.TabControl tabControlactions;
        public System.Windows.Forms.TabPage tabActions;
        private Controls.ModifyandSet modifyandSetLoiterRad;
        private Controls.MyButton BUT_ARM;
        private Controls.MyButton BUT_quickmanual;
        private Controls.MyButton BUT_quickrtl;
        private Controls.MyButton BUT_quickauto;
        private System.Windows.Forms.ComboBox CMB_setwp;
        private Controls.MyButton BUT_setwp;
        private System.Windows.Forms.ComboBox CMB_modes;
        private Controls.MyButton BUT_setmode;
        private System.Windows.Forms.ComboBox CMB_action;
        private Controls.MyButton BUT_Homealt;
        private Controls.MyButton BUTactiondo;
        private Controls.ModifyandSet modifyandSetSpeed;
        private Controls.ModifyandSet modifyandSetAlt;
        private System.Windows.Forms.TabPage tabPagePreFlight;
        private Controls.PreFlight.CheckListControl checkListControl1;
        private System.Windows.Forms.TabPage tabTLogs;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPaneltlogs;
        private Controls.MyButton BUT_loadtelem;
        private Controls.MyLabel lbl_playbackspeed;
        private Controls.MyLabel lbl_logpercent;
        private Controls.MyLabel LBL_logfn;
        private Controls.MyButton BUT_log2kml;
        private Controls.MyButton BUT_playlog;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private Controls.MyButton BUT_speed10;
        private Controls.MyButton BUT_speed5;
        private Controls.MyButton BUT_speed2;
        private Controls.MyButton BUT_speed1;
        private Controls.MyButton BUT_speed1_2;
        private Controls.MyButton BUT_speed1_4;
        private Controls.MyButton BUT_speed1_10;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer Messagetabletimer1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource currentStateBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private Controls.MyButton myButton6;
        private Controls.MyButton myButton7;
        private Controls.MyButton myButton4;
        private Controls.MyButton myButton5;
        private System.Windows.Forms.TabPage tabPageStatustext;
        private System.Windows.Forms.Timer ZedTimer;
        private System.Windows.Forms.CheckBox CB_Dbug;
        private System.Windows.Forms.TrackBar tracklog;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel panel3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.TabPage DataFlashLog;
        private Controls.MyButton myButton10;
        private Controls.MyButton myButton9;
        private Controls.MyButton myButton8;
        private Controls.MyButton myButton3;
        private Controls.MyButton myButton2;
        private Controls.MyButton myButton1;
        private System.Windows.Forms.BindingSource bindingSourcepreflight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
    }
}