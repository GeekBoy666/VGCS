using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using MissionPlanner.Utilities;

namespace MissionPlanner.GCSViews
{
    public partial class InitConfig : Form
    {
        private motor_frame_class work_frame_class;
        private motor_frame_type work_frame_type;

        public enum motor_frame_class
        {
            MOTOR_FRAME_UNDEFINED = 0,
            MOTOR_FRAME_QUAD = 1,
            MOTOR_FRAME_HEXA = 2,
            MOTOR_FRAME_OCTA = 3,
            MOTOR_FRAME_OCTAQUAD = 4,
            MOTOR_FRAME_Y6 = 5,
            MOTOR_FRAME_HELI = 6,
            MOTOR_FRAME_TRI = 7,
            MOTOR_FRAME_SINGLE = 8,
            MOTOR_FRAME_COAX = 9
        };

        public enum motor_frame_type
        {
            MOTOR_FRAME_TYPE_PLUS = 0,
            MOTOR_FRAME_TYPE_X = 1,
            MOTOR_FRAME_TYPE_V = 2,
            MOTOR_FRAME_TYPE_H = 3,
            MOTOR_FRAME_TYPE_VTAIL = 4,
            MOTOR_FRAME_TYPE_ATAIL = 5,
            MOTOR_FRAME_TYPE_Y6B = 10

        };
        public InitConfig()
        {


            InitializeComponent();
            GCSViews.ConfigurationView.ConfigHWCompass w1 = new GCSViews.ConfigurationView.ConfigHWCompass();
            w1.Activate();
            w1.Parent = tabPage1;
            w1.Dock = DockStyle.Fill;
            w1.Show();
            List<string> list = new List<string>();

            {
                list.Add("Undefined");
                list.Add("QUAD+");
                list.Add("QUADX");
                list.Add("QUADV");
                list.Add("QUADH");
                list.Add("HEXA+");
                list.Add("HEXAX");
                list.Add("OCTA+");
                list.Add("OCTAX");
                list.Add("OCTAV");
                list.Add("OCTAQUAD+");
                list.Add("OCTAQUADX");
                list.Add("OCTAQUADV");
                list.Add("OCTAQUADH");
                list.Add("Y6A");
                list.Add("TRI");
                //DO_SET_SERVO
                //DO_REPEAT_SERVO
            }

            


            this.comboBoxSelectairframe.DrawItem+= new DrawItemEventHandler(ComboBox1_DrawItem);
            this.comboBoxSelectairframe.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxSelectairframe.DataSource = list;
            
        }
        public new void Activate()
        {
            if (!MainV2.comPort.MAV.param.ContainsKey("FRAME_CLASS") || !MainV2.comPort.MAV.param.ContainsKey("FRAME_TYPE"))
            {
                Enabled = false;
                return;
            }

            // pre seed the correct values
            work_frame_class = (motor_frame_class)
                Enum.Parse(typeof(motor_frame_class), MainV2.comPort.MAV.param["FRAME_CLASS"].ToString());
            work_frame_type = (motor_frame_type)
                Enum.Parse(typeof(motor_frame_type), MainV2.comPort.MAV.param["FRAME_TYPE"].ToString());

            this.LogInfoFormat("Existing Class: {0} Type: {1}", work_frame_class, work_frame_type);
            if ((work_frame_class == motor_frame_class.MOTOR_FRAME_QUAD) && (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_PLUS))
            {
                comboBoxSelectairframe.SelectedIndex = 1;
            }
            //DoClass(work_frame_class);
            //DoType(work_frame_type);
        }

        private void ComboBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            ComboBox combo = sender as ComboBox;
            string text = combo.Items[e.Index].ToString();
            Brush brush = System.Drawing.Brushes.Black;
            if (text == "Undefined")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources.Undefined;
            }
            else if (text == "QUAD+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._500100;
            }
            else if (text == "QUADX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001001;
            }
            else if (text == "QUADV")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001003;
            }
            else if (text == "QUADH")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001004;
            }
            else if (text == "HEXA+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001005;
            }
            else if (text == "HEXAX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001006;
            }
            else if (text == "OCTA+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001007;
            }
            else if (text == "OCTAX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001008;
            }
            else if (text == "OCTAV")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001009;
            }
            else if (text == "OCTAQUAD+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001010;
            }
            else if (text == "OCTAQUADX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001011;
            }
            else if (text == "OCTAQUADV")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001012;
            }
            else if (text == "OCTAQUADH")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010013;
            }
            else if (text == "Y6A")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010014;
            }
            else if (text == "TRI")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010015;
            }

            e.DrawBackground();
            e.Graphics.DrawString(text, combo.Font, brush, e.Bounds.X, e.Bounds.Y);
            e.DrawFocusRectangle();
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
                //if (MainV2.comPort.MAV.cs.version >= Version.Parse("3.5"))
                //{
                //    GCSViews.ConfigurationView.ConfigFrameClassType w1 = new GCSViews.ConfigurationView.ConfigFrameClassType();
                //    w1.Activate();
                //    w1.Parent = tabPage5;
                //    w1.Dock = DockStyle.Fill;
                //    w1.Show();
                //}
                //else
                //{
                //    GCSViews.ConfigurationView.ConfigFrameType w2 = new GCSViews.ConfigurationView.ConfigFrameType();
                //    w2.Activate();
                //    w2.Parent = tabPage5;
                //    w2.Dock = DockStyle.Fill;
                //    w2.Show();
                //}
            }

            }

        private void comboBoxSelectairframe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelectairframe.SelectedIndex == 0)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources.Undefined;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 1)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._500100;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 2)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001001;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 3)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001003;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 4)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001004;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 5)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001005;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 6)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001006;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 7)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001007;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 8)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001008;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 9)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001009;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 10)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001010;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 11)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001011;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 12)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._5001012;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 13)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010013;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 14)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010014;
            }
            else if (comboBoxSelectairframe.SelectedIndex == 15)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._50010015;
            }




            //if (comboBoxSelectairframe.SelectedIndex == 0)
            //{
            //    pictureBoxAirframe.Image = MissionPlanner.Properties.Resources.Undefined;
            //}
            //else if (comboBoxSelectairframe.SelectedIndex == 1)
            //{
            //    pictureBoxAirframe.Image = MissionPlanner.Properties.Resources.QUAD_;
            //}
        }

        private void comboBoxSelectairframe_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        private void comboBoxSelectairframe_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBoxSelectairframe_MouseMove(object sender, MouseEventArgs e)
        {      
        }

        private void comboBoxSelectairframe_ValueMemberChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxSelectairframe_MouseEnter(object sender, EventArgs e)
        {
        }

        private void comboBoxSelectairframe_MouseHover(object sender, EventArgs e)
        {
        }

        private void comboBoxSelectairframe_DropDown(object sender, EventArgs e)
        {
            
        }

        private void comboBoxSelectairframe_MouseCaptureChanged(object sender, EventArgs e)
        {
        }

        private void comboBoxSelectairframe_MouseUp(object sender, MouseEventArgs e)
        {


        }

        private void comboBoxSelectairframe_Click(object sender, EventArgs e)
        {
         
        }
    }
}
