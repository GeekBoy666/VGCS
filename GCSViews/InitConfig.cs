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
        public bool isCopter35plus
        {
            get { return MainV2.comPort.MAV.cs.version >= Version.Parse("3.5"); }
        }
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
                list.Add("OCTAQUADX");
                list.Add("Y6A");
                //DO_SET_SERVO
                //DO_REPEAT_SERVO
            }

            


            this.comboBoxSelectairframe.DrawItem+= new DrawItemEventHandler(ComboBox1_DrawItem);
            this.comboBoxSelectairframe.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxSelectairframe.DataSource = list;

            //comboBoxSelectairframe.SelectedIndex = 1;
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
            if (work_frame_class == motor_frame_class.MOTOR_FRAME_QUAD)
            {
                if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_PLUS)
                { comboBoxSelectairframe.SelectedIndex = 2; }
                
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
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600101;
            }
            else if (text == "QUADX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600102;
            }
            else if (text == "QUADV")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600103;
            }
            else if (text == "QUADH")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600104;
            }
            else if (text == "HEXA+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600105;
            }
            else if (text == "HEXAX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600106;
            }
            else if (text == "OCTA+")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600107;
            }
            else if (text == "OCTAX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600108;
            }
            else if (text == "OCTAV")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600109;
            }
            else if (text == "OCTAQUADX")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600110;
            }
            else if (text == "Y6A")
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600111;
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
                GCSViews.ConfigurationView.ConfigFlightModes FMode = new GCSViews.ConfigurationView.ConfigFlightModes();

                FMode.Parent = tabPage1;
                FMode.Dock = DockStyle.Fill;
                FMode.ForeColor = Color.Black;
                FMode.Activate();
                ThemeManager.SetTheme(ThemeManager.Themes.HighContrast);
                ThemeManager.ApplyThemeTo(FMode);
                FMode.Show();

            }
            else if (TabInitConfig.SelectedTab == tabPage2)
            {
                GCSViews.ConfigurationView.ConfigHWCompass Compass = new GCSViews.ConfigurationView.ConfigHWCompass();
                
                Compass.Parent = tabPage2;
                Compass.Dock = DockStyle.Fill;
                Compass.ForeColor = Color.Black;
                Compass.Activate();
                Compass.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage3)
            {
                GCSViews.ConfigurationView.ConfigAccelerometerCalibration Accel = new GCSViews.ConfigurationView.ConfigAccelerometerCalibration();

                Accel.Parent = tabPage3;
                Accel.Dock = DockStyle.Fill;
                Accel.ForeColor = Color.Black;
                Accel.Activate();
                Accel.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage4)
            {
                GCSViews.ConfigurationView.ConfigRadioInput Radio = new GCSViews.ConfigurationView.ConfigRadioInput();

                Radio.Parent = tabPage4;
                Radio.Dock = DockStyle.Fill;
                Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage5)
            {
                GCSViews.ConfigurationView.ConfigESCCalibration ESC = new GCSViews.ConfigurationView.ConfigESCCalibration();

                ESC.Parent = groupBoxEsc;
                ESC.Dock = DockStyle.Fill;
                ESC.ForeColor = Color.Black;
                ESC.Activate();
                ESC.Show();

                GCSViews.ConfigurationView.ConfigMotorTest MotorTest = new GCSViews.ConfigurationView.ConfigMotorTest();
                MotorTest.Parent = groupBoxMotorTest;
                MotorTest.Dock = DockStyle.Fill;
                MotorTest.ForeColor = Color.Black;
                MotorTest.Activate();
                MotorTest.Show();
                if (isCopter35plus)
                {
                    if (!MainV2.comPort.MAV.param.ContainsKey("FRAME_CLASS") || !MainV2.comPort.MAV.param.ContainsKey("FRAME_TYPE"))
                    {
                        //Enabled = false;
                        //return;
                        comboBoxSelectairframe.SelectedIndex = 0;
                    }

                    // pre seed the correct values
                    work_frame_class = (motor_frame_class)
                        Enum.Parse(typeof(motor_frame_class), MainV2.comPort.MAV.param["FRAME_CLASS"].ToString());
                    work_frame_type = (motor_frame_type)
                        Enum.Parse(typeof(motor_frame_type), MainV2.comPort.MAV.param["FRAME_TYPE"].ToString());

                    this.LogInfoFormat("Existing Class: {0} Type: {1}", work_frame_class, work_frame_type);
                    if (work_frame_class == motor_frame_class.MOTOR_FRAME_QUAD)
                    {
                        if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_PLUS)
                        { comboBoxSelectairframe.SelectedIndex = 1; }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_X)
                        {
                            comboBoxSelectairframe.SelectedIndex = 2;
                        }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_V)
                        {
                            comboBoxSelectairframe.SelectedIndex = 3;
                        }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_H)
                        {
                            comboBoxSelectairframe.SelectedIndex = 4;
                        }
                    }
                    else if (work_frame_class == motor_frame_class.MOTOR_FRAME_HEXA)
                    {
                        if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_PLUS)
                        { comboBoxSelectairframe.SelectedIndex = 5; }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_X)
                        {
                            comboBoxSelectairframe.SelectedIndex = 6;
                        }
                    }
                    else if (work_frame_class == motor_frame_class.MOTOR_FRAME_OCTA)
                    {
                        if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_PLUS)
                        { comboBoxSelectairframe.SelectedIndex = 7; }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_X)
                        {
                            comboBoxSelectairframe.SelectedIndex = 8;
                        }
                        else if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_V)
                        {
                            comboBoxSelectairframe.SelectedIndex = 9;
                        }
                    }
                    else if (work_frame_class == motor_frame_class.MOTOR_FRAME_OCTAQUAD)
                    {
                        if (work_frame_type == motor_frame_type.MOTOR_FRAME_TYPE_X)
                        {
                            comboBoxSelectairframe.SelectedIndex = 10;
                        }
                    }
                    else if (work_frame_class == motor_frame_class.MOTOR_FRAME_Y6)
                    {
                        comboBoxSelectairframe.SelectedIndex = 11;
                    }
                }
                else
                {
                    groupBoxAirframe.Controls.Clear();
                    GCSViews.ConfigurationView.ConfigFrameType Radio = new GCSViews.ConfigurationView.ConfigFrameType();
                    Radio.Parent = groupBoxAirframe;
                    Radio.Dock = DockStyle.Fill;
                    Radio.ForeColor = Color.Black;
                    Radio.Activate();
                    Radio.Show();
                }

            }
            else if (TabInitConfig.SelectedTab == tabPage9)
            {
                GCSViews.ConfigurationView.ConfigBatteryMonitoring Radio = new GCSViews.ConfigurationView.ConfigBatteryMonitoring();

                Radio.Parent = tabPage9;
                Radio.Dock = DockStyle.Fill;
                Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage8)
            {
                GCSViews.ConfigurationView.ConfigMount Radio = new GCSViews.ConfigurationView.ConfigMount();

                Radio.Parent = tabPage8;
                Radio.Dock = DockStyle.Fill;
                //Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage11)
            {
                GCSViews.ConfigurationView.ConfigArducopter Radio = new GCSViews.ConfigurationView.ConfigArducopter();

                Radio.Parent = tabPage11;
                Radio.Dock = DockStyle.Fill;
                Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage10)
            {
                GCSViews.ConfigurationView.ConfigRawParams Radio = new GCSViews.ConfigurationView.ConfigRawParams();

                Radio.Parent = tabPage10;
                Radio.Dock = DockStyle.Fill;
       
                //Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage12)
            {
                GCSViews.ConfigurationView.ConfigRawParamsTree ParamsTree = new GCSViews.ConfigurationView.ConfigRawParamsTree();

                ParamsTree.Parent = tabPage12;
                ParamsTree.Dock = DockStyle.Fill;
                //ParamsTree.BackColor = Color.Gray;
                //ParamsTree.ForeColor = Color.Black;
                ParamsTree.Activate();
                ParamsTree.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage13)
            {
                GCSViews.ConfigurationView.ConfigFailSafe Radio = new GCSViews.ConfigurationView.ConfigFailSafe();

                Radio.Parent = tabPage13;
                Radio.Dock = DockStyle.Fill;
                Radio.ForeColor = Color.Black;
                Radio.Activate();
                Radio.Show();
            }
            else if (TabInitConfig.SelectedTab == tabPage14)
            {
                GCSViews.ConfigurationView.ConfigLoadFirmware Radio = new GCSViews.ConfigurationView.ConfigLoadFirmware();

                Radio.Parent = tabPage14;
                Radio.Dock = DockStyle.Fill;
               // Radio.BackColor = Color.Gray;
                //Radio.ForeColor = Color.Black;
                //Radio.Activate();
                Radio.Show();
            }


        }
        private void SetFrameParam(motor_frame_class frame_class, motor_frame_type frame_type)
        {
            try
            {
                MainV2.comPort.setParam("FRAME_CLASS", (int)frame_class);
                MainV2.comPort.setParam("FRAME_TYPE", (int)frame_type);
            }
            catch
            {
                CustomMessageBox.Show(string.Format(Strings.ErrorSetValueFailed, "FRAME_CLASS OR FRAME_TYPE"), Strings.ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600101;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_QUAD, motor_frame_type.MOTOR_FRAME_TYPE_PLUS);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 2)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600102;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_QUAD, motor_frame_type.MOTOR_FRAME_TYPE_X);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 3)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600103;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_QUAD, motor_frame_type.MOTOR_FRAME_TYPE_V);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 4)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600104;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_QUAD, motor_frame_type.MOTOR_FRAME_TYPE_H);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 5)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600105;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_HEXA, motor_frame_type.MOTOR_FRAME_TYPE_PLUS);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 6)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600106;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_HEXA, motor_frame_type.MOTOR_FRAME_TYPE_X);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 7)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600107;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_OCTA, motor_frame_type.MOTOR_FRAME_TYPE_PLUS);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 8)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600108;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_OCTA, motor_frame_type.MOTOR_FRAME_TYPE_X);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 9)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600109;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_OCTA, motor_frame_type.MOTOR_FRAME_TYPE_V);
            }
            else if (comboBoxSelectairframe.SelectedIndex == 10)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600110;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_OCTAQUAD, motor_frame_type.MOTOR_FRAME_TYPE_X);
            }

            else if (comboBoxSelectairframe.SelectedIndex == 11)
            {
                pictureBoxAirframe.Image = MissionPlanner.Properties.Resources._600111;
                SetFrameParam(motor_frame_class.MOTOR_FRAME_Y6, motor_frame_type.MOTOR_FRAME_TYPE_ATAIL);
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
