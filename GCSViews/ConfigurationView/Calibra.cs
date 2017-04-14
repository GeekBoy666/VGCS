using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using MissionPlanner.Controls;
using MissionPlanner.Controls.BackstageView;
using MissionPlanner.GCSViews.ConfigurationView;
using MissionPlanner.Utilities;
using System.Resources;
using System.Reflection;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class Calibra : MyUserControl, IActivate
    {

        internal static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static string lastpagename = "";

        public Calibra()
        {
            InitializeComponent();
            tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControl1.DrawItem += new DrawItemEventHandler(this.TabControl_DrawItem);
        }
        public bool isConnected
        {
            get { return MainV2.comPort.BaseStream.IsOpen; }
        }
        private BackstageViewPage AddBackstageViewPage(Type userControl, string headerText, bool enabled = true,
    BackstageViewPage Parent = null, bool advanced = false)
        {
            try
            {
                if (enabled)
                    return backstageView.AddPage(userControl, headerText, Parent, advanced);
            }
            catch (Exception ex)
            {
                log.Error(ex);
                return null;
            }

            return null;
        }
        private void TabControl_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Font fntTab;
            Brush bshBack;
            Brush bshFore;
            if (e.Index == this.tabControl1.SelectedIndex)
            {
                fntTab = new Font(new FontFamily("华文行楷"), e.Font.Size, FontStyle.Regular);
                //bshBack = new System.Drawing.Drawing2D.LinearGradientBrush(e.Bounds, SystemColors.Control, SystemColors.Control, System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal);
                bshBack = new SolidBrush(Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(151)))), ((int)(((byte)(248))))));
                bshFore = Brushes.White;
            }
            else
            {
                fntTab = new Font(new FontFamily("华文行楷"), e.Font.Size, FontStyle.Regular);
                bshBack = new SolidBrush(Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200))))));
                bshFore = new SolidBrush(Color.Black);
            }
            string tabName = tabControl1.TabPages[e.Index].Text;
            StringFormat sftTab = new StringFormat();
            e.Graphics.FillRectangle(bshBack, e.Bounds);
            Rectangle recTab = e.Bounds;
            recTab = new Rectangle(recTab.X, recTab.Y + 4, recTab.Width, recTab.Height - 4);
            e.Graphics.DrawString(tabName, fntTab, bshFore, recTab, sftTab);
        }

        private void Calibra_Load(object sender, EventArgs e)
        {
            //tabPage1.BackColor = Color.LightBlue;
        }
        public void Activate()
        {
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage3)
            {
                configRadioInput1.Activate();
            }


            //ResourceManager rm = new ResourceManager(this.GetType());
            //if (tabControl1.SelectedTab == tabPage3)
            //{

                //    var mand = AddBackstageViewPage(typeof(ConfigMandatory), rm.GetString("backstageViewPagemand.Text"), isConnected);
                //    AddBackstageViewPage(typeof(ConfigRadioInput), rm.GetString("backstageViewPageradio.Text"), isConnected, mand);
                //    // remeber last page accessed
                //    foreach (BackstageViewPage page in backstageView.Pages)
                //    {
                //        if (page.LinkText == lastpagename && page.Show)
                //        {
                //            backstageView.ActivatePage(page);
                //            break;
                //        }
                //    }
                //    GCSViews.ConfigurationView.ConfigRadioInput w1 = new GCSViews.ConfigurationView.ConfigRadioInput();
                //    w1.Parent = tabPage3;
                //    w1.Dock = DockStyle.Fill;
                //    w1.Show();
                //}
        }


    }
}
