using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Collections;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Reflection;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using MissionPlanner.Utilities;
using IronPython.Hosting;
using log4net;
using MissionPlanner.Controls;
using MissionPlanner.Comms;
using MissionPlanner.Log;
using Transitions;
using MissionPlanner.Warnings;
using System.Collections.Concurrent;
using MissionPlanner.GCSViews.ConfigurationView;
using WebCamService;
using OpenTK;
using MissionPlanner.GCSViews;
using IronPython.Runtime;
using static IronPython.Modules._ast;
using ZedGraph;

namespace MissionPlanner
{
    public partial class MainV2 : Form
    {
        private bool isMouseDown = false;
        private Point mouseOffset; //记录鼠标指针的坐标
        Thread thisthread1;
        public static bool threadrun;
        public static HUD myhud;
        AviWriter aviwriter;
        double LogPlayBackSpeed = 1.0;
        int tickStart;
        bool playingLog;
        RollingPointPairList list1 = new RollingPointPairList(1200);
        RollingPointPairList list2 = new RollingPointPairList(1200);
        RollingPointPairList list3 = new RollingPointPairList(1200);
        RollingPointPairList list4 = new RollingPointPairList(1200);
        RollingPointPairList list5 = new RollingPointPairList(1200);
        RollingPointPairList list6 = new RollingPointPairList(1200);
        RollingPointPairList list7 = new RollingPointPairList(1200);
        RollingPointPairList list8 = new RollingPointPairList(1200);
        RollingPointPairList list9 = new RollingPointPairList(1200);
        RollingPointPairList list10 = new RollingPointPairList(1200);

        PropertyInfo list1item;
        PropertyInfo list2item;
        PropertyInfo list3item;
        PropertyInfo list4item;
        PropertyInfo list5item;
        PropertyInfo list6item;
        PropertyInfo list7item;
        PropertyInfo list8item;
        PropertyInfo list9item;
        PropertyInfo list10item;

        CurveItem list1curve;
        CurveItem list2curve;
        CurveItem list3curve;
        CurveItem list4curve;
        CurveItem list5curve;
        CurveItem list6curve;
        CurveItem list7curve;
        CurveItem list8curve;
        CurveItem list9curve;
        CurveItem list10curve;

        private static readonly ILog log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        //public static FlightData instance1;
        private static class NativeMethods
        {
            // used to hide/show console window
            [DllImport("user32.dll")]
            public static extern int FindWindow(string szClass, string szTitle);

            [DllImport("user32.dll")]
            public static extern int ShowWindow(int Handle, int showState);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            internal static extern IntPtr RegisterDeviceNotification
                (IntPtr hRecipient,
                    IntPtr NotificationFilter,
                    Int32 Flags);

            // Import SetThreadExecutionState Win32 API and necessary flags

            [DllImport("kernel32.dll")]
            public static extern uint SetThreadExecutionState(uint esFlags);

            public const uint ES_CONTINUOUS = 0x80000000;
            public const uint ES_SYSTEM_REQUIRED = 0x00000001;

            static public int SW_SHOWNORMAL = 1;
            static public int SW_HIDE = 0;
        }

        public static menuicons displayicons = new burntkermitmenuicons();

        public abstract class menuicons
        {
            public abstract Image fd { get; }
            public abstract Image fp { get; }
            public abstract Image initsetup { get; }
            public abstract Image config_tuning { get; }
            public abstract Image sim { get; }
            public abstract Image terminal { get; }
            public abstract Image help { get; }
            public abstract Image donate { get; }
            public abstract Image connect { get; }
            public abstract Image disconnect { get; }
            public abstract Image bg { get; }
            public abstract Image wizard { get; }
        }

        public class burntkermitmenuicons : menuicons
        {
            public override Image fd
            {
                get { return global::MissionPlanner.Properties.Resources.light_flightdata_icon; }
            }

            public override Image fp
            {
                get { return global::MissionPlanner.Properties.Resources.light_flightplan_icon; }
            }

            public override Image initsetup
            {
                get { return global::MissionPlanner.Properties.Resources.light_initialsetup_icon; }
            }

            public override Image config_tuning
            {
                get { return global::MissionPlanner.Properties.Resources.light_tuningconfig_icon; }
            }

            public override Image sim
            {
                get { return global::MissionPlanner.Properties.Resources.light_simulation_icon; }
            }

            public override Image terminal
            {
                get { return global::MissionPlanner.Properties.Resources.light_terminal_icon; }
            }

            public override Image help
            {
                get { return global::MissionPlanner.Properties.Resources.light_help_icon; }
            }

            public override Image donate
            {
                get { return global::MissionPlanner.Properties.Resources.donate; }
            }

            public override Image connect
            {
                get { return global::MissionPlanner.Properties.Resources.disconnect001; }
            }

            public override Image disconnect
            {
                get { return global::MissionPlanner.Properties.Resources.connect001; }
            }

            public override Image bg
            {
                get { return global::MissionPlanner.Properties.Resources.bgdark; }
            }
            public override Image wizard
            {
                get { return global::MissionPlanner.Properties.Resources.wizardicon; }
            }
        }

        public class highcontrastmenuicons : menuicons
        {
            public override Image fd
            {
                get { return global::MissionPlanner.Properties.Resources.dark_flightdata_icon; }
            }

            public override Image fp
            {
                get { return global::MissionPlanner.Properties.Resources.dark_flightplan_icon; }
            }

            public override Image initsetup
            {
                get { return global::MissionPlanner.Properties.Resources.dark_initialsetup_icon; }
            }

            public override Image config_tuning
            {
                get { return global::MissionPlanner.Properties.Resources.dark_tuningconfig_icon; }
            }

            public override Image sim
            {
                get { return global::MissionPlanner.Properties.Resources.dark_simulation_icon; }
            }

            public override Image terminal
            {
                get { return global::MissionPlanner.Properties.Resources.dark_terminal_icon; }
            }

            public override Image help
            {
                get { return global::MissionPlanner.Properties.Resources.dark_help_icon; }
            }

            public override Image donate
            {
                get { return global::MissionPlanner.Properties.Resources.donate; }
            }

            public override Image connect
            {
                get { return global::MissionPlanner.Properties.Resources.dark_connect_icon; }
            }

            public override Image disconnect
            {
                get { return global::MissionPlanner.Properties.Resources.dark_disconnect_icon; }
            }

            public override Image bg
            {
                get { return null; }
            }
            public override Image wizard
            {
                get { return global::MissionPlanner.Properties.Resources.wizardicon; }
            }
        }

        Controls.MainSwitcher MyView;

        private static DisplayView _displayConfiguration = new DisplayView().Basic();

        public static event EventHandler LayoutChanged;

        public static DisplayView DisplayConfiguration
        {
            get { return _displayConfiguration; }
            set
            {
                _displayConfiguration = value;
                Settings.Instance["displayview"] = _displayConfiguration.ConvertToString();
                if (LayoutChanged != null)
                    LayoutChanged(null, EventArgs.Empty);
            }
        }


        public static bool ShowAirports { get; set; }
        public static bool ShowTFR { get; set; }

        private Utilities.adsb _adsb;

        public bool EnableADSB
        {
            get { return _adsb != null; }
            set
            {
                if (value == true)
                {
                    _adsb = new Utilities.adsb();

                    if (Settings.Instance["adsbserver"] != null)
                        Utilities.adsb.server = Settings.Instance["adsbserver"];
                    if (Settings.Instance["adsbport"] != null)
                        Utilities.adsb.serverport = int.Parse(Settings.Instance["adsbport"].ToString());
                }
                else
                {
                    Utilities.adsb.Stop();
                    _adsb = null;
                }
            }
        }

        //public static event EventHandler LayoutChanged;

        /// <summary>
        /// Active Comport interface
        /// </summary>
        public static MAVLinkInterface comPort
        {
            get
            {
                return _comPort;
            }
            set
            {
                if (_comPort == value)
                    return;
                _comPort = value;
                _comPort.MavChanged -= instance.comPort_MavChanged;
                _comPort.MavChanged += instance.comPort_MavChanged;
                instance.comPort_MavChanged(null, null);
            }
        }

        static MAVLinkInterface _comPort = new MAVLinkInterface();

        /// <summary>
        /// passive comports
        /// </summary>
        public static List<MAVLinkInterface> Comports = new List<MAVLinkInterface>();

        public delegate void WMDeviceChangeEventHandler(WM_DEVICECHANGE_enum cause);

        public event WMDeviceChangeEventHandler DeviceChanged;

        /// <summary>
        /// other planes in the area from adsb
        /// </summary>
        internal object adsblock = new object();

        public ConcurrentDictionary<string, adsb.PointLatLngAltHdg> adsbPlanes = new ConcurrentDictionary<string, adsb.PointLatLngAltHdg>();

        string titlebar;

        /// <summary>
        /// Comport name
        /// </summary>
        public static string comPortName = "";

        /// <summary>
        /// mono detection
        /// </summary>
        public static bool MONO = false;

        /// <summary>
        /// speech engine enable
        /// </summary>
        public static bool speechEnable = false;

        /// <summary>
        /// spech engine static class
        /// </summary>
        public static Speech speechEngine = null;

        /// <summary>
        /// joystick static class
        /// </summary>
        public static Joystick.Joystick joystick = null;

        /// <summary>
        /// track last joystick packet sent. used to control rate
        /// </summary>
        DateTime lastjoystick = DateTime.Now;

        /// <summary>
        /// determine if we are running sitl
        /// </summary>
        public static bool sitl
        {
            get
            {
                if (MissionPlanner.Controls.SITL.SITLSEND == null) return false;
                if (MissionPlanner.Controls.SITL.SITLSEND.Client.Connected) return true;
                return false;
            }
        }

        /// <summary>
        /// hud background image grabber from a video stream - not realy that efficent. ie no hardware overlays etc.
        /// </summary>
        public static WebCamService.Capture cam = null;

        /// <summary>
        /// controls the main serial reader thread
        /// </summary>
        bool serialThread = false;

        bool pluginthreadrun = false;

        bool joystickthreadrun = false;

        Thread httpthread;
        Thread joystickthread;
        Thread serialreaderthread;
        Thread pluginthread;

        /// <summary>
        /// track the last heartbeat sent
        /// </summary>
        private DateTime heatbeatSend = DateTime.Now;

        /// <summary>
        /// used to call anything as needed.
        /// </summary>
        public static MainV2 instance = null;


        public static MainSwitcher View;

        /// <summary>
        /// store the time we first connect
        /// </summary>
        DateTime connecttime = DateTime.Now;

        DateTime nodatawarning = DateTime.Now;
        DateTime OpenTime = DateTime.Now;

        /// <summary>
        /// enum of firmwares
        /// </summary>
        public enum Firmwares
        {
            ArduPlane,
            ArduCopter2,
            ArduRover,
            Ateryx,
            ArduTracker,
            Gymbal,
            PX4
        }

        DateTime connectButtonUpdate = DateTime.Now;

        /// <summary>
        /// declared here if i want a "single" instance of the form
        /// ie configuration gets reloaded on every click
        /// </summary>
        public GCSViews.FlightData FlightData;

        public GCSViews.FlightPlanner FlightPlanner;
        Controls.SITL Simulation;

        private Form connectionStatsForm;
        private ConnectionStats _connectionStats;

        /// <summary>
        /// This 'Control' is the toolstrip control that holds the comport combo, baudrate combo etc
        /// Otiginally seperate controls, each hosted in a toolstip sqaure, combined into this custom
        /// control for layout reasons.
        /// </summary>
        static internal ConnectionControl _connectionControl;

        public static bool TerminalTheming = true;

        public void updateLayout(object sender, EventArgs e)
        {
            //MenuSimulation.Visible = DisplayConfiguration.displaySimulation;
            //MenuTerminal.Visible = DisplayConfiguration.displayTerminal;
            //MenuHelp.Visible = DisplayConfiguration.displayHelp;
            MissionPlanner.Controls.BackstageView.BackstageView.Advanced = DisplayConfiguration.isAdvancedMode;

            if (MainV2.instance.FlightData != null)
            {
                TabControl t = MainV2.instance.FlightData.tabControlactions;

                if (DisplayConfiguration.displayAdvActionsTab && !t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Add(FlightData.tabActions);
                }
                else if (!DisplayConfiguration.displayAdvActionsTab && t.TabPages.Contains(FlightData.tabActions))
                {
                    t.TabPages.Remove(FlightData.tabActions);
                }
                if (DisplayConfiguration.displaySimpleActionsTab && !t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Add(FlightData.tabActionsSimple);
                }
                else if (!DisplayConfiguration.displaySimpleActionsTab && t.TabPages.Contains(FlightData.tabActionsSimple))
                {
                    t.TabPages.Remove(FlightData.tabActionsSimple);
                }
                if (DisplayConfiguration.displayStatusTab && !t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Add(FlightData.tabStatus);
                }
                else if (!DisplayConfiguration.displayStatusTab && t.TabPages.Contains(FlightData.tabStatus))
                {
                    t.TabPages.Remove(FlightData.tabStatus);
                }
                if (DisplayConfiguration.displayServoTab && !t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Add(FlightData.tabServo);
                }
                else if (!DisplayConfiguration.displayServoTab && t.TabPages.Contains(FlightData.tabServo))
                {
                    t.TabPages.Remove(FlightData.tabServo);
                }
                if (DisplayConfiguration.displayScriptsTab && !t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Add(FlightData.tabScripts);
                }
                else if (!DisplayConfiguration.displayScriptsTab && t.TabPages.Contains(FlightData.tabScripts))
                {
                    t.TabPages.Remove(FlightData.tabScripts);
                }
            }
        }


        public MainV2()
        {
            log.Info("Mainv2 ctor");
            //myhud = hud1;
            //HUD.Custom.src = MainV2.comPort.MAV.cs;
            //MissionPlanner.Controls.PreFlight.CheckListItem.defaultsrc = MainV2.comPort.MAV.cs;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // set this before we reset it
            Settings.Instance["NUM_tracklength"] = "200";

            // create one here - but override on load
            Settings.Instance["guid"] = Guid.NewGuid().ToString();

            // load config
            LoadConfig();

            // force language to be loaded
            L10N.GetConfigLang();

            ShowAirports = true;

            // setup adsb
            Utilities.adsb.UpdatePlanePosition += adsb_UpdatePlanePosition;

            Form splash = Program.Splash;

            splash.Refresh();

            Application.DoEvents();

            instance = this;

            //disable dpi scaling
            if (Font.Name != "宋体")
            {
                //Chinese displayed normally when scaling. But would be too small or large using this line of code.
                using (var g = CreateGraphics())
                {
                    Font = new Font(Font.Name, 8.25f * 96f / g.DpiX, Font.Style, Font.Unit, Font.GdiCharSet,
                        Font.GdiVerticalFont);
                }
            }

            InitializeComponent();
            //try
            //{
            //    if(Settings.Instance["theme"] != null)
            //        ThemeManager.SetTheme((ThemeManager.Themes)Enum.Parse(typeof(ThemeManager.Themes), Settings.Instance["theme"]));
            //}
            //catch
            //{
            //}
            //Utilities.ThemeManager.ApplyThemeTo(this);
            MyView = new MainSwitcher(this);

            View = MyView;

            //startup console
            TCPConsole.Write((byte)'S');

            _connectionControl = toolStripConnectionControl.ConnectionControl;
            _connectionControl.CMB_baudrate.TextChanged += this.CMB_baudrate_TextChanged;
            _connectionControl.CMB_serialport.SelectedIndexChanged += this.CMB_serialport_SelectedIndexChanged;
            _connectionControl.CMB_serialport.Click += this.CMB_serialport_Click;
            _connectionControl.cmb_sysid.Click += cmb_sysid_Click;

            _connectionControl.ShowLinkStats += (sender, e) => ShowConnectionStatsForm();
            srtm.datadirectory = Settings.GetDataDirectory() +
                                 "srtm";

            var t = Type.GetType("Mono.Runtime");
            MONO = (t != null);

            speechEngine = new Speech();

            Warnings.CustomWarning.defaultsrc = comPort.MAV.cs;
            Warnings.WarningEngine.Start();

            // proxy loader - dll load now instead of on config form load
            new Transition(new TransitionType_EaseInEaseOut(2000));

            foreach (object obj in Enum.GetValues(typeof(Firmwares)))
            {
                _connectionControl.TOOL_APMFirmware.Items.Add(obj);
            }

            if (_connectionControl.TOOL_APMFirmware.Items.Count > 0)
                _connectionControl.TOOL_APMFirmware.SelectedIndex = 0;

            comPort.BaseStream.BaudRate = 115200;

            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Count > 0)
            {
                _connectionControl.CMB_baudrate.SelectedIndex = 8;
                _connectionControl.CMB_serialport.SelectedIndex = 0;
            }
            // ** Done

            splash.Refresh();
            Application.DoEvents();

            // load last saved connection settings
            string temp = Settings.Instance.ComPort;
            if (!string.IsNullOrEmpty(temp))
            {
                _connectionControl.CMB_serialport.SelectedIndex = _connectionControl.CMB_serialport.FindString(temp);
                if (_connectionControl.CMB_serialport.SelectedIndex == -1)
                {
                    _connectionControl.CMB_serialport.Text = temp; // allows ports that dont exist - yet
                }
                comPort.BaseStream.PortName = temp;
                comPortName = temp;
            }
            string temp2 = Settings.Instance.BaudRate;
            if (!string.IsNullOrEmpty(temp2))
            {
                _connectionControl.CMB_baudrate.SelectedIndex = _connectionControl.CMB_baudrate.FindString(temp2);
                if (_connectionControl.CMB_baudrate.SelectedIndex == -1)
                {
                    _connectionControl.CMB_baudrate.Text = temp2;
                }
            }
            string temp3 = Settings.Instance.APMFirmware;
            if (!string.IsNullOrEmpty(temp3))
            {
                _connectionControl.TOOL_APMFirmware.SelectedIndex =
                    _connectionControl.TOOL_APMFirmware.FindStringExact(temp3);
                if (_connectionControl.TOOL_APMFirmware.SelectedIndex == -1)
                    _connectionControl.TOOL_APMFirmware.SelectedIndex = 0;
                MainV2.comPort.MAV.cs.firmware =
                    (MainV2.Firmwares)Enum.Parse(typeof(MainV2.Firmwares), _connectionControl.TOOL_APMFirmware.Text);
            }

            MissionPlanner.Utilities.Tracking.cid = new Guid(Settings.Instance["guid"].ToString());

            // setup guids for droneshare
            if (!Settings.Instance.ContainsKey("plane_guid"))
                Settings.Instance["plane_guid"] = Guid.NewGuid().ToString();

            if (!Settings.Instance.ContainsKey("copter_guid"))
                Settings.Instance["copter_guid"] = Guid.NewGuid().ToString();

            if (!Settings.Instance.ContainsKey("rover_guid"))
                Settings.Instance["rover_guid"] = Guid.NewGuid().ToString();

            if (Settings.Instance.ContainsKey("language") && !string.IsNullOrEmpty(Settings.Instance["language"]))
            {
                changelanguage(CultureInfoEx.GetCultureInfo(Settings.Instance["language"]));
            }

            this.Text = splash.Text;
            titlebar = splash.Text;

            if (!MONO) // windows only
            {
                if (Settings.Instance["showconsole"] != null && Settings.Instance["showconsole"].ToString() == "True")
                {
                }
                else
                {
                    int win = NativeMethods.FindWindow("ConsoleWindowClass", null);
                    NativeMethods.ShowWindow(win, NativeMethods.SW_HIDE); // hide window
                }

                // prevent system from sleeping while mp open
                var previousExecutionState =
                    NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
            }

            ChangeUnits();

            //if (Settings.Instance["theme"] != null)
            //{
            //    try
            //    {
            //        ThemeManager.SetTheme(
            //            (ThemeManager.Themes)
            //                Enum.Parse(typeof (ThemeManager.Themes), Settings.Instance["theme"].ToString()));
            //    }
            //    catch (Exception exception)
            //    {
            //        log.Error(exception);
            //    }

            //    if (ThemeManager.CurrentTheme == ThemeManager.Themes.Custom)
            //    {
            //        try
            //        {
            //            ThemeManager.BGColor = Color.FromArgb(int.Parse(Settings.Instance["theme_bg"].ToString()));
            //            ThemeManager.ControlBGColor = Color.FromArgb(int.Parse(Settings.Instance["theme_ctlbg"].ToString()));
            //            ThemeManager.TextColor = Color.FromArgb(int.Parse(Settings.Instance["theme_text"].ToString()));
            //            ThemeManager.ButBG = Color.FromArgb(int.Parse(Settings.Instance["theme_butbg"].ToString()));
            //            ThemeManager.ButBorder = Color.FromArgb(int.Parse(Settings.Instance["theme_butbord"].ToString()));
            //        }
            //        catch
            //        {
            //            log.Error("Bad Custom theme - reset to standard");
            //            ThemeManager.SetTheme(ThemeManager.Themes.BurntKermit);
            //        }
            //    }

            //    if (ThemeManager.CurrentTheme == ThemeManager.Themes.HighContrast)
            //    {
            //        switchicons(new highcontrastmenuicons());
            //    }
            //}

            if (Settings.Instance["showairports"] != null)
            {
                MainV2.ShowAirports = bool.Parse(Settings.Instance["showairports"]);
            }

            // set default
            ShowTFR = true;
            // load saved
            if (Settings.Instance["showtfr"] != null)
            {
                MainV2.ShowTFR = Settings.Instance.GetBoolean("showtfr");
            }

            if (Settings.Instance["enableadsb"] != null)
            {
                MainV2.instance.EnableADSB = Settings.Instance.GetBoolean("enableadsb");
            }

            try
            {
                log.Info("Create FD");
                FlightData = new GCSViews.FlightData();
                log.Info("Create FP");
                FlightPlanner = new GCSViews.FlightPlanner();
                //Configuration = new GCSViews.ConfigurationView.Setup();
                log.Info("Create SIM");
                Simulation = new SITL();
                //Firmware = new GCSViews.Firmware();
                //Terminal = new GCSViews.Terminal();

                FlightData.Width = MyView.Width;
                FlightPlanner.Width = MyView.Width;
                Simulation.Width = MyView.Width;
            }
            catch (ArgumentException e)
            {
                //http://www.microsoft.com/en-us/download/details.aspx?id=16083
                //System.ArgumentException: Font 'Arial' does not support style 'Regular'.

                log.Fatal(e);
                CustomMessageBox.Show(e.ToString() +
                                      "\n\n Font Issues? Please install this http://www.microsoft.com/en-us/download/details.aspx?id=16083");
                //splash.Close();
                //this.Close();
                Application.Exit();
            }
            catch (Exception e)
            {
                log.Fatal(e);
                CustomMessageBox.Show("A Major error has occured : " + e.ToString());
                Application.Exit();
            }

            //set first instance display configuration
            if (DisplayConfiguration == null)
            {
                DisplayConfiguration = DisplayConfiguration.Basic();
            }

            // load old config
            if (Settings.Instance["advancedview"] != null)
            {
                if (Settings.Instance.GetBoolean("advancedview") == true)
                {
                    DisplayConfiguration = new DisplayView().Advanced();
                }
                // remove old config
                Settings.Instance.Remove("advancedview");
            }            //// load this before the other screens get loaded
            if (Settings.Instance["displayview"] != null)
            {
                try
                {
                    DisplayConfiguration = Settings.Instance.GetDisplayView("displayview");
                }
                catch
                {
                    DisplayConfiguration = DisplayConfiguration.Basic();
                }
            }

            LayoutChanged += updateLayout;
            LayoutChanged(null, EventArgs.Empty);

            if (Settings.Instance["CHK_GDIPlus"] != null)
                GCSViews.FlightData.myhud.opengl = !bool.Parse(Settings.Instance["CHK_GDIPlus"].ToString());

            if (Settings.Instance["CHK_hudshow"] != null)
                GCSViews.FlightData.myhud.hudon = bool.Parse(Settings.Instance["CHK_hudshow"].ToString());

            try
            {
                if (Settings.Instance["MainLocX"] != null && Settings.Instance["MainLocY"] != null)
                {
                    this.StartPosition = FormStartPosition.Manual;
                    Point startpos = new Point(Settings.Instance.GetInt32("MainLocX"),
                        Settings.Instance.GetInt32("MainLocY"));

                    // fix common bug which happens when user removes a monitor, the app shows up
                    // offscreen and it is very hard to move it onscreen.  Also happens with 
                    // remote desktop a lot.  So this only restores position if the position
                    // is visible.
                    foreach (Screen s in Screen.AllScreens)
                    {
                        if (s.WorkingArea.Contains(startpos))
                        {
                            this.Location = startpos;
                            break;
                        }
                    }

                }

                if (Settings.Instance["MainMaximised"] != null)
                {
                    this.WindowState =
                        (FormWindowState)Enum.Parse(typeof(FormWindowState), Settings.Instance["MainMaximised"]);
                    // dont allow minimised start state
                    if (this.WindowState == FormWindowState.Minimized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.Location = new Point(100, 100);
                    }
                }

                if (Settings.Instance["MainHeight"] != null)
                    this.Height = Settings.Instance.GetInt32("MainHeight");
                if (Settings.Instance["MainWidth"] != null)
                    this.Width = Settings.Instance.GetInt32("MainWidth");

                if (Settings.Instance["CMB_rateattitude"] != null)
                    CurrentState.rateattitudebackup = Settings.Instance.GetByte("CMB_rateattitude");
                if (Settings.Instance["CMB_rateposition"] != null)
                    CurrentState.ratepositionbackup = Settings.Instance.GetByte("CMB_rateposition");
                if (Settings.Instance["CMB_ratestatus"] != null)
                    CurrentState.ratestatusbackup = Settings.Instance.GetByte("CMB_ratestatus");
                if (Settings.Instance["CMB_raterc"] != null)
                    CurrentState.ratercbackup = Settings.Instance.GetByte("CMB_raterc");
                if (Settings.Instance["CMB_ratesensors"] != null)
                    CurrentState.ratesensorsbackup = Settings.Instance.GetByte("CMB_ratesensors");

                // make sure rates propogate
                MainV2.comPort.MAV.cs.ResetInternals();

                if (Settings.Instance["speechenable"] != null)
                    MainV2.speechEnable = Settings.Instance.GetBoolean("speechenable");

                if (Settings.Instance["analyticsoptout"] != null)
                    MissionPlanner.Utilities.Tracking.OptOut = Settings.Instance.GetBoolean("analyticsoptout");

                try
                {
                    if (Settings.Instance["TXT_homelat"] != null)
                        MainV2.comPort.MAV.cs.HomeLocation.Lat = Settings.Instance.GetDouble("TXT_homelat");

                    if (Settings.Instance["TXT_homelng"] != null)
                        MainV2.comPort.MAV.cs.HomeLocation.Lng = Settings.Instance.GetDouble("TXT_homelng");

                    if (Settings.Instance["TXT_homealt"] != null)
                        MainV2.comPort.MAV.cs.HomeLocation.Alt = Settings.Instance.GetDouble("TXT_homealt");

                    // remove invalid entrys
                    if (Math.Abs(MainV2.comPort.MAV.cs.HomeLocation.Lat) > 90 ||
                        Math.Abs(MainV2.comPort.MAV.cs.HomeLocation.Lng) > 180)
                        MainV2.comPort.MAV.cs.HomeLocation = new PointLatLngAlt();
                }
                catch
                {
                }
            }
            catch
            {
            }

            if (CurrentState.rateattitudebackup == 0) // initilised to 10, configured above from save
            {
                CustomMessageBox.Show(
                    "NOTE: your attitude rate is 0, the hud will not work\nChange in Configuration > Planner > Telemetry Rates");
            }

            // create log dir if it doesnt exist
            try
            {
                if (!Directory.Exists(Settings.Instance.LogDir))
                    Directory.CreateDirectory(Settings.Instance.LogDir);
            }
            catch (Exception ex) { log.Error(ex); }

            Microsoft.Win32.SystemEvents.PowerModeChanged += SystemEvents_PowerModeChanged;

            // make sure new enough .net framework is installed
            if (!MONO)
            {
                Microsoft.Win32.RegistryKey installed_versions =
                    Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                string[] version_names = installed_versions.GetSubKeyNames();
                //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
                double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1),
                    CultureInfo.InvariantCulture);
                int SP =
                    Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1])
                        .GetValue("SP", 0));

                if (Framework < 4.0)
                {
                    CustomMessageBox.Show("This program requires .NET Framework 4.0. You currently have " + Framework);
                }
            }

            if (Program.IconFile != null)
            {
                this.Icon = Icon.FromHandle(((Bitmap)Program.IconFile).GetHicon());
            }

            //if (Program.Logo != null && Program.name == "VVVVZ")
            //{
            //    MenuDonate.Click -= this.toolStripMenuItem1_Click;
            //    MenuDonate.Text = "";
            //    MenuDonate.Image = Program.Logo;

            //    MenuDonate.Click += MenuCustom_Click;

            //    MenuFlightData.Visible = false;
            //    MenuFlightPlanner.Visible = true;
            //    MenuConfigTune.Visible = false;
            //    MenuHelp.Visible = false;
            //    MenuInitConfig.Visible = false;
            //    MenuSimulation.Visible = false;
            //    MenuTerminal.Visible = false;
            //}
            //else if (Program.Logo != null && Program.names.Contains(Program.name))
            //{
            //    MenuDonate.Click -= this.toolStripMenuItem1_Click;
            //    MenuDonate.Text = "";
            //    MenuDonate.Image = Program.Logo;
            //}
            List<string> list = new List<string>();

            {
                list.Add("LOITER_UNLIM");
                list.Add("RETURN_TO_LAUNCH");
                list.Add("PREFLIGHT_CALIBRATION");
                list.Add("MISSION_START");
                list.Add("PREFLIGHT_REBOOT_SHUTDOWN");
                list.Add("Trigger Camera NOW");
                //DO_SET_SERVO
                //DO_REPEAT_SERVO
            }


            CMB_action.DataSource = list;

            CMB_modes.DataSource = Common.getModesList(MainV2.comPort.MAV.cs);
            CMB_modes.ValueMember = "Key";
            CMB_modes.DisplayMember = "Value";

            //default to auto
            CMB_modes.Text = "Auto";

            CMB_setwp.SelectedIndex = 0;

            Application.DoEvents();

            Comports.Add(comPort);

            MainV2.comPort.MavChanged += comPort_MavChanged;

            // save config to test we have write access
            SaveConfig();
        }

        void cmb_sysid_Click(object sender, EventArgs e)
        {
            MainV2._connectionControl.UpdateSysIDS();
        }

        void comPort_MavChanged(object sender, EventArgs e)
        {
            log.Info("Mav Changed " + MainV2.comPort.MAV.sysid);

            HUD.Custom.src = MainV2.comPort.MAV.cs;

            CustomWarning.defaultsrc = MainV2.comPort.MAV.cs;

            MissionPlanner.Controls.PreFlight.CheckListItem.defaultsrc = MainV2.comPort.MAV.cs;

            // when uploading a firmware we dont want to reload this screen.
            if (instance.MyView.current.Control != null && instance.MyView.current.Control.GetType() == typeof(GCSViews.InitialSetup))
            {
                var page = ((GCSViews.InitialSetup)instance.MyView.current.Control).backstageView.SelectedPage;
                if (page != null && page.Text == "Install Firmware")
                {
                    return;
                }
            }

            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate
               {
                   instance.MyView.Reload();
               });
            }
            else
            {
                instance.MyView.Reload();
            }
        }

        void SystemEvents_PowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            // try prevent crash on resume
            if (e.Mode == Microsoft.Win32.PowerModes.Suspend)
            {
                doDisconnect(MainV2.comPort);
            }
        }

        private void BGLoadAirports(object nothing)
        {
            // read airport list
            try
            {
                Utilities.Airports.ReadOurairports(Settings.GetRunningDirectory() +
                                                   "airports.csv");

                Utilities.Airports.checkdups = true;

                //Utilities.Airports.ReadOpenflights(Application.StartupPath + Path.DirectorySeparatorChar + "airports.dat");

                log.Info("Loaded " + Utilities.Airports.GetAirportCount + " airports");
            }
            catch
            {
            }
        }

        public void switchicons(menuicons icons)
        {
            // dont update if no change
            if (displayicons.GetType() == icons.GetType())
                return;

            displayicons = icons;

            //MainMenu.BackColor = SystemColors.MenuBar;

            //MainMenu.BackgroundImage = displayicons.bg;

            //MenuFlightData.Image = displayicons.fd;
            //MenuFlightPlanner.Image = displayicons.fp;
            //MenuInitConfig.Image = displayicons.initsetup;
            //MenuSimulation.Image = displayicons.sim;
            //MenuConfigTune.Image = displayicons.config_tuning;
            //MenuTerminal.Image = displayicons.terminal;
            //MenuConnect.Image = displayicons.connect;
            //MenuHelp.Image = displayicons.help;
            //MenuDonate.Image = displayicons.donate;


            //MenuFlightData.ForeColor = ThemeManager.TextColor;
            //MenuFlightPlanner.ForeColor = ThemeManager.TextColor;
            //MenuInitConfig.ForeColor = ThemeManager.TextColor;
            //MenuSimulation.ForeColor = ThemeManager.TextColor;
            //MenuConfigTune.ForeColor = ThemeManager.TextColor;
            //MenuTerminal.ForeColor = ThemeManager.TextColor;
            //MenuConnect.ForeColor = ThemeManager.TextColor;
            //MenuHelp.ForeColor = ThemeManager.TextColor;
            //MenuDonate.ForeColor = ThemeManager.TextColor;
        }

        //void MenuCustom_Click(object sender, EventArgs e)
        //{
        //    if (Settings.Instance.GetBoolean("password_protect") == false)
        //    {
        //        MenuFlightData.Visible = true;
        //        MenuFlightPlanner.Visible = true;
        //        MenuConfigTune.Visible = true;
        //        MenuHelp.Visible = true;
        //        MenuInitConfig.Visible = true;
        //        MenuSimulation.Visible = true;
        //        MenuTerminal.Visible = true;
        //    }
        //    else
        //    {
        //        if (Password.VerifyPassword())
        //        {
        //            MenuFlightData.Visible = true;
        //            MenuFlightPlanner.Visible = true;
        //            MenuConfigTune.Visible = true;
        //            MenuHelp.Visible = true;
        //            MenuInitConfig.Visible = true;
        //            MenuSimulation.Visible = true;
        //            MenuTerminal.Visible = true;
        //        }
        //    }
        //}
        private double ConvertToDouble(object input)
        {
            if (input.GetType() == typeof(float))
            {
                return (float)input;
            }
            if (input.GetType() == typeof(double))
            {
                return (double)input;
            }
            if (input.GetType() == typeof(ulong))
            {
                return (ulong)input;
            }
            if (input.GetType() == typeof(long))
            {
                return (long)input;
            }
            if (input.GetType() == typeof(int))
            {
                return (int)input;
            }
            if (input.GetType() == typeof(uint))
            {
                return (uint)input;
            }
            if (input.GetType() == typeof(short))
            {
                return (short)input;
            }
            if (input.GetType() == typeof(ushort))
            {
                return (ushort)input;
            }
            if (input.GetType() == typeof(bool))
            {
                return (bool)input ? 1 : 0;
            }
            if (input.GetType() == typeof(string))
            {
                double ans = 0;
                if (double.TryParse((string)input, out ans))
                {
                    return ans;
                }
            }
            if (input is Enum)
            {
                return Convert.ToInt32(input);
            }

            if (input == null)
                throw new Exception("Bad Type Null");
            else
                throw new Exception("Bad Type " + input.GetType().ToString());
        }
        void adsb_UpdatePlanePosition(object sender, EventArgs e)
        {
            lock (adsblock)
            {
                var adsb = ((MissionPlanner.Utilities.adsb.PointLatLngAltHdg)sender);

                var id = adsb.Tag;

                if (MainV2.instance.adsbPlanes.ContainsKey(id))
                {
                    // update existing
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lat = adsb.Lat;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Lng = adsb.Lng;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Alt = adsb.Alt;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Heading = adsb.Heading;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).Time = DateTime.Now;
                    ((adsb.PointLatLngAltHdg)instance.adsbPlanes[id]).CallSign = adsb.CallSign;
                }
                else
                {
                    // create new plane
                    MainV2.instance.adsbPlanes[id] =
                        new adsb.PointLatLngAltHdg(adsb.Lat, adsb.Lng,
                            adsb.Alt, adsb.Heading, id,
                            DateTime.Now)
                        { CallSign = adsb.CallSign };
                }
            }
        }


        private void ResetConnectionStats()
        {
            log.Info("Reset connection stats");
            // If the form has been closed, or never shown before, we need do nothing, as 
            // connection stats will be reset when shown
            if (this.connectionStatsForm != null && connectionStatsForm.Visible)
            {
                // else the form is already showing.  reset the stats
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                //ThemeManager.ApplyThemeTo(this.connectionStatsForm);
            }
        }

        private void ShowConnectionStatsForm()
        {
            if (this.connectionStatsForm == null || this.connectionStatsForm.IsDisposed)
            {
                // If the form has been closed, or never shown before, we need all new stuff
                this.connectionStatsForm = new Form
                {
                    Width = 430,
                    Height = 180,
                    MaximizeBox = false,
                    MinimizeBox = false,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = Strings.LinkStats
                };
                // Change the connection stats control, so that when/if the connection stats form is showing,
                // there will be something to see
                this.connectionStatsForm.Controls.Clear();
                _connectionStats = new ConnectionStats(comPort);
                this.connectionStatsForm.Controls.Add(_connectionStats);
                this.connectionStatsForm.Width = _connectionStats.Width;
            }

            this.connectionStatsForm.Show();
            //ThemeManager.ApplyThemeTo(this.connectionStatsForm);
        }

        private void CMB_serialport_Click(object sender, EventArgs e)
        {
            string oldport = _connectionControl.CMB_serialport.Text;
            PopulateSerialportList();
            if (_connectionControl.CMB_serialport.Items.Contains(oldport))
                _connectionControl.CMB_serialport.Text = oldport;
        }

        private void PopulateSerialportList()
        {
            _connectionControl.CMB_serialport.Items.Clear();
            _connectionControl.CMB_serialport.Items.Add("AUTO");
            _connectionControl.CMB_serialport.Items.AddRange(SerialPort.GetPortNames());
            _connectionControl.CMB_serialport.Items.Add("TCP");
            _connectionControl.CMB_serialport.Items.Add("UDP");
            _connectionControl.CMB_serialport.Items.Add("UDPCl");
        }

        private void MenuFlightData_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightData");
        }

        private void MenuFlightPlanner_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("FlightPlanner");
        }

        public void MenuSetup_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("HWConfig");
            }
            else
            {
                if (Password.VerifyPassword())
                {
                    MyView.ShowScreen("HWConfig");
                }
            }
        }

        private void MenuSimulation_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Simulation");
        }

        private void MenuTuning_Click(object sender, EventArgs e)
        {
            if (Settings.Instance.GetBoolean("password_protect") == false)
            {
                MyView.ShowScreen("SWConfig");
            }
            else
            {
                if (Password.VerifyPassword())
                {
                    MyView.ShowScreen("SWConfig");
                }
            }
        }

        private void MenuTerminal_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Terminal");
        }

        public void doDisconnect(MAVLinkInterface comPort)
        {
            log.Info("We are disconnecting");
            try
            {
                if (speechEngine != null) // cancel all pending speech
                    speechEngine.SpeakAsyncCancelAll();

                comPort.BaseStream.DtrEnable = false;
                comPort.Close();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            // now that we have closed the connection, cancel the connection stats
            // so that the 'time connected' etc does not grow, but the user can still
            // look at the now frozen stats on the still open form
            try
            {
                // if terminal is used, then closed using this button.... exception
                if (this.connectionStatsForm != null)
                    ((ConnectionStats)this.connectionStatsForm.Controls[0]).StopUpdates();
            }
            catch
            {
            }

            // refresh config window if needed
            if (MyView.current != null)
            {
                if (MyView.current.Name == "HWConfig")
                    MyView.ShowScreen("HWConfig");
                if (MyView.current.Name == "SWConfig")
                    MyView.ShowScreen("SWConfig");
            }

            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate
               {
                   try
                   {
                       MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                   }
                   catch
                   {
                   }
               }
                    );
            }
            catch
            {
            }

            this.MenuConnect.Image = global::MissionPlanner.Properties.Resources.disconnect001;
        }

        public void doConnect(MAVLinkInterface comPort, string portname, string baud)
        {
            bool skipconnectcheck = false;
            log.Info("We are connecting");
            switch (portname)
            {
                case "preset":
                    skipconnectcheck = true;
                    if (comPort.BaseStream is TcpSerial)
                        _connectionControl.CMB_serialport.Text = "TCP";
                    if (comPort.BaseStream is UdpSerial)
                        _connectionControl.CMB_serialport.Text = "UDP";
                    if (comPort.BaseStream is UdpSerialConnect)
                        _connectionControl.CMB_serialport.Text = "UDPCl";
                    if (comPort.BaseStream is SerialPort)
                    {
                        _connectionControl.CMB_serialport.Text = comPort.BaseStream.PortName;
                        _connectionControl.CMB_baudrate.Text = comPort.BaseStream.BaudRate.ToString();
                    }
                    break;
                case "TCP":
                    comPort.BaseStream = new TcpSerial();
                    _connectionControl.CMB_serialport.Text = "TCP";
                    break;
                case "UDP":
                    comPort.BaseStream = new UdpSerial();
                    _connectionControl.CMB_serialport.Text = "UDP";
                    break;
                case "UDPCl":
                    comPort.BaseStream = new UdpSerialConnect();
                    _connectionControl.CMB_serialport.Text = "UDPCl";
                    break;
                case "AUTO":
                default:
                    comPort.BaseStream = new SerialPort();
                    break;
            }

            // Tell the connection UI that we are now connected.
            _connectionControl.IsConnected(true);

            // Here we want to reset the connection stats counter etc.
            this.ResetConnectionStats();

            comPort.MAV.cs.ResetInternals();

            //cleanup any log being played
            comPort.logreadmode = false;
            if (comPort.logplaybackfile != null)
                comPort.logplaybackfile.Close();
            comPort.logplaybackfile = null;

            try
            {
                // do autoscan
                if (portname == "AUTO")
                {
                    Comms.CommsSerialScan.Scan(false);

                    DateTime deadline = DateTime.Now.AddSeconds(50);

                    while (Comms.CommsSerialScan.foundport == false)
                    {
                        System.Threading.Thread.Sleep(100);

                        if (DateTime.Now > deadline)
                        {
                            CustomMessageBox.Show(Strings.Timeout);
                            _connectionControl.IsConnected(false);
                            return;
                        }
                    }

                    _connectionControl.CMB_serialport.Text = portname = Comms.CommsSerialScan.portinterface.PortName;
                    _connectionControl.CMB_baudrate.Text =
                        baud = Comms.CommsSerialScan.portinterface.BaudRate.ToString();
                }

                log.Info("Set Portname");
                // set port, then options
                comPort.BaseStream.PortName = portname;

                log.Info("Set Baudrate");
                try
                {
                    comPort.BaseStream.BaudRate = int.Parse(baud);
                }
                catch (Exception exp)
                {
                    log.Error(exp);
                }

                // prevent serialreader from doing anything
                comPort.giveComport = true;

                log.Info("About to do dtr if needed");
                // reset on connect logic.
                if (Settings.Instance.GetBoolean("CHK_resetapmonconnect") == true)
                {
                    log.Info("set dtr rts to false");
                    comPort.BaseStream.DtrEnable = false;
                    comPort.BaseStream.RtsEnable = false;

                    comPort.BaseStream.toggleDTR();
                }

                comPort.giveComport = false;

                // setup to record new logs
                try
                {
                    Directory.CreateDirectory(Settings.Instance.LogDir);
                    comPort.logfile =
                        new BufferedStream(
                            File.Open(
                                Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".tlog", FileMode.CreateNew,
                                FileAccess.ReadWrite, FileShare.None));

                    comPort.rawlogfile =
                        new BufferedStream(
                            File.Open(
                                Settings.Instance.LogDir + Path.DirectorySeparatorChar +
                                DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".rlog", FileMode.CreateNew,
                                FileAccess.ReadWrite, FileShare.None));

                    log.Info("creating logfile " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".tlog");
                }
                catch (Exception exp2)
                {
                    log.Error(exp2);
                    CustomMessageBox.Show(Strings.Failclog);
                } // soft fail

                // reset connect time - for timeout functions
                connecttime = DateTime.Now;

                // do the connect
                comPort.Open(false, skipconnectcheck);

                if (!comPort.BaseStream.IsOpen)
                {
                    log.Info("comport is closed. existing connect");
                    try
                    {
                        _connectionControl.IsConnected(false);
                        UpdateConnectIcon();
                        comPort.Close();
                    }
                    catch
                    {
                    }
                    return;
                }

                // get all the params
                foreach (var mavstate in comPort.MAVlist)
                {
                    comPort.sysidcurrent = mavstate.sysid;
                    comPort.compidcurrent = mavstate.compid;
                    comPort.getParamList();
                }

                // set to first seen
                comPort.sysidcurrent = comPort.MAVlist.First().sysid;
                comPort.compidcurrent = comPort.MAVlist.First().compid;

                _connectionControl.UpdateSysIDS();

                // detect firmware we are conected to.
                if (comPort.MAV.cs.firmware == Firmwares.ArduCopter2)
                {
                    _connectionControl.TOOL_APMFirmware.SelectedIndex =
                        _connectionControl.TOOL_APMFirmware.Items.IndexOf(Firmwares.ArduCopter2);
                }
                else if (comPort.MAV.cs.firmware == Firmwares.Ateryx)
                {
                    _connectionControl.TOOL_APMFirmware.SelectedIndex =
                        _connectionControl.TOOL_APMFirmware.Items.IndexOf(Firmwares.Ateryx);
                }
                else if (comPort.MAV.cs.firmware == Firmwares.ArduRover)
                {
                    _connectionControl.TOOL_APMFirmware.SelectedIndex =
                        _connectionControl.TOOL_APMFirmware.Items.IndexOf(Firmwares.ArduRover);
                }
                else if (comPort.MAV.cs.firmware == Firmwares.ArduPlane)
                {
                    _connectionControl.TOOL_APMFirmware.SelectedIndex =
                        _connectionControl.TOOL_APMFirmware.Items.IndexOf(Firmwares.ArduPlane);
                }

                // check for newer firmware
                var softwares = Firmware.LoadSoftwares();

                if (softwares.Count > 0)
                {
                    try
                    {
                        string[] fields1 = comPort.MAV.VersionString.Split(' ');

                        foreach (Firmware.software item in softwares)
                        {
                            string[] fields2 = item.name.Split(' ');

                            // check primare firmware type. ie arudplane, arducopter
                            if (fields1[0] == fields2[0])
                            {
                                Version ver1 = VersionDetection.GetVersion(comPort.MAV.VersionString);
                                Version ver2 = VersionDetection.GetVersion(item.name);

                                if (ver2 > ver1)
                                {
                                    Common.MessageShowAgain(Strings.NewFirmware + "-" + item.name,
                                        Strings.NewFirmwareA + item.name + Strings.Pleaseup);
                                    break;
                                }

                                // check the first hit only
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }

                FlightData.CheckBatteryShow();

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Connect", comPort.MAV.cs.firmware.ToString(),
                    comPort.MAV.param.Count.ToString());
                MissionPlanner.Utilities.Tracking.AddTiming("Connect", "Connect Time",
                    (DateTime.Now - connecttime).TotalMilliseconds, "");

                MissionPlanner.Utilities.Tracking.AddEvent("Connect", "Baud", comPort.BaseStream.BaudRate.ToString(), "");

                // save the baudrate for this port
                Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] = _connectionControl.CMB_baudrate.Text;

                this.Text = titlebar + " " + comPort.MAV.VersionString;

                // refresh config window if needed
                if (MyView.current != null)
                {
                    if (MyView.current.Name == "HWConfig")
                        MyView.ShowScreen("HWConfig");
                    if (MyView.current.Name == "SWConfig")
                        MyView.ShowScreen("SWConfig");
                }

                // load wps on connect option.
                if (Settings.Instance.GetBoolean("loadwpsonconnect") == true)
                {
                    // only do it if we are connected.
                    if (comPort.BaseStream.IsOpen)
                    {
                        MenuFlightPlanner_Click(null, null);
                        FlightPlanner.BUT_read_Click(null, null);
                    }
                }

                // get any rallypoints
                if (MainV2.comPort.MAV.param.ContainsKey("RALLY_TOTAL") &&
                    int.Parse(MainV2.comPort.MAV.param["RALLY_TOTAL"].ToString()) > 0)
                {
                    FlightPlanner.getRallyPointsToolStripMenuItem_Click(null, null);

                    double maxdist = 0;

                    foreach (var rally in comPort.MAV.rallypoints)
                    {
                        foreach (var rally1 in comPort.MAV.rallypoints)
                        {
                            var pnt1 = new PointLatLngAlt(rally.Value.lat / 10000000.0f, rally.Value.lng / 10000000.0f);
                            var pnt2 = new PointLatLngAlt(rally1.Value.lat / 10000000.0f, rally1.Value.lng / 10000000.0f);

                            var dist = pnt1.GetDistance(pnt2);

                            maxdist = Math.Max(maxdist, dist);
                        }
                    }

                    if (comPort.MAV.param.ContainsKey("RALLY_LIMIT_KM") &&
                        (maxdist / 1000.0) > (float)comPort.MAV.param["RALLY_LIMIT_KM"])
                    {
                        CustomMessageBox.Show(Strings.Warningrallypointdistance + " " +
                                              (maxdist / 1000.0).ToString("0.00") + " > " +
                                              (float)comPort.MAV.param["RALLY_LIMIT_KM"]);
                    }
                }

                // set connected icon
                this.MenuConnect.Image = displayicons.disconnect;
            }
            catch (Exception ex)
            {
                log.Warn(ex);
                try
                {
                    _connectionControl.IsConnected(false);
                    UpdateConnectIcon();
                    comPort.Close();
                }
                catch (Exception ex2)
                {
                    log.Warn(ex2);
                }
                CustomMessageBox.Show("Can not establish a connection\n\n" + ex.Message);
                return;
            }
        }

        private void MenuConnect_Click(object sender, EventArgs e)
        {
            comPort.giveComport = false;

            log.Info("MenuConnect Start");

            // sanity check
            if (comPort.BaseStream.IsOpen && MainV2.comPort.MAV.cs.groundspeed > 4)
            {
                if (DialogResult.No ==
                    CustomMessageBox.Show(Strings.Stillmoving, Strings.Disconnect, MessageBoxButtons.YesNo))
                {
                    return;
                }
            }

            try
            {
                log.Info("Cleanup last logfiles");
                // cleanup from any previous sessions
                if (comPort.logfile != null)
                    comPort.logfile.Close();

                if (comPort.rawlogfile != null)
                    comPort.rawlogfile.Close();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Strings.ErrorClosingLogFile + ex.Message, Strings.ERROR);
            }

            comPort.logfile = null;
            comPort.rawlogfile = null;

            // decide if this is a connect or disconnect
            if (comPort.BaseStream.IsOpen)
            {
                doDisconnect(comPort);
            }
            else
            {
                doConnect(comPort, _connectionControl.CMB_serialport.Text, _connectionControl.CMB_baudrate.Text);
            }

            MainV2._connectionControl.UpdateSysIDS();

            loadph_serial();
        }

        void loadph_serial()
        {
            try
            {
                var serials = File.ReadAllLines("ph2_serial.csv");

                foreach (var serial in serials)
                {
                    if (serial.Contains(comPort.MAV.SerialString.Substring(comPort.MAV.SerialString.Length - 26, 26)) &&
                        !Settings.Instance.ContainsKey(comPort.MAV.SerialString))
                    {
                        CustomMessageBox.Show(
                            "Your board has a Critical service bulletin please see [link;http://discuss.ardupilot.org/t/sb-0000001-critical-service-bulletin-for-beta-cube-2-1/14711;Click here]",
                            Strings.ERROR);

                        Settings.Instance[comPort.MAV.SerialString] = true.ToString();
                    }
                }
            }
            catch
            {

            }
        }

        private void CMB_serialport_SelectedIndexChanged(object sender, EventArgs e)
        {
            comPortName = _connectionControl.CMB_serialport.Text;
            if (comPortName == "UDP" || comPortName == "UDPCl" || comPortName == "TCP" || comPortName == "AUTO")
            {
                _connectionControl.CMB_baudrate.Enabled = false;
                if (comPortName == "TCP")
                    MainV2.comPort.BaseStream = new TcpSerial();
                if (comPortName == "UDP")
                    MainV2.comPort.BaseStream = new UdpSerial();
                if (comPortName == "UDPCl")
                    MainV2.comPort.BaseStream = new UdpSerialConnect();
                if (comPortName == "AUTO")
                {
                    MainV2.comPort.BaseStream = new SerialPort();
                    return;
                }
            }
            else
            {
                _connectionControl.CMB_baudrate.Enabled = true;
                MainV2.comPort.BaseStream = new SerialPort();
            }

            try
            {
                if (!String.IsNullOrEmpty(_connectionControl.CMB_serialport.Text))
                    comPort.BaseStream.PortName = _connectionControl.CMB_serialport.Text;

                MainV2.comPort.BaseStream.BaudRate = int.Parse(_connectionControl.CMB_baudrate.Text);

                // check for saved baud rate and restore
                if (Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"] != null)
                {
                    _connectionControl.CMB_baudrate.Text =
                        Settings.Instance[_connectionControl.CMB_serialport.Text + "_BAUD"];
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// overriding the OnCLosing is a bit cleaner than handling the event, since it 
        /// is this object.
        /// 
        /// This happens before FormClosed
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            // speed up tile saving on exit
            GMap.NET.GMaps.Instance.CacheOnIdleRead = false;
            GMap.NET.GMaps.Instance.BoostCacheEngine = true;

            log.Info("MainV2_FormClosing");

            Settings.Instance["MainHeight"] = this.Height.ToString();
            Settings.Instance["MainWidth"] = this.Width.ToString();
            Settings.Instance["MainMaximised"] = this.WindowState.ToString();

            Settings.Instance["MainLocX"] = this.Location.X.ToString();
            Settings.Instance["MainLocY"] = this.Location.Y.ToString();

            // close bases connection
            try
            {
                comPort.logreadmode = false;
                if (comPort.logfile != null)
                    comPort.logfile.Close();

                if (comPort.rawlogfile != null)
                    comPort.rawlogfile.Close();

                comPort.logfile = null;
                comPort.rawlogfile = null;
            }
            catch
            {
            }

            // close all connections
            foreach (var port in Comports)
            {
                try
                {
                    port.logreadmode = false;
                    if (port.logfile != null)
                        port.logfile.Close();

                    if (port.rawlogfile != null)
                        port.rawlogfile.Close();

                    port.logfile = null;
                    port.rawlogfile = null;
                }
                catch
                {
                }
            }

            Utilities.adsb.Stop();

            Warnings.WarningEngine.Stop();

            UDPVideoShim.Stop();

            GStreamer.Stop();

            log.Info("closing vlcrender");
            try
            {
                while (vlcrender.store.Count > 0)
                    vlcrender.store[0].Stop();
            }
            catch
            {
            }

            log.Info("closing pluginthread");

            pluginthreadrun = false;

            if (pluginthread != null)
                pluginthread.Join();

            log.Info("closing serialthread");

            serialThread = false;

            if (serialreaderthread != null)
                serialreaderthread.Join();

            log.Info("closing joystickthread");

            joystickthreadrun = false;

            if (joystickthread != null)
                joystickthread.Join();

            log.Info("closing httpthread");

            // if we are waiting on a socket we need to force an abort
            httpserver.Stop();

            log.Info("sorting tlogs");
            try
            {
                System.Threading.ThreadPool.QueueUserWorkItem((WaitCallback)delegate
               {
                   try
                   {
                       MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));
                   }
                   catch
                   {
                   }
               }
                    );
            }
            catch
            {
            }

            log.Info("closing MyView");

            // close all tabs
            MyView.Dispose();

            log.Info("closing fd");
            try
            {
                FlightData.Dispose();
            }
            catch
            {
            }
            log.Info("closing fp");
            try
            {
                FlightPlanner.Dispose();
            }
            catch
            {
            }
            log.Info("closing sim");
            try
            {
                Simulation.Dispose();
            }
            catch
            {
            }

            try
            {
                if (comPort.BaseStream.IsOpen)
                    comPort.Close();
            }
            catch
            {
            } // i get alot of these errors, the port is still open, but not valid - user has unpluged usb

            // save config
            SaveConfig();

            Console.WriteLine(httpthread.IsAlive);
            Console.WriteLine(joystickthread.IsAlive);
            Console.WriteLine(serialreaderthread.IsAlive);
            Console.WriteLine(pluginthread.IsAlive);

            log.Info("MainV2_FormClosing done");

            if (MONO)
                this.Dispose();
        }


        /// <summary>
        /// this happens after FormClosing...
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);

            Console.WriteLine("MainV2_FormClosed");

            if (joystick != null)
            {
                while (!joysendThreadExited)
                    Thread.Sleep(10);

                joystick.Dispose(); //proper clean up of joystick.
            }
        }

        private void LoadConfig()
        {
            try
            {
                log.Info("Loading config");

                Settings.Instance.Load();

                comPortName = Settings.Instance.ComPort;
            }
            catch (Exception ex)
            {
                log.Error("Bad Config File", ex);
            }
        }

        private void SaveConfig()
        {
            try
            {
                log.Info("Saving config");
                Settings.Instance.ComPort = comPortName;

                if (_connectionControl != null)
                    Settings.Instance.BaudRate = _connectionControl.CMB_baudrate.Text;

                Settings.Instance.APMFirmware = MainV2.comPort.MAV.cs.firmware.ToString();

                Settings.Instance.Save();
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// needs to be true by default so that exits properly if no joystick used.
        /// </summary>
        volatile private bool joysendThreadExited = true;

        /// <summary>
        /// thread used to send joystick packets to the MAV
        /// </summary>
        private void joysticksend()
        {
            float rate = 50; // 1000 / 50 = 20 hz
            int count = 0;

            DateTime lastratechange = DateTime.Now;

            joystickthreadrun = true;

            while (joystickthreadrun)
            {
                joysendThreadExited = false;
                //so we know this thread is stil alive.           
                try
                {
                    if (MONO)
                    {
                        log.Error("Mono: closing joystick thread");
                        break;
                    }

                    if (!MONO)
                    {
                        //joystick stuff

                        if (joystick != null && joystick.enabled)
                        {
                            if (!joystick.manual_control)
                            {
                                MAVLink.mavlink_rc_channels_override_t rc = new MAVLink.mavlink_rc_channels_override_t();

                                rc.target_component = comPort.MAV.compid;
                                rc.target_system = comPort.MAV.sysid;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan1_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan2_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan3_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan4_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech4;
                                if (joystick.getJoystickAxis(5) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan5_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech5;
                                if (joystick.getJoystickAxis(6) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan6_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech6;
                                if (joystick.getJoystickAxis(7) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan7_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech7;
                                if (joystick.getJoystickAxis(8) != Joystick.Joystick.joystickaxis.None)
                                    rc.chan8_raw = (ushort)MainV2.comPort.MAV.cs.rcoverridech8;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    /*
                                if (MainV2.comPort.MAV.cs.rssi > 0 && MainV2.comPort.MAV.cs.remrssi > 0)
                                {
                                    if (lastratechange.Second != DateTime.Now.Second)
                                    {
                                        if (MainV2.comPort.MAV.cs.txbuffer > 90)
                                        {
                                            if (rate < 20)
                                                rate = 21;
                                            rate--;

                                            if (MainV2.comPort.MAV.cs.linkqualitygcs < 70)
                                                rate = 50;
                                        }
                                        else
                                        {
                                            if (rate > 100)
                                                rate = 100;
                                            rate++;
                                        }

                                        lastratechange = DateTime.Now;
                                    }
                                 
                                }
                                */
                                    //                                Console.WriteLine(DateTime.Now.Millisecond + " {0} {1} {2} {3} {4}", rc.chan1_raw, rc.chan2_raw, rc.chan3_raw, rc.chan4_raw,rate);

                                    //Console.WriteLine("Joystick btw " + comPort.BaseStream.BytesToWrite);

                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            MissionPlanner.Controls.SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, rc.target_system, rc.target_component);
                                        }
                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                            else
                            {
                                MAVLink.mavlink_manual_control_t rc = new MAVLink.mavlink_manual_control_t();

                                rc.target = comPort.MAV.compid;

                                if (joystick.getJoystickAxis(1) != Joystick.Joystick.joystickaxis.None)
                                    rc.x = MainV2.comPort.MAV.cs.rcoverridech1;
                                if (joystick.getJoystickAxis(2) != Joystick.Joystick.joystickaxis.None)
                                    rc.y = MainV2.comPort.MAV.cs.rcoverridech2;
                                if (joystick.getJoystickAxis(3) != Joystick.Joystick.joystickaxis.None)
                                    rc.z = MainV2.comPort.MAV.cs.rcoverridech3;
                                if (joystick.getJoystickAxis(4) != Joystick.Joystick.joystickaxis.None)
                                    rc.r = MainV2.comPort.MAV.cs.rcoverridech4;

                                if (lastjoystick.AddMilliseconds(rate) < DateTime.Now)
                                {
                                    if (!comPort.BaseStream.IsOpen)
                                        continue;

                                    if (comPort.BaseStream.BytesToWrite < 50)
                                    {
                                        if (sitl)
                                        {
                                            MissionPlanner.Controls.SITL.rcinput();
                                        }
                                        else
                                        {
                                            comPort.sendPacket(rc, comPort.MAV.sysid, comPort.MAV.compid);
                                        }
                                        count++;
                                        lastjoystick = DateTime.Now;
                                    }
                                }
                            }
                        }
                    }
                    Thread.Sleep(20);
                }
                catch
                {
                } // cant fall out
            }
            joysendThreadExited = true; //so we know this thread exited.    
        }

        /// <summary>
        /// Used to fix the icon status for unexpected unplugs etc...
        /// </summary>
        private void UpdateConnectIcon()
        {
            if ((DateTime.Now - connectButtonUpdate).Milliseconds > 500)
            {
                //                        Console.WriteLine(DateTime.Now.Millisecond);
                if (comPort.BaseStream.IsOpen)
                {
                    if ((string)this.MenuConnect.Image.Tag != "Disconnect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image = displayicons.disconnect;
                           this.MenuConnect.Image.Tag = "Disconnect";
                           this.MenuConnect.Text = Strings.DISCONNECTc;
                           _connectionControl.IsConnected(true);
                       });
                    }
                }
                else
                {
                    if (this.MenuConnect.Image != null && (string)this.MenuConnect.Image.Tag != "Connect")
                    {
                        this.BeginInvoke((MethodInvoker)delegate
                       {
                           this.MenuConnect.Image = displayicons.connect;
                           this.MenuConnect.Image.Tag = "Connect";
                           this.MenuConnect.Text = Strings.CONNECTc;
                           _connectionControl.IsConnected(false);
                           if (_connectionStats != null)
                           {
                               _connectionStats.StopUpdates();
                           }
                       });
                    }

                    if (comPort.logreadmode)
                    {
                        this.BeginInvoke((MethodInvoker)delegate { _connectionControl.IsConnected(true); });
                    }
                }
                connectButtonUpdate = DateTime.Now;
            }
        }

        ManualResetEvent PluginThreadrunner = new ManualResetEvent(false);

        private void PluginThread()
        {
            Hashtable nextrun = new Hashtable();

            pluginthreadrun = true;

            PluginThreadrunner.Reset();

            while (pluginthreadrun)
            {
                try
                {
                    lock (Plugin.PluginLoader.Plugins)
                    {
                        foreach (var plugin in Plugin.PluginLoader.Plugins)
                        {
                            if (!nextrun.ContainsKey(plugin))
                                nextrun[plugin] = DateTime.MinValue;

                            if (DateTime.Now > plugin.NextRun)
                            {
                                // get ms till next run
                                int msnext = (int)(1000 / plugin.loopratehz);
                                // allow the plug to modify this, if needed
                                plugin.NextRun = DateTime.Now.AddMilliseconds(msnext);

                                try
                                {
                                    bool ans = plugin.Loop();
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                }
                            }
                        }
                    }
                }
                catch
                {
                }

                // max rate is 100 hz - prevent massive cpu usage
                System.Threading.Thread.Sleep(10);
            }

            while (Plugin.PluginLoader.Plugins.Count > 0)
            {
                var plugin = Plugin.PluginLoader.Plugins[0];
                try
                {
                    plugin.Exit();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                }
                Plugin.PluginLoader.Plugins.Remove(plugin);
            }

            PluginThreadrunner.Set();

            return;
        }

        ManualResetEvent SerialThreadrunner = new ManualResetEvent(false);

        /// <summary>
        /// main serial reader thread
        /// controls
        /// serial reading
        /// link quality stats
        /// speech voltage - custom - alt warning - data lost
        /// heartbeat packet sending
        /// 
        /// and can't fall out
        /// </summary>
        private void SerialReader()
        {
            if (serialThread == true)
                return;
            serialThread = true;

            SerialThreadrunner.Reset();

            int minbytes = 0;

            int altwarningmax = 0;

            bool armedstatus = false;

            string lastmessagehigh = "";

            DateTime speechcustomtime = DateTime.Now;

            DateTime speechlowspeedtime = DateTime.Now;

            DateTime linkqualitytime = DateTime.Now;

            while (serialThread)
            {
                try
                {
                    Thread.Sleep(1); // was 5

                    try
                    {
                        if (GCSViews.Terminal.comPort is MAVLinkSerialPort)
                        {
                        }
                        else
                        {
                            if (GCSViews.Terminal.comPort != null && GCSViews.Terminal.comPort.IsOpen)
                                continue;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // update connect/disconnect button and info stats
                    try
                    {
                        UpdateConnectIcon();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                    // 30 seconds interval speech options
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechcustomtime).TotalSeconds > 30 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (MainV2.speechEngine.IsReady)
                        {
                            if (Settings.Instance.GetBoolean("speechcustomenabled"))
                            {
                                MainV2.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechcustom"]));
                            }

                            speechcustomtime = DateTime.Now;
                        }

                        // speech for battery alerts
                        //speechbatteryvolt
                        float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                        float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                        if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                            MainV2.comPort.MAV.cs.battery_voltage <= warnvolt &&
                            MainV2.comPort.MAV.cs.battery_voltage >= 5.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                        else if (Settings.Instance.GetBoolean("speechbatteryenabled") == true &&
                                 (MainV2.comPort.MAV.cs.battery_remaining) < warnpercent &&
                                 MainV2.comPort.MAV.cs.battery_voltage >= 5.0 &&
                                 MainV2.comPort.MAV.cs.battery_remaining != 0.0)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync(
                                    Common.speechConversion("" + Settings.Instance["speechbattery"]));
                            }
                        }
                    }

                    // speech for airspeed alerts
                    if (speechEnable && speechEngine != null && (DateTime.Now - speechlowspeedtime).TotalSeconds > 10 &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        if (Settings.Instance.GetBoolean("speechlowspeedenabled") == true && MainV2.comPort.MAV.cs.armed)
                        {
                            float warngroundspeed = Settings.Instance.GetFloat("speechlowgroundspeedtrigger");
                            float warnairspeed = Settings.Instance.GetFloat("speechlowairspeedtrigger");

                            if (MainV2.comPort.MAV.cs.airspeed < warnairspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowairspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else if (MainV2.comPort.MAV.cs.groundspeed < warngroundspeed)
                            {
                                if (MainV2.speechEngine.IsReady)
                                {
                                    MainV2.speechEngine.SpeakAsync(
                                        Common.speechConversion("" + Settings.Instance["speechlowgroundspeed"]));
                                    speechlowspeedtime = DateTime.Now;
                                }
                            }
                            else
                            {
                                speechlowspeedtime = DateTime.Now;
                            }
                        }
                    }

                    // speech altitude warning - message high warning
                    if (speechEnable && speechEngine != null &&
                        (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen))
                    {
                        float warnalt = float.MaxValue;
                        if (Settings.Instance.ContainsKey("speechaltheight"))
                        {
                            warnalt = Settings.Instance.GetFloat("speechaltheight");
                        }
                        try
                        {
                            altwarningmax = (int)Math.Max(MainV2.comPort.MAV.cs.alt, altwarningmax);

                            if (Settings.Instance.GetBoolean("speechaltenabled") == true && MainV2.comPort.MAV.cs.alt != 0.00 &&
                                (MainV2.comPort.MAV.cs.alt <= warnalt) && MainV2.comPort.MAV.cs.armed)
                            {
                                if (altwarningmax > warnalt)
                                {
                                    if (MainV2.speechEngine.IsReady)
                                        MainV2.speechEngine.SpeakAsync(
                                            Common.speechConversion("" + Settings.Instance["speechalt"]));
                                }
                            }
                        }
                        catch
                        {
                        } // silent fail


                        try
                        {
                            // say the latest high priority message
                            if (MainV2.speechEngine.IsReady &&
                                lastmessagehigh != MainV2.comPort.MAV.cs.messageHigh && MainV2.comPort.MAV.cs.messageHigh != null)
                            {
                                if (!MainV2.comPort.MAV.cs.messageHigh.StartsWith("PX4v2 "))
                                {
                                    MainV2.speechEngine.SpeakAsync(MainV2.comPort.MAV.cs.messageHigh);
                                    lastmessagehigh = MainV2.comPort.MAV.cs.messageHigh;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }

                    // not doing anything
                    if (!MainV2.comPort.logreadmode && !comPort.BaseStream.IsOpen)
                    {
                        altwarningmax = 0;
                    }

                    // attenuate the link qualty over time
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds >= 1)
                    {
                        if (linkqualitytime.Second != DateTime.Now.Second)
                        {
                            MainV2.comPort.MAV.cs.linkqualitygcs = (ushort)(MainV2.comPort.MAV.cs.linkqualitygcs * 0.8f);
                            linkqualitytime = DateTime.Now;

                            // force redraw if there are no other packets are being read
                            GCSViews.FlightData.myhud.Invalidate();
                        }
                    }

                    // data loss warning - wait min of 10 seconds, ignore first 30 seconds of connect, repeat at 5 seconds interval
                    if ((DateTime.Now - MainV2.comPort.MAV.lastvalidpacket).TotalSeconds > 10
                        && (DateTime.Now - connecttime).TotalSeconds > 30
                        && (DateTime.Now - nodatawarning).TotalSeconds > 5
                        && (MainV2.comPort.logreadmode || comPort.BaseStream.IsOpen)
                        && MainV2.comPort.MAV.cs.armed)
                    {
                        if (speechEnable && speechEngine != null)
                        {
                            if (MainV2.speechEngine.IsReady)
                            {
                                MainV2.speechEngine.SpeakAsync("WARNING No Data for " +
                                                               (int)
                                                                   (DateTime.Now - MainV2.comPort.MAV.lastvalidpacket)
                                                                       .TotalSeconds + " Seconds");
                                nodatawarning = DateTime.Now;
                            }
                        }
                    }

                    // get home point on armed status change.
                    if (armedstatus != MainV2.comPort.MAV.cs.armed && comPort.BaseStream.IsOpen)
                    {
                        armedstatus = MainV2.comPort.MAV.cs.armed;
                        // status just changed to armed
                        if (MainV2.comPort.MAV.cs.armed == true && MainV2.comPort.MAV.aptype != MAVLink.MAV_TYPE.GIMBAL)
                        {
                            try
                            {
                                //MainV2.comPort.getHomePosition();
                                MainV2.comPort.MAV.cs.HomeLocation = new PointLatLngAlt(MainV2.comPort.getWP(0));
                                if (MyView.current != null && MyView.current.Name == "FlightPlanner")
                                {
                                    // update home if we are on flight data tab
                                    FlightPlanner.updateHome();
                                }
                            }
                            catch
                            {
                                // dont hang this loop
                                this.BeginInvoke(
                                    (MethodInvoker)
                                        delegate
                                        {
                                            CustomMessageBox.Show("Failed to update home location (" +
                                                                  MainV2.comPort.MAV.sysid + ")");
                                        });
                            }
                        }

                        if (speechEnable && speechEngine != null)
                        {
                            if (Settings.Instance.GetBoolean("speecharmenabled"))
                            {
                                string speech = armedstatus ? Settings.Instance["speecharm"] : Settings.Instance["speechdisarm"];
                                if (!string.IsNullOrEmpty(speech))
                                {
                                    MainV2.speechEngine.SpeakAsync(Common.speechConversion(speech));
                                }
                            }
                        }
                    }

                    // send a hb every seconds from gcs to ap
                    if (heatbeatSend.Second != DateTime.Now.Second)
                    {
                        MAVLink.mavlink_heartbeat_t htb = new MAVLink.mavlink_heartbeat_t()
                        {
                            type = (byte)MAVLink.MAV_TYPE.GCS,
                            autopilot = (byte)MAVLink.MAV_AUTOPILOT.INVALID,
                            mavlink_version = 3 // MAVLink.MAVLINK_VERSION
                        };

                        // enumerate each link
                        foreach (var port in Comports)
                        {
                            if (!port.BaseStream.IsOpen)
                                continue;

                            // poll for params at heartbeat interval
                            if (!port.giveComport)
                            {
                                try
                                {
                                    port.getParamPoll();
                                    port.getParamPoll();
                                }
                                catch
                                {
                                }
                            }

                            // there are 3 hb types we can send, mavlink1, mavlink2 signed and unsigned
                            bool sentsigned = false;
                            bool sentmavlink1 = false;
                            bool sentmavlink2 = false;

                            // enumerate each mav
                            foreach (var MAV in port.MAVlist)
                            {
                                try
                                {
                                    // are we talking to a mavlink2 device
                                    if (MAV.mavlinkv2)
                                    {
                                        // is signing enabled
                                        if (MAV.signing)
                                        {
                                            // check if we have already sent
                                            if (sentsigned)
                                                continue;
                                            sentsigned = true;
                                        }
                                        else
                                        {
                                            // check if we have already sent
                                            if (sentmavlink2)
                                                continue;
                                            sentmavlink2 = true;
                                        }
                                    }
                                    else
                                    {
                                        // check if we have already sent
                                        if (sentmavlink1)
                                            continue;
                                        sentmavlink1 = true;
                                    }

                                    port.sendPacket(htb, MAV.sysid, MAV.compid);
                                }
                                catch (Exception ex)
                                {
                                    log.Error(ex);
                                    // close the bad port
                                    try
                                    {
                                        port.Close();
                                    }
                                    catch
                                    {
                                    }
                                    // refresh the screen if needed
                                    if (port == MainV2.comPort)
                                    {
                                        // refresh config window if needed
                                        if (MyView.current != null)
                                        {
                                            this.Invoke((MethodInvoker)delegate ()
                                           {
                                               if (MyView.current.Name == "HWConfig")
                                                   MyView.ShowScreen("HWConfig");
                                               if (MyView.current.Name == "SWConfig")
                                                   MyView.ShowScreen("SWConfig");
                                           });
                                        }
                                    }
                                }
                            }
                        }

                        heatbeatSend = DateTime.Now;
                    }

                    // if not connected or busy, sleep and loop
                    if (!comPort.BaseStream.IsOpen || comPort.giveComport == true)
                    {
                        if (!comPort.BaseStream.IsOpen)
                        {
                            // check if other ports are still open
                            foreach (var port in Comports)
                            {
                                if (port.BaseStream.IsOpen)
                                {
                                    Console.WriteLine("Main comport shut, swapping to other mav");
                                    comPort = port;
                                    break;
                                }
                            }
                        }

                        System.Threading.Thread.Sleep(100);
                    }

                    // read the interfaces
                    foreach (var port in Comports.ToArray())
                    {
                        if (!port.BaseStream.IsOpen)
                        {
                            // skip primary interface
                            if (port == comPort)
                                continue;

                            // modify array and drop out
                            Comports.Remove(port);
                            port.Dispose();
                            break;
                        }

                        while (port.BaseStream.IsOpen && port.BaseStream.BytesToRead > minbytes &&
                               port.giveComport == false && serialThread)
                        {
                            try
                            {
                                port.readPacket();
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                        // update currentstate of sysids on the port
                        foreach (var MAV in port.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, port, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Tracking.AddException(e);
                    log.Error("Serial Reader fail :" + e.ToString());
                    try
                    {
                        comPort.Close();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }
                }
            }

            Console.WriteLine("SerialReader Done");
            SerialThreadrunner.Set();
        }
        //protected override void OnLoad(EventArgs e)
        //{
        //    // check if its defined, and force to show it if not known about
        //    if (Settings.Instance["menu_autohide"] == null)
        //    {
        //        Settings.Instance["menu_autohide"] = "false";
        //    }

        //    try
        //    {
        //        AutoHideMenu(Settings.Instance.GetBoolean("menu_autohide"));
        //    }
        //    catch
        //    {
        //    }

        //    MyView.AddScreen(new MainSwitcher.Screen("FlightData", FlightData, true));
        //    MyView.AddScreen(new MainSwitcher.Screen("FlightPlanner", FlightPlanner, true));
        //    MyView.AddScreen(new MainSwitcher.Screen("HWConfig", typeof(GCSViews.InitialSetup), false));
        //    MyView.AddScreen(new MainSwitcher.Screen("SWConfig", typeof(GCSViews.SoftwareConfig), false));
        //    MyView.AddScreen(new MainSwitcher.Screen("Simulation", Simulation, true));
        //    MyView.AddScreen(new MainSwitcher.Screen("Terminal", typeof(GCSViews.Terminal), false));
        //    MyView.AddScreen(new MainSwitcher.Screen("Help", typeof(GCSViews.Help), false));

        //    try
        //    {
        //        if (Control.ModifierKeys == Keys.Shift)
        //        {
        //        }
        //        else
        //        {
        //            log.Info("Load Pluggins");
        //            Plugin.PluginLoader.LoadAll();
        //            log.Info("Load Pluggins... Done");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex);
        //    }

        //    if (Program.Logo != null && Program.name == "VVVVZ")
        //    {
        //        this.PerformLayout();
        //        //MenuFlightPlanner_Click(this, e);
        //        //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightPlanner));
        //    }
        //    else
        //    {
        //        this.PerformLayout();
        //        log.Info("show FlightData");

        //        toolStripButton1_Click_1(this, e);
        //        //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
        //        //MenuFlightData_Click(this, e);
        //        log.Info("show FlightData... Done");
        //        //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
        //    }

        //    // for long running tasks using own threads.
        //    // for short use threadpool

        //    this.SuspendLayout();

        //    // setup http server
        //    try
        //    {
        //        log.Info("start http");
        //        httpthread = new Thread(new httpserver().listernforclients)
        //        {
        //            Name = "motion jpg stream-network kml",
        //            IsBackground = true
        //        };
        //        httpthread.Start();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error starting TCP listener thread: ", ex);
        //        CustomMessageBox.Show(ex.ToString());
        //    }

        //    log.Info("start joystick");
        //    // setup joystick packet sender
        //    joystickthread = new Thread(new ThreadStart(joysticksend))
        //    {
        //        IsBackground = true,
        //        Priority = ThreadPriority.AboveNormal,
        //        Name = "Main joystick sender"
        //    };
        //    joystickthread.Start();

        //    log.Info("start serialreader");
        //    // setup main serial reader
        //    serialreaderthread = new Thread(SerialReader)
        //    {
        //        IsBackground = true,
        //        Name = "Main Serial reader",
        //        Priority = ThreadPriority.AboveNormal
        //    };
        //    serialreaderthread.Start();

        //    log.Info("start plugin thread");
        //    // setup main plugin thread
        //    pluginthread = new Thread(PluginThread)
        //    {
        //        IsBackground = true,
        //        Name = "plugin runner thread",
        //        Priority = ThreadPriority.BelowNormal
        //    };
        //    pluginthread.Start();

        //    ThreadPool.QueueUserWorkItem(BGLoadAirports);

        //    ThreadPool.QueueUserWorkItem(BGCreateMaps);

        //    //ThreadPool.QueueUserWorkItem(BGGetAlmanac);

        //    ThreadPool.QueueUserWorkItem(BGgetTFR);

        //    ThreadPool.QueueUserWorkItem(BGNoFly);

        //    ThreadPool.QueueUserWorkItem(BGGetKIndex);

        //    // update firmware version list - only once per day
        //    ThreadPool.QueueUserWorkItem(BGFirmwareCheck);

        //    log.Info("start udpvideoshim");
        //    // start listener
        //    UDPVideoShim.Start();

        //    try
        //    {
        //        log.Info("Load AltitudeAngel");
        //        new Utilities.AltitudeAngel.AltitudeAngel();

        //        /*
        //        // setup as a prompt once dialog
        //        if (!Settings.Instance.GetBoolean("AACheck"))
        //        {
        //            if (CustomMessageBox.Show(
        //                    "Do you wish to enable Altitude Angel airspace management data?\nFor more information visit [link;http://www.altitudeangel.com;www.altitudeangel.com]",
        //                    "Altitude Angel - Enable", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //            {
        //                Utilities.AltitudeAngel.AltitudeAngel.service.SignInAsync();
        //            }

        //            Settings.Instance["AACheck"] = true.ToString();
        //        }
        //        */
        //        log.Info("Load AltitudeAngel... Done");
        //    }
        //    catch (TypeInitializationException) // windows xp lacking patch level
        //    {
        //        CustomMessageBox.Show("Please update your .net version. kb2468871");
        //    }
        //    catch (Exception ex)
        //    {
        //        Tracking.AddException(ex);
        //    }

        //    this.ResumeLayout();

        //    Program.Splash.Close();

        //    log.Info("appload time");
        //    MissionPlanner.Utilities.Tracking.AddTiming("AppLoad", "Load Time",
        //        (DateTime.Now - Program.starttime).TotalMilliseconds, "");

        //    try
        //    {
        //        // single update check per day - in a seperate thread
        //        if (Settings.Instance["update_check"] != DateTime.Now.ToShortDateString())
        //        {
        //            System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
        //            Settings.Instance["update_check"] = DateTime.Now.ToShortDateString();
        //        }
        //        else if (Settings.Instance.GetBoolean("beta_updates") == true)
        //        {
        //            MissionPlanner.Utilities.Update.dobeta = true;
        //            System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Update check failed", ex);
        //    }

        //    // play a tlog that was passed to the program/ load a bin log passed
        //    if (Program.args.Length > 0)
        //    {
        //        var cmds = ProcessCommandLine(Program.args);

        //        if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) && cmds["file"].ToLower().EndsWith(".tlog"))
        //        {
        //            FlightData.LoadLogFile(Program.args[0]);
        //            FlightData.BUT_playlog_Click(null, null);
        //        }
        //        else if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) &&
        //                 (cmds["file"].ToLower().EndsWith(".log") || cmds["file"].ToLower().EndsWith(".bin")))
        //        {
        //            LogBrowse logbrowse = new LogBrowse();
        //            ThemeManager.ApplyThemeTo(logbrowse);
        //            logbrowse.logfilename = Program.args[0];
        //            logbrowse.Show(this);
        //            logbrowse.BringToFront();
        //        }

        //        if (cmds.ContainsKey("joy") && cmds.ContainsKey("type"))
        //        {
        //            if (cmds["type"].ToLower() == "plane")
        //            {
        //                MainV2.comPort.MAV.cs.firmware = Firmwares.ArduPlane;
        //            }
        //            if (cmds["type"].ToLower() == "copter")
        //            {
        //                MainV2.comPort.MAV.cs.firmware = Firmwares.ArduCopter2;
        //            }
        //            if (cmds["type"].ToLower() == "rover")
        //            {
        //                MainV2.comPort.MAV.cs.firmware = Firmwares.ArduRover;
        //            }

        //            var joy = new Joystick.Joystick();

        //            if (joy.start(cmds["joy"]))
        //            {
        //                MainV2.joystick = joy;
        //                MainV2.joystick.enabled = true;
        //            }
        //            else
        //            {
        //                CustomMessageBox.Show("Failed to start joystick");
        //            }
        //        }

        //        if (cmds.ContainsKey("cam"))
        //        {
        //            try
        //            {
        //                MainV2.cam = new Capture(int.Parse(cmds["cam"]), null);

        //                MainV2.cam.Start();
        //            }
        //            catch (Exception ex)
        //            {
        //                CustomMessageBox.Show(ex.ToString());
        //            }
        //        }

        //        if (cmds.ContainsKey("port") && cmds.ContainsKey("baud"))
        //        {
        //            _connectionControl.CMB_serialport.Text = cmds["port"];
        //            _connectionControl.CMB_baudrate.Text = cmds["baud"];

        //            doConnect(MainV2.comPort, cmds["port"], cmds["baud"]);
        //        }
        //    }

        //    // show wizard on first use
        //    if (Settings.Instance["newuser"] == null)
        //    {
        //        if (CustomMessageBox.Show("This is your first run, Do you wish to use the setup wizard?\nRecomended for new users.", "Wizard", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
        //        {
        //            Wizard.Wizard wiz = new Wizard.Wizard();

        //            wiz.ShowDialog(this);
        //        }

        //        CustomMessageBox.Show("To use the wizard please goto the initial setup screen, and click the wizard icon.", "Wizard");

        //        Settings.Instance["newuser"] = DateTime.Now.ToShortDateString();
        //    }
        //    splitContainer2.SplitterDistance = splitContainer2.Height/7;
        //}
        protected override void OnLoad(EventArgs e)
        {
            // check if its defined, and force to show it if not known about
            if (Settings.Instance["menu_autohide"] == null)
            {
                Settings.Instance["menu_autohide"] = "false";
            }

            try
            {
                AutoHideMenu(Settings.Instance.GetBoolean("menu_autohide"));
            }
            catch
            {
            }

            MyView.AddScreen(new MainSwitcher.Screen("FlightData", FlightData, true));
            MyView.AddScreen(new MainSwitcher.Screen("FlightPlanner", FlightPlanner, true));
            MyView.AddScreen(new MainSwitcher.Screen("HWConfig", typeof(GCSViews.InitialSetup), false));
            MyView.AddScreen(new MainSwitcher.Screen("SWConfig", typeof(GCSViews.SoftwareConfig), false));
            MyView.AddScreen(new MainSwitcher.Screen("Simulation", Simulation, true));
            MyView.AddScreen(new MainSwitcher.Screen("Terminal", typeof(GCSViews.Terminal), false));
            MyView.AddScreen(new MainSwitcher.Screen("Help", typeof(GCSViews.Help), false));

            try
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                }
                else
                {
                    log.Info("Load Pluggins");
                    Plugin.PluginLoader.LoadAll();
                    log.Info("Load Pluggins... Done");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            if (Program.Logo != null && Program.name == "VVVVZ")
            {
                this.PerformLayout();
                //toolStripButton2_Click(this, e);
                //MenuFlightPlanner_Click(this, e);

                //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightPlanner));
            }
            else
            {
                this.PerformLayout();
                log.Info("show FlightPlanner");

                GCSViews.FlightPlanner w1 = new GCSViews.FlightPlanner();
                w1.Parent = splitContainer4.Panel2;

                w1.MainMap.Position = new GMap.NET.PointLatLng(39.7716824, 116.5296914);
                w1.MainMap.Zoom = 18;
                w1.Dock = DockStyle.Fill;
                w1.Activate();
                w1.Visible = true;
                w1.Focus();
                //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
                //MenuFlightData_Click(this, e);
                log.Info("show FlightPlanner... Done");
                //MainMenu_ItemClicked(this, new ToolStripItemClickedEventArgs(MenuFlightData));
            }

            // for long running tasks using own threads.
            // for short use threadpool

            this.SuspendLayout();

            // setup http server
            try
            {
                log.Info("start http");
                httpthread = new Thread(new httpserver().listernforclients)
                {
                    Name = "motion jpg stream-network kml",
                    IsBackground = true
                };
                httpthread.Start();
            }
            catch (Exception ex)
            {
                log.Error("Error starting TCP listener thread: ", ex);
                CustomMessageBox.Show(ex.ToString());
            }

            log.Info("start joystick");
            // setup joystick packet sender
            joystickthread = new Thread(new ThreadStart(joysticksend))
            {
                IsBackground = true,
                Priority = ThreadPriority.AboveNormal,
                Name = "Main joystick sender"
            };
            joystickthread.Start();

            log.Info("start serialreader");
            // setup main serial reader
            serialreaderthread = new Thread(SerialReader)
            {
                IsBackground = true,
                Name = "Main Serial reader",
                Priority = ThreadPriority.AboveNormal
            };
            serialreaderthread.Start();

            log.Info("start plugin thread");
            // setup main plugin thread
            pluginthread = new Thread(PluginThread)
            {
                IsBackground = true,
                Name = "plugin runner thread",
                Priority = ThreadPriority.BelowNormal
            };
            pluginthread.Start();

            ThreadPool.QueueUserWorkItem(BGLoadAirports);

            ThreadPool.QueueUserWorkItem(BGCreateMaps);

            //ThreadPool.QueueUserWorkItem(BGGetAlmanac);

            ThreadPool.QueueUserWorkItem(BGgetTFR);

            ThreadPool.QueueUserWorkItem(BGNoFly);

            ThreadPool.QueueUserWorkItem(BGGetKIndex);

            // update firmware version list - only once per day
            ThreadPool.QueueUserWorkItem(BGFirmwareCheck);

            log.Info("start udpvideoshim");
            // start listener
            UDPVideoShim.Start();

            try
            {
                log.Info("Load AltitudeAngel");
                new Utilities.AltitudeAngel.AltitudeAngel();

                /*
                // setup as a prompt once dialog
                if (!Settings.Instance.GetBoolean("AACheck"))
                {
                    if (CustomMessageBox.Show(
                            "Do you wish to enable Altitude Angel airspace management data?\nFor more information visit [link;http://www.altitudeangel.com;www.altitudeangel.com]",
                            "Altitude Angel - Enable", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Utilities.AltitudeAngel.AltitudeAngel.service.SignInAsync();
                    }

                    Settings.Instance["AACheck"] = true.ToString();
                }
                */
                log.Info("Load AltitudeAngel... Done");
            }
            catch (TypeInitializationException) // windows xp lacking patch level
            {
                CustomMessageBox.Show("Please update your .net version. kb2468871");
            }
            catch (Exception ex)
            {
                Tracking.AddException(ex);
            }

            this.ResumeLayout();

            Program.Splash.Close();

            log.Info("appload time");
            MissionPlanner.Utilities.Tracking.AddTiming("AppLoad", "Load Time",
                (DateTime.Now - Program.starttime).TotalMilliseconds, "");

            try
            {
                // single update check per day - in a seperate thread
                if (Settings.Instance["update_check"] != DateTime.Now.ToShortDateString())
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
                    Settings.Instance["update_check"] = DateTime.Now.ToShortDateString();
                }
                else if (Settings.Instance.GetBoolean("beta_updates") == true)
                {
                    MissionPlanner.Utilities.Update.dobeta = true;
                    System.Threading.ThreadPool.QueueUserWorkItem(checkupdate);
                }
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }

            // play a tlog that was passed to the program/ load a bin log passed
            if (Program.args.Length > 0)
            {
                var cmds = ProcessCommandLine(Program.args);

                if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) && cmds["file"].ToLower().EndsWith(".tlog"))
                {
                    FlightData.LoadLogFile(Program.args[0]);
                    FlightData.BUT_playlog_Click(null, null);
                }
                else if (cmds.ContainsKey("file") && File.Exists(cmds["file"]) &&
                         (cmds["file"].ToLower().EndsWith(".log") || cmds["file"].ToLower().EndsWith(".bin")))
                {
                    LogBrowse logbrowse = new LogBrowse();
                    //ThemeManager.ApplyThemeTo(logbrowse);
                    logbrowse.logfilename = Program.args[0];
                    logbrowse.Show(this);
                    logbrowse.BringToFront();
                }

                if (cmds.ContainsKey("joy") && cmds.ContainsKey("type"))
                {
                    if (cmds["type"].ToLower() == "plane")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduPlane;
                    }
                    if (cmds["type"].ToLower() == "copter")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduCopter2;
                    }
                    if (cmds["type"].ToLower() == "rover")
                    {
                        MainV2.comPort.MAV.cs.firmware = Firmwares.ArduRover;
                    }

                    var joy = new Joystick.Joystick();

                    if (joy.start(cmds["joy"]))
                    {
                        MainV2.joystick = joy;
                        MainV2.joystick.enabled = true;
                    }
                    else
                    {
                        CustomMessageBox.Show("Failed to start joystick");
                    }
                }

                if (cmds.ContainsKey("cam"))
                {
                    try
                    {
                        MainV2.cam = new Capture(int.Parse(cmds["cam"]), null);

                        MainV2.cam.Start();
                    }
                    catch (Exception ex)
                    {
                        CustomMessageBox.Show(ex.ToString());
                    }
                }

                if (cmds.ContainsKey("port") && cmds.ContainsKey("baud"))
                {
                    _connectionControl.CMB_serialport.Text = cmds["port"];
                    _connectionControl.CMB_baudrate.Text = cmds["baud"];

                    doConnect(MainV2.comPort, cmds["port"], cmds["baud"]);
                }
            }

            // show wizard on first use
            if (Settings.Instance["newuser"] == null)
            {
                if (CustomMessageBox.Show("This is your first run, Do you wish to use the setup wizard?\nRecomended for new users.", "Wizard", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    Wizard.Wizard wiz = new Wizard.Wizard();

                    wiz.ShowDialog(this);
                }

                CustomMessageBox.Show("To use the wizard please goto the initial setup screen, and click the wizard icon.", "Wizard");

                Settings.Instance["newuser"] = DateTime.Now.ToShortDateString();
            }
            splitContainer4.SplitterDistance = splitContainer4.Height / 22;
            splitContainer2.SplitterDistance = splitContainer2.Height / 10;
            splitContainer3.SplitterDistance = splitContainer3.Height - splitContainer3.Height / 6;
            tabControl1_SelectedIndexChanged(this, e);
            //

            //groupBox1.Height = tabControl1.Height / 3;
            hud1.doResize();

            thisthread1 = new Thread(mainloop);
            thisthread1.Name = "F Mainloop";
            thisthread1.IsBackground = true;
            thisthread1.Start();
        }
        private void mainloop()
        {
            //while (!IsHandleCreated)
            //    Thread.Sleep(1000);
            //threadrun = true;
            //while (threadrun)
            //{
            //    if (MainV2.comPort.giveComport)
            //    {
            //        Thread.Sleep(50);
            //        updateBindingSource();
            //        continue;
            //    }
            //    if (!MainV2.comPort.logreadmode)
            //        Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

            //    if (this.IsDisposed)
            //    {
            //        threadrun = false;
            //        break;
            //    }
            //    hud1.streamjpgenable = true;
            //    try
            //    {
            //        if (!MainV2.comPort.giveComport)
            //            MainV2.comPort.readPacket();

            //        // update currentstate of sysids on the port
            //        foreach (var MAV in MainV2.comPort.MAVlist)
            //        {
            //            try
            //            {
            //                MAV.cs.UpdateCurrentSettings(null, false, MainV2.comPort, MAV);
            //            }
            //            catch (Exception ex)
            //            {
            //                log.Error(ex);
            //            }
            //        }
            //    }
            //    catch
            //    {
            //        log.Error("Failed to read log packet");
            //    }
            //}
            threadrun = true;
            //EndPoint Remote = new IPEndPoint(IPAddress.Any, 0);

            
            DateTime tracklast = DateTime.Now.AddSeconds(0);

            DateTime tunning = DateTime.Now.AddSeconds(0);

            DateTime mapupdate = DateTime.Now.AddSeconds(0);

            DateTime vidrec = DateTime.Now.AddSeconds(0);

            DateTime waypoints = DateTime.Now.AddSeconds(0);

            DateTime updatescreen = DateTime.Now;

            DateTime tsreal = DateTime.Now;
            double taketime = 0;
            double timeerror = 0;

            while (!IsHandleCreated)
                Thread.Sleep(1000);

            while (threadrun)
            {
                //labelhome.Text = FlightPlanner.hometext;
                if (MainV2.comPort.giveComport)
                {
                    Thread.Sleep(50);
                    updateBindingSource();
                    continue;
                }

                if (!MainV2.comPort.logreadmode)
                    Thread.Sleep(50); // max is only ever 10 hz but we go a little faster to empty the serial queue

                if (this.IsDisposed)
                {
                    threadrun = false;
                    break;
                }

                try
                {
                    if (aviwriter != null && vidrec.AddMilliseconds(100) <= DateTime.Now)
                    {
                        vidrec = DateTime.Now;

                        hud1.streamjpgenable = true;

                        //aviwriter.avi_start("test.avi");
                        // add a frame
                        aviwriter.avi_add(hud1.streamjpg.ToArray(), (uint)hud1.streamjpg.Length);
                        // write header - so even partial files will play
                        aviwriter.avi_end(hud1.Width, hud1.Height, 10);
                    }
                }
                catch
                {
                    log.Error("Failed to write avi");
                }

                // log playback
                if (MainV2.comPort.logreadmode && MainV2.comPort.logplaybackfile != null)
                {
                    if (MainV2.comPort.BaseStream.IsOpen)
                    {
                        MainV2.comPort.logreadmode = false;
                        try
                        {
                            MainV2.comPort.logplaybackfile.Close();
                        }
                        catch
                        {
                            log.Error("Failed to close logfile");
                        }
                        MainV2.comPort.logplaybackfile = null;
                    }


                   labelhome.Text= GCSViews.FlightPlanner.instance.hometext;

                    //Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    DateTime logplayback = MainV2.comPort.lastlogread;
                    try
                    {
                        if (!MainV2.comPort.giveComport)
                            MainV2.comPort.readPacket();

                        // update currentstate of sysids on the port
                        foreach (var MAV in MainV2.comPort.MAVlist)
                        {
                            try
                            {
                                MAV.cs.UpdateCurrentSettings(null, false, MainV2.comPort, MAV);
                            }
                            catch (Exception ex)
                            {
                                log.Error(ex);
                            }
                        }
                    }
                    catch
                    {
                        log.Error("Failed to read log packet");
                    }

                    double act = (MainV2.comPort.lastlogread - logplayback).TotalMilliseconds;

                    if (act > 9999 || act < 0)
                        act = 0;

                    double ts = 0;


                    if (LogPlayBackSpeed >= 4 && MainV2.speechEnable)
                        MainV2.speechEngine.SpeakAsyncCancelAll();

                    double timetook = (DateTime.Now - tsreal).TotalMilliseconds;
                    if (timetook != 0)
                    {
                        //Console.WriteLine("took: " + timetook + "=" + taketime + " " + (taketime - timetook) + " " + ts);
                        //Console.WriteLine(MainV2.comPort.lastlogread.Second + " " + DateTime.Now.Second + " " + (MainV2.comPort.lastlogread.Second - DateTime.Now.Second));
                        //if ((taketime - timetook) < 0)
                        {
                            timeerror += (taketime - timetook);
                            if (ts != 0)
                            {
                                ts += timeerror;
                                timeerror = 0;
                            }
                        }
                        if (Math.Abs(ts) > 1000)
                            ts = 1000;
                    }

                    taketime = ts;
                    tsreal = DateTime.Now;

                    if (ts > 0 && ts < 1000)
                        Thread.Sleep((int)ts);

                    tracklast = tracklast.AddMilliseconds(ts - act);
                    tunning = tunning.AddMilliseconds(ts - act);

                    if (tracklast.Month != DateTime.Now.Month)
                    {
                        tracklast = DateTime.Now;
                        tunning = DateTime.Now;
                    }

                    try
                    {
                        if (MainV2.comPort.logplaybackfile != null &&
                            MainV2.comPort.logplaybackfile.BaseStream.Position ==
                            MainV2.comPort.logplaybackfile.BaseStream.Length)
                        {
                            MainV2.comPort.logreadmode = false;
                        }
                    }
                    catch
                    {
                        MainV2.comPort.logreadmode = false;
                    }
                }
                else
                {
                    //// ensure we know to stop
                    //if (MainV2.comPort.logreadmode)
                    //    MainV2.comPort.logreadmode = false;
                    //updatePlayPauseButton(false);

                    //if (!playingLog && MainV2.comPort.logplaybackfile != null)
                    //{
                    //    continue;
                    //}
                }

                try
                {
                    //CheckAndBindPreFlightData();
                    //Console.WriteLine(DateTime.Now.Millisecond);
                    //int fixme;
                    updateBindingSource();
                    // Console.WriteLine(DateTime.Now.Millisecond + " done ");

                    // battery warning.
                    float warnvolt = Settings.Instance.GetFloat("speechbatteryvolt");
                    float warnpercent = Settings.Instance.GetFloat("speechbatterypercent");

                    if (MainV2.comPort.MAV.cs.battery_voltage <= warnvolt)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else if ((MainV2.comPort.MAV.cs.battery_remaining) < warnpercent)
                    {
                        hud1.lowvoltagealert = true;
                    }
                    else
                    {
                        hud1.lowvoltagealert = false;
                    }

                    // update opengltest
                    if (OpenGLtest.instance != null)
                    {
                        OpenGLtest.instance.rpy = new Vector3(MainV2.comPort.MAV.cs.roll, MainV2.comPort.MAV.cs.pitch,
                            MainV2.comPort.MAV.cs.yaw);
                        OpenGLtest.instance.LocationCenter = new PointLatLngAlt(MainV2.comPort.MAV.cs.lat,
                            MainV2.comPort.MAV.cs.lng, MainV2.comPort.MAV.cs.altasl, "here");
                    }

                    // update opengltest2
                    if (OpenGLtest2.instance != null)
                    {
                        OpenGLtest2.instance.rpy = new Vector3(MainV2.comPort.MAV.cs.roll, MainV2.comPort.MAV.cs.pitch,
                            MainV2.comPort.MAV.cs.yaw);
                        OpenGLtest2.instance.LocationCenter = new PointLatLngAlt(MainV2.comPort.MAV.cs.lat,
                            MainV2.comPort.MAV.cs.lng, MainV2.comPort.MAV.cs.altasl, "here");
                    }

                    // update vario info
                    Vario.SetValue(MainV2.comPort.MAV.cs.climbrate);
                    
                    // udpate tunning tab
                    if (tunning.AddMilliseconds(50) < DateTime.Now && CB_Dbug.Checked)
                    {
                        double time = (Environment.TickCount - tickStart) / 1000.0;
                        if (list1item != null)
                            list1.Add(time, ConvertToDouble(list1item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list2item != null)
                            list2.Add(time, ConvertToDouble(list2item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list3item != null)
                            list3.Add(time, ConvertToDouble(list3item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list4item != null)
                            list4.Add(time, ConvertToDouble(list4item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list5item != null)
                            list5.Add(time, ConvertToDouble(list5item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list6item != null)
                            list6.Add(time, ConvertToDouble(list6item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list7item != null)
                            list7.Add(time, ConvertToDouble(list7item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list8item != null)
                            list8.Add(time, ConvertToDouble(list8item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list9item != null)
                            list9.Add(time, ConvertToDouble(list9item.GetValue(MainV2.comPort.MAV.cs, null)));
                        if (list10item != null)
                            list10.Add(time, ConvertToDouble(list10item.GetValue(MainV2.comPort.MAV.cs, null)));
                    }

                    // update map
                    if (tracklast.AddSeconds(1.2) < DateTime.Now)
                    {
                        // show disable joystick button
                        if (MainV2.joystick != null && MainV2.joystick.enabled)
                        {
                            this.Invoke((MethodInvoker)delegate
                            {
                                //but_disablejoystick.Visible = true;
                            });
                        }

                        if (Settings.Instance.GetBoolean("CHK_maprotation"))
                        {
                            // dont holdinvalidation here
                            //setMapBearing();
                        }

                        //if (route == null)
                        //{
                        //    route = new GMapRoute(trackPoints, "track");
                        //    routes.Routes.Add(route);
                        //}

                        //PointLatLng currentloc = new PointLatLng(MainV2.comPort.MAV.cs.lat, MainV2.comPort.MAV.cs.lng);

                        //gMapControl1.HoldInvalidation = true;

                        int numTrackLength = Settings.Instance.GetInt32("NUM_tracklength");
                        // maintain route history length
                        //if (route.Points.Count > numTrackLength)
                        //{
                        //    route.Points.RemoveRange(0,
                        //        route.Points.Count - numTrackLength);
                        //}
                        // add new route point
                        //if (MainV2.comPort.MAV.cs.lat != 0 && MainV2.comPort.MAV.cs.lng != 0)
                        //{
                        //    route.Points.Add(currentloc);
                        //}

                        if (!this.IsHandleCreated)
                            continue;

                        //updateRoutePosition();

                        // update programed wp course
                        if (waypoints.AddSeconds(5) < DateTime.Now)
                        {
                            //Console.WriteLine("Doing FD WP's");
                            //updateClearMissionRouteMarkers();

                            //float dist = 0;
                            //float travdist = 0;
                            //distanceBar1.ClearWPDist();
                            //MAVLink.mavlink_mission_item_t lastplla = new MAVLink.mavlink_mission_item_t();
                            //MAVLink.mavlink_mission_item_t home = new MAVLink.mavlink_mission_item_t();

                            //foreach (MAVLink.mavlink_mission_item_t plla in MainV2.comPort.MAV.wps.Values)
                            //{
                            //    if (plla.x == 0 || plla.y == 0)
                            //        continue;

                            //    if (plla.command == (ushort)MAVLink.MAV_CMD.DO_SET_ROI)
                            //    {
                            //        addpolygonmarkerred(plla.seq.ToString(), plla.y, plla.x, (int)plla.z, Color.Red,
                            //            routes);
                            //        continue;
                            //    }

                            //    string tag = plla.seq.ToString();
                            //    if (plla.seq == 0 && plla.current != 2)
                            //    {
                            //        tag = "Home";
                            //        home = plla;
                            //    }
                            //    if (plla.current == 2)
                            //    {
                            //        continue;
                            //    }

                            //    if (lastplla.command == 0)
                            //        lastplla = plla;

                            //    try
                            //    {
                            //        dist =
                            //            (float)
                            //                new PointLatLngAlt(plla.x, plla.y).GetDistance(new PointLatLngAlt(
                            //                    lastplla.x, lastplla.y));

                            //        distanceBar1.AddWPDist(dist);

                            //        if (plla.seq <= MainV2.comPort.MAV.cs.wpno)
                            //        {
                            //            travdist += dist;
                            //        }

                            //        lastplla = plla;
                            //    }
                            //    catch
                            //    {
                            //    }

                            //    addpolygonmarker(tag, plla.y, plla.x, (int)plla.z, Color.White, polygons);
                            //}

                            try
                            {
                                //dist = (float)new PointLatLngAlt(home.x, home.y).GetDistance(new PointLatLngAlt(lastplla.x, lastplla.y));
                                // distanceBar1.AddWPDist(dist);
                            }
                            catch
                            {
                            }

                            //travdist -= MainV2.comPort.MAV.cs.wp_dist;

                            //if (MainV2.comPort.MAV.cs.mode.ToUpper() == "AUTO")
                            //    distanceBar1.traveleddist = travdist;

                            //RegeneratePolygon();

                            //// update rally points

                            //rallypointoverlay.Markers.Clear();

                            //foreach (var mark in MainV2.comPort.MAV.rallypoints.Values)
                            //{
                            //    rallypointoverlay.Markers.Add(new GMapMarkerRallyPt(mark));
                            //}

                            // optional on Flight data
                            if (MainV2.ShowAirports)
                            {
                                // airports
                                //    foreach (var item in Airports.getAirports(gMapControl1.Position).ToArray())
                                //    {
                                //        try
                                //        {
                                //            rallypointoverlay.Markers.Add(new GMapMarkerAirport(item)
                                //            {
                                //                ToolTipText = item.Tag,
                                //                ToolTipMode = MarkerTooltipMode.OnMouseOver
                                //            });
                                //        }
                                //        catch (Exception e)
                                //        {
                                //            log.Error(e);
                                //        }
                                //    }
                                //}
                                //waypoints = DateTime.Now;
                            }

                            // updateClearRoutesMarkers();

                            // add this after the mav icons are drawn
                            if (MainV2.comPort.MAV.cs.MovingBase != null)
                            {
                                //addMissionRouteMarker(new GMarkerGoogle(currentloc, GMarkerGoogleType.blue_dot)
                                //{
                                //    Position = MainV2.comPort.MAV.cs.MovingBase,
                                //    ToolTipText = "Moving Base",
                                //    ToolTipMode = MarkerTooltipMode.OnMouseOver
                                //});
                            }

                            // add gimbal point center
                            try
                            {
                                if (MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_TILT")
                                    && MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_ROLL")
                                    && MainV2.comPort.MAV.param.ContainsKey("MNT_TYPE"))
                                {
                                    float temp1 = (float)MainV2.comPort.MAV.param["MNT_STAB_TILT"];
                                    float temp2 = (float)MainV2.comPort.MAV.param["MNT_STAB_ROLL"];

                                    float temp3 = (float)MainV2.comPort.MAV.param["MNT_TYPE"];

                                    if (MainV2.comPort.MAV.param.ContainsKey("MNT_STAB_PAN") &&
                                        // (float)MainV2.comPort.MAV.param["MNT_STAB_PAN"] == 1 &&
                                        ((float)MainV2.comPort.MAV.param["MNT_STAB_TILT"] == 1 &&
                                          (float)MainV2.comPort.MAV.param["MNT_STAB_ROLL"] == 0) ||
                                         (float)MainV2.comPort.MAV.param["MNT_TYPE"] == 4) // storm driver
                                    {
                                        var marker = GimbalPoint.ProjectPoint();

                                        if (marker != PointLatLngAlt.Zero)
                                        {
                                            MainV2.comPort.MAV.cs.GimbalPoint = marker;

                                            //addMissionRouteMarker(new GMarkerGoogle(marker, GMarkerGoogleType.blue_dot)
                                            //{
                                            //    ToolTipText = "Camera Target\n" + marker,
                                            //    ToolTipMode = MarkerTooltipMode.OnMouseOver
                                            //});
                                        }
                                    }
                                }


                                // cleanup old - no markers where added, so remove all old 
                                if (MainV2.comPort.MAV.camerapoints.Count == 0)
                                    //photosoverlay.Markers.Clear();

                                    //var min_interval = 0.0;
                                    //if (MainV2.comPort.MAV.param.ContainsKey("CAM_MIN_INTERVAL"))
                                    //    min_interval = MainV2.comPort.MAV.param["CAM_MIN_INTERVAL"].Value / 1000.0;

                                    // set fov's based on last grid calc
                                    if (Settings.Instance["camera_fovh"] != null)
                                    {
                                        GMapMarkerPhoto.hfov = Settings.Instance.GetDouble("camera_fovh");
                                        GMapMarkerPhoto.vfov = Settings.Instance.GetDouble("camera_fovv");
                                    }

                                // add new - populate camera_feedback to map
                                double oldtime = double.MinValue;
                                foreach (var mark in MainV2.comPort.MAV.camerapoints.ToArray())
                                {
                                    var timesincelastshot = (mark.time_usec / 1000.0) / 1000.0 - oldtime;
                                    MainV2.comPort.MAV.cs.timesincelastshot = timesincelastshot;
                                    //bool contains = photosoverlay.Markers.Any(p => p.Tag.Equals(mark.time_usec));
                                    //if (!contains)
                                    //{
                                    //    if (timesincelastshot < min_interval)
                                    //        addMissionPhotoMarker(new GMapMarkerPhoto(mark, true));
                                    //    else
                                    //        addMissionPhotoMarker(new GMapMarkerPhoto(mark, false));
                                    //}
                                    oldtime = (mark.time_usec / 1000.0) / 1000.0;
                                }

                                // age current
                                int camcount = MainV2.comPort.MAV.camerapoints.Count;
                                int a = 0;
                                //foreach (var mark in photosoverlay.Markers)
                                //{
                                //    if (mark is GMapMarkerPhoto)
                                //    {
                                //        if (CameraOverlap)
                                //        {
                                //            var marker = ((GMapMarkerPhoto)mark);
                                //            // abandon roll higher than 25 degrees
                                //            if (Math.Abs(marker.Roll) < 25)
                                //            {
                                //                MainV2.comPort.MAV.GMapMarkerOverlapCount.Add(
                                //                    ((GMapMarkerPhoto)mark).footprintpoly);
                                //            }
                                //        }
                                //        if (a < (camcount - 4))
                                //            ((GMapMarkerPhoto)mark).drawfootprint = false;
                                //    }
                                //    a++;
                                //}

                                //if (CameraOverlap)
                                //{
                                //    if (!kmlpolygons.Markers.Contains(MainV2.comPort.MAV.GMapMarkerOverlapCount) &&
                                //        camcount > 0)
                                //    {
                                //        kmlpolygons.Markers.Clear();
                                //        kmlpolygons.Markers.Add(MainV2.comPort.MAV.GMapMarkerOverlapCount);
                                //    }
                                //}
                                //else if (kmlpolygons.Markers.Contains(MainV2.comPort.MAV.GMapMarkerOverlapCount))
                                //{
                                //    kmlpolygons.Markers.Clear();
                                //}
                            }
                            catch
                            {
                            }

                            lock (MainV2.instance.adsblock)
                            {
                                foreach (adsb.PointLatLngAltHdg plla in MainV2.instance.adsbPlanes.Values)
                                {
                                    // 30 seconds history
                                    if (((DateTime)plla.Time) > DateTime.Now.AddSeconds(-30))
                                    {
                                        var adsbplane = new GMapMarkerADSBPlane(plla, plla.Heading)
                                        {
                                            ToolTipText = "ICAO: " + plla.Tag + " " + plla.Alt.ToString("0"),
                                            //ToolTipMode = MarkerTooltipMode.OnMouseOver,
                                            Tag = plla
                                        };

                                        if (plla.DisplayICAO)
                                            //adsbplane.ToolTipMode = MarkerTooltipMode.Always;

                                            switch (plla.ThreatLevel)
                                            {
                                                case MAVLink.MAV_COLLISION_THREAT_LEVEL.NONE:
                                                    adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Green;
                                                    break;
                                                case MAVLink.MAV_COLLISION_THREAT_LEVEL.LOW:
                                                    adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Orange;
                                                    break;
                                                case MAVLink.MAV_COLLISION_THREAT_LEVEL.HIGH:
                                                    adsbplane.AlertLevel = GMapMarkerADSBPlane.AlertLevelOptions.Red;
                                                    break;
                                            }

                                        ///addMissionRouteMarker(adsbplane);
                                    }
                                }
                            }


                            //if (route.Points.Count > 0)
                            //{
                            //    // add primary route icon

                            //    // draw guide mode point for only main mav
                            //    if (MainV2.comPort.MAV.cs.mode.ToLower() == "guided" && MainV2.comPort.MAV.GuidedMode.x != 0)
                            //    {
                            //        addpolygonmarker("Guided Mode", MainV2.comPort.MAV.GuidedMode.y,
                            //            MainV2.comPort.MAV.GuidedMode.x, (int)MainV2.comPort.MAV.GuidedMode.z, Color.Blue,
                            //            routes);
                            //    }

                            //    // draw all icons for all connected mavs
                            //    foreach (var port in MainV2.Comports)
                            //    {
                            //        // draw the mavs seen on this port
                            //        foreach (var MAV in port.MAVlist)
                            //        {
                            //            var marker = Common.getMAVMarker(MAV);

                            //            if (marker.Position.Lat == 0 && marker.Position.Lng == 0)
                            //                continue;

                            //            addMissionRouteMarker(marker);
                            //        }
                            //    }

                            //if (route.Points.Count == 0 || route.Points[route.Points.Count - 1].Lat != 0 &&
                            //    (mapupdate.AddSeconds(3) < DateTime.Now) && CHK_autopan.Checked)
                            //{
                            //    updateMapPosition(currentloc);
                            //    mapupdate = DateTime.Now;
                            //}

                            //if (route.Points.Count == 1 && gMapControl1.Zoom == 3) // 3 is the default load zoom
                            //{
                            //    updateMapPosition(currentloc);
                            //    updateMapZoom(17);
                            //}
                        }

                        //gMapControl1.HoldInvalidation = false;

                        //if (gMapControl1.Visible)
                        //{
                        //    gMapControl1.Invalidate();
                        //}

                        tracklast = DateTime.Now;
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    Tracking.AddException(ex);
                    Console.WriteLine("FD Main loop exception " + ex);
                }
            }
            Console.WriteLine("FD Main loop exit");
        }


        object updateBindingSourcelock = new object();
        volatile int updateBindingSourcecount;
        string updateBindingSourceThreadName = "";
        DateTime lastscreenupdate = DateTime.Now;
        private void updateBindingSource()
        {
            //  run at 25 hz.
            if (lastscreenupdate.AddMilliseconds(40) < DateTime.Now)
            {
                // this is an attempt to prevent an invoke queue on the binding update on slow machines
                if (updateBindingSourcecount > 0)
                    return;

                lock (updateBindingSourcelock)
                {
                    updateBindingSourcecount++;
                    updateBindingSourceThreadName = Thread.CurrentThread.Name;
                }

                this.BeginInvokeIfRequired((MethodInvoker)delegate
                {
                    updateBindingSourceWork();

                    lock (updateBindingSourcelock)
                    {
                        updateBindingSourcecount--;
                    }
                });
            }
        }
        private void updateBindingSourceWork()
        {

            //Console.WriteLine("Null Binding");
            // MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource_hub);

            //lastscreenupdate = DateTime.Now;
            try
            {
                if (this.Visible)
                {
                    //Console.Write("bindingSource1 ");
                    //MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource1);
                    //Console.Write("bindingSourceHud ");
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource_hub);
                    //Console.WriteLine("DONE ");

                    //if (tabControlactions.SelectedTab == tabQuick)
                    //{
                    //    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceQTab);
                    //}
                    //else if (tabControlactions.SelectedTab == tabQuick)
                    //{
                    //    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceQuickTab);
                    //}
                    //else if (tabControlactions.SelectedTab == tabGauges)
                    //{
                    //    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    //}
                    //else if (tabControlactions.SelectedTab == tabPagePreFlight)
                    //{
                    //    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSourceGaugesTab);
                    //}
                }
                else
                {
                    //Console.WriteLine("Null Binding");
                    MainV2.comPort.MAV.cs.UpdateCurrentSettings(bindingSource_hub);
                }
                lastscreenupdate = DateTime.Now;
            }
            catch
            {
            }
        }
        private Dictionary<string, string> ProcessCommandLine(string[] args)
        {
            Dictionary<string, string> cmdargs = new Dictionary<string, string>();
            string cmd = "";
            foreach (var s in args)
            {
                if (s.StartsWith("-") || s.StartsWith("/") || s.StartsWith("--"))
                {
                    cmd = s.TrimStart(new char[] { '-', '/', '-' }).TrimStart(new char[] { '-', '/', '-' });
                    continue;
                }
                if (cmd != "")
                {
                    cmdargs[cmd] = s;
                    log.Info("ProcessCommandLine: " + cmd + " = " + s);
                    cmd = "";
                    continue;
                }
                if (File.Exists(s))
                {
                    // we are not a command, and the file exists.
                    cmdargs["file"] = s;
                    log.Info("ProcessCommandLine: " + "file" + " = " + s);
                    continue;
                }

                log.Info("ProcessCommandLine: UnKnown = " + s);
            }

            return cmdargs;
        }

        private void BGFirmwareCheck(object state)
        {
            try
            {
                if (Settings.Instance["fw_check"] != DateTime.Now.ToShortDateString())
                {
                    var fw = new Firmware();
                    var list = fw.getFWList();
                    if (list.Count > 1)
                        Firmware.SaveSoftwares(list);

                    Settings.Instance["fw_check"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGGetKIndex(object state)
        {
            try
            {
                // check the last kindex date
                if (Settings.Instance["kindexdate"] == DateTime.Now.ToShortDateString())
                {
                    KIndex_KIndex(Settings.Instance.GetInt32("kindex"), null);
                }
                else
                {
                    // get a new kindex
                    KIndex.KIndexEvent += KIndex_KIndex;
                    KIndex.GetKIndex();

                    Settings.Instance["kindexdate"] = DateTime.Now.ToShortDateString();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGgetTFR(object state)
        {
            try
            {
                tfr.tfrcache = Settings.GetUserDataDirectory() + "tfr.xml";
                tfr.GetTFRs();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void BGNoFly(object state)
        {
            try
            {
                NoFly.NoFly.Scan();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }


        void KIndex_KIndex(object sender, EventArgs e)
        {
            CurrentState.KIndexstatic = (int)sender;
            Settings.Instance["kindex"] = CurrentState.KIndexstatic.ToString();
        }

        private void BGCreateMaps(object state)
        {
            // sort logs
            try
            {
                MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog"));

                MissionPlanner.Log.LogSort.SortLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.rlog"));
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                // create maps
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.tlog", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.bin", SearchOption.AllDirectories));
                Log.LogMap.MapLogs(Directory.GetFiles(Settings.Instance.LogDir, "*.log", SearchOption.AllDirectories));

                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }

            try
            {
                if (File.Exists(tlogThumbnailHandler.tlogThumbnailHandler.queuefile))
                {
                    Log.LogMap.MapLogs(File.ReadAllLines(tlogThumbnailHandler.tlogThumbnailHandler.queuefile));

                    File.Delete(tlogThumbnailHandler.tlogThumbnailHandler.queuefile);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void checkupdate(object stuff)
        {
            if (Program.WindowsStoreApp)
                return;

            try
            {
                MissionPlanner.Utilities.Update.CheckForUpdate();
            }
            catch (Exception ex)
            {
                log.Error("Update check failed", ex);
            }
        }

        private void MainV2_Resize(object sender, EventArgs e)
        {
            // mono - resize is called before the control is created
            if (MyView != null)
                log.Info("myview width " + MyView.Width + " height " + MyView.Height);

            log.Info("this   width " + this.Width + " height " + this.Height);
        }

        private void MenuHelp_Click(object sender, EventArgs e)
        {
            MyView.ShowScreen("Help");
        }


        /// <summary>
        /// keyboard shortcuts override
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                MenuConnect_Click(null, null);
                return true;
            }

            if (keyData == Keys.F2)
            {
                MenuFlightData_Click(null, null);
                return true;
            }
            if (keyData == Keys.F3)
            {
                MenuFlightPlanner_Click(null, null);
                return true;
            }
            if (keyData == Keys.F4)
            {
                MenuTuning_Click(null, null);
                return true;
            }

            if (keyData == Keys.F5)
            {
                comPort.getParamList();
                MyView.ShowScreen(MyView.current.Name);
                return true;
            }

            if (keyData == (Keys.Control | Keys.F)) // temp
            {
                Form frm = new temp();
                //ThemeManager.ApplyThemeTo(frm);
                frm.Show();
                return true;
            }
            /*if (keyData == (Keys.Control | Keys.S)) // screenshot
            {
                ScreenShot();
                return true;
            }*/
            if (keyData == (Keys.Control | Keys.G)) // nmea out
            {
                Form frm = new SerialOutputNMEA();
                //ThemeManager.ApplyThemeTo(frm);
                frm.Show();
                return true;
            }
            if (keyData == (Keys.Control | Keys.X))
            {

            }
            if (keyData == (Keys.Control | Keys.L)) // limits
            {
                return true;
            }
            if (keyData == (Keys.Control | Keys.W)) // test ac config
            {
                return true;
            }
            if (keyData == (Keys.Control | Keys.Z))
            {
                MissionPlanner.GenOTP otp = new MissionPlanner.GenOTP();

                otp.ShowDialog(this);

                return true;
            }
            if (keyData == (Keys.Control | Keys.T)) // for override connect
            {
                try
                {
                    MainV2.comPort.Open(false);
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show(ex.ToString());
                }
                return true;
            }
            if (keyData == (Keys.Control | Keys.Y)) // for ryan beall and ollyw42
            {
                // write
                try
                {
                    MainV2.comPort.doCommand(MAVLink.MAV_CMD.PREFLIGHT_STORAGE, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                }
                catch
                {
                    CustomMessageBox.Show("Invalid command");
                    return true;
                }
                //read
                ///////MainV2.comPort.doCommand(MAVLink09.MAV_CMD.PREFLIGHT_STORAGE, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f);
                CustomMessageBox.Show("Done MAV_ACTION_STORAGE_WRITE");
                return true;
            }
            if (keyData == (Keys.Control | Keys.J))
            {
                /*
                var test = MainV2.comPort.GetLogList();

                foreach (var item in test)
                {
                    var ms = comPort.GetLog(item.id);

                    using (BinaryWriter bw = new BinaryWriter(File.OpenWrite("test" + item.id + ".bin")))
                    {
                        bw.Write(ms.ToArray());
                    }

                    var temp1 = Log.BinaryLog.ReadLog("test" + item.id + ".bin");

                    File.WriteAllLines("test" + item.id + ".log", temp1);
                }*/
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        public void changelanguage(CultureInfo ci)
        {
            log.Info("change lang to " + ci.ToString() + " current " + Thread.CurrentThread.CurrentUICulture.ToString());

            if (ci != null && !Thread.CurrentThread.CurrentUICulture.Equals(ci))
            {
                Thread.CurrentThread.CurrentUICulture = ci;
                Settings.Instance["language"] = ci.Name;
                //System.Threading.Thread.CurrentThread.CurrentCulture = ci;

                HashSet<Control> views = new HashSet<Control> { this, FlightData, FlightPlanner, Simulation };

                foreach (Control view in MyView.Controls)
                    views.Add(view);

                foreach (Control view in views)
                {
                    if (view != null)
                    {
                        ComponentResourceManager rm = new ComponentResourceManager(view.GetType());
                        foreach (Control ctrl in view.Controls)
                        {
                            rm.ApplyResource(ctrl);
                        }
                        rm.ApplyResources(view, "$this");
                    }
                }
            }
        }


        public void ChangeUnits()
        {
            try
            {
                // dist
                if (Settings.Instance["distunits"] != null)
                {
                    switch (
                        (Common.distances)Enum.Parse(typeof(Common.distances), Settings.Instance["distunits"].ToString()))
                    {
                        case Common.distances.Meters:
                            CurrentState.multiplierdist = 1;
                            CurrentState.DistanceUnit = "m";
                            break;
                        case Common.distances.Feet:
                            CurrentState.multiplierdist = 3.2808399f;
                            CurrentState.DistanceUnit = "ft";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierdist = 1;
                    CurrentState.DistanceUnit = "m";
                }

                // speed
                if (Settings.Instance["speedunits"] != null)
                {
                    switch ((Common.speeds)Enum.Parse(typeof(Common.speeds), Settings.Instance["speedunits"].ToString()))
                    {
                        case Common.speeds.meters_per_second:
                            CurrentState.multiplierspeed = 1;
                            CurrentState.SpeedUnit = "m/s";
                            break;
                        case Common.speeds.fps:
                            CurrentState.multiplierdist = 3.2808399f;
                            CurrentState.SpeedUnit = "fps";
                            break;
                        case Common.speeds.kph:
                            CurrentState.multiplierspeed = 3.6f;
                            CurrentState.SpeedUnit = "kph";
                            break;
                        case Common.speeds.mph:
                            CurrentState.multiplierspeed = 2.23693629f;
                            CurrentState.SpeedUnit = "mph";
                            break;
                        case Common.speeds.knots:
                            CurrentState.multiplierspeed = 1.94384449f;
                            CurrentState.SpeedUnit = "knots";
                            break;
                    }
                }
                else
                {
                    CurrentState.multiplierspeed = 1;
                    CurrentState.SpeedUnit = "m/s";
                }
            }
            catch
            {
            }
        }

        private void CMB_baudrate_TextChanged(object sender, EventArgs e)
        {
            var sb = new StringBuilder();
            int baud = 0;
            for (int i = 0; i < _connectionControl.CMB_baudrate.Text.Length; i++)
                if (char.IsDigit(_connectionControl.CMB_baudrate.Text[i]))
                {
                    sb.Append(_connectionControl.CMB_baudrate.Text[i]);
                    baud = baud * 10 + _connectionControl.CMB_baudrate.Text[i] - '0';
                }
            if (_connectionControl.CMB_baudrate.Text != sb.ToString())
            {
                _connectionControl.CMB_baudrate.Text = sb.ToString();
            }
            try
            {
                if (baud > 0 && comPort.BaseStream.BaudRate != baud)
                    comPort.BaseStream.BaudRate = baud;
            }
            catch (Exception)
            {
            }
        }

        private void MainMenu_MouseLeave(object sender, EventArgs e)
        {
            //if (_connectionControl.PointToClient(Control.MousePosition).Y < MainMenu.Height)
            //    return;

            //this.SuspendLayout();

            //panel1.Visible = false;

            this.ResumeLayout();
        }

        void menu_MouseEnter(object sender, EventArgs e)
        {
            this.SuspendLayout();
            //panel1.Location = new Point(0, 0);
            //panel1.Width = menu.Width;
            //panel1.BringToFront();
            //panel1.Visible = true;
            this.ResumeLayout();
        }

        private void autoHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoHideMenu(autoHideToolStripMenuItem.Checked);

            Settings.Instance["menu_autohide"] = autoHideToolStripMenuItem.Checked.ToString();
        }

        void AutoHideMenu(bool hide)
        {
            autoHideToolStripMenuItem.Checked = hide;

            //if (!hide)
            //{
            //    this.SuspendLayout();
            //    panel1.Dock = DockStyle.Top;
            //    panel1.SendToBack();
            //    panel1.Visible = true;
            //    menu.Visible = false;
            //    MainMenu.MouseLeave -= MainMenu_MouseLeave;
            //    panel1.MouseLeave -= MainMenu_MouseLeave;
            //    toolStripConnectionControl.MouseLeave -= MainMenu_MouseLeave;
            //    this.ResumeLayout(false);
            //}
            //else
            //{
            //    this.SuspendLayout();
            //    panel1.Dock = DockStyle.None;
            //    panel1.Visible = false;
            //    MainMenu.MouseLeave += MainMenu_MouseLeave;
            //    panel1.MouseLeave += MainMenu_MouseLeave;
            //    toolStripConnectionControl.MouseLeave += MainMenu_MouseLeave;
            //    menu.Visible = true;
            //    menu.SendToBack();
            //    this.ResumeLayout(false);
            //}
        }

        private void MainV2_KeyDown(object sender, KeyEventArgs e)
        {
            Message temp = new Message();
            ProcessCmdKey(ref temp, e.KeyData);
            Console.WriteLine("MainV2_KeyDown " + e.ToString());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(
                    "https://www.paypal.com/cgi-bin/webscr?cmd=_donations&business=mich146%40hotmail%2ecom&lc=AU&item_name=Michael%20Oborne&no_note=0&bn=PP%2dDonationsBF%3abtn_donate_SM%2egif%3aNonHostedGuest");
            }
            catch
            {
                CustomMessageBox.Show("Link open failed. check your default webpage association");
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class DEV_BROADCAST_HDR
        {
            internal Int32 dbch_size;
            internal Int32 dbch_devicetype;
            internal Int32 dbch_reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_PORT
        {
            public int dbcp_size;
            public int dbcp_devicetype;
            public int dbcp_reserved; // MSDN say "do not use"
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            public byte[] dbcp_name;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal class DEV_BROADCAST_DEVICEINTERFACE
        {
            public Int32 dbcc_size;
            public Int32 dbcc_devicetype;
            public Int32 dbcc_reserved;

            [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U1, SizeConst = 16)]
            internal Byte[]
                dbcc_classguid;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255)]
            internal Byte[] dbcc_name;
        }


        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_CREATE:
                    try
                    {
                        DEV_BROADCAST_DEVICEINTERFACE devBroadcastDeviceInterface = new DEV_BROADCAST_DEVICEINTERFACE();
                        IntPtr devBroadcastDeviceInterfaceBuffer;
                        IntPtr deviceNotificationHandle = IntPtr.Zero;
                        Int32 size = 0;

                        // frmMy is the form that will receive device-change messages.


                        size = Marshal.SizeOf(devBroadcastDeviceInterface);
                        devBroadcastDeviceInterface.dbcc_size = size;
                        devBroadcastDeviceInterface.dbcc_devicetype = DBT_DEVTYP_DEVICEINTERFACE;
                        devBroadcastDeviceInterface.dbcc_reserved = 0;
                        devBroadcastDeviceInterface.dbcc_classguid = GUID_DEVINTERFACE_USB_DEVICE.ToByteArray();
                        devBroadcastDeviceInterfaceBuffer = Marshal.AllocHGlobal(size);
                        Marshal.StructureToPtr(devBroadcastDeviceInterface, devBroadcastDeviceInterfaceBuffer, true);


                        deviceNotificationHandle = NativeMethods.RegisterDeviceNotification(this.Handle,
                            devBroadcastDeviceInterfaceBuffer, DEVICE_NOTIFY_WINDOW_HANDLE);
                    }
                    catch
                    {
                    }

                    break;

                case WM_DEVICECHANGE:
                    // The WParam value identifies what is occurring.
                    WM_DEVICECHANGE_enum n = (WM_DEVICECHANGE_enum)m.WParam;
                    var l = m.LParam;
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVEPENDING)
                    {
                        Console.WriteLine("DBT_DEVICEREMOVEPENDING");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVNODES_CHANGED)
                    {
                        Console.WriteLine("DBT_DEVNODES_CHANGED");
                    }
                    if (n == WM_DEVICECHANGE_enum.DBT_DEVICEARRIVAL ||
                        n == WM_DEVICECHANGE_enum.DBT_DEVICEREMOVECOMPLETE)
                    {
                        Console.WriteLine(((WM_DEVICECHANGE_enum)n).ToString());

                        DEV_BROADCAST_HDR hdr = new DEV_BROADCAST_HDR();
                        Marshal.PtrToStructure(m.LParam, hdr);

                        try
                        {
                            switch (hdr.dbch_devicetype)
                            {
                                case DBT_DEVTYP_DEVICEINTERFACE:
                                    DEV_BROADCAST_DEVICEINTERFACE inter = new DEV_BROADCAST_DEVICEINTERFACE();
                                    Marshal.PtrToStructure(m.LParam, inter);
                                    log.InfoFormat("Interface {0}",
                                        ASCIIEncoding.Unicode.GetString(inter.dbcc_name, 0, inter.dbcc_size - (4 * 3)));
                                    break;
                                case DBT_DEVTYP_PORT:
                                    DEV_BROADCAST_PORT prt = new DEV_BROADCAST_PORT();
                                    Marshal.PtrToStructure(m.LParam, prt);
                                    log.InfoFormat("port {0}",
                                        ASCIIEncoding.Unicode.GetString(prt.dbcp_name, 0, prt.dbcp_size - (4 * 3)));
                                    break;
                            }
                        }
                        catch
                        {
                        }

                        //string port = Marshal.PtrToStringAuto((IntPtr)((long)m.LParam + 12));
                        //Console.WriteLine("Added port {0}",port);
                    }
                    log.InfoFormat("Device Change {0} {1} {2}", m.Msg, (WM_DEVICECHANGE_enum)m.WParam, m.LParam);

                    if (DeviceChanged != null)
                    {
                        try
                        {
                            DeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                        }
                        catch
                        {
                        }
                    }

                    foreach (var item in MissionPlanner.Plugin.PluginLoader.Plugins)
                    {
                        item.Host.ProcessDeviceChanged((WM_DEVICECHANGE_enum)m.WParam);
                    }

                    break;
                case 0x86: // WM_NCACTIVATE
                    //var thing = Control.FromHandle(m.HWnd);

                    var child = Control.FromHandle(m.LParam);

                    if (child is Form)
                    {
                        log.Debug("ApplyThemeTo " + child.Name);
                        //ThemeManager.ApplyThemeTo(child);
                    }
                    break;
                default:
                    //Console.WriteLine(m.ToString());
                    break;
            }
            base.WndProc(ref m);
        }

        const int DBT_DEVTYP_PORT = 0x00000003;
        const int WM_CREATE = 0x0001;
        const Int32 DBT_DEVTYP_HANDLE = 6;
        const Int32 DBT_DEVTYP_DEVICEINTERFACE = 5;
        const Int32 DEVICE_NOTIFY_WINDOW_HANDLE = 0;
        const Int32 DIGCF_PRESENT = 2;
        const Int32 DIGCF_DEVICEINTERFACE = 0X10;
        const Int32 WM_DEVICECHANGE = 0X219;
        public static Guid GUID_DEVINTERFACE_USB_DEVICE = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");


        public enum WM_DEVICECHANGE_enum
        {
            DBT_CONFIGCHANGECANCELED = 0x19,
            DBT_CONFIGCHANGED = 0x18,
            DBT_CUSTOMEVENT = 0x8006,
            DBT_DEVICEARRIVAL = 0x8000,
            DBT_DEVICEQUERYREMOVE = 0x8001,
            DBT_DEVICEQUERYREMOVEFAILED = 0x8002,
            DBT_DEVICEREMOVECOMPLETE = 0x8004,
            DBT_DEVICEREMOVEPENDING = 0x8003,
            DBT_DEVICETYPESPECIFIC = 0x8005,
            DBT_DEVNODES_CHANGED = 0x7,
            DBT_QUERYCHANGECONFIG = 0x17,
            DBT_USERDEFINED = 0xFFFF,
        }

        //private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        //{
        //    foreach (ToolStripItem item in MainMenu.Items)
        //    {
        //        if (e.ClickedItem == item)
        //        {
        //            item.BackColor = ThemeManager.ControlBGColor;
        //        }
        //        else
        //        {
        //            item.BackColor = Color.Transparent;
        //            item.BackgroundImage = displayicons.bg; //.BackColor = Color.Black;
        //        }
        //    }
        //    //MainMenu.BackColor = Color.Black;
        //    //MainMenu.BackgroundImage = MissionPlanner.Properties.Resources.bgdark;
        //}

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // full screen
            if (fullScreenToolStripMenuItem.Checked)
            {
                this.TopMost = true;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.TopMost = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void readonlyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainV2.comPort.ReadOnly = readonlyToolStripMenuItem.Checked;
        }

        private void connectionOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ConnectionOptions().Show(this);
        }

        private void toolStrip1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset.X = e.X;
                mouseOffset.Y = e.Y;
                isMouseDown = true;
            }
        }

        private void toolStrip1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isMouseDown = false;
            }
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            //if (isMouseDown)
            //{
            //    int left = panel2.Left + e.X - mouseOffset.X;
            //    int top = panel2.Top + e.Y - mouseOffset.Y;
            //    panel2.Location = new Point(left, top);
            //}

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //MyView.ShowScreen("FlightData");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
           // MyView.ShowScreen("FlightPlanner");
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //if (Settings.Instance.GetBoolean("password_protect") == false)
            //{
            //    MyView.ShowScreen("HWConfig");
            //}
            //else
            //{
            //    if (Password.VerifyPassword())
            //    {
            //        MyView.ShowScreen("HWConfig");
            //    }
            //}
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (Settings.Instance.GetBoolean("password_protect") == false)
            //{
            //    MyView.ShowScreen("SWConfig");
            //}
            //else
            //{
            //    if (Password.VerifyPassword())
            //    {
            //        MyView.ShowScreen("SWConfig");
            //    }
            //}
        }

        private void MainV2_Load(object sender, EventArgs e)
        {
            hud1.doResize();

            thisthread1 = new Thread(mainloop);
            thisthread1.Name = "F Mainloop";
            thisthread1.IsBackground = true;
            thisthread1.Start();
        }

        private void hud1_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("HUD resize " + hud1.Width + " " + hud1.Height); // +"\n"+ System.Environment.StackTrace);

            if (hud1.Parent == this.panel2)
                panel2.Height = hud1.Height;
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            //splitContainer4.Panel2.Controls.Clear();
            
           
           // w1.Show();
           // MyView.ShowScreen("FlightPlanner");
        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            splitContainer4.Panel2.Controls.Clear();
            GCSViews.InitialSetup w1 = new GCSViews.InitialSetup();
            w1.Parent = splitContainer4.Panel2;
            w1.Dock = DockStyle.Fill;
            w1.Show();
        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
            splitContainer4.Panel2.Controls.Clear();

            GCSViews.ConfigurationView.Calibra w1 = new GCSViews.ConfigurationView.Calibra();
            w1.Parent = splitContainer4.Panel2;
            w1.Dock = DockStyle.Fill;
            
            //w1.Activate();
            //ThemeManager.ApplyThemeTo(this);
            w1.Show();
            

        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            splitContainer4.Panel2.Controls.Clear();
            GCSViews.InitialSetup w1 = new GCSViews.InitialSetup();
            w1.Parent = splitContainer4.Panel2;
            
            w1.Dock = DockStyle.Fill;
            w1.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            splitContainer4.Panel2.Controls.Clear();


            GCSViews.ConfigurationView.ConfigRadioInput w2 = new GCSViews.ConfigurationView.ConfigRadioInput();
            GCSViews.ConfigurationView.ConfigFlightModes w1 = new GCSViews.ConfigurationView.ConfigFlightModes();
            w2.Deactivate();
            w1.Activate();
            w1.Parent = splitContainer4.Panel2;
            w1.Dock = DockStyle.Fill;
            //ThemeManager.ApplyThemeTo(this);
            w1.Show();
        }

          void tabFilghtStatus_Resize(object sender, EventArgs e)
        {
            // localise it
            //Control tabStatus = sender as Control;

            //  tabStatus.SuspendLayout();

            //foreach (Control temp in tabStatus.Controls)
            {
                //  temp.DataBindings.Clear();
                //temp.Dispose();
            }
            //tabStatus.Controls.Clear();

            int x = 10;
            int y = 10;

            object thisBoxed = MainV2.comPort.MAV.cs;
            Type test = thisBoxed.GetType();

            PropertyInfo[] props = test.GetProperties();

            //props

            foreach (var field in props)
            {
                // field.Name has the field's name.
                object fieldValue;
                TypeCode typeCode;
                try
                {
                    fieldValue = field.GetValue(thisBoxed, null); // Get value

                    if (fieldValue == null)
                        continue;
                    // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                    typeCode = Type.GetTypeCode(fieldValue.GetType());
                }
                catch
                {
                    continue;
                }

                MyLabel lbl1 = null;
                MyLabel lbl2 = null;
                try
                {
                    var temp = tabPageStatustext.Controls.Find(field.Name, false);

                    if (temp.Length > 0)
                        lbl1 = (MyLabel) temp[0];

                    var temp2 = tabPageStatustext.Controls.Find(field.Name + "value", false);

                    if (temp2.Length > 0)
                        lbl2 = (MyLabel) temp2[0];
                }
                catch
                {
                }


                if (lbl1 == null)
                    lbl1 = new MyLabel();

                lbl1.Location = new Point(x, y);
                lbl1.Size = new Size(90, 13);
                lbl1.Text = field.Name;
                lbl1.Name = field.Name;
                lbl1.Visible = true;

                if (lbl2 == null)
                    lbl2 = new MyLabel();

                lbl2.AutoSize = false;

                lbl2.Location = new Point(lbl1.Right + 5, y);
                lbl2.Size = new Size(50, 13);
                //if (lbl2.Name == "")
                lbl2.DataBindings.Clear();
                lbl2.DataBindings.Add(new Binding("Text", bindingSource_hub, field.Name, false,
                    DataSourceUpdateMode.Never, "0"));
                lbl2.Name = field.Name + "value";
                lbl2.Visible = true;
                //lbl2.Text = fieldValue.ToString();

                tabPageStatustext.Controls.Add(lbl1);
                tabPageStatustext.Controls.Add(lbl2);


                x += 0;
                y += 15;

                if (y > tabPageStatustext.Height - 30)
                {
                    x = lbl2.Right + 10; //+= 165;
                    y = 10;
                }
            }

            tabPageStatustext.Width = x;

            //ThemeManager.ApplyThemeTo(tabPageStatus);
        }





        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Messagetabletimer1.Stop();
            if (tabControlactions.SelectedTab == tabPageStatustext)
            {
                tabFilghtStatus_Resize(sender, e);
            }
            else if (tabControl1.SelectedTab == tabPage11)
             {
                Messagetabletimer1.Start();
                tabFilghtStatus_Resize(sender, e);
            }

        }
        int messagecount;
        private void Messagetalbetimer1_Tick(object sender, EventArgs e)
        {
            var newmsgcount = MainV2.comPort.MAV.cs.messages.Count;
            if (messagecount != newmsgcount)
            {
                try
                {
                    StringBuilder message = new StringBuilder();
                    MainV2.comPort.MAV.cs.messages.ForEach(x => { message.Insert(0, x + "\r\n"); });
                    textBox1.Text = message.ToString();

                    messagecount = newmsgcount;
                }
                catch
                {
                }
            }
        }

        private void label1_BindingContextChanged(object sender, EventArgs e)
        {

        }

        private void tabActions_Click(object sender, EventArgs e)
        {

        }

        private void BUT_quickauto_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setMode("Auto");
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
            ((Button)sender).Enabled = true;
        }

        private void BUT_quickmanual_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduPlane ||
                    MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.Ateryx ||
                    MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduRover)
                    MainV2.comPort.setMode("Loiter");
                if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                    MainV2.comPort.setMode("Loiter");
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
            ((Button)sender).Enabled = true;
        }

        private void BUT_Homealt_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.MAV.cs.altoffsethome != 0)
            {
                MainV2.comPort.MAV.cs.altoffsethome = 0;
            }
            else
            {
                MainV2.comPort.MAV.cs.altoffsethome = -MainV2.comPort.MAV.cs.HomeAlt / CurrentState.multiplierdist;
            }
        }

        private void myButton5_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;

                MainV2.comPort.setWPCurrent(0); // set nav to
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
            ((Button)sender).Enabled = true;
        }

        private void myButton4_Click(object sender, EventArgs e)
        {
            if (
               Common.MessageShowAgain("Resume Mission",
                   "Warning this will reprogram your mission, arm and issue a takeoff command (copter)") !=
               DialogResult.OK)
                return;

            try
            {
                if (MainV2.comPort.BaseStream.IsOpen)
                {
                    string lastwp = MainV2.comPort.MAV.cs.lastautowp.ToString();
                    if (lastwp == "-1")
                        lastwp = "1";

                    if (InputBox.Show("Resume at", "Resume mission at waypoint#", ref lastwp) == DialogResult.OK)
                    {
                        int timeout = 0;
                        int lastwpno = int.Parse(lastwp);

                        // scan and check wp's we are skipping
                        // get our target wp
                        var lastwpdata = MainV2.comPort.getWP((ushort)lastwpno);

                        // get all
                        List<Locationwp> cmds = new List<Locationwp>();

                        var wpcount = MainV2.comPort.getWPCount();

                        for (ushort a = 0; a < wpcount; a++)
                        {
                            var wpdata = MainV2.comPort.getWP(a);

                            if (a < lastwpno && a != 0) // allow home
                            {
                                if (wpdata.id != (ushort)MAVLink.MAV_CMD.TAKEOFF)
                                    if (wpdata.id < (ushort)MAVLink.MAV_CMD.LAST)
                                        continue;

                                if (wpdata.id > (ushort)MAVLink.MAV_CMD.DO_LAST)
                                    continue;
                            }

                            cmds.Add(wpdata);
                        }

                        ushort wpno = 0;
                        // upload from wp 0 to end
                        MainV2.comPort.setWPTotal((ushort)(cmds.Count));

                        // add our do commands
                        foreach (var loc in cmds)
                        {
                            MAVLink.MAV_MISSION_RESULT ans = MainV2.comPort.setWP(loc, wpno,
                                (MAVLink.MAV_FRAME)(loc.options));
                            if (ans != MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED)
                            {
                                CustomMessageBox.Show("Upload wps failed " +
                                                      Enum.Parse(typeof(MAVLink.MAV_CMD), loc.id.ToString()) + " " +
                                                      Enum.Parse(typeof(MAVLink.MAV_MISSION_RESULT), ans.ToString()));
                                return;
                            }
                            wpno++;
                        }

                        MainV2.comPort.setWPACK();

                        FlightPlanner.instance.pictureBox5_Click(this, null);

                        // set index back to 1
                        MainV2.comPort.setWPCurrent(1);

                        if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                        {
                            while (MainV2.comPort.MAV.cs.mode.ToLower() != "Guided".ToLower())
                            {
                                MainV2.comPort.setMode("GUIDED");
                                Thread.Sleep(1000);
                                Application.DoEvents();
                                timeout++;

                                if (timeout > 30)
                                {
                                    CustomMessageBox.Show(Strings.ERROR, Strings.ErrorNoResponce);
                                    return;
                                }
                            }

                            timeout = 0;
                            while (!MainV2.comPort.MAV.cs.armed)
                            {
                                MainV2.comPort.doARM(true);
                                Thread.Sleep(1000);
                                Application.DoEvents();
                                timeout++;

                                if (timeout > 30)
                                {
                                    CustomMessageBox.Show(Strings.ERROR, Strings.ErrorNoResponce);
                                    return;
                                }
                            }

                            timeout = 0;
                            while (MainV2.comPort.MAV.cs.alt < (lastwpdata.alt - 2))
                            {
                                MainV2.comPort.doCommand(MAVLink.MAV_CMD.TAKEOFF, 0, 0, 0, 0, 0, 0, lastwpdata.alt);
                                Thread.Sleep(1000);
                                Application.DoEvents();
                                timeout++;

                                if (timeout > 40)
                                {
                                    CustomMessageBox.Show(Strings.ERROR, Strings.ErrorNoResponce);
                                    return;
                                }
                            }
                        }

                        timeout = 0;
                        while (MainV2.comPort.MAV.cs.mode.ToLower() != "AUTO".ToLower())
                        {
                            MainV2.comPort.setMode("AUTO");
                            Thread.Sleep(1000);
                            Application.DoEvents();
                            timeout++;

                            if (timeout > 30)
                            {
                                CustomMessageBox.Show(Strings.ERROR, Strings.ErrorNoResponce);
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.Show(Strings.CommandFailed + "\n" + ex.ToString(), Strings.ERROR);
            }
        }
        GMapRoute route;
        private void myButton6_Click(object sender, EventArgs e)
        {
            if (route != null)
                route.Points.Clear();
        }

        private void BUT_ARM_Click(object sender, EventArgs e)
        {
            if (!MainV2.comPort.BaseStream.IsOpen)
                return;

            // arm the MAV
            try
            {
                if (MainV2.comPort.MAV.cs.armed)
                    if (CustomMessageBox.Show("Are you sure you want to Disarm?", "Disarm?", MessageBoxButtons.YesNo) !=
                        DialogResult.Yes)
                        return;

                bool ans = MainV2.comPort.doARM(!MainV2.comPort.MAV.cs.armed);
                if (ans == false)
                    CustomMessageBox.Show(Strings.ErrorRejectedByMAV, Strings.ERROR);
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorNoResponce, Strings.ERROR);
            }
        }

            

        private void BUTactiondo_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMB_action.Text == "Trigger Camera NOW")
                {
                    MainV2.comPort.setDigicamControl(true);
                    return;
                }
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                return;
            }

            if (
                CustomMessageBox.Show("Are you sure you want to do " + CMB_action.Text + " ?", "Action",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    ((Button)sender).Enabled = false;

                    int param1 = 0;
                    int param3 = 1;

                    // request gyro
                    if (CMB_action.Text == "PREFLIGHT_CALIBRATION")
                    {
                        if (MainV2.comPort.MAV.cs.firmware == MainV2.Firmwares.ArduCopter2)
                            param1 = 1; // gyro
                        param3 = 1; // baro / airspeed
                    }
                    if (CMB_action.Text == "PREFLIGHT_REBOOT_SHUTDOWN")
                    {
                        param1 = 1; // reboot
                    }

                    MainV2.comPort.doCommand((MAVLink.MAV_CMD)Enum.Parse(typeof(MAVLink.MAV_CMD), CMB_action.Text),
                        param1, 0, param3, 0, 0, 0, 0);
                }
                catch
                {
                    CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
                }
                ((Button)sender).Enabled = true;
            }
        }

        private void BUT_setmode_Click(object sender, EventArgs e)
        {
            MainV2.comPort.setMode(CMB_modes.Text);
        }

        private void BUT_setwp_Click(object sender, EventArgs e)
        {
            try
            {
                ((Button)sender).Enabled = false;
                MainV2.comPort.setWPCurrent((ushort)CMB_setwp.SelectedIndex); // set nav to
            }
            catch
            {
                CustomMessageBox.Show(Strings.CommandFailed, Strings.ERROR);
            }
            ((Button)sender).Enabled = true;
        }

        private void modifyandSetAlt_Click(object sender, EventArgs e)
        {
            // QUAD
            if (MainV2.comPort.MAV.param.ContainsKey("WP_SPEED_MAX"))
            {
                try
                {
                    MainV2.comPort.setParam("WP_SPEED_MAX", ((float)modifyandSetSpeed.Value * 100.0f));
                }
                catch
                {
                    CustomMessageBox.Show(String.Format(Strings.ErrorSetValueFailed, "WP_SPEED_MAX"), Strings.ERROR);
                }
            } // plane with airspeed
            else if (MainV2.comPort.MAV.param.ContainsKey("TRIM_ARSPD_CM") &&
                     MainV2.comPort.MAV.param.ContainsKey("ARSPD_ENABLE")
                     && MainV2.comPort.MAV.param.ContainsKey("ARSPD_USE") &&
                     (float)MainV2.comPort.MAV.param["ARSPD_ENABLE"] == 1
                     && (float)MainV2.comPort.MAV.param["ARSPD_USE"] == 1)
            {
                try
                {
                    MainV2.comPort.setParam("TRIM_ARSPD_CM", ((float)modifyandSetSpeed.Value * 100.0f));
                }
                catch
                {
                    CustomMessageBox.Show(String.Format(Strings.ErrorSetValueFailed, "TRIM_ARSPD_CM"), Strings.ERROR);
                }
            } // plane without airspeed
            else if (MainV2.comPort.MAV.param.ContainsKey("TRIM_THROTTLE") &&
                     MainV2.comPort.MAV.param.ContainsKey("ARSPD_USE")
                     && (float)MainV2.comPort.MAV.param["ARSPD_USE"] == 0)
            {
                try
                {
                    MainV2.comPort.setParam("TRIM_THROTTLE", (float)modifyandSetSpeed.Value);
                }
                catch
                {
                    CustomMessageBox.Show(String.Format(Strings.ErrorSetValueFailed, "TRIM_THROTTLE"),
                        Strings.ERROR);
                }
            }
        }

        private void modifyandSetSpeed_Click(object sender, EventArgs e)
        {
            int newalt = (int)modifyandSetAlt.Value;
            try
            {
                MainV2.comPort.setNewWPAlt(new Locationwp { alt = newalt / CurrentState.multiplierdist });
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorCommunicating, Strings.ERROR);
            }
            //MainV2.comPort.setNextWPTargetAlt((ushort)MainV2.comPort.MAV.cs.wpno, newalt);
        }

        private void modifyandSetLoiterRad_Click(object sender, EventArgs e)
        {
            int newrad = (int)modifyandSetLoiterRad.Value;

            try
            {
                MainV2.comPort.setParam(new[] { "LOITER_RAD", "WP_LOITER_RAD" }, newrad / CurrentState.multiplierdist);
            }
            catch
            {
                CustomMessageBox.Show(Strings.ErrorCommunicating, Strings.ERROR);
            }
        }

        private void BUT_loadtelem_Click(object sender, EventArgs e)
        {
            LBL_logfn.Text = "";

            if (MainV2.comPort.logplaybackfile != null)
            {
                try
                {
                    MainV2.comPort.logplaybackfile.Close();
                    MainV2.comPort.logplaybackfile = null;
                }
                catch
                {
                }
            }

            using (OpenFileDialog fd = new OpenFileDialog())
            {
                fd.AddExtension = true;
                fd.Filter = "Telemetry log (*.tlog)|*.tlog;*.tlog.*|Mavlink Log (*.mavlog)|*.mavlog";
                fd.InitialDirectory = Settings.Instance.LogDir;
                fd.DefaultExt = ".tlog";
                DialogResult result = fd.ShowDialog();
                string file = fd.FileName;
                LoadLogFile(file);
            }
        }
        public void LoadLogFile(string file)
        {
            if (file != "")
            {
                try
                {
                    myButton6_Click(null, null);

                    MainV2.comPort.logreadmode = true;
                    MainV2.comPort.logplaybackfile = new BinaryReader(File.OpenRead(file));
                    MainV2.comPort.lastlogread = DateTime.MinValue;

                    LBL_logfn.Text = Path.GetFileName(file);

                    log.Info("Open logfile " + file);

                    MainV2.comPort.getHeartBeat();

                    tracklog.Value = 0;
                    tracklog.Minimum = 0;
                    tracklog.Maximum = 100;
                }
                catch
                {
                    CustomMessageBox.Show(Strings.PleaseLoadValidFile, Strings.ERROR);
                }
            }
        }

        private void BUT_playlog_Click(object sender, EventArgs e)
        {
            if (MainV2.comPort.logreadmode)
            {
                MainV2.comPort.logreadmode = false;
                ZedTimer.Stop();
                playingLog = false;
            }
            else
            {
                // BUT_clear_track_Click(sender, e);
                MainV2.comPort.logreadmode = true;
                list1.Clear();
                list2.Clear();
                list3.Clear();
                list4.Clear();
                list5.Clear();
                list6.Clear();
                list7.Clear();
                list8.Clear();
                list9.Clear();
                list10.Clear();
                tickStart = Environment.TickCount;

                zedGraphControl1.GraphPane.XAxis.Scale.Min = 0;
                zedGraphControl1.GraphPane.XAxis.Scale.Max = 1;
                ZedTimer.Start();
                playingLog = true;
            }
        }

        private void ZedTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                
                // Make sure that the curvelist has at least one curve
                if (zedGraphControl1.GraphPane.CurveList.Count <= 0)
                    return;

                // Get the first CurveItem in the graph
                LineItem curve = zedGraphControl1.GraphPane.CurveList[0] as LineItem;
                if (curve == null)
                    return;

                // Get the PointPairList
                IPointListEdit list = curve.Points as IPointListEdit;
                // If this is null, it means the reference at curve.Points does not
                // support IPointListEdit, so we won't be able to modify it
                if (list == null)
                    return;

                // Time is measured in seconds
                double time = (Environment.TickCount - tickStart) / 1000.0;

                // Keep the X scale at a rolling 30 second interval, with one
                // major step between the max X value and the end of the axis
                Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
                if (time > xScale.Max - xScale.MajorStep)
                {
                    xScale.Max = time + xScale.MajorStep;
                    xScale.Min = xScale.Max - 10.0;
                }

                // Make sure the Y axis is rescaled to accommodate actual data确保Y轴调整以适应实际的数据
                zedGraphControl1.AxisChange();

                // Force a redraw

                zedGraphControl1.Invalidate();
            }
            catch
            {
            }
        }

        private void zedGraphControl1_DoubleClick(object sender, EventArgs e)
        {
            string formname = "select";
            Form selectform = Application.OpenForms[formname];
            if (selectform != null)
            {
                selectform.WindowState = FormWindowState.Minimized;
                selectform.Show();
                selectform.WindowState = FormWindowState.Normal;
                return;
            }

            selectform = new Form
            {
                Name = formname,
                Width = 50,
                Height = 550,
                Text = "Graph This"
            };

            int x = 10;
            int y = 10;

            {
                CheckBox chk_box = new CheckBox();
                chk_box.Text = "Logarithmic";
                chk_box.Name = "Logarithmic";
                chk_box.Location = new Point(x, y);
                chk_box.Size = new Size(100, 20);
                chk_box.CheckedChanged += chk_log_CheckedChanged;

                selectform.Controls.Add(chk_box);
            }

            //ThemeManager.ApplyThemeTo(selectform);

            y += 20;

            object thisBoxed = MainV2.comPort.MAV.cs;
            Type test = thisBoxed.GetType();

            foreach (var field in test.GetProperties())
            {
                // field.Name has the field's name.
                object fieldValue;
                TypeCode typeCode;
                try
                {
                    fieldValue = field.GetValue(thisBoxed, null); // Get value

                    if (fieldValue == null)
                        continue;

                    // Get the TypeCode enumeration. Multiple types get mapped to a common typecode.
                    typeCode = Type.GetTypeCode(fieldValue.GetType());
                }
                catch
                {
                    continue;
                }

                if (
                    !(typeCode == TypeCode.Single || typeCode == TypeCode.Double || typeCode == TypeCode.Int32 ||
                      typeCode == TypeCode.UInt16))
                    continue;

                CheckBox chk_box = new CheckBox();

                //ThemeManager.ApplyThemeTo(chk_box);

                if (list1item != null && list1item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list2item != null && list2item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list3item != null && list3item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list4item != null && list4item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list5item != null && list5item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list6item != null && list6item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list7item != null && list7item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list8item != null && list8item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list9item != null && list9item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }
                if (list10item != null && list10item.Name == field.Name)
                {
                    chk_box.Checked = true;
                    chk_box.BackColor = Color.Green;
                }

                chk_box.Text = field.Name;
                chk_box.Name = field.Name;
                chk_box.Location = new Point(x, y);
                chk_box.Size = new Size(100, 20);
                chk_box.CheckedChanged += chk_box_CheckedChanged;

                selectform.Controls.Add(chk_box);

                Application.DoEvents();

                x += 0;
                y += 20;

                if (y > selectform.Height - 50)
                {
                    x += 100;
                    y = 10;

                    selectform.Width = x + 100;
                }
            }

            selectform.Show();
        }
        bool setupPropertyInfo(ref PropertyInfo input, string name, object source)
        {
            Type test = source.GetType();

            foreach (var field in test.GetProperties())
            {
                if (field.Name == name)
                {
                    input = field;
                    return true;
                }
            }

            return false;
        }

        void chk_log_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                zedGraphControl1.GraphPane.YAxis.Type = AxisType.Log;
            }
            else
            {
                zedGraphControl1.GraphPane.YAxis.Type = AxisType.Linear;
            }
        }

        void chk_box_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                ((CheckBox)sender).BackColor = Color.Green;

                if (list1item == null)
                {
                    if (setupPropertyInfo(ref list1item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list1.Clear();
                        list1curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list1, Color.Red, SymbolType.None);
                    }
                }
                else if (list2item == null)
                {
                    if (setupPropertyInfo(ref list2item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list2.Clear();
                        list2curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list2, Color.Blue, SymbolType.None);
                    }
                }
                else if (list3item == null)
                {
                    if (setupPropertyInfo(ref list3item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list3.Clear();
                        list3curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list3, Color.Green,
                            SymbolType.None);
                    }
                }
                else if (list4item == null)
                {
                    if (setupPropertyInfo(ref list4item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list4.Clear();
                        list4curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list4, Color.Orange,
                            SymbolType.None);
                    }
                }
                else if (list5item == null)
                {
                    if (setupPropertyInfo(ref list5item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list5.Clear();
                        list5curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list5, Color.Yellow,
                            SymbolType.None);
                    }
                }
                else if (list6item == null)
                {
                    if (setupPropertyInfo(ref list6item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list6.Clear();
                        list6curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list6, Color.Magenta,
                            SymbolType.None);
                    }
                }
                else if (list7item == null)
                {
                    if (setupPropertyInfo(ref list7item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list7.Clear();
                        list7curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list7, Color.Purple,
                            SymbolType.None);
                    }
                }
                else if (list8item == null)
                {
                    if (setupPropertyInfo(ref list8item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list8.Clear();
                        list8curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list8, Color.LimeGreen,
                            SymbolType.None);
                    }
                }
                else if (list9item == null)
                {
                    if (setupPropertyInfo(ref list9item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list9.Clear();
                        list9curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list9, Color.Cyan, SymbolType.None);
                    }
                }
                else if (list10item == null)
                {
                    if (setupPropertyInfo(ref list10item, ((CheckBox)sender).Name, MainV2.comPort.MAV.cs))
                    {
                        list10.Clear();
                        list10curve = zedGraphControl1.GraphPane.AddCurve(((CheckBox)sender).Name, list10, Color.Violet,
                            SymbolType.None);
                    }
                }
                else
                {
                    CustomMessageBox.Show("Max 10 at a time.");
                    ((CheckBox)sender).Checked = false;
                }
                //ThemeManager.ApplyThemeTo((Control)sender);

                string selected = "";
                try
                {
                    foreach (var curve in zedGraphControl1.GraphPane.CurveList)
                    {
                        selected = selected + curve.Label.Text + "|";
                    }
                }
                catch
                {
                }
                Settings.Instance["Tuning_Graph_Selected"] = selected;
            }
            else
            {
                ((CheckBox)sender).BackColor = Color.Transparent;

                // reset old stuff
                if (list1item != null && list1item.Name == ((CheckBox)sender).Name)
                {
                    list1item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list1curve);
                }
                if (list2item != null && list2item.Name == ((CheckBox)sender).Name)
                {
                    list2item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list2curve);
                }
                if (list3item != null && list3item.Name == ((CheckBox)sender).Name)
                {
                    list3item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list3curve);
                }
                if (list4item != null && list4item.Name == ((CheckBox)sender).Name)
                {
                    list4item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list4curve);
                }
                if (list5item != null && list5item.Name == ((CheckBox)sender).Name)
                {
                    list5item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list5curve);
                }
                if (list6item != null && list6item.Name == ((CheckBox)sender).Name)
                {
                    list6item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list6curve);
                }
                if (list7item != null && list7item.Name == ((CheckBox)sender).Name)
                {
                    list7item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list7curve);
                }
                if (list8item != null && list8item.Name == ((CheckBox)sender).Name)
                {
                    list8item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list8curve);
                }
                if (list9item != null && list9item.Name == ((CheckBox)sender).Name)
                {
                    list9item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list9curve);
                }
                if (list10item != null && list10item.Name == ((CheckBox)sender).Name)
                {
                    list10item = null;
                    zedGraphControl1.GraphPane.CurveList.Remove(list10curve);
                }
            }
        }

        private void CB_Dbug_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Dbug .Checked)
            {
                //splitContainer1.Panel1Collapsed = false;
                ZedTimer.Enabled = true;
                ZedTimer.Start();
                zedGraphControl1.Visible = true;
                zedGraphControl1.Refresh();
            }
            else
            {
                //splitContainer1.Panel1Collapsed = true;
                ZedTimer.Enabled = false;
                ZedTimer.Stop();
                zedGraphControl1.Visible = false;
            }
        }
        private void updateLogPlayPosition()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                try
                {
                    if (tracklog.Visible)
                        tracklog.Value =
                            (int)
                                (MainV2.comPort.logplaybackfile.BaseStream.Position /
                                 (double)MainV2.comPort.logplaybackfile.BaseStream.Length * 100);
                    if (lbl_logpercent.Visible)
                        lbl_logpercent.Text =
                            (MainV2.comPort.logplaybackfile.BaseStream.Position /
                             (double)MainV2.comPort.logplaybackfile.BaseStream.Length).ToString("0.00%");

                    if (lbl_playbackspeed.Visible)
                        lbl_playbackspeed.Text = "x " + LogPlayBackSpeed;
                }
                catch
                {
                }
            });
        }
        private void tracklog_Scroll(object sender, EventArgs e)
        {
            try
            {
                myButton6_Click(sender, e);

                MainV2.comPort.lastlogread = DateTime.MinValue;
                MainV2.comPort.MAV.cs.ResetInternals();

                if (MainV2.comPort.logplaybackfile != null)
                    MainV2.comPort.logplaybackfile.BaseStream.Position =
                        (long)(MainV2.comPort.logplaybackfile.BaseStream.Length * (tracklog.Value / 100.0));

                updateLogPlayPosition();
            }
            catch
            {
            } // ignore any invalid 
        }

        private void BUT_log2kml_Click(object sender, EventArgs e)
        {
            Form frm = new MavlinkLog();
            //ThemeManager.ApplyThemeTo(frm);
            frm.Show();
        }

        private void BUT_speed1_10_Click(object sender, EventArgs e)
        {
            LogPlayBackSpeed = double.Parse(((MyButton)sender).Tag.ToString(), CultureInfo.InvariantCulture);
            lbl_playbackspeed.Text = "x " + LogPlayBackSpeed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            //if (!MainV2.comPort.BaseStream.IsOpen)
            //{
            //    CustomMessageBox.Show("请首先进行系统连接!");
            //    return;
            //}
            Form ConfigWindow = new InitConfig();
            ConfigWindow.Activate();
            ConfigWindow.Show();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.PaleGreen;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BackColor = Color.Azure;
        }
    }
}