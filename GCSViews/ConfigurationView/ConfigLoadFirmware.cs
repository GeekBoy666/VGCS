using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MissionPlanner.Utilities;
using MissionPlanner.Controls;

namespace MissionPlanner.GCSViews.ConfigurationView
{
    public partial class ConfigLoadFirmware : UserControl
    {
        private readonly Firmware fw = new Firmware();
        private string custom_fw_dir = "";
        private ProgressReporterDialogue pdr;

        public ConfigLoadFirmware()
        {
            InitializeComponent();
        }
        private void fw_Progress(int progress, string status)
        {
            pdr.UpdateProgressAndStatus(progress, status);
        }

        /// <summary>
        ///     for when updating fw to hardware
        /// </summary>
        /// <param name="progress"></param>
        /// <param name="status"></param>
        private void fw_Progress1(int progress, string status)
        {
            var change = false;

            if (progress != -1)
            {
                if (this.progressBarLoad.Value != progress)
                {
                    this.progressBarLoad.Value = progress;
                    change = true;
                }
            }
            if (LabelStatu.Text != status)
            {
                LabelStatu.Text = status;
                change = true;
            }

            if (change)
                Refresh();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fd = new OpenFileDialog { Filter = "Firmware (*.hex;*.px4;*.vrx)|*.hex;*.px4;*.vrx|All files (*.*)|*.*" })
            {
                if (Directory.Exists(custom_fw_dir))
                    fd.InitialDirectory = custom_fw_dir;
                fd.ShowDialog();
                if (File.Exists(fd.FileName))
                {
                    custom_fw_dir = Path.GetDirectoryName(fd.FileName);

                    fw.Progress -= fw_Progress;
                    fw.Progress += fw_Progress1;

                    var boardtype = BoardDetect.boards.none;
                    try
                    {
                        if (fd.FileName.ToLower().EndsWith(".px4"))
                        {
                            if (solo.Solo.is_solo_alive)
                            {
                                boardtype = BoardDetect.boards.solo;
                            }
                            else
                            {
                                boardtype = BoardDetect.boards.px4v2;
                            }
                        }
                        else
                        {
                            boardtype = BoardDetect.DetectBoard(MainV2.comPortName);
                        }
                    }
                    catch
                    {
                        CustomMessageBox.Show(Strings.CanNotConnectToComPortAnd, Strings.ERROR);
                        return;
                    }

                    fw.UploadFlash(MainV2.comPortName, fd.FileName, boardtype);
                }
            }
        }
    }
}
