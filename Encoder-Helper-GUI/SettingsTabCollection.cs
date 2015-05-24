﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder_Helper_GUI
{
    public partial class SettingsTabCollection : UserControl
    {
        private int RightClickedArgSettingsTab = -1;
        private TabControl lastTc = null;
        private List<VideoTabControl> vidTab;
        private List<AudioTabControl> audioTab;
        private AppSettings settings;

        public TabControl TabCollectionControl
        {
            get { return TabControl_Settings; }
        }
        public List<VideoTabControl> VideoTabList
        {
            get { return vidTab; }
        }
        public List<AudioTabControl> AudioTabList
        {
            get { return audioTab; }
        }
        public string TextBox_VideoTrackName_Text
        {
            get { return TextBox_VideoTrackName.Text; }
            set { TextBox_VideoTrackName.Text = value; }
        }
        public string TextBox_VideoLanguageCode_Text
        {
            get { return TextBox_VideoLanguageCode.Text; }
            set { TextBox_VideoLanguageCode.Text = value; }
        }
        public string TextBox_AvisynthTemplate_Text
        {
            get { return textBox_AvisynthTemplate.Text; }
            set { textBox_AvisynthTemplate.Text = value; }
        }

        public SettingsTabCollection()
        {
            InitializeComponent();
        }

        public void LoadSettings(AppSettings settings)
        {
            vidTab = new List<VideoTabControl>();
            audioTab = new List<AudioTabControl>();
            TabControl_VideoArgSettings.TabPages.RemoveAt(0);
            TabControl_AudioArgSettings.TabPages.RemoveAt(0);
            for (int i = 0; i < settings.x264Args.Length; i++)
            {
                vidTab.Add(new VideoTabControl());
                vidTab[i].AttachToLastTab(TabControl_VideoArgSettings);
                vidTab[i].TextBox_x264_Args_Text = settings.x264Args[i];
                vidTab[i].ComboBox_Encoder_SelectedIndex = settings.encoder[i];
            }
            TextBox_VideoTrackName.Text = settings.videoTrackName;
            TextBox_VideoLanguageCode.Text = settings.videoLanguageCode;
            textBox_AvisynthTemplate.Text = settings.avisynthTemplate;
            for (int i = 0; i < settings.audioTrackName.Length; i++)
            {
                audioTab.Add(new AudioTabControl());
                audioTab[i].AttachToLastTab(TabControl_AudioArgSettings);
                audioTab[i].NumericUpDown_Quality_Value = settings.quality[i];
                audioTab[i].TextBox_AudioTrackName_Text = settings.audioTrackName[i];
                audioTab[i].TextBox_LanguageCode_Text = settings.audioLanguageCode[i];
            }
            TabControl_VideoArgSettings.TabPages.Add("    +");
            TabControl_AudioArgSettings.TabPages.Add("    +");
        }

        private void button_BrowseAvisynthTemplate_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                textBox_AvisynthTemplate.Text = openFileDialog.FileName;
            }
        }

        private void TabControl_VideoArgSettings_TabIndexChanged(object sender, EventArgs e)
        {
            var tc = (TabControl)sender;

            if (tc.TabCount == tc.SelectedIndex + 1)
            {
                vidTab.Add(new VideoTabControl());
                vidTab[vidTab.Count - 1].AttachToNewTab(tc);
            }
        }

        private void TabControl_AudioArgSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tc = (TabControl)sender;

            if (tc.TabCount == tc.SelectedIndex + 1)
            {
                audioTab.Add(new AudioTabControl());
                audioTab[audioTab.Count - 1].AttachToNewTab(tc);
            }
        }

        private void TabControl_AVSettings_MouseClick(object sender, MouseEventArgs e)
        {
            var tc = (TabControl)sender;

            if (e.Button == MouseButtons.Right && tc.TabCount != 2)
            {
                lastTc = tc;
                for (int i = 0; i < tc.TabCount - 1; i++)
                {
                    var rect = tc.GetTabRect(i);
                    if (rect.Contains(e.Location))
                    {
                        ContextMenuStrip_Tabs.Show(TabControl_VideoArgSettings, e.Location);
                        RightClickedArgSettingsTab = i;
                    }
                }
            }
        }

        private void StripMenuItem_DeleteTab_Click(object sender, EventArgs e)
        {
            for (int i = RightClickedArgSettingsTab + 1; i < lastTc.TabCount - 1; i++)
            {
                lastTc.TabPages[i].Text = i.ToString();
            }
            lastTc.TabPages.RemoveAt(RightClickedArgSettingsTab);
            if (TabControl_Settings.SelectedIndex == 0) //Video settings tab
            {
                vidTab.RemoveAt(RightClickedArgSettingsTab);
            }
            else
            {
                audioTab.RemoveAt(RightClickedArgSettingsTab);
            }
        }
    }
}