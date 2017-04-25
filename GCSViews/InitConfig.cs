using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MissionPlanner.GCSViews
{
    public partial class InitConfig : Form
    {
        public InitConfig()
        {


            InitializeComponent();
            GCSViews.ConfigurationView.ConfigHWCompass w1 = new GCSViews.ConfigurationView.ConfigHWCompass();
            w1.Activate();
            w1.Parent = tabPage1;
            w1.Dock = DockStyle.Fill;
            w1.Show();
 

        }


        private void configFlightModes1_Load(object sender, EventArgs e)
        {
            
            //TabInitConfig.SelectedIndex = 1;

        }

        private void TabInitConfig_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (TabInitConfig.SelectedTab == tabPage1)
            {
                InitializeComponent();
                GCSViews.ConfigurationView.ConfigHWCompass w1 = new GCSViews.ConfigurationView.ConfigHWCompass();
                w1.Activate();
                w1.Parent = tabPage1;
                w1.Dock = DockStyle.Fill;
                w1.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage2)
            {
                GCSViews.ConfigurationView.ConfigFlightModes w1 = new GCSViews.ConfigurationView.ConfigFlightModes();
                w1.Activate();
                w1.Parent = tabPage2;
                w1.Dock = DockStyle.Fill;
                w1.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage3)
            {
                GCSViews.ConfigurationView.ConfigAccelerometerCalibration w1 = new GCSViews.ConfigurationView.ConfigAccelerometerCalibration();
                w1.Activate();
                w1.Parent = tabPage3;
                w1.Dock = DockStyle.Fill;
                w1.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage4)
            {
                GCSViews.ConfigurationView.ConfigRadioInput w1 = new GCSViews.ConfigurationView.ConfigRadioInput();
                w1.Activate();
                w1.Parent = tabPage4;
                w1.Dock = DockStyle.Fill;
                w1.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage5)
            {
                if (MainV2.comPort.MAV.cs.version >= Version.Parse("3.5"))
                {
                    GCSViews.ConfigurationView.ConfigFrameClassType w1 = new GCSViews.ConfigurationView.ConfigFrameClassType();
                    w1.Activate();
                    w1.Parent = tabPage5;
                    w1.Dock = DockStyle.Fill;
                    w1.Show();
                }
                else
                {
                    GCSViews.ConfigurationView.ConfigFrameType w2 = new GCSViews.ConfigurationView.ConfigFrameType();
                    w2.Activate();
                    w2.Parent = tabPage5;
                    w2.Dock = DockStyle.Fill;
                    w2.Show();
                }
            }

            }
    }
}
