using FlStudioRpc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlStudioRpcGui
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Representing instance of class, which intended to updating and generating presence for Discord RPC.
        /// </summary>
        public RpcSender Sender { get; private set; }

        public MainForm()
        {
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new(Properties.Settings.Default.Language);

            InitializeComponent();

            EnglishToolStripMenuItem.Checked = (Properties.Settings.Default.Language == "en-US");
            RussianToolStripMenuItem.Checked = (Properties.Settings.Default.Language == "ru-RU");
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "en-US";
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new("en-US");

            EnglishToolStripMenuItem.Checked = true;
            RussianToolStripMenuItem.Checked = false;
        }

        private void RussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = "ru-RU";
            Properties.Settings.Default.Save();
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture = new("ru-RU");

            EnglishToolStripMenuItem.Checked = false;
            RussianToolStripMenuItem.Checked = true;
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("FL Studio Rich Presence by Emil Dalalyan\n" +
                            "__________________________________________\n\n" +
                            "Thanks to: DiscordRichPresence by Lachee.", "About FL Studio Rich Presence");
        }

        /// <summary>
        /// Represents main loop of the app, it is getting information about <b>FL Studio</b> and setting presence.
        /// </summary>
        private async void MainLoop()
        {
            while(!Sender.FlStudioInfo.FlStudioProcess.HasExited)
            {
                await Task.Run(() => Sender.UpdatePresence(Sender.GeneratePresence()));

                await Task.Delay(Properties.Settings.Default.DelayBetweenIterations);
            }

            Application.OpenForms.DisposeAll();
            Application.Exit();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.StartFile))
            {
                Sender = new(new(Process.Start(Properties.Settings.Default.StartFile, Program.ProvidedArguments)));
            }
            else
            {
                using OpenFileDialog dialog = new()
                {
                    Filter = "Executable files (*.exe)|*.exe"
                };

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.StartFile = dialog.FileName;
                    Properties.Settings.Default.Save();
                    Sender = new(new(Process.Start(dialog.FileName, Program.ProvidedArguments)));
                }
                else
                {
                    Application.OpenForms.DisposeAll();
                    Application.Exit();
                }
            }
            
            MainLoop();
        }

        private void ChangeExecutableFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new()
            {
                Filter = "Executable files (*.exe)|*.exe"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.StartFile = dialog.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}
