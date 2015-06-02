﻿/*Bench
Copyright (C) 2015 Thomas Sweeney

This file is part of Bench.
Bench is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

Bench is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
 
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bench
{
    public partial class SettingsTabCollection : UserControl
    {
        private bool unsavedChanges;
        private int RightClickedArgSettingsTab = -1;
        private TabControl lastTc = null;
        private List<VideoTabControl> vidTab;
        private List<AudioTabControl> audioTab;

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
        public int ComboBoxCounterSelectedIndex
        {
            get { return comboBoxCounter.SelectedIndex; }
            set { comboBoxCounter.SelectedIndex = value; }
        }
        public int NumericUpDownCounterValue
        {
            get { return (int)numericUpDownCounter.Value; }
            set { numericUpDownCounter.Value = value; }
        }
        public bool CheckBoxNoAudio
        {
            get { return checkBoxNoAudio.Checked; }
            set { checkBoxNoAudio.Checked = value; }
        }
        public string FileNameBodyText
        {
            get { return textBoxBody.Text; }
            set { textBoxBody.Text = value; }
        }
        public bool UnsavedChanges
        {
            get
            {
                foreach (var page in audioTab)
                {
                    if (page.UnsavedChanges)
                    {
                        return true;
                    }
                }
                foreach (var page in vidTab)
                {
                    if (page.UnsavedChanges)
                    {
                        return true;
                    }
                }
                return this.unsavedChanges;
            }
            set
            {
                foreach (var page in audioTab)
                {
                    page.UnsavedChanges = value;
                }
                foreach (var page in vidTab)
                {
                    page.UnsavedChanges = value;
                }
                this.unsavedChanges = value;
            }
        }

        public SettingsTabCollection()
        {
            InitializeComponent();
            //need to initialize vidTab and audioTab in the constructor even though they're just going to be overwritten
            //so that visual studio can generate the code needed for the UnsavedChanges property for the designer
            vidTab = new List<VideoTabControl>();
            audioTab = new List<AudioTabControl>();
            toolTipCounter.SetToolTip(comboBoxCounter, "Use {0}, {0:D1}, {0:D2}, etc. in your filename for it to have a counter.");
        }

        public void LoadSettings(Settings settings)
        {
            vidTab = new List<VideoTabControl>();
            audioTab = new List<AudioTabControl>();
            bool unsavedChangesState = UnsavedChanges;

            TabControl_VideoArgSettings.TabPages.Clear();
            TabControl_AudioArgSettings.TabPages.Clear();
            //now we actually load everything
            for (int i = 0; i < settings.x264Args.Length; i++)
            {
                vidTab.Add(new VideoTabControl());
                vidTab[i].AttachToLastTab(TabControl_VideoArgSettings);
                vidTab[i].TextBox_x264_Args_Text = settings.x264Args[i];
                vidTab[i].ComboBox_Encoder_SelectedIndex = settings.encoder[i];
                vidTab[i].FileNamePrefixText = settings.fileNamePrefix[i];
                vidTab[i].FileNameSuffixText = settings.fileNameSuffix[i];
            }
            textBoxBody.Text = settings.fileNameBody;
            TextBox_VideoTrackName.Text = settings.videoTrackName;
            TextBox_VideoLanguageCode.Text = settings.videoLanguageCode;
            textBox_AvisynthTemplate.Text = settings.avisynthTemplate;
            comboBoxCounter.SelectedIndex = settings.counterIndex;
            numericUpDownCounter.Value = settings.counterValue;
            for (int i = 0; i < settings.audioTrackName.Length; i++)
            {
                audioTab.Add(new AudioTabControl());
                audioTab[i].AttachToLastTab(TabControl_AudioArgSettings);
                audioTab[i].NumericUpDown_Quality_Value = settings.quality[i];
                audioTab[i].TextBox_AudioTrackName_Text = settings.audioTrackName[i];
                audioTab[i].TextBox_LanguageCode_Text = settings.audioLanguageCode[i];
            }
            checkBoxNoAudio.Checked = settings.noAudio;
            TabControl_VideoArgSettings.TabPages.Add("    +");
            TabControl_AudioArgSettings.TabPages.Add("    +");
            UnsavedChanges = unsavedChangesState;
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

            if (tc.TabCount == tc.SelectedIndex + 1 && tc.SelectedIndex > -1)
            {
                vidTab.Add(new VideoTabControl());
                vidTab[vidTab.Count - 1].AttachToNewTab(tc);
                unsavedChanges = true;
            }
        }

        private void TabControl_AudioArgSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tc = (TabControl)sender;

            if (tc.TabCount == tc.SelectedIndex + 1 && tc.SelectedIndex > -1)
            {
                audioTab.Add(new AudioTabControl());
                audioTab[audioTab.Count - 1].AttachToNewTab(tc);
                unsavedChanges = true;
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
            unsavedChanges = true;
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

        protected virtual void comboBoxCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void TextBox_VideoTrackName_TextChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void TextBox_VideoLanguageCode_TextChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void textBox_AvisynthTemplate_TextChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            unsavedChanges = true;
        }

        private void numericUpDownCounter_ValueChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }

        private void checkBoxNoAudio_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNoAudio.Checked)
            {
                TabControl_AudioArgSettings.Enabled = false;
            }
            else
            {
                TabControl_AudioArgSettings.Enabled = true;
            }
        }

        private void textBoxBody_TextChanged(object sender, EventArgs e)
        {
            unsavedChanges = true;
        }
    }

    public class SettingsTabCollectionMain : SettingsTabCollection
    {
        public List<OutputSettings> OutputSettings { get; set; }
        public ListBox ListBox { get; set; }

        public SettingsTabCollectionMain() : base()
        {

        }

        protected override void comboBoxCounter_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.OutputSettings.Count; i++)
            {
                if (ComboBoxCounterSelectedIndex == this.OutputSettings[i].counterIndex && i != this.ListBox.SelectedIndex)
                {
                    NumericUpDownCounterValue = this.OutputSettings[i].counterValue;
                    return;
                }
            }
            NumericUpDownCounterValue = 1;
        }
    }
}
